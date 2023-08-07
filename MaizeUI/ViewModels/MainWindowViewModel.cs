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
using Nethereum.Signer.EIP712;
using Avalonia.Media.TextFormatting.Unicode;
using Maize.Services;

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

        public MainWindowViewModel()
        {
            Greeting = "Welcome to Maize!";
            Version = "v1.2.0";
            Slogan = "Cornveniently Manage your NFTs";
            Networks = new List<string> { "👇 choose", "💎 mainnet", "🧪 testnet" };
            SelectedNetwork = Networks[0];
            VerifyAppSettingsCommand = ReactiveCommand.Create(VerifyAppSettings);
            RefreshAppSettingsCommand = ReactiveCommand.Create(RefreshAppSettings);
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
                    await ShowAppSettingsDialog($"Read the Below to setup the application. Further help at https://maizehelps.art/docs/tutorials/setup-maize.", appSettingsEnvironment, environment);
                }
                else
                {
                    ILoopringService loopringService = new LoopringServiceUI(environment.Url);
                    string signedMessage;
                    do
                    {
                        signedMessage = EDDSAHelper.EddsaSignUrl(settings.LoopringPrivateKey, HttpMethod.Get, new List<(string Key, string Value)>() { ("accountId", settings.LoopringAccountId.ToString()) }, null, "api/v3/apiKey", environment.Url);
                        if (signedMessage == "The value could not be parsed.")
                        {
                            await ShowAppSettingsDialog($"There was an issue with your Loopring account information. Further help at https://maizehelps.art/docs/tutorials/setup-maize.", appSettingsEnvironment, environment);
                            appSettingsEnvironment = $"{Constants.BaseDirectory}{Constants.EnvironmentPath}{network}appsettings.json";
                            config = new ConfigurationBuilder()
                           .AddJsonFile(appSettingsEnvironment)
                           .AddEnvironmentVariables()
                           .Build();
                            settings = config.GetRequiredSection("Settings").Get<Settings>();
                        }
                    } while (signedMessage == "The value could not be parsed.");

                    var apiKey = await loopringService.GetApiKey(settings.LoopringAccountId, signedMessage);
                    if (apiKey != settings.LoopringApiKey)
                    {
                        await ShowAppSettingsDialog($"There was an issue with your Loopring account information. Further help at https://maizehelps.art/docs/tutorials/setup-maize.", appSettingsEnvironment, environment);
                        appSettingsEnvironment = $"{Constants.BaseDirectory}{Constants.EnvironmentPath}{network}appsettings.json";
                        config = new ConfigurationBuilder()
                       .AddJsonFile(appSettingsEnvironment)
                       .AddEnvironmentVariables()
                       .Build();
                        settings = config.GetRequiredSection("Settings").Get<Settings>();
                    }
                    else
                    {
                        //var test = await loopringService.RefreshNft();
                        var ensResult = await loopringService.GetLoopringEns(settings.LoopringApiKey, settings.LoopringAddress);
                        string ens = ensResult.data != "" ? $"🙋‍♂ {ensResult.data}" : $"🙋‍♂️ {settings.LoopringAddress.Substring(0, 6) + "..." + settings.LoopringAddress.Substring(settings.LoopringAddress.Length - 4)}!";
                        ShowMainMenuDialog(settings, environment, selectedNetwork, Version, Slogan, ens);
                    }
                }
            }
        }
        private async void RefreshAppSettings()
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
                //if (settings.LoopringAccountId == 1234 || settings.LoopringApiKey == "asdfasdfasdfasdfasdfasdf")
                //{
                await ShowAppSettingsDialog($"Read the Below to setup the application. Further help at https://maizehelps.art/docs/tutorials/setup-maize.", appSettingsEnvironment, environment);
                //}
                //else
                //{
                //    ILoopringService loopringService = new LoopringService(environment.Url);
                //    string signedMessage;
                //    do
                //    {
                //        signedMessage = EDDSAHelper.EddsaSignUrl(settings.LoopringPrivateKey, HttpMethod.Get, new List<(string Key, string Value)>() { ("accountId", settings.LoopringAccountId.ToString()) }, null, "api/v3/apiKey", environment.Url);
                //        if (signedMessage == "The value could not be parsed.")
                //        {
                //            await ShowAppSettingsDialog($"There was an issue with your Loopring account information. Further help at https://maizehelps.art/docs/tutorials/setup-maize.", $"{appSettingsEnvironment}");
                //            appSettingsEnvironment = $"{Constants.BaseDirectory}{Constants.EnvironmentPath}{network}appsettings.json";
                //            config = new ConfigurationBuilder()
                //           .AddJsonFile(appSettingsEnvironment)
                //           .AddEnvironmentVariables()
                //           .Build();
                //            settings = config.GetRequiredSection("Settings").Get<Settings>();
                //        }
                //    } while (signedMessage == "The value could not be parsed.");

                //    var apiKey = await loopringService.GetApiKey(settings.LoopringAccountId, signedMessage);
                //    if (apiKey != settings.LoopringApiKey)
                //    {
                //        await ShowAppSettingsDialog($"There was an issue with your Loopring account information. Further help at https://maizehelps.art/docs/tutorials/setup-maize.", $"{appSettingsEnvironment}");
                //        appSettingsEnvironment = $"{Constants.BaseDirectory}{Constants.EnvironmentPath}{network}appsettings.json";
                //        config = new ConfigurationBuilder()
                //       .AddJsonFile(appSettingsEnvironment)
                //       .AddEnvironmentVariables()
                //       .Build();
                //        settings = config.GetRequiredSection("Settings").Get<Settings>();
                //    }
                //    else
                //    {
                //        var ensResult = await loopringService.GetLoopringEns(settings.LoopringApiKey, settings.LoopringAddress);
                //        string ens = ensResult.data != "" ? $"🙋‍♂ {ensResult.data}" : $"🙋‍♂️ {settings.LoopringAddress.Substring(0, 6) + "..." + settings.LoopringAddress.Substring(settings.LoopringAddress.Length - 4)}!";
                //        ShowMainMenuDialog(settings, environment, selectedNetwork, Version, Slogan, ens);
                //    }
                //}
            }
        }

        private async Task ShowAppSettingsDialog(string notice, string location, Constants.Environment environment)
        {
            var dialog = new AppsettingsNoticeWindow();
            dialog.DataContext = new AppsettingsNoticeWindowViewModel
            {
                Notice = notice,
                Location = location,
                LoopringService = new LoopringServiceUI(environment.Url),
            };
            dialog.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);
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
            var mainWindow = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow;
            (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow = dialog;
            dialog.Show();
            mainWindow.Close();
        }
    }
}
