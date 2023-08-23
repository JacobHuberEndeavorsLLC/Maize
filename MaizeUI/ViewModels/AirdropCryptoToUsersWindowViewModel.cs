using Maize;
using Maize.Services;
using Maize.Helpers;
using Maize.Models.ApplicationSpecific;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;
using System.Text;
using Maize.Models;
using Maize.Models.Responses;
using System.Text.RegularExpressions;

namespace MaizeUI.ViewModels
{
    public class AirdropCryptoToUsersWindowViewModel : ViewModelBase 
    {
        List<TransferInformationCrypto> transferInfoCryptoList = new();
        List<TransferInformation> transferInfoList = new();
        string invalidLines;
        private bool isNextButtonVisible;
        private bool isStartButtonVisible;
        private bool isPreviewButtonVisible;
        private bool isFeeInfoVisible;
        private bool step1;
        private bool step2;
        private bool step3;
        public bool Step1
        {
            get => step1;
            set => this.RaiseAndSetIfChanged(ref step1, value);
        }
        public bool Step2
        {
            get => step2;
            set => this.RaiseAndSetIfChanged(ref step2, value);
        }
        public bool Step3
        {
            get => step3;
            set => this.RaiseAndSetIfChanged(ref step3, value);
        }
        public bool IsPreviewButtonVisible
        {
            get => isPreviewButtonVisible;
            set => this.RaiseAndSetIfChanged(ref isPreviewButtonVisible, value);
        }
        public bool IsFeeInfoVisible
        {
            get => isFeeInfoVisible;
            set => this.RaiseAndSetIfChanged(ref isFeeInfoVisible, value);
        }
        public bool IsNextButtonVisible
        {
            get => isNextButtonVisible;
            set => this.RaiseAndSetIfChanged(ref isNextButtonVisible, value);
        }
        public bool IsStartButtonVisible
        {
            get => isStartButtonVisible;
            set => this.RaiseAndSetIfChanged(ref isStartButtonVisible, value);
        }
        private bool isCheckboxVisible;

        public bool IsCheckboxVisible
        {
            get => isCheckboxVisible;
            set => this.RaiseAndSetIfChanged(ref isCheckboxVisible, value);
        }
        private bool _isChecked;
        private bool isEnabledCheckBox = true;

        public bool IsChecked
        {
            get => _isChecked;
            set => this.RaiseAndSetIfChanged(ref _isChecked, value);
        }        
        public bool IsEnabledCheckBox
        {
            get => isEnabledCheckBox;
            set => this.RaiseAndSetIfChanged(ref isEnabledCheckBox, value);
        }
        public string Notice { get; set; }
        public string Notice2 { get; set; }
        public string Notice3 { get; set; }
        public string Notice4 { get; set; }
        public string Notice5 { get; set; }
        public string Notice6 { get; set; }
        public bool isEnabled = true; 
        public bool isComboBoxEnabled = true; 
        public bool notice5Visible = false; 
        public bool notice6Visible = false; 
        public bool IsComboBoxEnabled
        {
            get => isComboBoxEnabled;
            set => this.RaiseAndSetIfChanged(ref isComboBoxEnabled, value);
        }        
        public bool Notice5Visible
        {
            get => notice5Visible;
            set => this.RaiseAndSetIfChanged(ref notice5Visible, value);
        }
        public bool Notice6Visible
        {
            get => notice6Visible;
            set => this.RaiseAndSetIfChanged(ref notice6Visible, value);
        }
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
        public Constants.Environment environment;

        public Constants.Environment Environment
        {
            get => environment;
            set => this.RaiseAndSetIfChanged(ref environment, value);
        }
        public List<string> LoopringFeeDropdown { get; } 
        public List<string> MaizeFeeDropdown { get; } 
        public string LoopringFeeSelectedOption { get; set; } 
        public string MaizeFeeSelectedOption { get; set; } 
        public ReactiveCommand<Unit, Unit> AirdropCryptoToUsersCommand { get; }
        public ReactiveCommand<Unit, Unit> StartProcessCommand { get; }
        public ReactiveCommand<Unit, Unit> PreviewProcessCommand { get; }

