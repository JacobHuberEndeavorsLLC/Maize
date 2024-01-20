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
using Microsoft.Extensions.Configuration;
using NBitcoin;
using Splat;
using System;
using System.Reactive.Linq;
using static Maize.Models.ApplicationSpecific.Constants;

namespace MaizeUI.ViewModels
{
    public class MainMenuWindowViewModel : ViewModelBase
    {
        public Window OwnerWindow { get; private set; } 

        private readonly IDialogService _dialogService;
        public Action LogoutAction { get; }
        private bool _isMainnetSelected;
        public bool IsMainnetSelected
        {
            get => _isMainnetSelected;
            set
            {
                this.RaiseAndSetIfChanged(ref _isMainnetSelected, value);
                SelectedNetwork = _isMainnetSelected ? "💎 main" : "🧪 test";
            }
        }
        public AccountService _accountService;
        public string userPassword;
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
        public Settings _settings;

        public Settings Settings
        {
            get => _settings;
            set => this.RaiseAndSetIfChanged(ref _settings, value);
        }

        public Constants.Environment _environment;

        public Constants.Environment Environment
        {
            get => _environment;
            set => this.RaiseAndSetIfChanged(ref _environment, value);
        }
        public string selectedNetwork;

        public string SelectedNetwork
        {
            get => selectedNetwork;
            set => this.RaiseAndSetIfChanged(ref selectedNetwork, value);
        }

        public LoopringServiceUI _loopringService;
        private string _userPassword;

