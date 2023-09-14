using DynamicData;
using Maize;
using Maize.Services;
using Maize.Helpers;
using Maize.Models.Responses;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;
using Maize.Models.ApplicationSpecific;
using OpenCvSharp;

namespace MaizeUI.ViewModels
{
    public class FindNftDataFromACollectionWindowViewModel : ViewModelBase
    {
        public string HelpButtonText { get; set; } = "Help";
        public string FindButtonText { get; set; } = "Find";
        public string MeButtonText { get; set; } = "Me";
        public string TitleText { get; set; } = "NFT Info From Collection";
        public string MainContent { get; set; } = "Here you will find relevant information about the NFTs in a Collection.";
        public string WatermarkOne { get; set; } = "collection address...";
        public string WatermarkTwo { get; set; } = "minter address...";
        public string WatermarkThree { get; set; } = "nft id...";
        public string ToolTipOne { get; set; } = "collection/token address";
        public string ToolTipTwo { get; set; } = "minter address from collection";
        public string ToolTipThree { get; set; } = "nft id from collection";

        private int _windowHeight = 365; // initial value
        public int WindowHeight
        {
            get => _windowHeight;
            set => this.RaiseAndSetIfChanged(ref _windowHeight, value);
        }

        private bool _isTextBoxVisible;
        public bool IsTextBoxVisible
        {
            get => _isTextBoxVisible;
            set
            {
                this.RaiseAndSetIfChanged(ref _isTextBoxVisible, value);
                WindowHeight = _isTextBoxVisible ? 450 : 365;
            }
        }

        public string minterAddress;
        public string MinterAddress
        {
            get => minterAddress;
            set => this.RaiseAndSetIfChanged(ref minterAddress, value);
        }
        public string collectionAddress;
        public string CollectionAddress
        {
            get => collectionAddress;
            set => this.RaiseAndSetIfChanged(ref collectionAddress, value);
        }
        public string nftId;

        public string NftId
        {
            get => nftId;
            set => this.RaiseAndSetIfChanged(ref nftId, value);
        }

        public bool isEnabled = true;

        public bool IsEnabled
        {
            get => isEnabled;
            set => this.RaiseAndSetIfChanged(ref isEnabled, value);
        }