        public AirdropCryptoToUsersWindowViewModel()
        {
            IsChecked = false;
            IsComboBoxEnabled = true;
            Step1 = true;
            Step2 = false;
            Step3 = false;
            LoopringFeeDropdown = new List<string> { "Send/Loopring Fee", "ETH", "LRC" };
            MaizeFeeDropdown = new List<string> { "Maize Fee", "ETH", "LRC", "PEPE" };
            LoopringFeeSelectedOption = LoopringFeeDropdown[0];
            MaizeFeeSelectedOption = MaizeFeeDropdown[0];
            IsNextButtonVisible = true;
            IsFeeInfoVisible = false;
            Notice5Visible = false;
            IsStartButtonVisible = false;
            IsCheckboxVisible = false;
            IsPreviewButtonVisible = false;
            Log = $"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile} (should automatically open)";
            Notice = "In the below file add your Crypto Amount to Transfer,Wallet Address to Transfer to,Memo. Include commas for separation and you will have one record per line.";
            Notice2 = "👈 Choose";
            Notice3 = "Press Preview to see a summary of your Crypto Airdrop";
            Notice4 = "Press Start to begin your Crypto Airdrop";
            Notice5 = "☝️ insufficient funds";
            Notice6 = "Crypto Airdrop completed! Exit to start a new one.";
            ApplicationUtilitiesUI.OpenFile($"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}");
            AirdropCryptoToUsersCommand = ReactiveCommand.Create(AirdropCryptoToUsers);
            StartProcessCommand = ReactiveCommand.Create(StartProcess);
            PreviewProcessCommand = ReactiveCommand.Create(PreviewProcess);

        }
        private async void ViewPreview()
        {
            Step3 = false;
            IsComboBoxEnabled = false;
            Step1 = false;
            Step2 = true;
            IsNextButtonVisible = false;
            IsPreviewButtonVisible = true;
            IsStartButtonVisible = false;
        }
        private async void ViewStart()
        {
            IsComboBoxEnabled = false;
            Notice5Visible = false;
            Step1 = false;
            Step2 = false;
            Step3 = true;
            IsNextButtonVisible = false;
            IsPreviewButtonVisible = false;
            IsStartButtonVisible = true;
        }
        private async void StartProcess()
        {
            //PreviewProcess();
            var sw = new Stopwatch();
            sw.Start();
            IsEnabled = false;
            CryptoTransferAuditInformation auditInfo = new CryptoTransferAuditInformation();
            auditInfo.validAddress = new List<string>();
            auditInfo.invalidAddress = new List<string>();
            auditInfo.banishAddress = new List<string>();
            auditInfo.alreadyActivatedAddress = new List<string>();
            auditInfo.gasFeeTotal = 0;
            auditInfo.transactionFeeTotal = 0;
            auditInfo.cryptoSentTotal = 0;
            int maxFeeTokenId = ("ETH" == LoopringFeeSelectedOption) ? 0 : 1;
            CounterFactualInfo isCounterFactual = new();
            if (settings.MMorGMEPrivateKey == "")
                isCounterFactual = await LoopringService.GetCounterFactualInfo(settings.LoopringAccountId);
            foreach (var item in transferInfoCryptoList.Where(x => x.Activated == true).ToList())
            {
                Log = $"Transfering {LoopringFeeSelectedOption} to wallet {transferInfoCryptoList.Where(x => x.Activated == true).ToList().IndexOf(item) + 1}/{transferInfoCryptoList.Where(x => x.Activated == true).ToList().Count()} ";
                // token transfer
                var newAuditInfo = await LoopringService.TokenTransfer(
                    LoopringService,
                    settings.Environment,
                    Environment.Url,
                    Environment.Exchange,
                    settings.LoopringApiKey,
                    settings.LoopringPrivateKey,
                    settings.MMorGMEPrivateKey,
                    settings.LoopringAccountId,
                    0,
                    LoopringFeeSelectedOption,
                    maxFeeTokenId,
                    settings.LoopringAddress,
                    Constants.InputFile,
                    Constants.InputFolder,
                    settings.ValidUntil,
                    Constants.LcrTransactionFee,
                    item.Memo,
                    item.Amount,
                    item.ToAddress,
                    false,
               isCounterFactual
                    );
                auditInfo.validAddress.AddRange(newAuditInfo.validAddress);
                auditInfo.invalidAddress.AddRange(newAuditInfo.invalidAddress);
                auditInfo.banishAddress.AddRange(newAuditInfo.banishAddress);

                if (auditInfo.alreadyActivatedAddress != null)
                {
                    auditInfo.alreadyActivatedAddress.AddRange(newAuditInfo.alreadyActivatedAddress);
                }

                auditInfo.gasFeeTotal += newAuditInfo.gasFeeTotal;
                auditInfo.transactionFeeTotal += newAuditInfo.transactionFeeTotal;
                auditInfo.cryptoSentTotal += newAuditInfo.cryptoSentTotal;

            }
            if (IsChecked == true)
            {
                foreach (var item in transferInfoCryptoList.Where(x => x.Activated == false).ToList())
                {
                    Log = $"Transfering {LoopringFeeSelectedOption} with activation to wallet {transferInfoCryptoList.Where(x => x.Activated == false).ToList().IndexOf(item) + 1}/{transferInfoCryptoList.Where(x => x.Activated == false).ToList().Count()} ";
                    // token transfer
                    var newAuditInfo = await LoopringService.TokenTransfer(
                        LoopringService,
                        settings.Environment,
                        Environment.Url,
                        Environment.Exchange,
                        settings.LoopringApiKey,
                        settings.LoopringPrivateKey,
                        settings.MMorGMEPrivateKey,
                        settings.LoopringAccountId,
                        0,
                        LoopringFeeSelectedOption,
                        maxFeeTokenId,
                        settings.LoopringAddress,
                        Constants.InputFile,
                        Constants.InputFolder,
                        settings.ValidUntil,
                        Constants.LcrTransactionFee,
                        item.Memo,
                        item.Amount,
                        item.ToAddress,
                        true,
                        isCounterFactual
                        );
                    auditInfo.validAddress.AddRange(newAuditInfo.validAddress);
                    auditInfo.invalidAddress.AddRange(newAuditInfo.invalidAddress);
                    auditInfo.banishAddress.AddRange(newAuditInfo.banishAddress);

                    if (auditInfo.alreadyActivatedAddress != null)
                    {
                        auditInfo.alreadyActivatedAddress.AddRange(newAuditInfo.alreadyActivatedAddress);
                    }

                    auditInfo.gasFeeTotal += newAuditInfo.gasFeeTotal;
                    auditInfo.transactionFeeTotal += newAuditInfo.transactionFeeTotal;
                    auditInfo.cryptoSentTotal += newAuditInfo.cryptoSentTotal;

                }
            }
            maxFeeTokenId = ("ETH" == LoopringFeeSelectedOption) ? 0 : 1;
            var maizeMaxFeeTokenId = ("ETH" == MaizeFeeSelectedOption) ? 0 : 1;
            if (MaizeFeeSelectedOption == "PEPE")
                maizeMaxFeeTokenId = 272;

            var maizeFee = await CalculateMaizeFee(LoopringService, auditInfo.validAddress.Count(), MaizeFeeSelectedOption);

            var maxFeeVolume = await LoopringService.CobTransferTransactionFee(
               settings.Environment,
               Environment.Url,
               Environment.Exchange,
               settings.LoopringApiKey,
               settings.LoopringPrivateKey,
               settings.MMorGMEPrivateKey,
               settings.LoopringAccountId,
               maizeFee,
               Convert.ToInt32(Math.Round(auditInfo.cryptoSentTotal)),
               LoopringFeeSelectedOption,
               maxFeeTokenId,
               Environment.MyAccountAddress,
               settings.LoopringAddress,
               1,
               maizeMaxFeeTokenId,
               MaizeFeeSelectedOption,
               isCounterFactual
               );
            auditInfo.gasFeeTotal += maxFeeVolume;

            var fileName = ApplicationUtilitiesUI.ShowAirdropAudit(auditInfo.validAddress, auditInfo.invalidAddress, auditInfo.banishAddress, null, auditInfo.alreadyActivatedAddress, "LRC", auditInfo.gasFeeTotal, LoopringFeeSelectedOption, maizeFee, MaizeFeeSelectedOption);
            sw.Stop();
            var swTime = $"This took {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m / 60, 3) : Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m)} {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
            Log = $"{swTime}\r\n\r\nYour audit file is here:\r\n\r\n{fileName}";
            Step3 = false;
            Notice6Visible = true;
        }
        private async void PreviewProcess()
        {
            if (LoopringFeeSelectedOption == LoopringFeeDropdown[0] || MaizeFeeSelectedOption == MaizeFeeDropdown[0])
                return;
            string totalTransactions = $"There will be a total of {transferInfoCryptoList.Count()} transactions with ";
            string totalCrypto = $"{transferInfoCryptoList.Sum(x => x.Amount)} {LoopringFeeSelectedOption} sent to ";
            string totalWallets = $"{transferInfoCryptoList.DistinctBy(x => x.ToAddress).Count()} different wallets.";
            var totalTransfersList =  transferInfoCryptoList.Where(x=>x.Activated == true).ToList();
            var totalActivationsList =  transferInfoCryptoList.Where(x=>x.Activated == false).ToList();
            string totalTransfers = $"Transfers: {totalTransfersList.Count()}";
            string totalActivations = $"Transfers with wallet activation: {totalActivationsList.Count()}";
            var transferFees = (decimal.Parse((await LoopringService.GetNftOffChainFee(settings.LoopringApiKey, settings.LoopringAccountId, 11)).fees.First(x => x.token == LoopringFeeSelectedOption).fee) / 1000000000000000000) * totalTransfersList.Count();
            var activationFees = (decimal.Parse((await LoopringService.GetNftOffChainFee(settings.LoopringApiKey, settings.LoopringAccountId, 19)).fees.First(x => x.token == LoopringFeeSelectedOption).fee) / 1000000000000000000) * totalActivationsList.Count();
            var maizeFee = await CalculateMaizeFee(LoopringService, transferInfoCryptoList.Count(), MaizeFeeSelectedOption); 

            var userAssets = await LoopringService.GetUserAssetsForFees(settings.LoopringApiKey, settings.LoopringAccountId);
            var eth = userAssets.FirstOrDefault(asset => asset.tokenId == 0);
            var lrc = userAssets.FirstOrDefault(asset => asset.tokenId == 1);
            var pepe = userAssets.FirstOrDefault(asset => asset.tokenId == 272);
            decimal userLrc = 0;
            decimal userEth = 0;
            decimal userPepe = 0;
            if (lrc != null)
                userLrc = decimal.Parse(lrc.total) / 1000000000000000000;
            if (eth != null)
                userEth = decimal.Parse(eth.total) / 1000000000000000000;
            if (pepe != null)
                userPepe = decimal.Parse(pepe.total) / 1000000000000000000;

            if (_isChecked == true)
                Log = $"Your Assets:\r\n{userEth} ETH | {userLrc} LRC | {userPepe} PEPE\r\n\r\n{totalTransactions}{totalCrypto}{totalWallets}\r\n\r\n{totalTransfers}\r\n{totalActivations}\r\n\r\nTransfer Fees: {transferFees} {LoopringFeeSelectedOption}\r\nActivation Fees: {activationFees} {LoopringFeeSelectedOption}\r\nMaize Fee: {maizeFee} {MaizeFeeSelectedOption}";
            else
                Log = $"Your Assets:\r\n{userEth} ETH | {userLrc} LRC | {userPepe} PEPE\r\n\r\n{totalTransactions}{totalCrypto}{totalWallets}\r\n\r\n{totalTransfers}\r\nTransfer Fees: {transferFees} {LoopringFeeSelectedOption}\r\nMaize Fee: {maizeFee} {MaizeFeeSelectedOption}";
            switch (MaizeFeeSelectedOption)
            {
                case "ETH":
                    if (LoopringFeeSelectedOption == "ETH")
                    {
                        if (userEth < (transferFees + activationFees + maizeFee))
                        {
                            IsComboBoxEnabled = true;
                            Notice5Visible = true;
                            return;
                        }
                    }
                    else
                    {
                        if ((userEth < maizeFee) || transferFees + activationFees > userLrc)
                        {
                            IsComboBoxEnabled = true;
                            Notice5Visible = true;
                            return;
                        }
                    }
                    break;

                case "LRC":
                    if (LoopringFeeSelectedOption == "LRC")
                    {
                        if (IsChecked == true)
                        {
                            if (userLrc < (transferFees + activationFees + maizeFee))
                            {
                                IsComboBoxEnabled = true;
                                Notice5Visible = true;
                                return;
                            }
                        }
                        else
                        {
                            if (userLrc < (transferFees + maizeFee))
                            {
                                IsComboBoxEnabled = true;
                                Notice5Visible = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (userLrc < maizeFee || transferFees + activationFees > userEth)
                        {
                            IsComboBoxEnabled = true;
                            Notice5Visible = true;
                            return;
                        }
                    }
                    break;

                case "PEPE":
                    if (LoopringFeeSelectedOption == "ETH")
                    {
                        if (userPepe <  maizeFee || transferFees + activationFees > userEth)
                        {
                            IsComboBoxEnabled = true;
                            Notice5Visible = true;
                            return;
                        }
                    }
                    else
                    {
                        if (userPepe < maizeFee || transferFees + activationFees > userLrc)
                        {
                            IsComboBoxEnabled = true;
                            Notice5Visible = true;
                            return;
                        }
                    }
                    break;
            }
            IsEnabledCheckBox = false;
            ViewStart();
        }
        public static async Task<decimal> CurrentTokenPriceInUsd(ILoopringService LoopringService, string maizeFee)
        {
            var varHexAddress = await LoopringService.GetTokens();
            var currentFeePrice = (await LoopringService.GetTokenPrice()).data.Where(x=>x.token == varHexAddress.FirstOrDefault(x=>x.symbol == maizeFee).address).FirstOrDefault().price;
            var convertToOneUsd = 1 / decimal.Parse(currentFeePrice);
            
            return convertToOneUsd;
        }
        public static async Task<decimal> CalculateMaizeFee(ILoopringService LoopringService, decimal totalTransactions, string MaizeFeeSelectedOption)
        {
            return Math.Round((await CurrentTokenPriceInUsd(LoopringService, MaizeFeeSelectedOption)) * (totalTransactions * Constants.LcrTransactionFee), 14);
        }
        private async void AirdropCryptoToUsers()
        {

            if (LoopringFeeSelectedOption == LoopringFeeDropdown[0] || MaizeFeeSelectedOption == MaizeFeeDropdown[0])
            {
                IsCheckboxVisible = false;
                IsFeeInfoVisible = true;
                return;
            }
            IsFeeInfoVisible = false;

            Log = "Checking Input file please give me a moment...";
            IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();
            NftOffChainFeeResponse activationFees = new();
            //IEthereumService ethereumService = new EthereumService();
            INftMetadataService nftMetadataService = new NftMetadataService("https://ipfs.loopring.io/ipfs/");
            StringBuilder buildinvalidLines = new StringBuilder();
            StringBuilder buildAttentionLines = new StringBuilder();
            (transferInfoList, invalidLines, transferInfoCryptoList) = await Files.CheckInputFileVariables(3);
            if (invalidLines.Contains("Error"))
            {
                Log = $"{invalidLines}\r\nPlease fix the above lines in your Input file and then press Next.";
                IsEnabled = true;
                return;
            }
                
            else
                Log = "Input file is formatted correctly!";
            List<List<Datum>> allCrypto = new List<List<Datum>>();
            int offset = 0;
            int total = 0;
            Log = $"Checking data for for issues... ";
            int validCounter = 0;

            validCounter = 0;
            foreach (var item in transferInfoCryptoList.DistinctBy(x=>x.Memo))
            {
                Log = $"Checking Memos: {++validCounter}/{transferInfoCryptoList.DistinctBy(x => x.Memo).Count()}";
                if (item.Memo?.Length > 120)
                {
                    buildinvalidLines.Append($"Error with Memo: Length greater than 120 characters. {item.Memo}\r\n");
                }
            }
            validCounter = 0;
            foreach (var item in transferInfoCryptoList.DistinctBy(x => x.ToAddress))
            {
                Log = $"Checking Wallets: {++validCounter}/{transferInfoCryptoList.DistinctBy(x => x.ToAddress).Count()}";
                var walletAddressCheck = await LoopringService.GetUserAccountInformationFromOwner(await CheckForEthAddress(LoopringService, settings.LoopringApiKey, item.ToAddress));
                if (walletAddressCheck == null || (walletAddressCheck.tags != "FirstUpdateAccountPaid" && walletAddressCheck.nonce == 0))
                {
                    buildAttentionLines.Append($"Attention at line {transferInfoCryptoList.IndexOf(item) + 1}: {item.ToAddress} Loopring account is not active.\r\n");
                    item.Activated = false;
                }
            }
            if (buildinvalidLines.ToString().Contains("Error"))
            {
                Log = $"{buildinvalidLines}\r\nPlease fix the above errors in your Input file and then press Next.";
                IsEnabled = true;
                return;
            }
            else if (buildAttentionLines.ToString().Contains("Attention"))
            {
                Log = $"Your data is valid!\r\n\r\nThere are wallets without an active Loopring account. Check the below box to include them and pay their activation fee.";
                IsCheckboxVisible = true;
            }
            else
                Log = $"Your data is valid!";

            activationFees = await LoopringService.GetNftOffChainFee(settings.LoopringApiKey, settings.LoopringAccountId, 19);
            
            if (buildAttentionLines.ToString().Contains("Attention") && _isChecked == true)                
                Log = $"{buildAttentionLines}\r\nYou will pay for the above {Regex.Matches(buildAttentionLines.ToString(), "\\b" + Regex.Escape("Attention") + "\\b", RegexOptions.IgnoreCase).Count} wallets activation fees. Total costs in LRC or ETH below.\r\n\r\nLRC: {(decimal.Parse(activationFees.fees.First(x => x.token == "LRC").fee)/1000000000000000000) * Regex.Matches(buildAttentionLines.ToString(), "\\b" + Regex.Escape("Attention") + "\\b", RegexOptions.IgnoreCase).Count}\r\nETH: {(decimal.Parse(activationFees.fees.First(x => x.token == "ETH").fee) / 1000000000000000000) * Regex.Matches(buildAttentionLines.ToString(), "\\b" + Regex.Escape("Attention") + "\\b", RegexOptions.IgnoreCase).Count}";
            ViewPreview();

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