        public LoopringServiceUI LoopringService
        {
            get => _loopringService;
            set => this.RaiseAndSetIfChanged(ref _loopringService, value);
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
        public ReactiveCommand<Unit, Unit> MintCommand { get; }
        public ReactiveCommand<Unit, Unit> LogoutCommand { get; }
        public ReactiveCommand<Unit, Unit> ExpressAirdropNftsCommand { get; }

        public MainMenuWindowViewModel(Action logoutAction, IDialogService dialogService, Window ownerWindow, AccountService accountService, string userPassword, Settings userSettings, LoopringServiceUI loopringService, Constants.Environment environment)
        {
            _environment = environment;
            _loopringService = loopringService;
            _settings = userSettings;
            _userPassword = userPassword ?? string.Empty;
            _accountService = accountService;
            LogoutAction = logoutAction;
            _dialogService = dialogService;
            OwnerWindow = ownerWindow;
            LogoutAction = logoutAction;
            _dialogService = dialogService;
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
            MintCommand = ReactiveCommand.Create(Mint);
            LogoutCommand = ReactiveCommand.Create(Logout);
            ExpressAirdropNftsCommand = ReactiveCommand.Create(ExpressAirdropNfts);
            CheckForCollectionlessNfts();
            this.WhenAnyValue(x => x.OwnerWindow).Where(x => x != null).Subscribe(window =>
            {
                window.Closing += OnMainMenuWindowClosing;
            });
        }
        private void OnMainMenuWindowClosing(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        public void Logout()
        {
            LogoutAction?.Invoke();
        }
        private async void CheckForCollectionlessNfts()
        {
            var hasCollectionlessNfts = await _loopringService.HasCollectionlessNfts(_settings.LoopringApiKey, _settings.LoopringAccountId);
            if (hasCollectionlessNfts)
                Maize.Helpers.Things.OpenUrl("https://www.cobmin.com/posts/Setup-Your-Loopring-Legacy-NFTs");

        }
        private async void FindNftDataFromAWallet()
        {
            var viewModel = new FindNftDataFromAWalletWindowViewModel
            {
                LoopringService = _loopringService,
                Settings = _settings
            };

            await _dialogService.ShowDialogAsync<FindNftDataFromAWalletWindow, FindNftDataFromAWalletWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void FindNftDataFromACollection()
        {
            var viewModel = new FindNftDataFromACollectionWindowViewModel
            {
                LoopringService = _loopringService,
                Settings = _settings
            };

            await _dialogService.ShowDialogAsync<FindNftDataFromACollectionWindow, FindNftDataFromACollectionWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void FindHoldersFromNftData()
        {
            var viewModel = new FindHoldersFromNftDataWindowViewModel
            {
                LoopringService = _loopringService,
                Settings = _settings
            };

            await _dialogService.ShowDialogAsync<FindHoldersFromNftDataWindow, FindHoldersFromNftDataWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void AirdropNftsToUsers()
        {
            var viewModel = new AirdropNftsToUsersWindowViewModel
            {
                LoopringService = _loopringService,
                Settings = _settings,
                Environment = _environment
            };

            await _dialogService.ShowDialogAsync<AirdropNftsToUsersWindow, AirdropNftsToUsersWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void AirdropCryptoToUsers()
        {
            var viewModel = new AirdropCryptoToUsersWindowViewModel
            {
                LoopringService = _loopringService,
                Settings = _settings,
                Environment = _environment
            };

            await _dialogService.ShowDialogAsync<AirdropCryptoToUsersWindow, AirdropCryptoToUsersWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void AirdropMigrateWallet()
        {
            var viewModel = new AirdropMigrateWalletWindowViewModel
            {
                LoopringService = _loopringService,
                Settings = _settings,
                Environment = _environment
            };

            await _dialogService.ShowDialogAsync<AirdropMigrateWalletWindow, AirdropMigrateWalletWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void ScriptingAirdropInputFile()
        {
            var viewModel = new ScriptingAirdropInputFileWindowViewModel
            {
                LoopringService = _loopringService,
                Settings = _settings,
                Environment = _environment
            };

            await _dialogService.ShowDialogAsync<ScriptingAirdropInputFileWindow, ScriptingAirdropInputFileWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void ScriptingCryptoAirdropInputFile()
        {
            var viewModel = new ScriptingCryptoAirdropInputFileWindowViewModel
            {
                LoopringService = _loopringService,
                Settings = _settings,
                Environment = _environment
            };

            await _dialogService.ShowDialogAsync<ScriptingCryptoAirdropInputFileWindow, ScriptingCryptoAirdropInputFileWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void MetadataRefreshCollection()
        {
            var viewModel = new MetadataRefreshCollectionWindowViewModel
            {
                LoopringService = _loopringService,
                Settings = _settings
            };

            await _dialogService.ShowDialogAsync<MetadataRefreshCollectionWindow, MetadataRefreshCollectionWindowViewModel>(viewModel, OwnerWindow);
        }

        private async void LooperLandsGenerateOneOfOnes()
        {
            foreach (var item in _accountService.MainnetAccounts)
            {
                try
                {
                    var mainnet = await _accountService.LoadMainSettingsForPremium(_userPassword, item);
                    var premiumAccess = await ApplicationUtilitiesUI.AccessPremiumContent(mainnet.Item1, _loopringService = new LoopringServiceUI("https://api3.loopring.io/"));
                    if (premiumAccess == false)
                    {
                        Maize.Helpers.Things.OpenUrl("https://loopexchange.art/collection/maize-access/item/0x6692d7a147762ce9335746c7b062576ef9834500f5546a29c724c55752f668c7");
                        return;
                    }
                    else if (premiumAccess == true)
                        break;
                }
                catch (Exception)
                {

                }
            }

            var viewModel = new LooperLandsGenerateOneOfOnesWindowViewModel(_settings, _loopringService);
            await _dialogService.ShowDialogAsync<LooperLandsGenerateOneOfOnesWindow, LooperLandsGenerateOneOfOnesWindowViewModel>(viewModel);
        }
        private async void GenerateOneOfOnes()
        {
            var viewModel = new GenerateOneOfOnesWindowViewModel(_settings, _loopringService);
            await _dialogService.ShowDialogAsync<GenerateOneOfOnesWindow, GenerateOneOfOnesWindowViewModel>(viewModel);
        }
        private async void Mint()
        {
            var viewModel = new MintWindowViewModel(_settings, _loopringService);
            await _dialogService.ShowDialogAsync<MintWindow, MintWindowViewModel>(viewModel);
        }

        private async void MetadataUploadToInfura()
        {
            var viewModel = new MetadataUploadToInfuraWindowViewModel();
            await _dialogService.ShowDialogAsync<MetadataUploadToInfuraWindow, MetadataUploadToInfuraWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void ExpressAirdropNfts()
        {
            var viewModel = new ExpressAirdropNftsWindowViewModel(_environment)
            {
                LoopringService = _loopringService,
                Settings = _settings
            };

            await _dialogService.ShowDialogAsync<ExpressAirdropNftsWindow, ExpressAirdropNftsWindowViewModel>(viewModel, OwnerWindow);
        }
        private void HelpFile()
        {
            Maize.Helpers.Things.OpenUrl("https://maizehelps.art/docs");
        }
    }
}
