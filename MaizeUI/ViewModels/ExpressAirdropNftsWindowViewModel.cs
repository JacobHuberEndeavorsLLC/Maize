using Maize.Services;
using Maize;
using ReactiveUI;
using System.Reactive;
using Maize.Models.ApplicationSpecific;
using MaizeUI.Helpers;
using System.Reflection.Metadata;
using Maize.Models.Responses;
using DynamicData;
using Maize.Models;
using Maize.Helpers;
using System.Diagnostics;
using System.Text;
using System;

namespace MaizeUI.ViewModels
{
    public class ExpressAirdropNftsWindowViewModel : ViewModelBase
    {
        private double progress;
        public double Progress
        {
            get => progress;
            set => this.RaiseAndSetIfChanged(ref progress, value);
        }

        public int logBoxHeight;
        public int LogBoxHeight
        {
            get => logBoxHeight;
            set => this.RaiseAndSetIfChanged(ref logBoxHeight, value);
        }
        private int nftDataLineCount;
        public int NftDataLineCount
        {
            get => nftDataLineCount;
            private set => this.RaiseAndSetIfChanged(ref nftDataLineCount, value);
        }
        public string memo;
        public string Memo
        {
            get => memo;
            set => this.RaiseAndSetIfChanged(ref memo, value);
        }
        private int walletAddressesLineCount;
        public int WalletAddressesLineCount
        {
            get => walletAddressesLineCount;
            private set => this.RaiseAndSetIfChanged(ref walletAddressesLineCount, value);
        }

        public List<string> LoopringFeeDropdown { get; }
        public List<string> MaizeFeeDropdown { get; }

        private object loopringFeeSelectedOption;
        public object LoopringFeeSelectedOption
        {
            get => loopringFeeSelectedOption;
            set
            {
                this.RaiseAndSetIfChanged(ref loopringFeeSelectedOption, value);
                if (_enableApiCheck)
                {
                    CheckDataAndCallApi();
                }
            }
        }
        private object maizeFeeSelectedOption;
        public object MaizeFeeSelectedOption
        {
            get => maizeFeeSelectedOption;
            set
            {
                this.RaiseAndSetIfChanged(ref maizeFeeSelectedOption, value);
                if (_enableApiCheck)
                {
                    CheckDataAndCallApi();
                }
            }
        }
        private string nftData;
        public string NftData
        {
            get => nftData;
            set
            {
                this.RaiseAndSetIfChanged(ref nftData, value);
                NftDataLineCount = ParseInputToList(nftData).Count;
                this.RaisePropertyChanged(nameof(CanStart));
                if (_enableApiCheck)
                {
                    CheckDataAndCallApi();
                }
            }
        }
        private string walletAddresses;
        public string WalletAddresses
        {
            get => walletAddresses;
            set
            {
                this.RaiseAndSetIfChanged(ref walletAddresses, value);
                WalletAddressesLineCount = ParseInputToList(walletAddresses).Count;
                this.RaisePropertyChanged(nameof(CanStart));
                if (_enableApiCheck)
                {
                    CheckDataAndCallApi();
                }
            }
        }
        public string log;
        public string Log
        {
            get => log;
            set => this.RaiseAndSetIfChanged(ref log, value);
        }

        private bool _IsBeginningVisible = true;
        public bool IsBeginningVisible
        {
            get => _IsBeginningVisible;
            set => this.RaiseAndSetIfChanged(ref _IsBeginningVisible, value);
        }
        private bool _enableApiCheck = true;
        private bool isProgressBarVisible;
        public bool IsProgressBarVisible
        {
            get => isProgressBarVisible;
            set => this.RaiseAndSetIfChanged(ref isProgressBarVisible, value);
        }

