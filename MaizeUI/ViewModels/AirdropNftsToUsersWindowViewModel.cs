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
using Maize.Helpers;
using MaizeUI.Helpers;

namespace MaizeUI.ViewModels
{
    public class AirdropNftsToUsersWindowViewModel : ViewModelBase 
    {
        List<TransferInformation> transferInfoList = new();
        List<TransferInformationCrypto> transferInfoCryptoList = new();

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
        public ReactiveCommand<Unit, Unit> AirdropNftsToUsersCommand { get; }
        public ReactiveCommand<Unit, Unit> StartProcessCommand { get; }
        public ReactiveCommand<Unit, Unit> PreviewProcessCommand { get; }

        public AirdropNftsToUsersWindowViewModel()
        {
            IsChecked = false;
            IsComboBoxEnabled = true;
            Step1 = true;
            Step2 = false;
            Step3 = false;
            LoopringFeeDropdown = new List<string> { "Loopring Fee", "ETH", "LRC" };
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
            Notice = "In the below file add your NFT Data,NFT Amount to Transfer,Wallet Address to Transfer to,Memo. Include commas for separation and you will have one record per line.";
            Notice2 = "👈 Choose";
            Notice3 = "Press Preview to see a summary of your NFT Airdrop";
            Notice4 = "Press Start to begin your NFT Airdrop";
            Notice5 = "☝️ insufficient funds";
            Notice6 = "NFT Airdrop completed! Exit to start a new one.";
            ApplicationUtilitiesUI.OpenFile($"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}");
            AirdropNftsToUsersCommand = ReactiveCommand.Create(AirdropNftsToUsers);
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
            NftTransferAuditInformation auditInfo = new NftTransferAuditInformation();
            auditInfo.validAddress = new List<string>();
            auditInfo.invalidAddress = new List<string>();
            auditInfo.banishAddress = new List<string>();
            auditInfo.invalidNftData = new List<string>();
            auditInfo.alreadyActivatedAddress = new List<string>();
            auditInfo.gasFeeTotal = 0;
            auditInfo.transactionFeeTotal = 0;
            auditInfo.nftSentTotal = 0;
            int maxFeeTokenId = ("ETH" == LoopringFeeSelectedOption) ? 0 : 1;
            CounterFactualInfo isCounterFactual = new();
            if (settings.MMorGMEPrivateKey == "")
                isCounterFactual = await LoopringService.GetCounterFactualInfo(settings.LoopringAccountId);
            List<TransferInformation> tempTransferInfoList = transferInfoList;
            if (IsChecked == true)
            {
                foreach (var item in transferInfoList.Where(x => x.Activated == false).DistinctBy(x=>x.ToAddress).ToList())
                {
                    Log = $"Transfering NFT with activation {transferInfoList.Where(x => x.Activated == false).ToList().IndexOf(item) + 1}/{transferInfoList.Where(x => x.Activated == false).DistinctBy(x => x.ToAddress).Count()} ";
                    // nft transfer
                    var newAuditInfo = await LoopringService.NftTransfer(
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
                        transferInfoList.DistinctBy(x => x.ToAddress).Count(),
                        0,
                        item.Amount.ToString(),
                        settings.ValidUntil,
                        Constants.LcrTransactionFee,
                        item.Memo,
                        item.NftData,
                        item.ToAddress,
                        true,
                        isCounterFactual
                        );
                    auditInfo.validAddress.AddRange(newAuditInfo.validAddress);
                    auditInfo.invalidAddress.AddRange(newAuditInfo.invalidAddress);
                    auditInfo.banishAddress.AddRange(newAuditInfo.banishAddress);

                    if (auditInfo.invalidNftData != null)
                    {
                        auditInfo.invalidNftData.AddRange(newAuditInfo.invalidNftData);
                    }

                    if (auditInfo.alreadyActivatedAddress != null)
                    {
                        auditInfo.alreadyActivatedAddress.AddRange(newAuditInfo.alreadyActivatedAddress);
                    }

                    auditInfo.gasFeeTotal += newAuditInfo.gasFeeTotal;
                    auditInfo.transactionFeeTotal += newAuditInfo.transactionFeeTotal;
                    auditInfo.nftSentTotal += newAuditInfo.nftSentTotal;

                    tempTransferInfoList.Remove(item);
                    foreach (var duplicateItem in transferInfoList.Where(x => x.ToAddress == item.ToAddress))
                    {
                        duplicateItem.Activated = true;
                    }
                }
            }

            foreach (var item in tempTransferInfoList.Where(x => x.Activated == true).ToList())
            {
                Log = $"Transfering NFT {tempTransferInfoList.Where(x => x.Activated == true).ToList().IndexOf(item) + 1}/{tempTransferInfoList.Where(x => x.Activated == true).ToList().Count()} ";
                // nft transfer
                var newAuditInfo = await LoopringService.NftTransfer(
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
                    transferInfoList.DistinctBy(x => x.ToAddress).Count(),
                    0,
                    item.Amount.ToString(),
                    settings.ValidUntil,
                    Constants.LcrTransactionFee,
                    item.Memo,
                    item.NftData,
                    item.ToAddress,
                    false,
                    isCounterFactual
                    );
                auditInfo.validAddress.AddRange(newAuditInfo.validAddress);
                auditInfo.invalidAddress.AddRange(newAuditInfo.invalidAddress);
                auditInfo.banishAddress.AddRange(newAuditInfo.banishAddress);

                if (auditInfo.invalidNftData != null)
                {
                    auditInfo.invalidNftData.AddRange(newAuditInfo.invalidNftData);
                }

                if (auditInfo.alreadyActivatedAddress != null)
                {
                    auditInfo.alreadyActivatedAddress.AddRange(newAuditInfo.alreadyActivatedAddress);
                }

                auditInfo.gasFeeTotal += newAuditInfo.gasFeeTotal;
                auditInfo.transactionFeeTotal += newAuditInfo.transactionFeeTotal;
                auditInfo.nftSentTotal += newAuditInfo.nftSentTotal;

            }

            maxFeeTokenId = ("ETH" == LoopringFeeSelectedOption) ? 0 : 1;
            var maizeMaxFeeTokenId = ("ETH" == MaizeFeeSelectedOption) ? 0 : 1;
            if (MaizeFeeSelectedOption == "PEPE")
                maizeMaxFeeTokenId = 272;

            var maizeFee = await Calculations.CalculateMaizeFee(LoopringService, auditInfo.validAddress.Count(), MaizeFeeSelectedOption);

            var maxFeeVolume = await loopringService.CobTransferTransactionFee(
               settings.Environment,
               Environment.Url,
               Environment.Exchange,
               settings.LoopringApiKey,
               settings.LoopringPrivateKey,
               settings.MMorGMEPrivateKey,
               settings.LoopringAccountId,
               maizeFee,
               auditInfo.nftSentTotal,
               LoopringFeeSelectedOption,
               maxFeeTokenId,
               Environment.MyAccountAddress,
               settings.LoopringAddress,
               0,
               maizeMaxFeeTokenId,
               MaizeFeeSelectedOption,
               isCounterFactual
               );
            auditInfo.gasFeeTotal += maxFeeVolume;

            //var walletsNftsBasicInformation = allNfts.SelectMany(d => d).Select(m => new { m.metadata.nftBase.name, m.nftData, m.nftId, m.minter, m.tokenAddress }).ToList();
            //var fileName = ApplicationUtilitiesUI.WriteDataToCsvFile("NFTAirdrop", walletsNftsBasicInformation);
            var fileName = ApplicationUtilitiesUI.ShowAirdropAudit(auditInfo.validAddress, auditInfo.invalidAddress, auditInfo.banishAddress, auditInfo.invalidNftData, auditInfo.alreadyActivatedAddress, null, auditInfo.gasFeeTotal, LoopringFeeSelectedOption, maizeFee, MaizeFeeSelectedOption);
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
            string totalTransactions = $"There will be a total of {transferInfoList.Count()} transactions with ";
            string totalNfts = $"{transferInfoList.Sum(x => x.Amount)} NFTs sent to ";
            string totalWallets = $"{transferInfoList.DistinctBy(x => x.ToAddress).Count()} different wallets.";
            var totalActivationsList =  transferInfoList.Where(x=>x.Activated == false).DistinctBy(x=>x.ToAddress).ToList();
            var totalTransfersList =  transferInfoList.Where(x=>x.Activated == true).ToList();
            string totalActivations = $"Transfers with wallet activation: {totalActivationsList.Count()}";
            int actualTransfers;
            int forMaizeTranscationCount;
            if (_isChecked == true)
            {
                actualTransfers = transferInfoList.Count - totalActivationsList.Count;
                forMaizeTranscationCount = transferInfoList.Count;
            }
            else
            {
                actualTransfers = totalTransfersList.Count;
                forMaizeTranscationCount = actualTransfers;
            }
            string totalTransfers = $"Transfers: {actualTransfers}";
            var transferFees = (decimal.Parse((await LoopringService.GetNftOffChainFee(settings.LoopringApiKey, settings.LoopringAccountId, 11)).fees.First(x => x.token == LoopringFeeSelectedOption).fee) / 1000000000000000000) * actualTransfers;
            var activationFees = (decimal.Parse((await LoopringService.GetNftOffChainFee(settings.LoopringApiKey, settings.LoopringAccountId, 19)).fees.First(x => x.token == LoopringFeeSelectedOption).fee) / 1000000000000000000) * totalActivationsList.Count();

            var maizeFee = await Calculations.CalculateMaizeFee(LoopringService, forMaizeTranscationCount, MaizeFeeSelectedOption); 
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
                Log = $"Your Assets:\r\n{userEth} ETH | {userLrc} LRC | {userPepe} PEPE\r\n\r\n{totalTransactions}{totalNfts}{totalWallets}\r\n\r\n{totalTransfers}\r\n{totalActivations}\r\n\r\nTransfer Fees: {transferFees} {LoopringFeeSelectedOption}\r\nActivation Fees: {activationFees} {LoopringFeeSelectedOption}\r\nMaize Fee: {maizeFee} {MaizeFeeSelectedOption}";
            else
                Log = $"Your Assets:\r\n{userEth} ETH | {userLrc} LRC | {userPepe} PEPE\r\n\r\nThere will be a total of {transferInfoList.Where(x => x.Activated == true).Count()} transactions with {transferInfoList.Where(x => x.Activated == true).Sum(x => x.Amount)} NFTs sent to {transferInfoList.Where(x => x.Activated == true).DistinctBy(x => x.ToAddress).Count()} different wallets.\r\n\r\n{totalTransfers}\r\nTransfer Fees: {transferFees} {LoopringFeeSelectedOption}\r\nMaize Fee: {maizeFee} {MaizeFeeSelectedOption}";
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
        private async void AirdropNftsToUsers()
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
            IEthereumService ethereumService = new EthereumService();
            INftMetadataService nftMetadataService = new NftMetadataService("https://ipfs.loopring.io/ipfs/");
            StringBuilder buildinvalidLines = new StringBuilder();
            StringBuilder buildAttentionLines = new StringBuilder();
            (transferInfoList, invalidLines, transferInfoCryptoList) = await Files.CheckInputFileVariables(4);
            if (invalidLines.Contains("Error"))
            {
                Log = $"{invalidLines}\r\nPlease fix the above lines in your Input file and then press Next.";
                IsEnabled = true;
                return;
            }
                
            else
                Log = "Input file is formatted correctly!";
            List<List<Datum>> allNfts = new List<List<Datum>>();
            int offset = 0;
            int total = 0;
            while (true)
            {
                var nfts = await LoopringService.GetWalletsNftsOffset(settings.LoopringApiKey, settings.LoopringAccountId, offset);
                if (nfts.Item1.Count > 0)
                {
                    total = nfts.Item2;
                    Log = $"Gathering your NFTs: {allNfts.SelectMany(d => d).Count()}/{total} NFTs retrieved...";
                    allNfts.Add(nfts.Item1);
                    offset += 50;
                }
                else
                {
                    break;
                }
            }
            Log = $"Checking data for for issues... ";
            int validCounter = 0;
            foreach (var item in transferInfoList.DistinctBy(x => x.Memo))
            {
                Log = $"Checking Memos: {++validCounter}/{transferInfoList.DistinctBy(x => x.Memo).Count()}";
                if (item.Memo?.Length > 120)
                {
                    buildinvalidLines.Append($"Error with Memo: Length greater than 120 characters. {item.Memo}\r\n");
                }
            }
            validCounter = 0;
            foreach (var item in transferInfoList.DistinctBy(x => x.NftData))
            {
                Log = $"Checking NFTs: {++validCounter}/{transferInfoList.DistinctBy(x => x.NftData).Count()}";
                var nftDataCheck = await LoopringService.GetNftInformationFromNftData(Settings.LoopringApiKey, item.NftData);
                if (nftDataCheck.Count == 0)
                {
                    buildinvalidLines.Append($"Error with NFT Data: Invalid NFT Data.{item.NftData}\r\n");
                }
                if (allNfts.SelectMany(d => d).Where(x => x.nftData == item.NftData).Count() > 0)
                {
                    if (int.Parse(allNfts.SelectMany(d => d).Where(x => x.nftData == item.NftData).First().total) == 0)
                    {
                        buildinvalidLines.Append($"Error at line {transferInfoList.IndexOf(item) + 1}: You do not own this NFT.\r\n");
                    }
                    else
                    {
                        if (int.Parse(allNfts.SelectMany(d => d).Where(x => x.nftData == item.NftData).First().total) < transferInfoList.Where(x => x.NftData == item.NftData).Sum(x => x.Amount))
                            buildinvalidLines.Append($"Error at line {transferInfoList.IndexOf(item) + 1}: You own {allNfts.SelectMany(d => d).Where(x => x.nftData == item.NftData).First().total} and are trying to transfer {transferInfoList.Where(x => x.NftData == item.NftData).Sum(x => x.Amount)}.\r\n");
                    }
                }
                else if (allNfts.SelectMany(d => d).Where(x => x.nftData == item.NftData).Count() == 0)
                    buildinvalidLines.Append($"Error at line {transferInfoList.IndexOf(item) + 1}: You do not own this NFT.\r\n");
            }

            validCounter = 0;
            foreach (var item in transferInfoList.DistinctBy(x => x.ToAddress))
            {
                Log = $"Checking Wallets: {++validCounter}/{transferInfoList.DistinctBy(x => x.ToAddress).Count()}";
                var walletAddressCheck = await LoopringService.GetUserAccountInformationFromOwner(await LoopringService.CheckForEthAddress(LoopringService, settings.LoopringApiKey, item.ToAddress));

                if (walletAddressCheck == null || (walletAddressCheck.tags != "FirstUpdateAccountPaid" && walletAddressCheck.nonce == 0))
                {
                    buildAttentionLines.Append($"Attention at line {transferInfoList.IndexOf(item) + 1}: {item.ToAddress} Loopring account is not active.\r\n");
                    item.Activated = false;

                    foreach (var duplicateItem in transferInfoList.Where(x => x.ToAddress == item.ToAddress))
                    {
                        duplicateItem.Activated = false;
                    }
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
                Log = $"Your data is valid!\r\n\r\nThere are wallets without an active Loopring account. Check the below box to include them and pay their activation fee. If unchecked they will not be sent the NFT.";
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
    }
}
