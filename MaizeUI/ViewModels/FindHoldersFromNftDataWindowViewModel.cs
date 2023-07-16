using Maize;
using Maize.Services;
using Maize.Helpers;
using Maize.Models.ApplicationSpecific;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;
using static Maize.Models.NftHolders;
using Maize.Models.Responses;

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
            Location = $"Place NFT Data here. One per line.\r\n\r\nExample:\r\n0x118fabbd46c9a5c724de4394198fc7e2807d0deea5ea41f0bb533615e51c2b4b\r\n0x08dccae9dac82c69e6836977c932bb55e608d548d19e95addee8817f7edb5f8d\r\n0x2ea5bb3cf95ceb87d89c3048ce0b44d53560c955579576b58486e8edb2cc108c\r\n";
            Notice = "Here you will find NFT Holders from NFT Data.";
            FindHoldersFromNftDataCommand = ReactiveCommand.Create(FindHoldersFromNftData);
        }

        private async void FindHoldersFromNftData()
        {
            string nftDatas = location;
            List<string> stringList = new List<string>(nftDatas.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            Location = "Retrieving Holders, please give me a moment...";
            IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();
            var howManyLines = Files.CheckInputFile();

            //var filePath = $"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}";
            //string[] linesArray = File.ReadAllLines(filePath);
            //List<string> linesList = new List<string>(linesArray);
            var ownerAndAmount = new List<OwnerAndAmount>();
            var ownerAndTotal = new List<OwnerAndTotal>();
            int iteration = 0;
            int iterationAgain = 0;
            var counter = 0;
            int initialLinesListCount = stringList.Count;
            for (int i = stringList.Count; i > 0; i--)
            {
                string line = "";
                try
                {
                    line = stringList[i - 1];

                }
                catch (Exception)
                {
                    continue;
                }
                Location = $"Checking NFT Data: {iteration++}/{initialLinesListCount} Nfts retrieved...";
                var singleHolder = await LoopringService.GetNftHolderSingle(settings.LoopringApiKey, line);
                var collectionId = await LoopringService.FindCollectionIdFromHolder(settings.LoopringApiKey, singleHolder.nftHolders.First().accountId, line);
                List<NftTokenInfo> allCollectionsNfts = new List<NftTokenInfo>();
                List<List<CollectionOwned>> allOwnedCollections = new List<List<CollectionOwned>>();

                var offset = 0;
                var total = 0;
                while (true)
                {
                    var nfts = await LoopringService.GetCollectionNftsOffset(settings.LoopringApiKey, collectionId.data.First().collectionInfo?.id.ToString(), offset);
                    if (nfts.Item1 == null)
                    {
                        // need to handle nfts without an associated collection
                    }
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
                for (int j = stringList.Count; j > 0; j--)
                {
                    string lineAgain;
                    try
                    {
                        lineAgain = stringList[j - 1];
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    var nft = allCollectionsNfts.SingleOrDefault(x => x.nftData == lineAgain);
                    if (nft != null)
                    {
                        Location = $"Checking Collection Against other NFT Data: {iterationAgain++}/{initialLinesListCount} Nfts retrieved...";
                        stringList.Remove(lineAgain);
                        List<List<NftHolder>> allHolders = new List<List<NftHolder>>();
                        offset = 0;
                        total = 0;
                        while (true)
                        {
                            var nftHolders = await LoopringService.GetNftHoldersOffset(settings.LoopringApiKey, lineAgain, offset);
                            if (nftHolders.Item1.Count > 0)
                            {
                                total = nftHolders.Item2;
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
                    }
                    if (stringList.Count == 0)
                        break;
                }
                if (stringList.Count == 0)
                    break;
            }
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
