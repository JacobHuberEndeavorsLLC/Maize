using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Maize;
using Maize.Services;
using Maize.Models.ApplicationSpecific;
using MaizeUI.Views;
using ReactiveUI;
using System.Reactive;
using MaizeUI.Helpers;
using Maize.Helpers;

namespace MaizeUI.ViewModels
{
    public class MainMenuWindowViewModel : ViewModelBase
    {
        public string ens;
        public string Ens
        {
            get => ens;
            set => this.RaiseAndSetIfChanged(ref ens, value);
        }
        public string slogan;
        public string Slogan
        {
            get => slogan;
            set => this.RaiseAndSetIfChanged(ref slogan, value);
        }
        public string version;
        public string Version
        {
            get => version;
            set => this.RaiseAndSetIfChanged(ref version, value);
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
        public string selectedNetwork;

        public string SelectedNetwork
        {
            get => selectedNetwork;
            set => this.RaiseAndSetIfChanged(ref selectedNetwork, value);
        }

        public LoopringServiceUI loopringService;

        public LoopringServiceUI LoopringService
        {
            get => loopringService;
            set => this.RaiseAndSetIfChanged(ref loopringService, value);
        }

        public ReactiveCommand<Unit, Unit> FindNftDataFromAWalletCommand { get; }
        public ReactiveCommand<Unit, Unit> FindNftDataFromACollectionCommand { get; }
        public ReactiveCommand<Unit, Unit> FindHoldersFromNftDataCommand { get; }
        public ReactiveCommand<Unit, Unit> AirdropNftsToUsersCommand { get; }
        public ReactiveCommand<Unit, Unit> AirdropCryptoToUsersCommand { get; }
        public ReactiveCommand<Unit, Unit> AirdropMigrateWalletCommand { get; }
        public ReactiveCommand<Unit, Unit> ScriptingAirdropInputFileCommand { get; }
        public ReactiveCommand<Unit, Unit> ScriptingCryptoAirdropInputFileCommand { get; }
        public ReactiveCommand<Unit, Unit> MetadataRefreshCollectionCommand { get; }
        public ReactiveCommand<Unit, Unit> MetadataUploadToInfuraCommand { get; }
        public ReactiveCommand<Unit, Unit> HelpFileCommand { get; }
        public ReactiveCommand<Unit, Unit> LooperLandsGenerateOneOfOnesCommand { get; }
        public ReactiveCommand<Unit, Unit> GenerateOneOfOnesCommand { get; }
        public ReactiveCommand<Unit, Unit> MintAndPinToIPFSCommand { get; }
        public ReactiveCommand<Unit, Unit> MintCommand { get; }

        public MainMenuWindowViewModel()
        {
            FindNftDataFromAWalletCommand = ReactiveCommand.Create(FindNftDataFromAWallet);
            FindNftDataFromACollectionCommand = ReactiveCommand.Create(FindNftDataFromACollection);
            FindHoldersFromNftDataCommand = ReactiveCommand.Create(FindHoldersFromNftData);
            AirdropNftsToUsersCommand = ReactiveCommand.Create(AirdropNftsToUsers);
            AirdropCryptoToUsersCommand = ReactiveCommand.Create(AirdropCryptoToUsers);
            AirdropMigrateWalletCommand = ReactiveCommand.Create(AirdropMigrateWallet);
            ScriptingAirdropInputFileCommand = ReactiveCommand.Create(ScriptingAirdropInputFile);
            ScriptingCryptoAirdropInputFileCommand = ReactiveCommand.Create(ScriptingCryptoAirdropInputFile);
            MetadataRefreshCollectionCommand = ReactiveCommand.Create(MetadataRefreshCollection);
            MetadataUploadToInfuraCommand = ReactiveCommand.Create(MetadataUploadToInfura);
            HelpFileCommand = ReactiveCommand.Create(HelpFile);
            LooperLandsGenerateOneOfOnesCommand = ReactiveCommand.Create(LooperLandsGenerateOneOfOnes);
            GenerateOneOfOnesCommand = ReactiveCommand.Create(GenerateOneOfOnes);
            MintAndPinToIPFSCommand = ReactiveCommand.Create(MintAndPinToIPFS);
            MintCommand = ReactiveCommand.Create(Mint);


        }
        private async void FindNftDataFromAWallet()
        {
            await ShowDialog<FindNftDataFromAWalletWindow, FindNftDataFromAWalletWindowViewModel>(new FindNftDataFromAWalletWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings
            });
        }
        private async void FindNftDataFromACollection()
        {
            await ShowDialog<FindNftDataFromACollectionWindow, FindNftDataFromACollectionWindowViewModel>(
                new FindNftDataFromACollectionWindowViewModel
                {
                    LoopringService = new LoopringServiceUI(Environment.Url),
                    Settings = settings
                });
        }
        private async void FindHoldersFromNftData()
        {
            await ShowDialog<FindHoldersFromNftDataWindow, FindHoldersFromNftDataWindowViewModel>(
                new FindHoldersFromNftDataWindowViewModel
                {
                    LoopringService = new LoopringServiceUI(Environment.Url),
                    Settings = settings
                });
        }
        private async void AirdropNftsToUsers()
        {
            await ShowDialog<AirdropNftsToUsersWindow, AirdropNftsToUsersWindowViewModel>(
                new AirdropNftsToUsersWindowViewModel
                {
                    LoopringService = new LoopringServiceUI(Environment.Url),
                    Settings = settings,
                    Environment = environment
                });
        }
        private async void AirdropCryptoToUsers()
        {
            await ShowDialog<AirdropCryptoToUsersWindow, AirdropCryptoToUsersWindowViewModel>(
                new AirdropCryptoToUsersWindowViewModel
                {
                    LoopringService = new LoopringServiceUI(Environment.Url),
                    Settings = settings,
                    Environment = environment
                });
        }
        private async void AirdropMigrateWallet()
        {
            await ShowDialog<AirdropMigrateWalletWindow, AirdropMigrateWalletWindowViewModel>(
                new AirdropMigrateWalletWindowViewModel
                {
                    LoopringService = new LoopringServiceUI(Environment.Url),
                    Settings = settings,
                    Environment = environment
                });
        }
        private async void ScriptingAirdropInputFile()
        {
            await ShowDialog<ScriptingAirdropInputFileWindow, ScriptingAirdropInputFileWindowViewModel>(
                new ScriptingAirdropInputFileWindowViewModel
                {
                    LoopringService = new LoopringServiceUI(Environment.Url),
                    Settings = settings,
                    Environment = environment
                });
        }
        private async void ScriptingCryptoAirdropInputFile()
        {
            await ShowDialog<ScriptingCryptoAirdropInputFileWindow, ScriptingCryptoAirdropInputFileWindowViewModel>(
                new ScriptingCryptoAirdropInputFileWindowViewModel
                {
                    LoopringService = new LoopringServiceUI(Environment.Url),
                    Settings = settings,
                    Environment = environment
                });
            }
        private async void MetadataRefreshCollection()
        {
            await ShowDialog<MetadataRefreshCollectionWindow, MetadataRefreshCollectionWindowViewModel>(
                new MetadataRefreshCollectionWindowViewModel
                {
                    LoopringService = new LoopringServiceUI(Environment.Url),
                    Settings = settings
                });
        }
        private async void LooperLandsGenerateOneOfOnes()
        {
            var premiumAccess = await ApplicationUtilitiesUI.AccessPremiumContent(settings, loopringService = new LoopringServiceUI(Environment.Url));
            if (premiumAccess == false)
            {
                Website.OpenWebsite("https://loopexchange.art/collection/maize-access/item/0x6692d7a147762ce9335746c7b062576ef9834500f5546a29c724c55752f668c7");
                return;
            }

            await ShowDialog<LooperLandsGenerateOneOfOnesWindow, LooperLandsGenerateOneOfOnesWindowViewModel>(
                new LooperLandsGenerateOneOfOnesWindowViewModel(settings, new LoopringServiceUI(Environment.Url)));
        }
        private async void GenerateOneOfOnes()
        {
            var premiumAccess = await ApplicationUtilitiesUI.AccessPremiumContent(settings, loopringService = new LoopringServiceUI(Environment.Url));
            if (premiumAccess == false)
            {
                Website.OpenWebsite("https://loopexchange.art/collection/maize-access/item/0x6692d7a147762ce9335746c7b062576ef9834500f5546a29c724c55752f668c7");
                return;
            }

            await ShowDialog<GenerateOneOfOnesWindow, GenerateOneOfOnesWindowViewModel>(
                new GenerateOneOfOnesWindowViewModel(settings, new LoopringServiceUI(Environment.Url))
);
        }
        private async void MintAndPinToIPFS()
        {
            await ShowDialog<MintAndPinToIPFSWindow, MintAndPinToIPFSWindowViewModel>(
                new MintAndPinToIPFSWindowViewModel
                {
                    LoopringService = new LoopringServiceUI(Environment.Url),
                    Settings = settings,
                    Environment = environment
                });
        }
        private async void Mint()
        {
            await ShowDialog<MintWindow, MintWindowViewModel>(
            new MintWindowViewModel(settings, new LoopringServiceUI(Environment.Url)));
        }
        private async Task ShowDialog<TDialog, TViewModel>(TViewModel viewModel) where TDialog : Window, new() where TViewModel : class
        {
            var dialog = new TDialog();
            dialog.DataContext = viewModel;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void MetadataUploadToInfura()
        {
            await ShowDialog<MetadataUploadToInfuraWindow, MetadataUploadToInfuraWindowViewModel>(new MetadataUploadToInfuraWindowViewModel());
        }
        private void HelpFile()
        {
            Website.OpenWebsite("https://maizehelps.art/docs");
        }
    }
}