        private string _log;
        public string Log
        {
            get => _log;
            set => this.RaiseAndSetIfChanged(ref _log, value);
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

        public ReactiveCommand<Unit, Unit> FindNftDataFromACollectionCommand { get; }
        public ReactiveCommand<Unit, Unit> FindNftDataFromMyCollectionsCommand { get; }

        public FindNftDataFromACollectionWindowViewModel()
        {
            IsTextBoxVisible = false;
            FindNftDataFromACollectionCommand = ReactiveCommand.CreateFromTask(FindNftDataFromACollection);
            FindNftDataFromMyCollectionsCommand = ReactiveCommand.CreateFromTask(FindNftDataFromMyCollections);
        }
        private async Task<List<T>> FetchDataInBatches<T>(Func<int, Task<(List<T>, int)>> fetchData, int initialOffset = 0)
        {
            var allData = new List<T>();
            int offset = initialOffset, total = 0;

            while (true)
            {
                var (batchData, totalCount) = await fetchData(offset);
                if (batchData.Count > 0)
                {
                    total = totalCount;
                    allData.AddRange(batchData);
                    offset += 50;
                }
                else
                {
                    break;
                }
            }
            return allData;
        }

        private async Task<List<NftTokenInfo>> FetchNftsForCollections(List<CollectionOwned> ownedCollections, List<CollectionMinted> mintedCollections, string targetAddress)
        {
            var allCollectionsNfts = new List<NftTokenInfo>();
            var relevantCollections = ownedCollections.Select(c => new { c.collection }).Concat(mintedCollections.Select(c => new { c.collection })).ToList();
            var targetCollection = relevantCollections.FirstOrDefault(x => x.collection.collectionAddress == targetAddress || x.collection.contractAddress == targetAddress);

            if (targetCollection != null)
            {
                allCollectionsNfts = await FetchDataInBatches<NftTokenInfo>(
                    offset => LoopringService.GetCollectionNftsOffset(settings.LoopringApiKey, targetCollection.collection.id.ToString(), offset)
                );
            }
            return allCollectionsNfts;
        }

        private string WriteNftInfoToCsv(List<NftTokenInfo> nftData)
        {
            var collectionsNftsInformation = nftData.Select(m => new
            {
                name = m.metadata.basename.name,
                description = m.metadata.basename.description,
                nftData = m.nftData,
                metadataCid = m.metadata.uri.Replace("ipfs://", ""),
                nftId = m.nftId,
                minter = m.minter,
                tokenAddress = m.tokenAddress,
                properties = m.metadata.basename.properties
            }).ToList();
            return ApplicationUtilitiesUI.WriteDataToCsvFile("NftInfoFromCollection", collectionsNftsInformation);
        }

        private async Task FindNftDataFromACollection()
        {
            Log = "Checking collection, please give me a moment...";
            IsEnabled = false;
            var sw = Stopwatch.StartNew();
            if (string.IsNullOrWhiteSpace(collectionAddress))
            {
                Log = "Enter a collection! Try Again...";
                sw.Stop();
                IsEnabled = true;
                return;
            }

            var allOwnedCollections = await FetchDataInBatches<CollectionOwned>(
                offset => LoopringService.GetUserOwnedCollectionsOffset(settings.LoopringApiKey, settings.LoopringAccountId, offset)
            );

            var allMintedCollections = await FetchDataInBatches<CollectionMinted>(
                offset => LoopringService.GetUserMintedCollectionsOffset(settings.LoopringApiKey, settings.LoopringAddress, offset)
            );

            var allCollectionsNfts = await FetchNftsForCollections(allOwnedCollections, allMintedCollections, collectionAddress);

            if (allCollectionsNfts.Count == 0)
            {
                allCollectionsNfts = await HandleUnownedAndUnmintedCollection(sw);
                if (allCollectionsNfts == null) return;
            }
            var fileName = WriteNftInfoToCsv(allCollectionsNfts);

            sw.Stop();
            UpdateLog(sw.ElapsedMilliseconds, allCollectionsNfts.Count(), fileName);
            HideTextBox();
            IsEnabled = true;
        }

        private void UpdateLog(long elapsedMs, int total, string fileName)
        {
            var swTime = $"This took {(elapsedMs > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(elapsedMs) / 1000m / 60, 3) : Convert.ToDecimal(elapsedMs) / 1000m)} {(elapsedMs > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
            Log = $"{swTime}\r\n\r\n{collectionAddress} has {total} NFTs in its collection.\r\n\r\nYour file is here:\r\n{fileName}";
        }
        private async Task<List<NftTokenInfo>> HandleUnownedAndUnmintedCollection(Stopwatch sw)
        {
            // If collection is neither owned nor minted
            if (IsTextBoxVisible == false)
            {
                Log = "This collection is not minted or owned by you.\r\n\r\nAdditional information is required.\r\n\r\nEnter the Above and press Find.";
                ShowTextBox();
                IsEnabled = true;
                return null;
            }

            Log = "Checking information, please give me a moment...";

            AccountInformationResponse accountInformation = await loopringService.GetUserAccountInformationFromOwner(await loopringService.CheckForEthAddress(loopringService, settings.LoopringApiKey, minterAddress));

            if (accountInformation == null)
            {
                Log = "Invalid Wallet Address/ENS! Try Again...";
                IsEnabled = true;
                sw.Stop();
                return null;
            }

            var nftdataRequest = await loopringService.GetNftData(settings.LoopringApiKey, NftId, accountInformation.owner, collectionAddress);

            if (nftdataRequest == null)
            {
                Log = "Invalid Information! Try Again...";
                IsEnabled = true;
                sw.Stop();
                return null;
            }

            var singleHolder = await loopringService.GetNftHolderSingle(settings.LoopringApiKey, nftdataRequest.nftData);
            var collectionId = await loopringService.FindCollectionIdFromHolder(settings.LoopringApiKey, singleHolder.nftHolders.First().accountId, nftdataRequest.nftData);

            return await FetchDataInBatches<NftTokenInfo>(
                offset => LoopringService.GetCollectionNftsOffset(settings.LoopringApiKey, collectionId.data.First().collectionInfo.id.ToString(), offset)
            );

        }
        private async Task FindNftDataFromMyCollections()
        {
            Log = "Checking collections, please give me a moment...";
            IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();
            List<NftTokenInfo> allCollectionsNfts = new List<NftTokenInfo>();
            List<List<CollectionMinted>> allMintedCollections = new List<List<CollectionMinted>>();
            int offset = 0;
            int total = 0;

            while (true)
            {
                // checking if user minted the collection to get the collectionId
                var collections = await LoopringService.GetUserMintedCollectionsOffset(settings.LoopringApiKey, settings.LoopringAddress, offset);
                if (collections.Item1.Count > 0)
                {
                    total = collections.Item2;
                    Log = $"{allMintedCollections.SelectMany(d => d).Count()}/{total} Collections retrieved...";
                    allMintedCollections.Add(collections.Item1);
                    offset += 50;
                }
                else
                {
                    break;
                }
            }
            foreach (var item in allMintedCollections.SelectMany(d=>d))
            {
                offset = 0;
                total = 0;
                while (true)
                {
                    var nfts = await LoopringService.GetCollectionNftsOffset(settings.LoopringApiKey, item.collection.id.ToString(), offset);
                    if (nfts.Item1.Count > 0)
                    {
                        total = nfts.Item2;
                        Log = $"{nfts.Item1.Count}/{total} Nfts retrieved...";
                        allCollectionsNfts.Add(nfts.Item1);
                        offset += 50;
                    }
                    else
                    {
                        break;
                    }
                }
                Thread.Sleep(1000);
                var collectionsNftsInformation = allCollectionsNfts.Select(m => new { m.metadata.basename.name, m.metadata.basename.description, m.nftData, m.nftId, m.minter, m.tokenAddress, m.metadata.basename.properties }).ToList();
                var fileName = ApplicationUtilitiesUI.WriteDataToCsvFile("NftInfoFromCollection", collectionsNftsInformation);

            }
            sw.Stop();
            var swTime = $"This took {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m / 60, 3) : Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m)} {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
            Log = $"{swTime}\r\n\r\nYou have {allMintedCollections.SelectMany(d=>d).Count()} collection(s).\r\n\r\nYour file(s) are here:\r\n{Constants.BaseDirectory}{Constants.OutputFolder}";

            nftId = string.Empty;
            minterAddress = string.Empty;
            IsEnabled = true;
        }
        public void ShowTextBox()
        {
            IsTextBoxVisible = true;
        }
        public void HideTextBox()
        {
            nftId = string.Empty;
            minterAddress = string.Empty;
            IsTextBoxVisible = false;
        }

    }
}
