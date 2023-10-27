using Avalonia.Controls.ApplicationLifetimes;
using Maize;
using Maize.Models.ApplicationSpecific;
using MaizeUI.Views;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using System.Reactive;
using Maize.Helpers;
using Avalonia.Controls;
using Maize.Services;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MaizeUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; set; }
        public string Version { get; set; }
        public string Slogan { get; set; }

        public List<string> Networks { get; set; } 

        public string selectedNetwork;

        public string SelectedNetwork
        {
            get => selectedNetwork;
            set => this.RaiseAndSetIfChanged(ref selectedNetwork, value);
        }

        public ReactiveCommand<Unit, Unit> VerifyAppSettingsCommand { get; }
        public ReactiveCommand<Unit, Unit> RefreshAppSettingsCommand { get; }
        public ReactiveCommand<Unit, Unit> HelpFileCommand { get; }

        public MainWindowViewModel()
        {
            Greeting = "Welcome to Maize!";
            Version = "v1.9.0";
            Slogan = "Cornveniently Manage your NFTs";
            Networks = new List<string> { "👇 choose", "💎 mainnet", "🧪 testnet" };
            SelectedNetwork = Networks[0];
            VerifyAppSettingsCommand = ReactiveCommand.Create(VerifyAppSettings);
            RefreshAppSettingsCommand = ReactiveCommand.Create(RefreshAppSettings);
            HelpFileCommand = ReactiveCommand.Create(HelpFile);
        }


        private async Task<(Settings, string)> LoadSettings(string network)
        {
            string appSettingsEnvironment = $"{Constants.BaseDirectory}{Constants.EnvironmentPath}{network}appsettings.json";
            IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile(appSettingsEnvironment)
               .AddEnvironmentVariables()
               .Build();
            return (config.GetRequiredSection("Settings").Get<Settings>(), appSettingsEnvironment);
        }

        private async Task ShowNoticeDialog(string notice, string location, string url)
        {
            var dialog = new AppsettingsNoticeWindow();
            dialog.DataContext = new AppsettingsNoticeWindowViewModel
            {
                Notice = notice,
                Location = location,
                LoopringService = new LoopringServiceUI(url),
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Avalonia.Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }

        private async void VerifyOrRefreshAppSettings(bool isVerify)
        {
            if (selectedNetwork == Networks[0]) return;

            string network = selectedNetwork.Remove(0, 3);
            (Settings settings, string appSettingsEnvironment) = await LoadSettings(network);
            var environment = Constants.GetNetworkConfig(settings.Environment);


            if (isVerify)
            {
                // Verification-specific logic
                if (settings.LoopringAccountId == 1234 || settings.LoopringApiKey == "asdfasdfasdfasdfasdfasdf")
                {
                    await ShowNoticeDialog("Issue with Loopring account information", appSettingsEnvironment, environment.Url);
                    return;
                }

                // More verification logic, like API calls
                ILoopringService loopringService = new LoopringServiceUI(environment.Url);
                // Assume you have a method to do the signing
                string signedMessage = EDDSAHelper.EddsaSignUrl(settings.LoopringPrivateKey, HttpMethod.Get, new List<(string Key, string Value)>() { ("accountId", settings.LoopringAccountId.ToString()) }, null, "api/v3/apiKey", environment.Url);

                var apiKey = await loopringService.GetApiKey(settings.LoopringAccountId, signedMessage);
                if (apiKey != settings.LoopringApiKey)
                {
                    await ShowNoticeDialog("Issue with Loopring account information", appSettingsEnvironment, environment.Url);
                    return;
                }
                var ensResult = await loopringService.GetLoopringEns(settings.LoopringApiKey, settings.LoopringAddress);
                string ens = ensResult.data != "" ? $"🙋‍♂ {ensResult.data}" : $"🙋‍♂️ {settings.LoopringAddress.Substring(0, 6) + "..." + settings.LoopringAddress.Substring(settings.LoopringAddress.Length - 4)}!";
                // If all checks pass, proceed to show the main menu
                ShowMainMenuDialog(settings, environment, selectedNetwork, Version, Slogan, ens);
            }
            else
            {
                // Refresh-specific logic
                await ShowNoticeDialog("Read the Below to setup the application.", appSettingsEnvironment, environment.Url);
            }
        }

        // Your existing VerifyAppSettings and RefreshAppSettings would then simply call VerifyOrRefreshAppSettings with the appropriate boolean flag.
        private async void VerifyAppSettings()
        {
            VerifyOrRefreshAppSettings(true);
        }

        private async void RefreshAppSettings()
        {
            VerifyOrRefreshAppSettings(false);
        }
        private void ShowMainMenuDialog(Settings settings, Constants.Environment environment, string selectedNetwork, string version, string slogan, string ens)
        {
            var dialog = new MainMenuWindow();
            dialog.DataContext = new MainMenuWindowViewModel
            {
                Ens = ens,
                Slogan = slogan,
                Version = version,
                Settings = settings,
                Environment = environment,
                SelectedNetwork = selectedNetwork
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            var mainWindow = (Avalonia.Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow;
            (Avalonia.Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow = dialog;
            dialog.Show();
            mainWindow.Close();
        }
        private void HelpFile()
        {
            string url = "https://maizehelps.art/docs";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
            }
        }
    }
}
