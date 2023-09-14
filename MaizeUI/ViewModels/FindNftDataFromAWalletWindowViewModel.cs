using Maize;
using Maize.Services;
using Maize.Helpers;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;
using Nethereum.Model;

namespace MaizeUI.ViewModels
{
    public class FindNftDataFromAWalletWindowViewModel : ViewModelBase
    {
        public string HelpButtonText { get; set; } = "Help";
        public string FindButtonText { get; set; } = "Find";
        public string MeButtonText { get; set; } = "Me";
        public string TitleText { get; set; } = "NFT Info From a Wallet";
        public string MainContent { get; set; } = "Here you will find relevant information about the NFTs in a wallet.";
        public string WatermarkOne { get; set; } = "wallet address...";
        public string ToolTipOne { get; set; } = "0x address or ens";

        public string walletAddress;

        public string WalletAddress
        {
            get => walletAddress;
            set => this.RaiseAndSetIfChanged(ref walletAddress, value);
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

        public ReactiveCommand<Unit, Unit> FindNftDataFromAWalletCommand { get; }
        public ReactiveCommand<Unit, Unit> FindMyNftDataFromAWalletCommand { get; }

        public FindNftDataFromAWalletWindowViewModel()
        {
            FindNftDataFromAWalletCommand = ReactiveCommand.CreateFromTask(() => RetrieveNFTs(WalletAddress));
            FindMyNftDataFromAWalletCommand = ReactiveCommand.CreateFromTask(() => RetrieveNFTs(settings.LoopringAddress, true));
        }
        private async Task RetrieveNFTs(string address, bool isMyData = false)
        {
            Log = "Retrieving NFTs, please give me a moment...";
            IsEnabled = false;
            var sw = Stopwatch.StartNew();

            string checkedAddress = await loopringService.CheckForEthAddress(loopringService, settings.LoopringApiKey, address);
            AccountInformationResponse accountInformation = await loopringService.GetUserAccountInformationFromOwner(checkedAddress);

            if (accountInformation == null)
            {
                Log = "Invalid address/ENS! Try Again...";
                sw.Stop();
                IsEnabled = true;
                return;
            }

            var allNfts = await GetAllNfts(accountInformation.accountId);
            var fileName = WriteNftInfoToCsv(allNfts);

            sw.Stop();
            UpdateLog(sw.ElapsedMilliseconds, allNfts.Count, fileName, isMyData);

            IsEnabled = true;
        }

        private async Task<List<Datum>> GetAllNfts(int accountId)
        {
            List<List<Datum>> allNfts = new List<List<Datum>>();
            int offset = 0;

            while (true)
            {
                var nfts = await loopringService.GetWalletsNftsOffset(settings.LoopringApiKey, accountId, offset);
                if (nfts.Item1.Count > 0)
                {
                    allNfts.Add(nfts.Item1);
                    Log = $"Gathering NFTs {allNfts.SelectMany(x => x).Count()}/{nfts.Item2}";
                    offset += 50;
                }
                else
                {
                    break;
                }
            }

            return allNfts.SelectMany(d => d).ToList();
        }

        private string WriteNftInfoToCsv(List<Datum> allNfts)
        {
            var walletsNftsBasicInformation = allNfts.Select(m => new { m.metadata.nftBase.name, m.total, m.nftData, m.nftId, m.minter, m.tokenAddress }).ToList();
            return ApplicationUtilitiesUI.WriteDataToCsvFile("NftDataFromWallet", walletsNftsBasicInformation);
        }

        private void UpdateLog(long elapsedMs, int nftCount, string fileName, bool isMyData)
        {
            var swTime = $"This took {(elapsedMs > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(elapsedMs) / 1000m / 60, 3) : Convert.ToDecimal(elapsedMs) / 1000m)} {(elapsedMs > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
            Log = $"{swTime}\r\n\r\n{(isMyData ? "You have" : $"{WalletAddress} has")} {nftCount} NFTs.\r\n\r\nYour file is here:\r\n{fileName}";
        }
    }
}
