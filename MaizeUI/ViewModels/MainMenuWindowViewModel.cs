using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Maize;
using Maize.Services;
using Maize.Models.ApplicationSpecific;
using MaizeUI.Views;
using ReactiveUI;
using System.Reactive;
using System.Diagnostics;
using System.Runtime.InteropServices;
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


        }

        private async void FindNftDataFromAWallet()
        {
            var dialog = new FindNftDataFromAWalletWindow();
            dialog.DataContext = new FindNftDataFromAWalletWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void FindNftDataFromACollection()
        {
            var dialog = new FindNftDataFromACollectionWindow();
            dialog.DataContext = new FindNftDataFromACollectionWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void FindHoldersFromNftData()
        {
            var dialog = new FindHoldersFromNftDataWindow();
            dialog.DataContext = new FindHoldersFromNftDataWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void AirdropNftsToUsers()
        {
            var dialog = new AirdropNftsToUsersWindow();
            dialog.DataContext = new AirdropNftsToUsersWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void AirdropCryptoToUsers()
        {
            var dialog = new AirdropCryptoToUsersWindow();
            dialog.DataContext = new AirdropCryptoToUsersWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void AirdropMigrateWallet()
        {
            var dialog = new AirdropMigrateWalletWindow();
            dialog.DataContext = new AirdropMigrateWalletWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void ScriptingAirdropInputFile()
        {
            var dialog = new ScriptingAirdropInputFileWindow();
            dialog.DataContext = new ScriptingAirdropInputFileWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void ScriptingCryptoAirdropInputFile()
        {
            var dialog = new ScriptingCryptoAirdropInputFileWindow();
            dialog.DataContext = new ScriptingCryptoAirdropInputFileWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void MetadataRefreshCollection()
        {
            var dialog = new MetadataRefreshCollectionWindow();
            dialog.DataContext = new MetadataRefreshCollectionWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private async void MetadataUploadToInfura()
        {
            var dialog = new MetadataUploadToInfuraWindow();
            dialog.DataContext = new MetadataUploadToInfuraWindowViewModel
            {
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
        private void HelpFile()
        {
            Website.OpenWebsite("https://maizehelps.art/docs");
        }
        private async void LooperLandsGenerateOneOfOnes()
        {
            var premiumAccess = await ApplicationUtilitiesUI.AccessPremiumContent(settings, loopringService = new LoopringServiceUI(Environment.Url));
            if (premiumAccess == false)
            {
                Website.OpenWebsite("https://loopexchange.art/collection/maize-access/item/0x6692d7a147762ce9335746c7b062576ef9834500f5546a29c724c55752f668c7");
                return;
            }
            var dialog = new LooperLandsGenerateOneOfOnesWindow();
            dialog.DataContext = new LooperLandsGenerateOneOfOnesWindowViewModel
            {
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }
    }

}
