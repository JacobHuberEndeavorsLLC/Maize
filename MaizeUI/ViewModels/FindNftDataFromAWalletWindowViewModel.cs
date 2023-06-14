using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Rendering;
using Maize;
using Maize.Services;
using Maize.Helpers;
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

namespace MaizeUI.ViewModels
{
    public class FindNftDataFromAWalletWindowViewModel : ViewModelBase
    {
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

        public FindNftDataFromAWalletWindowViewModel()
        {
            FindNftDataFromAWalletCommand = ReactiveCommand.Create(FindNftDataFromAWallet);
        }

        private async void FindNftDataFromAWallet()
        {
            Log = "Retrieving NFTs, please give me a moment...";
            IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();
            AccountInformationResponse accountInformation = await LoopringService.GetUserAccountInformationFromOwner(await CheckForEthAddress(LoopringService, settings.LoopringApiKey, WalletAddress));
            if (accountInformation == null)
            {
                Log = "Invalid address/ENS! Try Again...";
                sw.Stop();
            }
            else
            {
                List<List<Datum>> allNfts = new List<List<Datum>>();
                int offset = 0;
                int total = 0;
                while(true)
                {
                    var nfts = await LoopringService.GetWalletsNftsOffset(settings.LoopringApiKey, accountInformation.accountId, offset);
                    if(nfts.Item1.Count > 0)
                    {
                        total = nfts.Item2;
                        Log = $"{allNfts.SelectMany(d => d).Count()}/{total} NFTs retrieved...";
                        allNfts.Add(nfts.Item1);
                        offset += 50;
                    }
                    else
                    {
                        break;
                    }
                }

                var walletsNftsBasicInformation = allNfts.SelectMany(d=> d).Select(m => new { m.metadata.nftBase.name, m.nftData, m.nftId, m.minter, m.tokenAddress }).ToList();
                var fileName = ApplicationUtilitiesUI.WriteDataToCsvFile("NftDataFromWallet", walletsNftsBasicInformation);
                sw.Stop();
                var swTime = $"This took {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m / 60, 3) : Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m)} {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
                Log = $"{swTime}\r\n\r\n{walletAddress} has {total} NFTs in their wallet.\r\n\r\nYour file is here:\r\n\r\n{fileName}";
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
