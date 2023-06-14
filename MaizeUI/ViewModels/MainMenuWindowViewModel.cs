using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Maize;
using Maize.Services;
using Maize.Models.ApplicationSpecific;
using MaizeUI.Views;
using ReactiveUI;
using System.Reactive;

namespace MaizeUI.ViewModels
{
    public class MainMenuWindowViewModel : ViewModelBase
    {
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

        public MainMenuWindowViewModel()
        {
            FindNftDataFromAWalletCommand = ReactiveCommand.Create(FindNftDataFromAWallet);
            FindNftDataFromACollectionCommand = ReactiveCommand.Create(FindNftDataFromACollection);
            FindHoldersFromNftDataCommand = ReactiveCommand.Create(FindHoldersFromNftData);
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
    }

}
