using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Rendering;
using DynamicData;
using Maize;
using Maize.Services;
using Maize.Helpers;
using Maize.Models.Responses;
using MaizeUI.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Tmds.DBus;
using System.Reflection.Metadata;
using Maize.Models.ApplicationSpecific;

namespace MaizeUI.ViewModels
{
    public class MetadataRefreshCollectionWindowViewModel : ViewModelBase
    {
        private bool isTextBoxVisible;

        public bool IsTextBoxVisible
        {
            get => isTextBoxVisible;
            set => this.RaiseAndSetIfChanged(ref isTextBoxVisible, value);
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

        public ReactiveCommand<Unit, Unit> FindNftDataFromACollectionCommand { get; }
        public ReactiveCommand<Unit, Unit> FindNftDataFromMyCollectionsCommand { get; }

        public MetadataRefreshCollectionWindowViewModel()
        {
            IsTextBoxVisible = false;
            FindNftDataFromACollectionCommand = ReactiveCommand.Create(FindNftDataFromACollection);
            //FindNftDataFromMyCollectionsCommand = ReactiveCommand.Create(FindNftDataFromMyCollections);
        }

        private async void FindNftDataFromACollection()
        {
            Log = "Checking collection, please give me a moment...";
            IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();

            List<List<CollectionOwned>> allOwnedCollections = new List<List<CollectionOwned>>();
            List<List<CollectionMinted>> allMintedCollections = new List<List<CollectionMinted>>();
            List<NftTokenInfo> allCollectionsNfts = new List<NftTokenInfo>();
            int offset = 0;
            int total = 0;
            if (collectionAddress == null)
            {
                Log = "Enter a collection! Try Again...";
                sw.Stop();
                IsEnabled = true;
                return;
            }
            else
            {
                offset = 0;
                total = 0;
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
                if (allMintedCollections.SelectMany(d => d).Any(x => x.collection.collectionAddress == collectionAddress))
                {
                    offset = 0;
                    total = 0;
                    while (true)
                    {
                        var nfts = await LoopringService.GetCollectionNftsOffset(settings.LoopringApiKey, allMintedCollections.SelectMany(d => d).Where(x => x.collection.collectionAddress == collectionAddress).First().collection.id.ToString(), offset);
                        if (nfts.Item1.Count > 0)
                        {
                            total = nfts.Item2;
                            Log = $"{allMintedCollections.SelectMany(d => d).Count()}/{total} Nfts retrieved...";
                            allCollectionsNfts.Add(nfts.Item1);
                            offset += 50;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (!allMintedCollections.SelectMany(d => d).Any(x => x.collection.collectionAddress == collectionAddress))
                {
                    offset = 0;
                    total = 0;
                    while (true)
                    {
                        // checking if user owns an nft from the collection to get the collectionId
                        var collections = await LoopringService.GetUserOwnedCollectionsOffset(settings.LoopringApiKey, settings.LoopringAccountId, offset);
                        if (collections.Item1.Count > 0)
                        {
                            total = collections.Item2;
                            Log = $"{allOwnedCollections.SelectMany(d => d).Count()}/{total} Collections retrieved...";
                            allOwnedCollections.Add(collections.Item1);
                            offset += 50;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (allOwnedCollections.SelectMany(d => d).Any(x => x.collection.contractAddress == collectionAddress))
                    {
                        offset = 0;
                        total = 0;
                        while (true)
                        {
                            var nfts = await LoopringService.GetCollectionNftsOffset(settings.LoopringApiKey, allOwnedCollections.SelectMany(d => d).Where(x => x.collection.contractAddress == collectionAddress).First().collection.id.ToString(), offset);
                            if (nfts.Item1.Count > 0)
                            {
                                total = nfts.Item2;
                                Log = $"{allOwnedCollections.SelectMany(d => d).Count()}/{total} Nfts retrieved...";
                                allCollectionsNfts.Add(nfts.Item1);
                                offset += 50;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        // user did not mint collection and does not own an nft from the collection so there is a workaround to get the collection id. i think i will need to create a new window to accept the minter and an nftId
                        if (IsTextBoxVisible == false)
                        {
                            Log = "This collection is not minted or owned by you.\r\n\r\nAdditional information is required.\r\n\r\nEnter the Above and press Find.";
                            ShowTextBox();
                            IsEnabled = true;
                            return;
                        }
                        else
                        {
                            Log = "Checking information, please give me a moment...";
                            AccountInformationResponse accountInformation = await LoopringService.GetUserAccountInformationFromOwner(await CheckForEthAddress(LoopringService, settings.LoopringApiKey, MinterAddress));
                            if (accountInformation == null)
                            {
                                Log = "Invalid Wallet Address/ENS! Try Again...";
                                IsEnabled = true;
                                sw.Stop();
                                return;
                            }
                            else
                            {
                                var nftdataRequest = await LoopringService.GetNftData(settings.LoopringApiKey, NftId, accountInformation.owner, collectionAddress);
                                if (nftdataRequest == null)
                                {
                                    Log = "Invalid Information! Try Again...";
                                    IsEnabled = true;
                                    sw.Stop();
                                    return;
                                }
                                var singleHolder = await LoopringService.GetNftHolderSingle(settings.LoopringApiKey, nftdataRequest.nftData);
                                var collectionId = await LoopringService.FindCollectionIdFromHolder(settings.LoopringApiKey, singleHolder.nftHolders.First().accountId, nftdataRequest.nftData);
                                offset = 0;
                                total = 0;
                                while (true)
                                {
                                    var nfts = await LoopringService.GetCollectionNftsOffset(settings.LoopringApiKey, collectionId.data.First().collectionInfo.id.ToString(), offset);
                                    if (nfts.Item1.Count > 0)
                                    {
                                        total = nfts.Item2;
                                        Log = $"{allOwnedCollections.SelectMany(d => d).Count()}/{total} Nfts retrieved...";
                                        allCollectionsNfts.Add(nfts.Item1);
                                        offset += 50;
                                    }
                                    else
                                    {
                                        HideTextBox();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            var refreshAudit = new List<RefreshNftResponse>();
            for (int i = 0; i < allCollectionsNfts.Count; i++)
            {
                var item = allCollectionsNfts[i];
                var response = await loopringService.RefreshNft(item.nftId, item.tokenAddress);
                response.name = item.metadata.basename.name; // Make sure to set the nftId in the response object
                response.nftId = item.nftId; // Make sure to set the nftId in the response object
                refreshAudit.Add(response);
                Log = $"Refreshing {i + 1}/{allCollectionsNfts.Count()}";
            }

            var fileName = ApplicationUtilitiesUI.WriteDataToCsvFile($"{collectionAddress}MetadataRefresh", refreshAudit);
            sw.Stop();
            var swTime = $"This took {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m / 60, 3) : Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m)} {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
            Log = $"{swTime}\r\n\r\n{collectionAddress} has {total} NFTs in its collection.\r\n\r\nYour file is here:\r\n\r\n{fileName}";
            NftId = string.Empty;
            MinterAddress = string.Empty;
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
        public void ShowTextBox()
        {
            IsTextBoxVisible = true;
        }
        public void HideTextBox()
        {
            IsTextBoxVisible = false;
        }
    }
}
