
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Maize;
using Maize.Models.ApplicationSpecific;
using MaizeUI.Views;
using ReactiveUI;
using System.Reactive;

namespace MaizeUI.ViewModels
{
    public class MainMenuWindowViewModel : ViewModelBase
    {
        public string Slogan { get; set; }
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

        public MainMenuWindowViewModel()
        {
            Slogan = "Cornveniently Manage your NFTs";
            FindNftDataFromAWalletCommand = ReactiveCommand.Create(FindNftDataFromAWallet);
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
    }

}
