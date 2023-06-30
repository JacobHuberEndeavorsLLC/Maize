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
using Maize.Models.Responses;
using Maize.Models;
using System.Collections;

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
            var howManyLines = Files.CheckInputFile();

            var filePath = $"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}";
            string[] linesArray = File.ReadAllLines(filePath);
            List<string> linesList = new List<string>(linesArray);
            var ownerAndAmount = new List<OwnerAndAmount>();
            var ownerAndTotal = new List<OwnerAndTotal>();
            int iteration = 0;
            int iterationAgain = 0;
            var counter = 0;
            //foreach (string line in linesList)
            //{
            for (int i = linesList.Count; i >= 0; i--)
            {
                string line = linesList[i - 1];
                Location = $"Checking NFT Data: {iteration++}/{linesList.Count()} Nfts retrieved...";
                var singleHolder = await LoopringService.GetNftHolderSingle(settings.LoopringApiKey, line);
                var collectionId = await LoopringService.FindCollectionIdFromHolder(settings.LoopringApiKey, singleHolder.nftHolders.First().accountId, line);
                List<NftTokenInfo> allCollectionsNfts = new List<NftTokenInfo>();
                List<List<CollectionOwned>> allOwnedCollections = new List<List<CollectionOwned>>();

                var offset = 0;
                var total = 0;
                while (true)
                {
                    var nfts = await LoopringService.GetCollectionNftsOffset(settings.LoopringApiKey, collectionId.data.First().collectionInfo.id.ToString(), offset);
                    if (nfts.Item1.Count > 0)
                    {
                        Location = $"Retrieving Collection Information: {allCollectionsNfts.Count()}/{total} Nfts retrieved...";
                        total = nfts.Item2;
                        allCollectionsNfts.AddRange(nfts.Item1);
                        offset += 50;
                    }
                    else
                    {
                        break;
                    }
                }
                //foreach (var lineAgain in linesList)
                //{
                for (int j = linesList.Count; j >= 0; j--)
                {
                    string lineAgain = linesList[j - 1];
                    Location = $"Checking Collection Against other NFT Data: {iterationAgain++}/{linesList.Count()} Nfts retrieved...";
                    var nft = allCollectionsNfts.First(x => x.nftData == lineAgain);
                    if (nft != null)
                    {
                        linesList.Remove(lineAgain);
                        List<List<NftHolder>> allHolders = new List<List<NftHolder>>();
                        offset = 0;
                        total = 0;
                        while (true)
                        {
                            var nftHolders = await LoopringService.GetNftHoldersOffset(settings.LoopringApiKey, lineAgain, offset);
                            if (nftHolders.Item1.Count > 0)
                            {
                                total = nftHolders.Item2;
                                //Location = $"Nft {counter}/{howManyLines} {nftMetadata.name}: {allHolders.SelectMany(d => d).Count()}/{total} Holders retrieved...";
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
                            //var userAccountInformation = await LoopringService.GetUserAccountInformationFromId(nftHolder.accountId.ToString());
                            Location = $"Nft {counter}/{howManyLines} {nft.metadata.basename.name}: {++holderCounter}/{allHolders.SelectMany(d => d).Count()} Holders calculated...";
                            if (nft.metadata.basename.name != null)
                            {
                                ownerAndAmount.Add(new OwnerAndAmount
                                {
                                    nftData = nft.nftData,
                                    nftName = nft.metadata.basename.name,
                                    nftOwner = nftHolder.address,
                                    ownerAmountOwned = nftHolder.amount
                                });
                                if (!ownerAndTotal.Any(x => x.owner.ToLower() == nftHolder.address.ToLower()))
                                {
                                    ownerAndTotal.Add(new OwnerAndTotal
                                    {
                                        owner = nftHolder.address,
                                        total = int.Parse(nftHolder.amount)
                                    });
                                }
                                else
                                {
                                    int currentTotal = ownerAndTotal.First(x => x.owner.ToLower() == nftHolder.address.ToLower()).total;
                                    ownerAndTotal.RemoveAt(ownerAndTotal.IndexOf(ownerAndTotal.First(x => x.owner.ToLower() == nftHolder.address.ToLower())));
                                    ownerAndTotal.Add(new OwnerAndTotal
                                    {
                                        owner = nftHolder.address,
                                        total = currentTotal += int.Parse(nftHolder.amount)
                                    });
                                }
                            }
                        }

















                        //ownerAndAmount.Add(new OwnerAndAmount
                        //{
                        //    nftData = collectionNft.nftData,
                        //    nftName = collectionNft.metadata.basename.name,
                        //    nftOwner = nftHolder.address,
                        //    ownerAmountOwned = nftHolder.amount
                        //});
                        //if (!ownerAndTotal.Any(x => x.owner.ToLower() == nftHolder.address.ToLower()))
                        //{
                        //    ownerAndTotal.Add(new OwnerAndTotal
                        //    {
                        //        owner = nftHolder.address,
                        //        total = int.Parse(nftHolder.amount)
                        //    });
                        //}
                        //else
                        //{
                        //    currentTotal = ownerAndTotal.First(x => x.owner.ToLower() == nftHolder.address.ToLower()).total;
                        //    ownerAndTotal.RemoveAt(ownerAndTotal.IndexOf(ownerAndTotal.First(x => x.owner.ToLower() == nftHolder.address.ToLower())));
                        //    ownerAndTotal.Add(new OwnerAndTotal
                        //    {
                        //        owner = nftHolder.address,
                        //        total = currentTotal += int.Parse(nftHolder.amount)
                        //    });
                        //}
                    }
                    if (linesList.Count == 0)
                        break;
                }
                if (linesList.Count == 0)
                    break;
            }















            //string[] allLines = File.ReadAllLines(filePath);
            //int linesPerIteration = 25;
            //string delimiter = ",";
            //List<NftInformationResponse> nftInformation = new();
            //StringBuilder combinedLines = new StringBuilder();


            //for (int i = 0; i < allLines.Length; i += linesPerIteration)
            //{
            //    int linesToProcess = Math.Min(linesPerIteration, allLines.Length - i);
            //    string[] lines = new string[linesToProcess];
            //    Array.Copy(allLines, i, lines, 0, linesToProcess);

            //    string combined = string.Join(delimiter, lines);

            //    nftInformation.AddRange(await LoopringService.GetNftInformationFromNftData(settings.LoopringApiKey, combined));
            //}
            //foreach (var line in nftInformation)
            //{
            //    var singleHolder = await LoopringService.GetNftHolderSingle(settings.LoopringApiKey, line.nftData);
            //    var collectionId = await LoopringService.FindCollectionIdFromHolder(settings.LoopringApiKey, singleHolder.nftHolders.First().accountId, line.nftData);


            //}


















            //using (StreamReader sr = new($"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}"))
            //{
            //    IEthereumService ethereumService = new EthereumService();
            //    INftMetadataService nftMetadataService = new NftMetadataService("https://ipfs.loopring.io/ipfs/");
            //    int currentTotal;

            //    string nftData;
            //    var counter = 0;
            //    while ((nftData = sr.ReadLine()) != null)
            //    {
            //        Location = $"Nft {++counter}/{howManyLines}";
            //        var minterFromNftDatas = await LoopringService.GetNftInformationFromNftData(settings.LoopringApiKey, nftData);
            //        var nftMetadata = await ApplicationUtilities.GetNftMetadataUI(ethereumService, nftMetadataService, minterFromNftDatas.FirstOrDefault().nftId, minterFromNftDatas.FirstOrDefault().tokenAddress);
            //        Location = $"Nft {counter}/{howManyLines} {nftMetadata.name}: ";
            //        int offset = 0;
            //        int total = 0;
            //        while (true)
            //        {
            //            var nftHolders = await LoopringService.GetNftHoldersOffset(settings.LoopringApiKey, nftData, offset);
            //            if (nftHolders.Item1.Count > 0)
            //            {
            //                total = nftHolders.Item2;
            //                Location = $"Nft {counter}/{howManyLines} {nftMetadata.name}: {allHolders.SelectMany(d => d).Count()}/{total} Holders retrieved...";
            //                allHolders.Add(nftHolders.Item1);
            //                offset += 50;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }

            //        var holderCounter = 0;
            //        foreach (var nftHolder in allHolders.SelectMany(d => d))
            //        {
            //            //font.ToTertiaryInline($"\rNft: {counter}/{howManyLines} {nftMetadata.name} Nft Holder: {++holderCounter}/{nftHoldersList.Count}");
            //            //var userAccountInformation = await LoopringService.GetUserAccountInformationFromId(nftHolder.accountId.ToString());
            //            Location = $"Nft {counter}/{howManyLines} {nftMetadata.name}: {++holderCounter}/{allHolders.SelectMany(d => d).Count()} Holders calculated...";
            //            if (nftMetadata != null)
            //            {
            //                ownerAndAmount.Add(new OwnerAndAmount
            //                {
            //                    nftData = nftData,
            //                    nftName = nftMetadata.name,
            //                    nftOwner = nftHolder.address,
            //                    ownerAmountOwned = nftHolder.amount
            //                });
            //                if (!ownerAndTotal.Any(x => x.owner.ToLower() == nftHolder.address.ToLower()))
            //                {
            //                    ownerAndTotal.Add(new OwnerAndTotal
            //                    {
            //                        owner = nftHolder.address,
            //                        total = int.Parse(nftHolder.amount)
            //                    });
            //                }
            //                else
            //                {
            //                    currentTotal = ownerAndTotal.First(x => x.owner.ToLower() == nftHolder.address.ToLower()).total;
            //                    ownerAndTotal.RemoveAt(ownerAndTotal.IndexOf(ownerAndTotal.First(x => x.owner.ToLower() == nftHolder.address.ToLower())));
            //                    ownerAndTotal.Add(new OwnerAndTotal
            //                    {
            //                        owner = nftHolder.address,
            //                        total = currentTotal += int.Parse(nftHolder.amount)
            //                    });
            //                }
            //            }
            //        }
            //    }
            //}
            var fileName = ApplicationUtilitiesUI.WriteDataToCsvFile("NftHolderFromNftData", ownerAndAmount);
            var fileNameTwo = ApplicationUtilitiesUI.WriteDataToCsvFile("NftHoldersAndTotals", ownerAndTotal.OrderByDescending(x => x.total));
            sw.Stop();
            var swTime = $"This took {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m / 60, 3) : Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m)} {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
            Location = $"{swTime}\r\n\r\nYour files are here:\r\n\r\n{fileName}\r\n\r\n{fileNameTwo}";
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
