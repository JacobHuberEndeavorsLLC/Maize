using ReactiveUI;
using System.Reactive;
using Maize.Models.ApplicationSpecific;
using Maize.Services;
using Maize;
using MaizeUI.Things;
using LoopMintSharp;
using Maize.Helpers;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MaizeUI.Helpers;
using Maize.Models;
using Maize.Models.Responses;

namespace MaizeUI.ViewModels
{
    public class MintAndPinToIPFSWindowViewModel : ViewModelBase
    {
        public List<string> LoopringFeeDropdown { get; }
        public List<string> MaizeFeeDropdown { get; }
        public string LoopringFeeSelectedOption { get; set; }
        public string MaizeFeeSelectedOption { get; set; }
        public string RoyaltyWalletAddresses { get; set; }

        private bool _isTextAndSkipVisible = true;
        public bool IsTextAndSkipVisible
        {
            get => _isTextAndSkipVisible;
            set => this.RaiseAndSetIfChanged(ref _isTextAndSkipVisible, value);
        }        
        private bool lockForMinting = false;
        public bool LockForMinting
        {
            get => lockForMinting;
            set => this.RaiseAndSetIfChanged(ref lockForMinting, value);
        }

        private bool step1;
        private bool step2 = false;
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
        public void Initialize()
        {
            if (environment != null && settings != null)
            {
                minter = new Minter(environment.Url, settings.Environment);
            }
            else
            {
                // Handle error: Environment and Settings should be set before calling Initialize.
            }
        }
        public event Action RequestOpenFolder;
        public string processButtonText = "Preview";
        public string ProcessButtonText
        {
            get => processButtonText;
            set => this.RaiseAndSetIfChanged(ref processButtonText, value);
        }
        public string skipButtonText = "Metadata ready? 👉";
        public string SkipButtonText
        {
            get => skipButtonText;
            set => this.RaiseAndSetIfChanged(ref skipButtonText, value);
        }
        private string stepDescription;
        public string StepDescription
        {
            get => stepDescription;
            set => this.RaiseAndSetIfChanged(ref stepDescription, value);
        }
        private string mainContent;
        public string MainContent
        {
            get => mainContent;
            set => this.RaiseAndSetIfChanged(ref mainContent, value);
        }
        public string inputDirectory;
        public string InputDirectory
        {
            get => inputDirectory;
            set => this.RaiseAndSetIfChanged(ref inputDirectory, value);
        }
        public string nftFolderCid;
        public string NftFolderCid
        {
            get => nftFolderCid;
            set => this.RaiseAndSetIfChanged(ref nftFolderCid, value);
        }
        public int nftAmount;
        public int NftAmount
        {
            get => nftAmount;
            set => this.RaiseAndSetIfChanged(ref nftAmount, value);
        }
        public string metadataFolderCid;

