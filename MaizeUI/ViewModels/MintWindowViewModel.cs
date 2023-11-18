using ReactiveUI;
using System.Reactive;
using Maize.Models.ApplicationSpecific;
using Maize.Services;
using Maize;
using LoopMintSharp;
using Maize.Helpers;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MaizeUI.Helpers;
using Maize.Models;
using Maize.Models.Responses;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.IO.Compression;

namespace MaizeUI.ViewModels
{
    public class MintWindowViewModel : ViewModelBase
    {
        public List<string> Items { get; set; }
        public string selectedItem;

        public string SelectedItem
        {
            get => selectedItem;
            set => this.RaiseAndSetIfChanged(ref selectedItem, value);
        }
        private string _selectedCollection;
        public string SelectedCollection
        {
            get => _selectedCollection;
            set
            {
                if (SetSelectedCollection(value))
                {
                    this.RaiseAndSetIfChanged(ref _selectedCollection, value);
                    SelectedCollectionAddress = _collectionNameAddressMap[value];
                }
            }
        }
        public string SelectedCollectionAddress { get; private set; }
        public List<string> LoopringFeeDropdown { get; }
        public List<string> MaizeFeeDropdown { get; }
        public string LoopringFeeSelectedOption { get; set; }
        public string MaizeFeeSelectedOption { get; set; }
        public string RoyaltyWalletAddresses { get; set; }
        public string looperLandsProjectName;
        public string LooperLandsProjectName
        {
            get => looperLandsProjectName;
            set => this.RaiseAndSetIfChanged(ref looperLandsProjectName, value);
        }
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
        private bool step2;
        private bool stepLL;
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
        public bool StepLL
        {
            get => stepLL;
            set => this.RaiseAndSetIfChanged(ref stepLL, value);
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
        // Asynchronous factory method
        public static async Task<MintWindowViewModel> CreateAsync(Settings settings, LoopringServiceUI loopringService)
        {
            var model = new MintWindowViewModel(settings, loopringService);
            await model.InitializeAsync();
            return model;
        }

        // Asynchronous initialization method
        private async Task InitializeAsync()
        {
            if (environment != null && settings != null)
            {
                minter = new Minter(environment.Url, settings.Environment);
            }
            else
            {
                // Handle error: Environment and Settings should be set before calling Initialize.
            }

            await UpdateCollectionNames();
        }
        public event Action RequestOpenFolder;
        public string processButtonText = "Check";
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

        public MintWindowViewModel(Settings settings, LoopringServiceUI loopringService)
        {
            Items = new List<string> { "👇 choose", "🦸‍ Looper", "🗡 Weapon", "🎣 Fishing Rod" };
            SelectedItem = Items[0];
            this.settings = settings;
            this.loopringService = loopringService;
            this.environment = Constants.GetNetworkConfig(settings.Environment);
            InitializeAsync();
            LoadCollectionNames();
            NftAmount = 1;
            step1 = true;
            step2 = false;
            stepLL = false;
            StepDescription = "1: Select Collection, Fees, and browse to your folders file path.";
            MainContent = "Here you will Mint your NFTs on Loopring.";
            LoopringFeeDropdown = new List<string> { "Loopring Fee", "ETH", "LRC" };
            MaizeFeeDropdown = new List<string> { "Maize Fee", "ETH", "LRC", "PEPE" };
            LoopringFeeSelectedOption = LoopringFeeDropdown[0];
            MaizeFeeSelectedOption = MaizeFeeDropdown[0];
            OpenFolderCommand = ReactiveCommand.CreateFromTask(() => OpenFolder());
            MintAndPinCommand = ReactiveCommand.CreateFromTask<string>(parameter => Mint(minter));
        }
        private async void LoadCollectionNames()
        {
            await FetchCollectionNamesFromApi();
            CollectionNames = new ObservableCollection<string>(_collectionNameAddressMap.Keys.ToList());
        }
        private Dictionary<string, string> _collectionNameAddressMap = new Dictionary<string, string>();



        private async Task FetchCollectionNamesFromApi()
        {
            List<CollectionMinted> userCollections = await loopringService.GetUserMintedCollections(settings.LoopringApiKey, settings.LoopringAddress);

            if (userCollections != null)
            {
                foreach (var collectionMinted in userCollections)
                {
                    if (collectionMinted?.collection != null)
                    {
                        _collectionNameAddressMap[collectionMinted.collection.name] = collectionMinted.collection.collectionAddress;
                    }
                }
            }
            CollectionNames = new ObservableCollection<string>(_collectionNameAddressMap.Keys.ToList());
        }
        private string GetSubDirectory(string[] directories, string startsWith)
        {
            return directories.FirstOrDefault(dir => Path.GetFileName(dir).StartsWith(startsWith));
        }
        private void StepTwo(string buttonTitle)
        {
            StepDescription = "2: Select the number of NFTs to create per mint and specify royalties if needed.";
            ProcessButtonText = buttonTitle;
            Step1 = false;
            Step2 = true;
            StepLL = false;
        }
        private void StepLooperLands(string buttonTitle)
        {
            StepDescription = "1a: Enter in Looper Lands information.";
            ProcessButtonText = buttonTitle;
            Step1 = false;
            Step2 = false;
            StepLL = true;
        }
        public async Task Mint(Minter minter)
        {
            if (string.IsNullOrEmpty(inputDirectory)) return;

            string[] allSubDirectories = Directory.GetDirectories(inputDirectory);
            var metadataPath = GetSubDirectory(allSubDirectories, "Metadatas");
            var nftPath = GetSubDirectory(allSubDirectories, "NFTs");
            var animationPath = GetSubDirectory(allSubDirectories, "Animations");
            var bulkUploadPath = GetSubDirectory(allSubDirectories, "BulkUpload");
            if (bulkUploadPath != null && stepLL == true && (SelectedItem.Contains("choose") || string.IsNullOrEmpty(LooperLandsProjectName))) return;
            if (metadataPath == null || nftPath == null)
            {
                Log = "The selected folder must contain subfolders starting with 'Metadatas' and 'NFTs'.";
                return;
            }
            var lineCount = Directory.GetFiles(metadataPath).Length;
            
            if (step1 == true || stepLL == true)
            {
                var isNulls = CheckForNullsStepOne(inputDirectory, LoopringFeeSelectedOption, LoopringFeeDropdown, MaizeFeeSelectedOption, MaizeFeeDropdown);
                if (isNulls)
                    return;

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

                Log = ($"💰 Your Assets:\r\n{canAfford.userEth} ETH | {canAfford.userLrc} LRC | {canAfford.userPepe} PEPE\r\n\r\n🚨🚨 It will cost around " +
                        $"{feeAmount / 1000000000000000000m} {LoopringFeeSelectedOption} to mint {lineCount} NFTs with a Maize Fee of {maizeFee} {MaizeFeeSelectedOption}");
                if (bulkUploadPath != null && StepLL == false)
                    StepLooperLands("Preview");
                else
                    StepTwo("Mint");
                return;
            }
            LockForMinting = true;
            await MintCids(nftPath, metadataPath, bulkUploadPath, animationPath);
        }
        private static bool CheckForNullsStepOne(string inputDirectory, string LoopringFeeSelectedOption, List<string> LoopringFeeDropdown, string MaizeFeeSelectedOption, List<string> MaizeFeeDropdown)
        {
            if (string.IsNullOrEmpty(inputDirectory))
                return true;
            if (LoopringFeeSelectedOption == LoopringFeeDropdown[0] || MaizeFeeSelectedOption == MaizeFeeDropdown[0])
                return true;
            return false;
        }
        private async Task MintCids(string nftPath, string metadataPath, string? bulkUploadPath, string? animationPath)
        {
            // Get all the full file paths in the directories
            string[] nftFilesFullPaths = Directory.GetFiles(nftPath);
            string[] animationFilesFullPaths;
            if (animationPath != null)
                animationFilesFullPaths = Directory.GetFiles(animationPath);
            string[] metadataFilesFullPaths = Directory.GetFiles(metadataPath);

            // Extract just the filenames from the full paths
            List<string> nftFileNames = nftFilesFullPaths.ToList();
            List<string> animationFileNames = metadataFilesFullPaths.ToList();
            List<string> metadataFileNames = metadataFilesFullPaths.ToList();

            var lineCount = nftFileNames.Count();
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
                royaltyAddressesForCids = Enumerable.Repeat(settings.LoopringAddress, lineCount).ToList();
            }
            else if (inputAddresses.Count == 1)
            {
                royaltyAddressesForCids = Enumerable.Repeat(inputAddresses[0], lineCount).ToList();
            }
            else
            {
                int numAddresses = inputAddresses.Count;
                int numCids = nftFileNames.Count();
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

            var count = 0;

            var collectionResult = await minter.FindNftCollection(settings.LoopringApiKey, 12, 0, settings.LoopringAddress, SelectedCollectionAddress);
            if (collectionResult == null)
            {
                Log = ($"Could not find collection with contract address {SelectedCollectionAddress}");
                return;
            }
            var offChainFee = await minter.GetMintFee(settings.LoopringApiKey, settings.LoopringAccountId, settings.LoopringAddress, Environment.NftFactoryCollection, collectionResult.collections[0].collection.baseUri);
            var fee = offChainFee.fees[maxFeeTokenId].fee;

            Log = ($"Minting started on {SelectedCollectionAddress}...");

            List<(string name, string royaltyAddress)> cidAddressPairs = new List<(string, string)>();
            List<OutputRecord> outputRecords = new List<OutputRecord>();
            foreach (var (cid, royaltyAddress) in nftFileNames.Zip(royaltyAddressesForCids, (cid, royaltyAddress) => (cid, royaltyAddress)))
            {
                //var limit = true;
                //do
                //{
                //    var recommendedGasPrice = await loopringService.GetRecommendedGasPrice();
                //    limit = (recommendedGasPrice >= 17961166704) ? true : false;
                //    if (limit)
                //    {
                //        await Task.Delay(5000);
                //        Log = ($"Gas at {recommendedGasPrice}. Waiting for it to go below 17961166704.");
                //    }

                //} while (limit);

                var fileExtensions = new List<string> { ".json", ".jpeg", ".jpg", ".gif", ".webp", ".png", ".mp3", ".mpeg", ".mp4", ".mpeg4", ".glb" };

                string numberPart = Regex.Match(Path.GetFileName(cid), @"\d+").Value;
                string metadataFullPath = FindFileByNumber(metadataPath, numberPart, fileExtensions);                    

                var nftCid = await loopringService.PostImage(cid);

                string animationCid = null;
                if (animationPath != null)
                {
                    var animationFullPath = FindFileByNumber(animationPath, numberPart, fileExtensions);
                    animationCid = await loopringService.PostImage(animationFullPath);
                }
                (int royaltyPercentage, string name, string updatedJsonMetadata) = MetadataModifier.UpdateAndFetchRoyalty(metadataFullPath, nftCid, animationCid, SelectedCollectionAddress);
                string metadataHash = await loopringService.PostMetadata(updatedJsonMetadata, Path.GetFileName(metadataFullPath));
             
                string currentCid = metadataHash.Trim();

                cidAddressPairs.Add((name, royaltyAddress));
                count++;
                Log = ($"Attempting mint {count} out of {lineCount} NFTs");
                
                var mintResponse = await minter.MintCollection(settings.LoopringApiKey, settings.LoopringPrivateKey, settings.LoopringAddress, settings.LoopringAccountId, 0, royaltyPercentage, nftAmount, validUntil, maxFeeTokenId, Environment.NftFactoryCollection, Environment.Exchange, currentCid, collectionResult.collections[0].collection.baseUri, SelectedCollectionAddress, royaltyAddress);

                if (!string.IsNullOrEmpty(mintResponse.Item1.errorMessage))
                {
                    auditInfo.invalidAddress.Add(mintResponse.Item1.metadataCid);
                }
                else
                {
                    auditInfo.gasFeeTotal += mintResponse.Item2;
                    auditInfo.validAddress.Add(mintResponse.Item1.metadataCid);
                }
                await Task.Delay(500);

                if (bulkUploadPath != null)
                {
                    string assetType;
                    if (selectedItem == Items[1])
                        assetType = "armor";
                    else if (selectedItem == Items[2])
                        assetType = "weapon";
                    else if (selectedItem == Items[3])
                        assetType = "fishingrod";
                    else
                        assetType = "";
                    OutputRecord outputRecord = new OutputRecord
                    {
                        LooperName = name.Replace("#", ""), // Assuming LooperName exists in the original CSV
                        ShortNFTID = mintResponse.Item1.nftId,
                        NFTID = $"{settings.LoopringAddress}-0-{SelectedCollectionAddress}-{mintResponse.Item1.nftId}-{royaltyPercentage}",
                        projectname = LooperLandsProjectName, // Replace with actual project name
                        assetyype = assetType // Replace with actual asset type
                    };
                    RenameFilesInDirectory(bulkUploadPath, Path.GetFileName(cid), mintResponse.Item1.nftId + Path.GetExtension(Path.GetFileName(cid)));
                    outputRecords.Add(outputRecord);
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
            if (cidAddressPairs != null && cidAddressPairs.DistinctBy(x=>x.royaltyAddress).Count() > 1)
            {
                string csvFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}Output\\NFT_address_pairs.csv";
                using (StreamWriter sw2 = new StreamWriter(csvFilePath))
                {
                    sw2.WriteLine("NFT,Address");
                    foreach (var (name, royaltyAddress) in cidAddressPairs)
                    {
                        sw2.WriteLine($"{name},{royaltyAddress}");
                    }
                }
                ApplicationUtilitiesUI.OpenFile(csvFilePath);
            }
            if (bulkUploadPath != null)
            {
                using (var writer = new StreamWriter($"{bulkUploadPath}\\ToLooperLands.csv"))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
                {
                    csv.WriteRecords(outputRecords);
                }
                ApplicationUtilitiesUI.OpenFile(inputDirectory);

                // Call the method to create the text file with instructions
                CreateInstructionTextFile(inputDirectory + "\\ReadMeForNextSteps.txt");
            }
            ZipFolderAndDeleteSource(bulkUploadPath, $"{Path.GetDirectoryName(bulkUploadPath)}\\ToLooperLands.zip");
            Log = $"{swTime}\r\n\r\nYour audit file is here:\r\n\r\n{fileName}";
        }
        public static string FindFileByNumber(string directoryPath, string number, IEnumerable<string> fileExtensions)
        {
            string[] files = Directory.GetFiles(directoryPath);

            // Regex pattern to match the number as a standalone word
            string exactMatchPattern = $@"(?<!\d){number}(?!\d)";

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);

                // Use Regex for precise matching
                if (Regex.IsMatch(fileName, exactMatchPattern) && fileExtensions.Any(ext => fileName.EndsWith(ext)))
                {
                    return file;
                }
            }

            Console.WriteLine("No matching file found.");
            return null;
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
        private async Task UpdateCollectionNames()
        {
            await FetchCollectionNamesFromApi();
            CollectionNames = new ObservableCollection<string>(_collectionNameAddressMap.Keys.ToList());
        }
        private ObservableCollection<string> _collectionNames;
        public ObservableCollection<string> CollectionNames
        {
            get => _collectionNames;
            set => this.RaiseAndSetIfChanged(ref _collectionNames, value);
        }
        private bool SetSelectedCollection(string value)
        {
            string oldValue = _selectedCollection;
            _selectedCollection = value;
            return !string.Equals(oldValue, value) && _collectionNameAddressMap.ContainsKey(value);
        }
        static void RenameFilesInDirectory(string directoryPath, string targetFileName, string newFileName)
        {
            try
            {
                // Get all files in the current directory
                string[] files = Directory.GetFiles(directoryPath);

                // Rename matching files
                foreach (string file in files)
                {
                    if (Path.GetFileName(file) == targetFileName)
                    {
                        string newFilePath = Path.Combine(directoryPath, newFileName);
                        File.Move(file, newFilePath);
                    }
                }

                // Recursively search subdirectories
                string[] subdirectories = Directory.GetDirectories(directoryPath);
                foreach (string subdirectory in subdirectories)
                {
                    RenameFilesInDirectory(subdirectory, targetFileName, newFileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void ZipFolderAndDeleteSource(string sourceFolder, string zipFilePath)
        {
            try
            {
                // Zip the folder
                ZipFile.CreateFromDirectory(sourceFolder, zipFilePath);

                // Delete the original folder
                Directory.Delete(sourceFolder, true); // Set the second argument to true to delete subdirectories and files
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void CreateInstructionTextFile(string filePath)
        {
            // Content to be written to the text file
            string content = @"Now take your BulkUpload folder to the Looper Lands discord.

1. https://discord.gg/QRqDEqsNjT
2. Go to the channel #open-a-ticket
3. type in /open and click the /open link
4. click subject and type 'BulkUpload from <Your Wallet address>'
   example: BulkUpload from 0x6458CC5902D4F9e466B599E220D1663C4718625A
5. Click into the created ticket
6. Give the LL team a nice message and upload the ToLooperLands.zip file. 
7. Done!
8. Keep an eye on your ticket ^_^";

            try
            {
                // Write the content to the text file
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
    public class OutputRecord
        {
            public string LooperName { get; set; }
            public string ShortNFTID { get; set; }
            public string NFTID { get; set; }
            public string projectname { get; set; }
            public string assetyype { get; set; }
        }
    }
