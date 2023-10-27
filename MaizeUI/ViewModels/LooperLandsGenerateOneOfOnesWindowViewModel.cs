using ReactiveUI;
using System.Reactive;
using System.Text.RegularExpressions;
using MaizeUI.Things;
using Maize.Models.ApplicationSpecific;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reactive.Concurrency;
using Maize.Services;
using Maize;
using System.Collections.ObjectModel;
using Maize.Models.Responses;

namespace MaizeUI.ViewModels
{
    public class LooperLandsGenerateOneOfOnesWindowViewModel : ViewModelBase
    {
        private bool _isFeatureEnabled;
        public bool IsFeatureEnabled
        {
            get { return _isFeatureEnabled; }
            set { this.RaiseAndSetIfChanged(ref _isFeatureEnabled, value); }
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

        private ObservableCollection<string> _collectionNames;
        public ObservableCollection<string> CollectionNames
        {
            get => _collectionNames;
            set => this.RaiseAndSetIfChanged(ref _collectionNames, value);
        }

        private string _selectedCollection;
        public string SelectedCollection
        {
            get => _selectedCollection;
            set
            {
                string oldValue = _selectedCollection;
                _selectedCollection = value;
                bool isChanged = !string.Equals(oldValue, value);

                if (isChanged)
                {
                    this.RaiseAndSetIfChanged(ref _selectedCollection, value); // Assuming this triggers UI or other updates

                    if (_collectionNameAddressMap.ContainsKey(value))
                    {
                        SelectedCollectionAddress = _collectionNameAddressMap[value];
                    }
                }
            }
        }
        public string SelectedCollectionAddress { get; private set; }
        public event Action RequestOpenFolder;
        public string HelpButtonText { get; set; } = "Help";
        public string ProcessButtonText { get; set; } = "Process";
        public string TitleText { get; set; } = "Generate 1/1 Loopers";
        public string MainContent { get; set; } = "Here you will generate 1/1 Loopers for Looper Lands from sprite sheets.";

        private int royaltyPercentage;
        public int RoyaltyPercentage
        {
            get => royaltyPercentage;
            set => this.RaiseAndSetIfChanged(ref royaltyPercentage, value);
        }

        private bool _isTextBoxVisible;
        public bool IsTextBoxVisible
        {
            get => _isTextBoxVisible;
            set => this.RaiseAndSetIfChanged(ref _isTextBoxVisible, value);
        }

        public string inputDirectory;
        public string InputDirectory
        {
            get => inputDirectory;
            set => this.RaiseAndSetIfChanged(ref inputDirectory, value);
        }
        public int totalIterations;

        public int TotalIterations
        {
            get => totalIterations;
            set => this.RaiseAndSetIfChanged(ref totalIterations, value);
        }
        public string nftName;

        public string NftName
        {
            get => nftName;
            set => this.RaiseAndSetIfChanged(ref nftName, value);
        }
        public string nftDescription;

        public string NftDescription
        {
            get => nftDescription;
            set => this.RaiseAndSetIfChanged(ref nftDescription, value);
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
        private async Task InitializeAsync()
        {
            await FetchCollectionNamesFromApi();
            CollectionNames = new ObservableCollection<string>(_collectionNameAddressMap.Keys.ToList());
        }
        public ReactiveCommand<Unit, Unit> OpenFolderCommand { get; }
        public ReactiveCommand<Unit, Unit> GenerateSpritesCommand { get; }

        public LooperLandsGenerateOneOfOnesWindowViewModel(Settings settings, LoopringServiceUI loopringService)
        {
            this.settings = settings;
            this.loopringService = loopringService;
            InitializeAsync();
            LoadCollectionNames();
            OpenFolderCommand = ReactiveCommand.CreateFromTask(() => OpenFolder());
            GenerateSpritesCommand = ReactiveCommand.CreateFromTask(() => GenerateAndProcessSprites());
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
        public async Task OpenFolder()
        {
            // You'll trigger an event here that will be caught in your View's code-behind
            RequestOpenFolder?.Invoke();
        }
        private void UpdateLog(long elapsedMs, int count, string fileName)
        {
            var swTime = $"This took {(elapsedMs > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(elapsedMs) / 1000m / 60, 3) : Convert.ToDecimal(elapsedMs) / 1000m)} {(elapsedMs > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.";
            Log = $"{swTime}\r\n\r\n{count} 1/1s were created.\r\n\r\nYour file is here:\r\n{fileName}";
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
        private async Task GenerateAndProcessSprites()
        {
            var collectionAddress = SelectedCollectionAddress;
            List<List<string>> allOrderedSprites = new List<List<string>>();
            Dictionary<string, int> spriteFrequency = new Dictionary<string, int>();
            string outputDirectory = $"{Constants.BaseDirectory}{Constants.OutputFolder}/{collectionAddress}";
            Directory.CreateDirectory(outputDirectory);
            var sw = Stopwatch.StartNew();

            await Task.Run(() =>
            {
                for (int i = 1; i <= totalIterations; i++)
                {
                    bool meetConstraint;
                    do
                    {
                        bool isUnique = true;
                        List<string> orderedSprites = Components.StackRandomSpritesFromSubdirectories(inputDirectory);
                        if (!_isFeatureEnabled)
                            isUnique = Components.CheckForDuplicates(orderedSprites);

                        // Temporary dictionary to hold the frequency counts for this iteration
                        Dictionary<string, int> tempSpriteFrequency = new Dictionary<string, int>(spriteFrequency);

                        // Update temporary sprite frequencies
                        foreach (var sprite in orderedSprites)
                        {
                            string spriteType = Path.GetFileNameWithoutExtension(sprite);
                            if (tempSpriteFrequency.ContainsKey(spriteType))
                            {
                                tempSpriteFrequency[spriteType]++;
                            }
                            else
                            {
                                tempSpriteFrequency[spriteType] = 1;
                            }
                        }

                        // Initialize meetConstraint to true before the loop
                        meetConstraint = true;

                        // Check and enforce max percentages
                        foreach (var sprite in orderedSprites)
                        {
                            string filename = Path.GetFileName(sprite);
                            Match match = Regex.Match(filename, @"X#(\d+)");
                            if (match.Success)
                            {
                                int maxPercentage = int.Parse(match.Groups[1].Value);
                                string spriteType = Path.GetFileNameWithoutExtension(sprite);
                                if (tempSpriteFrequency[spriteType] / (double)totalIterations > maxPercentage / 100.0)
                                {
                                    meetConstraint = false;
                                    break;
                                }
                            }
                        }

                        if (isUnique && meetConstraint)
                        {
                            // Update the actual spriteFrequency dictionary
                            spriteFrequency = tempSpriteFrequency;

                            allOrderedSprites.Add(orderedSprites);
                            break;
                        }

                    } while (true);
                    if (i % 10 == 0 || i == allOrderedSprites.Count - 1)
                    {
                        // Update Log from the main thread
                        RxApp.MainThreadScheduler.Schedule(() => Log = $"Processing: {i - 1}/{totalIterations}");
                    }
                }
            });

            await Task.Run(() =>
            {
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string iterationsDirectory = Path.Combine(outputDirectory, $"Iterations_{timestamp}");
                string metadataDirectory = Path.Combine(outputDirectory, $"Metadatas_{timestamp}");
                string nftDirectory = Path.Combine(outputDirectory, $"NFTs_{timestamp}");
                Directory.CreateDirectory(iterationsDirectory);
                Directory.CreateDirectory(metadataDirectory);
                Directory.CreateDirectory(nftDirectory);

                for (int i = 0; i < allOrderedSprites.Count; i++)
                {
                    string iterationDirectory = Path.Combine(iterationsDirectory, $"Iteration_{i + 1}");
                    Directory.CreateDirectory(iterationDirectory); // Create unique folder for this iteration
                    var nftName = $"{NftName} #{Things.Helpers.GetIterationNumberFromFilePath(iterationDirectory)}";

                    List<string> orderedSprites = allOrderedSprites[i];
                    Components.ProcessMetadata(metadataDirectory, orderedSprites, iterationDirectory, collectionAddress, royaltyPercentage, nftName, nftDescription);
                    Components.ProcessSprites(nftDirectory, orderedSprites, iterationDirectory);
                    if (i % 10 == 0 || i == allOrderedSprites.Count - 1)
                    {
                        RxApp.MainThreadScheduler.Schedule(() => Log = $"Creating: {i}/{totalIterations}");
                    }
                }
            });
            sw.Stop();
            UpdateLog(sw.ElapsedMilliseconds, allOrderedSprites.Count, outputDirectory);
            ViewResults(outputDirectory);
        }
    }
}