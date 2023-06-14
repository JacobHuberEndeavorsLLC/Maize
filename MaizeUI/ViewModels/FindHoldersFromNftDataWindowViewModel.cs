using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Rendering;
using Maize;
using Maize.Services;
using Maize.Helpers;
using Maize.Models.ApplicationSpecific;
using MaizeUI.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using static Maize.Models.NftHolders;

namespace MaizeUI.ViewModels
{
    public class FindHoldersFromNftDataWindowViewModel : ViewModelBase 
    {
        public string location;
        public string Location
        {
            get => location;
            set => this.RaiseAndSetIfChanged(ref location, value);
        }
        public string Notice { get; set; }
        public string Notice2 { get; set; }
        public bool isEnabled = true;
        public bool IsEnabled
        {
            get => isEnabled;
            set => this.RaiseAndSetIfChanged(ref isEnabled, value);
        }

        public string log;

        public string Log
        {
            get => log;
            set => this.RaiseAndSetIfChanged(ref log, value);
        }

        public LoopringServiceUI loopringService;

        public LoopringServiceUI LoopringService
        {
            get => loopringService;
            set => this.RaiseAndSetIfChanged(ref loopringService, value);
        }

        public Settings settings;

        public Settings Settings
        {
            get => settings;
            set => this.RaiseAndSetIfChanged(ref settings, value);
        }

        public ReactiveCommand<Unit, Unit> FindHoldersFromNftDataCommand { get; }

        public FindHoldersFromNftDataWindowViewModel()
        {
            Location = $"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}";
            Notice = "In the below file add your Nft Data. You will have one Nft Data per line.";
            Notice2 = "Press Find when ready.";
            FindHoldersFromNftDataCommand = ReactiveCommand.Create(FindHoldersFromNftData);
        }

        private async void FindHoldersFromNftData()
        {
            Location = "Retrieving Holders, please give me a moment...";
            IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();

            using (StreamReader sr = new($"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}"))
            {
                IEthereumService ethereumService = new EthereumService();
                INftMetadataService nftMetadataService = new NftMetadataService("https://ipfs.loopring.io/ipfs/");
                int currentTotal;
                var ownerAndAmount = new List<OwnerAndAmount>();
                var ownerAndTotal = new List<OwnerAndTotal>();
                string nftData;
                var counter = 0;
                var howManyLines = Files.CheckInputFile();
                while ((nftData = sr.ReadLine()) != null)
                {
                    Location = $"Nft {++counter}/{howManyLines}";
                    var minterFromNftDatas = await LoopringService.GetNftInformationFromNftData(settings.LoopringApiKey, nftData);
                    var nftMetadata = await ApplicationUtilities.GetNftMetadataUI(ethereumService, nftMetadataService, minterFromNftDatas.FirstOrDefault().nftId, minterFromNftDatas.FirstOrDefault().tokenAddress);
                    Location = $"Nft {counter}/{howManyLines} {nftMetadata.name}: ";
                    List<List<NftHolder>> allHolders = new List<List<NftHolder>>();
                    int offset = 0;
                    int total = 0;
                    while (true)
                    {
                        var nftHolders = await LoopringService.GetNftHoldersOffset(settings.LoopringApiKey, nftData, offset);
                        if (nftHolders.Item1.Count > 0)
                        {
                            total = nftHolders.Item2;
                            Location = $"Nft {counter}/{howManyLines} {nftMetadata.name}: {allHolders.SelectMany(d => d).Count()}/{total} Holders retrieved...";
                            allHolders.Add(nftHolders.Item1);
                            offset += 50;
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    var holderCounter = 0;
                    foreach (var nftHolder in allHolders.SelectMany(d => d))
                    {
                        //font.ToTertiaryInline($"\rNft: {counter}/{howManyLines} {nftMetadata.name} Nft Holder: {++holderCounter}/{nftHoldersList.Count}");
                        var userAccountInformation = await LoopringService.GetUserAccountInformationFromId(nftHolder.accountId.ToString());
                        Location = $"Nft {counter}/{howManyLines} {nftMetadata.name}: {++holderCounter}/{allHolders.SelectMany(d => d).Count()} Holders calculated...";
                        if (nftMetadata != null)
                        {
                            ownerAndAmount.Add(new OwnerAndAmount
                            {
                                nftData = nftData,
                                nftName = nftMetadata.name,
                                nftOwner = userAccountInformation.owner,
                                ownerAmountOwned = nftHolder.amount
                            });
                            if (!ownerAndTotal.Any(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()))
                            {
                                ownerAndTotal.Add(new OwnerAndTotal
                                {
                                    owner = userAccountInformation.owner,
                                    total = int.Parse(nftHolder.amount)
                                });
                            }
                            else
                            {
                                currentTotal = ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()).total;
                                ownerAndTotal.RemoveAt(ownerAndTotal.IndexOf(ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower())));
                                ownerAndTotal.Add(new OwnerAndTotal
                                {
                                    owner = userAccountInformation.owner,
                                    total = currentTotal += int.Parse(nftHolder.amount)
                                });
                            }
                        }
                    }
                }
                var fileName = ApplicationUtilitiesUI.WriteDataToCsvFile("NftHolderFromNftData", ownerAndAmount);
                var fileNameTwo = ApplicationUtilitiesUI.WriteDataToCsvFile("NftHoldersAndTotals", ownerAndTotal.OrderByDescending(x => x.total));
                sw.Stop();
                var swTime = $"This took {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m / 60, 3) : Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m)} {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
                Location = $"{swTime}\r\n\r\nYour files are here:\r\n\r\n{fileName}\r\n\r\n{fileNameTwo}";
            }
            IsEnabled = true;
        }

        public static async Task<string> CheckForEthAddress(ILoopringService LoopringService, string apiKey, string address)
        {
            address = address.Trim().ToLower();
            if (address.Contains(".eth"))
            {
                var varHexAddress = await LoopringService.GetHexAddress(apiKey, address);
                if (!String.IsNullOrEmpty(varHexAddress.data))
                    return varHexAddress.data;
                else
                    return null;
            }
            return address;
        }

    }
}