        private bool isLogVisible;
        public bool IsLogVisible
        {
            get => isLogVisible;
            set => this.RaiseAndSetIfChanged(ref isLogVisible, value);
        }
        public bool IsRandom { get; set; }
        private bool canStart;
        public bool CanStart
        {
            get => canStart && NftDataLineCount == WalletAddressesLineCount;
            set => this.RaiseAndSetIfChanged(ref canStart, value);
        }
        public bool isComboBoxEnabled = true;
        public bool IsComboBoxEnabled
        {
            get => isComboBoxEnabled;
            set => this.RaiseAndSetIfChanged(ref isComboBoxEnabled, value);
        }
        private bool _isStartButtonVisible = false;
        public bool IsStartButtonVisible
        {
            get => _isStartButtonVisible;
            set => this.RaiseAndSetIfChanged(ref _isStartButtonVisible, value);
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

        public Constants.Environment _environment;
        public Constants.Environment Environment
        {
            get => _environment;
            set => this.RaiseAndSetIfChanged(ref _environment, value);
        }

        public ReactiveCommand<Unit, Unit> StartCommand { get; }
        public ReactiveCommand<Unit, Unit> ResetAirdropUICommand { get; }

        public ExpressAirdropNftsWindowViewModel(Constants.Environment environment)
        {
            _environment = environment;
            LoopringFeeDropdown = new List<string> { "Loopring Fee", "ETH", "LRC" };
            MaizeFeeDropdown = new List<string> { "Maize Fee", "ETH", "LRC", "PEPE" };
            LoopringFeeSelectedOption = LoopringFeeDropdown[0];
            MaizeFeeSelectedOption = MaizeFeeDropdown[0];
            canStart = true;
            IsProgressBarVisible = false; 
            IsLogVisible = true;
            logBoxHeight = 90;
            StartCommand = ReactiveCommand.Create(Start);
            ResetAirdropUICommand = ReactiveCommand.Create(ResetAirdropUI);

        }
        private async void Start()
        {
            if (LoopringFeeSelectedOption == LoopringFeeDropdown[0] || MaizeFeeSelectedOption == MaizeFeeDropdown[0])
                return;

            var sw = Stopwatch.StartNew();
            CanStart = false;
            this.RaisePropertyChanged(nameof(CanStart));

            var (nftDataList, walletAddressesList) = PrepareDataLists(NftData, WalletAddresses, IsRandom);

            var transferInformations = CreateAndAggregateAssociations(nftDataList, walletAddressesList);

            int maxFeeTokenId = ("ETH" == LoopringFeeSelectedOption) ? 0 : 1;
            CounterFactualInfo isCounterFactual = new();
            if (settings.MMorGMEPrivateKey == "")
                isCounterFactual = await LoopringService.GetCounterFactualInfo(settings.LoopringAccountId);

            int total = transferInformations.Count;
            int processedCount = 0;


            IsProgressBarVisible = true;
            IsLogVisible = false;

            foreach (var transferInformation in transferInformations) {
                var apiSw = Stopwatch.StartNew();
                var newAuditInfo = await loopringService.CallNftTransfer(
                    loopringService,
                    settings,
                    _environment,
                    maxFeeTokenId,
                    transferInformation,
                    memo,
                    false,
                    isCounterFactual
                        );

                transferInformation.TransferFail = newAuditInfo.TransferFail;
                transferInformation.ErrorMessage = newAuditInfo.ErrorMessage;
                Timers.ApiStopWatchCheck(apiSw);

                processedCount++;
                Progress = (double)processedCount / total * 100; 
            }

            var maizeMaxFeeTokenId = ("ETH" == MaizeFeeSelectedOption) ? 0 : 1;
            if (MaizeFeeSelectedOption == "PEPE")
                maizeMaxFeeTokenId = 272;

            var maizeFee = await Calculations.CalculateMaizeFee(LoopringService, transferInformations.Where(x=>x.TransferFail == false).Count(), MaizeFeeSelectedOption.ToString());

            var maxFeeVolume = await loopringService.MaizeTransferFee(
                    loopringService,
                    settings,
                    _environment,
                    transferInformations,
                    maizeFee,
                    loopringFeeSelectedOption.ToString(),
                    maxFeeTokenId,
                    maizeMaxFeeTokenId,
                    maizeFeeSelectedOption.ToString(),
                    isCounterFactual,
                    0
                    );
            var fileName = "ExpressAirdrop";

            ApplicationUtilitiesUI.WriteDataToCsvFile(fileName, transferInformations.OrderBy(transferInfo => transferInfo.TransferFail)
                .ThenBy(transferInfo => transferInfo.ErrorMessage));
            sw.Stop();
            IsProgressBarVisible = false;
            IsLogVisible = true;
            Progress = 0;

            var elapsedTime = sw.ElapsedMilliseconds;
            var elapsedTimeFormatted = elapsedTime > (1 * 60 * 1000) ?
                                       $"{Math.Round(Convert.ToDecimal(elapsedTime) / 1000m / 60, 3)} minutes" :
                                       $"{Convert.ToDecimal(elapsedTime) / 1000m} seconds";

            var totalTransactions = transferInformations.Count(x => !x.TransferFail);
            var totalNftsTransferred = transferInformations.Where(x => !x.TransferFail).Sum(x => x.Amount);
            var loopringFeeTotal = transferInformations.Sum(x => x.GasFee);
            var maizeFeeTotal = maxFeeVolume / 1000000000000000000M;

            StringBuilder logBuilder = new StringBuilder();
            logBuilder.AppendLine("📋 NFT Airdrop Summary 📋");
            logBuilder.AppendLine("-----------------------------------------");
            logBuilder.AppendLine($"🔢 Total NFT Transactions: {transferInformations.Count}");
            logBuilder.AppendLine($"✅ Successful Transactions: {totalTransactions}");
            logBuilder.AppendLine($"❌ Failed Transactions: {transferInformations.Count - totalTransactions}");
            logBuilder.AppendLine($"⏱️ Elapsed Time: {elapsedTimeFormatted}");
            logBuilder.AppendLine("-----------------------------------------");
            logBuilder.AppendLine("💰 Fees Summary:");
            logBuilder.AppendLine($"   Loopring Fee: {loopringFeeTotal} {loopringFeeSelectedOption} ({loopringFeeTotal * await Calculations.CurrentTokenPriceInUsd(loopringService, loopringFeeSelectedOption.ToString()):F3} USD)");
            logBuilder.AppendLine($"   Maize Fee: {maizeFee} {maizeFeeSelectedOption} ({maizeFee * await Calculations.CurrentTokenPriceInUsd(loopringService, maizeFeeSelectedOption.ToString()):F3} USD)");
            logBuilder.AppendLine("-----------------------------------------");
            logBuilder.AppendLine($"📈 Total NFTs Transferred: {totalNftsTransferred}");
            logBuilder.AppendLine("");
            logBuilder.AppendLine("📊 For detailed transaction info, refer to the provided CSV report.");

            IsBeginningVisible = false;
            IsStartButtonVisible = true;
            LogBoxHeight = 300;

            _enableApiCheck = false;
            ResetFields();
            _enableApiCheck = true;

            Log = logBuilder.ToString();

            CanStart = true;
            this.RaisePropertyChanged(nameof(CanStart));
        }
        private async void CheckDataAndCallApi()
        {
            if (settings != null &&  (NftDataLineCount == WalletAddressesLineCount || 
                !loopringFeeSelectedOption.Equals(LoopringFeeDropdown[0]) && !maizeFeeSelectedOption.Equals(MaizeFeeDropdown[0])))
            {
                try
                {
                    // Call the API and wait for the result
                    var gas = await LoopringService.GetNftOffChainFee(settings.LoopringApiKey, settings.LoopringAccountId, 11);

                    // Process the result if needed and update the Log
                    Log = "Gas: " + decimal.Parse(gas.gasPrice) / 1000000000;
                    if (!loopringFeeSelectedOption.Equals(LoopringFeeDropdown[0]))
                    {
                        var loopringFee = (decimal.Parse(gas.fees.First(x => x.token == loopringFeeSelectedOption.ToString()).fee) / 1000000000000000000) * NftDataLineCount;
                        Log += $"\nLoopring Fee: ~{loopringFee} {loopringFeeSelectedOption}";
                        Log += $" ({loopringFee * await Calculations.CurrentTokenPriceInUsd(loopringService, loopringFeeSelectedOption.ToString()):F3} USD)";
                    }
                    else
                        Log += "\nSelect Fee for Loopring estimates";
                    if (!MaizeFeeSelectedOption.Equals(MaizeFeeDropdown[0]))
                    {
                        var maizeFee = await Calculations.CalculateMaizeFee(LoopringService, NftDataLineCount, MaizeFeeSelectedOption.ToString());
                        Log += $"\nMaize Fee: ~{maizeFee} {MaizeFeeSelectedOption}";
                        Log += $" ({maizeFee * await Calculations.CurrentTokenPriceInUsd(loopringService, maizeFeeSelectedOption.ToString()):F3} USD)";
                    }
                    else
                        Log += "\nSelect Fee for Maize estimates";
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Sequence contains no matching element")
                    {
                        Log += "\nSelect Fees for cost estimates";
                    }
                    else
                    {
                        Log = "\nError Finding Gas: " + ex.Message;
                    }
                }
            }
        }
        private List<string> ParseInputToList(string input)
        {
            // Split the input by new lines and remove empty entries
            return input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        // Filter out lines that are empty or contain only whitespace
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .ToList();
        }

        private List<T> ShuffleList<T>(List<T> inputList)
        {
            Random rng = new Random();
            int n = inputList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = inputList[k];
                inputList[k] = inputList[n];
                inputList[n] = value;
            }
            return inputList;
        }
        private List<UserTransferInformation> CreateAndAggregateAssociations(List<string> nftDataList, List<string> walletAddressesList)
        {
            var associations = new List<UserTransferInformation>();

            // Create initial associations with an amount of 1
            for (int i = 0; i < Math.Min(nftDataList.Count, walletAddressesList.Count); i++)
            {
                associations.Add(new UserTransferInformation
                {
                    NftData = nftDataList[i],
                    WalletAddress = walletAddressesList[i],
                    Amount = 1
                });
            }

            // Group by NftData and WalletAddress to aggregate amounts for duplicates
            return associations
                .GroupBy(a => new { a.NftData, a.WalletAddress })
                .Select(group => new UserTransferInformation
                {
                    NftData = group.Key.NftData,
                    WalletAddress = group.Key.WalletAddress,
                    Amount = group.Sum(a => a.Amount)
                })
                .ToList();
        }
        private (List<string> nftDataList, List<string> walletAddressesList) PrepareDataLists(string nftData, string walletAddresses, bool isRandom)
        {
            var nftDataList = ParseInputToList(nftData);
            var walletAddressesList = ParseInputToList(walletAddresses);

            if (isRandom)
            {
                nftDataList = ShuffleList(nftDataList);
                walletAddressesList = ShuffleList(walletAddressesList);
            }

            return (nftDataList, walletAddressesList);
        }
        private void ResetFields()
        {
            NftData = string.Empty;
            WalletAddresses = string.Empty;
            Memo = string.Empty;
            LoopringFeeSelectedOption = LoopringFeeDropdown[0];
            MaizeFeeSelectedOption = MaizeFeeDropdown[0];
            Progress = 0;
            IsProgressBarVisible = false;
            IsComboBoxEnabled = true;
        }
        public void ResetAirdropUI()
        {
            IsBeginningVisible = true;
            IsStartButtonVisible = false;
            LogBoxHeight = 90;
            Log = string.Empty;
                               
        }
    }
}
