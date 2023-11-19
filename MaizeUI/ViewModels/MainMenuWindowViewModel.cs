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
        private string _userPassword;

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
        public ReactiveCommand<Unit, Unit> MintCommand { get; }
        public ReactiveCommand<Unit, Unit> LogoutCommand { get; }

        public MainMenuWindowViewModel(Action logoutAction, IDialogService dialogService, Window ownerWindow, AccountService accountService, string userPassword)
        {
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
        }
        public void Logout()
        {
            LogoutAction?.Invoke();
        }

        private async void FindNftDataFromAWallet()
        {
            var viewModel = new FindNftDataFromAWalletWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings
            };

            await _dialogService.ShowDialogAsync<FindNftDataFromAWalletWindow, FindNftDataFromAWalletWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void FindNftDataFromACollection()
        {
            var viewModel = new FindNftDataFromACollectionWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings
            };

            await _dialogService.ShowDialogAsync<FindNftDataFromACollectionWindow, FindNftDataFromACollectionWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void FindHoldersFromNftData()
        {
            var viewModel = new FindHoldersFromNftDataWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings
            };

            await _dialogService.ShowDialogAsync<FindHoldersFromNftDataWindow, FindHoldersFromNftDataWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void AirdropNftsToUsers()
        {
            var viewModel = new AirdropNftsToUsersWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };

            await _dialogService.ShowDialogAsync<AirdropNftsToUsersWindow, AirdropNftsToUsersWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void AirdropCryptoToUsers()
        {
            var viewModel = new AirdropCryptoToUsersWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };

            await _dialogService.ShowDialogAsync<AirdropCryptoToUsersWindow, AirdropCryptoToUsersWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void AirdropMigrateWallet()
        {
            var viewModel = new AirdropMigrateWalletWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };

            await _dialogService.ShowDialogAsync<AirdropMigrateWalletWindow, AirdropMigrateWalletWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void ScriptingAirdropInputFile()
        {
            var viewModel = new ScriptingAirdropInputFileWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };

            await _dialogService.ShowDialogAsync<ScriptingAirdropInputFileWindow, ScriptingAirdropInputFileWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void ScriptingCryptoAirdropInputFile()
        {
            var viewModel = new ScriptingCryptoAirdropInputFileWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings,
                Environment = environment
            };

            await _dialogService.ShowDialogAsync<ScriptingCryptoAirdropInputFileWindow, ScriptingCryptoAirdropInputFileWindowViewModel>(viewModel, OwnerWindow);
        }
        private async void MetadataRefreshCollection()
        {
            var viewModel = new MetadataRefreshCollectionWindowViewModel
            {
                LoopringService = new LoopringServiceUI(Environment.Url),
                Settings = settings
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
                    var premiumAccess = await ApplicationUtilitiesUI.AccessPremiumContent(mainnet.Item1, loopringService = new LoopringServiceUI("https://api3.loopring.io/"));
                    if (premiumAccess == false || item == _accountService.MainnetAccounts.Last())
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

            var viewModel = new LooperLandsGenerateOneOfOnesWindowViewModel(settings, new LoopringServiceUI(Environment.Url));
            await _dialogService.ShowDialogAsync<LooperLandsGenerateOneOfOnesWindow, LooperLandsGenerateOneOfOnesWindowViewModel>(viewModel);
        }
        private async void GenerateOneOfOnes()
        {
            foreach (var item in _accountService.MainnetAccounts)
            {
                try
                {
                    var mainnet = await _accountService.LoadMainSettingsForPremium(_userPassword, item);
                    var premiumAccess = await ApplicationUtilitiesUI.AccessPremiumContent(mainnet.Item1, loopringService = new LoopringServiceUI("https://api3.loopring.io/"));
                    if (premiumAccess == false || item == _accountService.MainnetAccounts.Last())
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
            var viewModel = new GenerateOneOfOnesWindowViewModel(settings, new LoopringServiceUI(Environment.Url));
            await _dialogService.ShowDialogAsync<GenerateOneOfOnesWindow, GenerateOneOfOnesWindowViewModel>(viewModel);
        }
        private async void Mint()
        {
            var viewModel = new MintWindowViewModel(settings, new LoopringServiceUI(Environment.Url));
            await _dialogService.ShowDialogAsync<MintWindow, MintWindowViewModel>(viewModel);
        }

        private async void MetadataUploadToInfura()
        {
            var viewModel = new MetadataUploadToInfuraWindowViewModel();
            await _dialogService.ShowDialogAsync<MetadataUploadToInfuraWindow, MetadataUploadToInfuraWindowViewModel>(viewModel, OwnerWindow);
        }
        private void HelpFile()
        {
            Maize.Helpers.Things.OpenUrl("https://maizehelps.art/docs");
        }
    }
}
