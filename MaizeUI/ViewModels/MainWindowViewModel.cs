using Avalonia.Controls.ApplicationLifetimes;
using Maize;
using Maize.Models.ApplicationSpecific;
using MaizeUI.Views;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using Avalonia;
using Maize.Helpers;
using System.Net.Http;
using static Maize.Models.ApplicationSpecific.Constants;
using System.Threading.Tasks;
using Avalonia.Controls;

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

        public MainWindowViewModel()
        {
            Greeting = "Welcome to Maize!";
            Version = "v1.0.2";
            Slogan = "Cornveniently Manage your NFTs";
            Networks = new List<string> { "👇 choose", "💎 mainnet", "🧪 testnet" };
            SelectedNetwork = Networks[0];
            VerifyAppSettingsCommand = ReactiveCommand.Create(VerifyAppSettings);
        }


        private async void VerifyAppSettings()
        {
            if (selectedNetwork != Networks[0])
            {
                var network = selectedNetwork.Remove(0, 3);
                string appSettingsEnvironment = $"{Constants.BaseDirectory}{Constants.EnvironmentPath}{network}appsettings.json";
                IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile(appSettingsEnvironment)
               .AddEnvironmentVariables()
               .Build();
                Settings settings = config.GetRequiredSection("Settings").Get<Settings>();
                var environment = Constants.GetNetworkConfig(settings.Environment);
                if (settings.LoopringAccountId == 1234 || settings.LoopringApiKey == "asdfasdfasdfasdfasdfasdf")
                {
                    await ShowAppSettingsDialog($"Please verify that your {network}appsettings.json is correct. Located at: ", $"{appSettingsEnvironment}");
                }
                else
                {
                    ILoopringService loopringService = new LoopringService(environment.Url);
                    var signedMessage = EDDSAHelper.EddsaSignUrl(settings.LoopringPrivateKey, HttpMethod.Get, new List<(string Key, string Value)>() { ("accountId", settings.LoopringAccountId.ToString()) }, null, "api/v3/apiKey", environment.Url);
                    var apiKey = await loopringService.GetApiKey(settings.LoopringAccountId, signedMessage);
                    if (apiKey != settings.LoopringApiKey)
                    {
                        await ShowAppSettingsDialog($"Please verify that your {network}appsettings.json is correct. Located at: ", $"{appSettingsEnvironment}");
                    }
                    else
                    {
                        ShowMainMenuDialog(settings, environment, selectedNetwork, Version, Slogan);
                    }
                }
            }
        }

        private async Task ShowAppSettingsDialog(string notice, string location)
        {
            var dialog = new AppsettingsNoticeWindow();
            dialog.DataContext = new AppsettingsNoticeWindowViewModel
            {
                Notice = notice,
                Location = location
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
        }

        private void ShowMainMenuDialog(Settings settings, Constants.Environment environment, string selectedNetwork, string version, string slogan)
        {
            var dialog = new MainMenuWindow();
            dialog.DataContext = new MainMenuWindowViewModel
            {
                Slogan = slogan,
                Version = version,
                Settings = settings,
                Environment = environment,
                SelectedNetwork = selectedNetwork
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            var mainWindow = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow;
            (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow = dialog;
            dialog.Show();
            mainWindow.Close();
        }
    }
}