        public string MetadataFolderCid
        {
            get => metadataFolderCid;
            set => this.RaiseAndSetIfChanged(ref metadataFolderCid, value);
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

        public ReactiveCommand<Unit, Unit> OpenFolderCommand { get; }
        public ReactiveCommand<string, Unit> MintAndPinCommand { get; }

        public int maxFeeTokenId;
        private Minter minter;


        public MintAndPinToIPFSWindowViewModel()
        {
            NftAmount = 1;
            step1 = true;
            StepDescription = "1: Upload your NFTs folder to IPFS and place the folder's CID below.";
            MainContent = "Here you will Pin your files to IPFS and Mint them on Loopring.";
            LoopringFeeDropdown = new List<string> { "Loopring Fee", "ETH", "LRC" };
            MaizeFeeDropdown = new List<string> { "Maize Fee", "ETH", "LRC", "PEPE" };
            LoopringFeeSelectedOption = LoopringFeeDropdown[0];
            MaizeFeeSelectedOption = MaizeFeeDropdown[0];
            OpenFolderCommand = ReactiveCommand.CreateFromTask(() => OpenFolder());
            MintAndPinCommand = ReactiveCommand.CreateFromTask<string>(parameter => MintAndPinToIPFS(minter, parameter));
        }
        public async Task MintAndPinToIPFS(Minter minter, string action)
        {
            if (action == "Skip")
            {
                if (LoopringFeeSelectedOption == LoopringFeeDropdown[0] || MaizeFeeSelectedOption == MaizeFeeDropdown[0])
                {
                    SkipButtonText = "Select Fees ☝️";
                    return;
                }
                SetMetadataUploadStep("Fees");
                return;
            }
            else if (step1 == true)
            {
                var isNulls = CheckForNullsStepOne(nftFolderCid, inputDirectory, LoopringFeeSelectedOption, LoopringFeeDropdown, MaizeFeeSelectedOption, MaizeFeeDropdown);
                if (isNulls)
                    return;
                string[] allSubDirectories = Directory.GetDirectories(inputDirectory);

                string metadataPath = allSubDirectories.FirstOrDefault(dir => dir.StartsWith(Path.Combine(inputDirectory, "Metadatas")));
                string nftPath = allSubDirectories.FirstOrDefault(dir => dir.StartsWith(Path.Combine(inputDirectory, "NFTs")));

                if (string.IsNullOrEmpty(metadataPath) || string.IsNullOrEmpty(nftPath))
                {
                    Log = "The selected folder must contain subfolders starting with 'Metadatas' and 'NFTs'.";
                    return;
                }

                var lineCount = Directory.GetFiles(metadataPath).Length;
                maxFeeTokenId = ("ETH" == LoopringFeeSelectedOption) ? 0 : 1;
                var offChainFee = await minter.GetMintFee(settings.LoopringApiKey, settings.LoopringAccountId, settings.LoopringAddress, Environment.NftFactoryCollection, null);
                var fee = offChainFee.fees[maxFeeTokenId].fee;
                decimal feeAmount = lineCount * decimal.Parse(fee);

                var maizeFee = await Calculations.CalculateMaizeFee(LoopringService, lineCount, MaizeFeeSelectedOption);
                var canAfford = await Calculations.CanUserAfford(loopringService, settings, MaizeFeeSelectedOption, LoopringFeeSelectedOption, maizeFee, feeAmount / 1000000000000000000m);

                if (!canAfford.Item1)
                {
                    Log = ($"⚠️ Insufficient Funds ⚠️\r\n💰 Your Assets: {canAfford.userEth} ETH | {canAfford.userLrc} LRC | {canAfford.userPepe} PEPE\r\n\r\n🚨🚨 It will cost around " +
                            $"{feeAmount / 1000000000000000000m} {LoopringFeeSelectedOption} to mint {lineCount} NFTs with a Maize Fee of {maizeFee} {MaizeFeeSelectedOption}");
                    return;
                }

                await ProcessMetadataFilesAsync(metadataPath, nftFolderCid);

                Log = ($"📁 Metadata Files updated 📁\r\nReview them at {metadataPath}.\r\n\r\n💰 Your Assets:\r\n{canAfford.userEth} ETH | {canAfford.userLrc} LRC | {canAfford.userPepe} PEPE\r\n\r\n🚨🚨 It will cost around " +
                        $"{feeAmount / 1000000000000000000m} {LoopringFeeSelectedOption} to mint {lineCount} NFTs with a Maize Fee of {maizeFee} {MaizeFeeSelectedOption}");
                return;
            }

            if (string.IsNullOrEmpty(MetadataFolderCid))
            {
                Log = "Please add your Metadatas Folder CID.";
                return;
            }
            var metadataInformation = await IpfsHttpHelper.GetFolderDetails(metadataFolderCid);
            if (ProcessButtonText == "Fees")
            {
                var offChainFee = await minter.GetMintFee(settings.LoopringApiKey, settings.LoopringAccountId, settings.LoopringAddress, Environment.NftFactoryCollection, null);
                var fee = offChainFee.fees[maxFeeTokenId].fee;
                decimal feeAmount = metadataInformation.cids.Count * decimal.Parse(fee);
                var maizeFee = await Calculations.CalculateMaizeFee(LoopringService, metadataInformation.cids.Count, MaizeFeeSelectedOption);
                var canAfford = await Calculations.CanUserAfford(loopringService, settings, MaizeFeeSelectedOption, LoopringFeeSelectedOption, maizeFee, feeAmount / 1000000000000000000m);

                if (!canAfford.Item1)
                {
                    Log = ($"⚠️ Insufficient Funds ⚠️\r\n💰 Your Assets: {canAfford.userEth} ETH | {canAfford.userLrc} LRC | {canAfford.userPepe} PEPE\r\n\r\n🚨🚨 It will cost around " +
                            $"{feeAmount / 1000000000000000000m} {LoopringFeeSelectedOption} to mint {metadataInformation.cids.Count} NFTs with a Maize Fee of {maizeFee} {MaizeFeeSelectedOption}");
                    return;
                }
                Log = ($"💰 Your Assets:\r\n{canAfford.userEth} ETH | {canAfford.userLrc} LRC | {canAfford.userPepe} PEPE\r\n\r\n🚨🚨 It will cost around " +
                            $"{feeAmount / 1000000000000000000m} {LoopringFeeSelectedOption} to mint {metadataInformation.cids.Count} NFTs with a Maize Fee of {maizeFee} {MaizeFeeSelectedOption}");
                ProcessButtonText = "Mint";
                LockForMinting = true;
                return;
            }
            await MintCids(metadataInformation.cids, metadataInformation.royaltyPercentage, metadataInformation.collectionAddress);
        }
        private static bool CheckForNullsStepOne(string nftFolderCid, string inputDirectory, string LoopringFeeSelectedOption, List<string> LoopringFeeDropdown, string MaizeFeeSelectedOption, List<string> MaizeFeeDropdown)
        {
            if (string.IsNullOrEmpty(nftFolderCid))
                return true;
            if (string.IsNullOrEmpty(inputDirectory))
                return true;
            if (LoopringFeeSelectedOption == LoopringFeeDropdown[0] || MaizeFeeSelectedOption == MaizeFeeDropdown[0])
                return true;
            return false;
        }
        private async Task ProcessMetadataFilesAsync(string metadataPath, string nftFolderCid)
        {
            MetadataModifier.UpdateMetadataFiles(metadataPath, nftFolderCid);
            SetMetadataUploadStep("Mint");
        }
        private void SetMetadataUploadStep(string processButton)
        {
            StepDescription = "2: Upload your Metadatas folder to IPFS and provide the folder's CID.";
            ProcessButtonText = processButton;
            Step1 = false;
            Step2 = true;
            IsTextAndSkipVisible = false;
        }
        private async Task MintCids(List<string> cids, int royaltyPercentage, string collectionContractAddress)
        {
            List<string> royaltyAddressesForCids = new List<string>(); // This list will store the royaltyAddress for each cid.

            List<string> inputAddresses = string.IsNullOrEmpty(RoyaltyWalletAddresses) ? new List<string>() : RoyaltyWalletAddresses.Split(',').Select(a => a.Trim()).ToList();

            var sw = Stopwatch.StartNew();
            var validUntil = ApplicationUtilitiesUI.GetUnixTimestamp() + (int)TimeSpan.FromDays(365).TotalSeconds;
            var maxFeeTokenId = 1;

            NftTransferAuditInformation auditInfo = new NftTransferAuditInformation();
            auditInfo.validAddress = new List<string>();
            auditInfo.invalidAddress = new List<string>();
            auditInfo.banishAddress = new List<string>();
            auditInfo.invalidNftData = new List<string>();
            auditInfo.alreadyActivatedAddress = new List<string>();
            auditInfo.gasFeeTotal = 0;
            auditInfo.transactionFeeTotal = 0;
            auditInfo.nftSentTotal = 0;
            CounterFactualInfo isCounterFactual = new();
            if (settings.MMorGMEPrivateKey == "")
                isCounterFactual = await LoopringService.GetCounterFactualInfo(settings.LoopringAccountId);

            if (inputAddresses.Count == 0)
            {
                royaltyAddressesForCids = Enumerable.Repeat(settings.LoopringAddress, cids.Count).ToList();
            }
            else if (inputAddresses.Count == 1)
            {
                royaltyAddressesForCids = Enumerable.Repeat(inputAddresses[0], cids.Count).ToList();
            }
            else
            {
                int numAddresses = inputAddresses.Count;
                int numCids = cids.Count;
                int baseCidsPerAddress = numCids / numAddresses;
                int remainder = numCids % numAddresses;

                for (int i = 0; i < numAddresses; i++)
                {
                    int cidsForCurrentAddress = baseCidsPerAddress + (i < remainder ? 1 : 0);
                    royaltyAddressesForCids.AddRange(Enumerable.Repeat(inputAddresses[i], cidsForCurrentAddress));
                }

                Random rng = new Random();
                int n = royaltyAddressesForCids.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    var value = royaltyAddressesForCids[k];
                    royaltyAddressesForCids[k] = royaltyAddressesForCids[n];
                    royaltyAddressesForCids[n] = value;
                }
            }

            var lineCount = cids.Count();
            var count = 0;

            var collectionResult = await minter.FindNftCollection(settings.LoopringApiKey, 12, 0, settings.LoopringAddress, collectionContractAddress);
            if (collectionResult == null)
            {
                Log = ($"Could not find collection with contract address {collectionContractAddress}");
                return;
            }
            var offChainFee = await minter.GetMintFee(settings.LoopringApiKey, settings.LoopringAccountId, settings.LoopringAddress, Environment.NftFactoryCollection, collectionResult.collections[0].collection.baseUri);
            var fee = offChainFee.fees[maxFeeTokenId].fee;

            Log = ($"Minting started on {collectionContractAddress}...");

            List<(string cid, string royaltyAddress)> cidAddressPairs = new List<(string, string)>();
            foreach (var (cid, royaltyAddress) in cids.Zip(royaltyAddressesForCids, (cid, royaltyAddress) => (cid, royaltyAddress)))
            {
                string currentCid = cid.Trim();
                cidAddressPairs.Add((currentCid, royaltyAddress));
                count++;
                Log = ($"Attempting mint {count} out of {lineCount} NFTs");
                var mintResponse = await minter.MintCollection(settings.LoopringApiKey, settings.LoopringPrivateKey, settings.LoopringAddress, settings.LoopringAccountId, 0, royaltyPercentage, nftAmount, validUntil, maxFeeTokenId, Environment.NftFactoryCollection, Environment.Exchange, currentCid, collectionResult.collections[0].collection.baseUri, collectionContractAddress, royaltyAddress);

                if (!string.IsNullOrEmpty(mintResponse.Item1.errorMessage))
                {
                    auditInfo.invalidAddress.Add(mintResponse.Item1.metadataCid);
                }
                else
                {
                    auditInfo.gasFeeTotal += mintResponse.Item2;
                    auditInfo.validAddress.Add(mintResponse.Item1.metadataCid);
                }
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
               auditInfo.validAddress.Count,
               LoopringFeeSelectedOption,
               maxFeeTokenId,
               Environment.MyAccountAddress,
               settings.LoopringAddress,
               2,
               maizeMaxFeeTokenId,
               MaizeFeeSelectedOption,
               isCounterFactual
               );
            auditInfo.gasFeeTotal += maxFeeVolume;

            var fileName = ApplicationUtilitiesUI.ShowAirdropAudit(auditInfo.validAddress, auditInfo.invalidAddress, auditInfo.banishAddress, auditInfo.invalidNftData, auditInfo.alreadyActivatedAddress, "MINT", auditInfo.gasFeeTotal, LoopringFeeSelectedOption, maizeFee, MaizeFeeSelectedOption);
            sw.Stop();
            var swTime = $"This took {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m / 60, 3) : Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m)} {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
            string csvFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}Output\\cid_address_pairs.csv";
            using (StreamWriter sw2 = new StreamWriter(csvFilePath))
            {
                // Write header
                sw2.WriteLine("CID,Address");

                // Write each pair
                foreach (var (cid, royaltyAddress) in cidAddressPairs)
                {
                    sw2.WriteLine($"{cid},{royaltyAddress}");
                }
            }
            ApplicationUtilitiesUI.OpenFile(csvFilePath);
            Log = $"{swTime}\r\n\r\nYour audit file is here:\r\n\r\n{fileName}";
        }
        public async Task OpenFolder()
        {
            RequestOpenFolder?.Invoke();
        }
        public void ViewResults(string folderPath)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = folderPath,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", folderPath);
            }
        }
    }
}