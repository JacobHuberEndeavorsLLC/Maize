using Avalonia.Controls.ApplicationLifetimes;
using Maize;
using Maize.Models.ApplicationSpecific;
using MaizeUI.Views;
using Avalonia;
using ReactiveUI;
using System.Reactive;
using Maize.Helpers;
using Avalonia.Controls;
using Maize.Services;
using MaizeUI.Helpers;
using System.Collections.ObjectModel;
using Splat;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MaizeUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private HttpClient _httpClient = new HttpClient();
        public string DownloadUrl { get; private set; }
        public bool IsUpdateAvailable { get; private set; }

        public string DownloadUrlMac { get; private set; }
        public string DownloadUrlWindows { get; private set; }
        private readonly IDialogService _dialogService;
        private readonly AccountService _accountService;
        private string _password;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }
        private string _invalidPasswordMessage;
        public string InvalidPasswordMessage
        {
            get => _invalidPasswordMessage;
            set => this.RaiseAndSetIfChanged(ref _invalidPasswordMessage, value);
        }
        private bool _isMainnetSelected;
        public bool IsMainnetSelected
        {
            get => _isMainnetSelected;
            set
            {
                this.RaiseAndSetIfChanged(ref _isMainnetSelected, value);
                _accountService.ChangeNetwork(_isMainnetSelected ? "💎 main" : "🧪 test");
                this.RaisePropertyChanged(nameof(SelectedNetwork));
                SelectedAccount = _accountService.Accounts.FirstOrDefault();
            }
        }

        public string Greeting { get; set; } = "Welcome to Maize!";
        public string Version { get; set; } = "v1.15.2";
        public string Slogan { get; set; } = "Cornveniently Manage your NFTs";
        public List<string> Networks => _accountService.Networks;
        public ObservableCollection<string> Accounts => _accountService.Accounts;

        public string SelectedNetwork
        {
            get => _accountService.SelectedNetwork;
            set
            {
                _accountService.SelectedNetwork = value;
                this.RaisePropertyChanged(nameof(SelectedNetwork));
            }
        }
        public string SelectedAccount
        {
            get => _accountService.SelectedAccount;
            set
            {
                if (_accountService.SelectedAccount != value)
                {
                    _accountService.SelectedAccount = value;
                    this.RaisePropertyChanged(nameof(SelectedAccount));
                }
            }
        }

        public ReactiveCommand<Unit, Unit> VerifyAppSettingsCommand { get; }
        public ReactiveCommand<Unit, Unit> CreateAppSettingsCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteAccountCommand { get; }
        public ReactiveCommand<Unit, Unit> OpenDownloadUrlCommand { get; }
        public ReactiveCommand<Unit, Unit> HelpFileCommand { get; }

        public MainWindowViewModel(AccountService accountService, IDialogService dialogService)
        {
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Maize");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");

            _accountService = accountService;
            _dialogService = dialogService;

            // Subscribe to account list updates
            _accountService.OnAccountsUpdated += () =>
            {
                this.RaisePropertyChanged(nameof(Accounts));
                // Update selected account if it's null
                SelectedAccount = SelectedAccount ?? Accounts.FirstOrDefault();
                this.RaisePropertyChanged(nameof(SelectedAccount));
            };
            _accountService.AccountsListUpdated += OnAccountsListUpdated;
            // Initialize ReactiveCommands
            OpenDownloadUrlCommand = ReactiveCommand.Create(OpenDownloadUrl);
            VerifyAppSettingsCommand = ReactiveCommand.Create(VerifyAppSettings);
            CreateAppSettingsCommand = ReactiveCommand.Create(CreateAppSettings);
            DeleteAccountCommand = ReactiveCommand.Create(DeleteSelectedAccount);
            HelpFileCommand = ReactiveCommand.Create(HelpFile);

            // Set initial values
            Greeting = "Welcome to Maize!";
            Slogan = "Cornveniently Manage your NFTs";
            IsMainnetSelected = true;

            // Set initial selected account
            SelectedAccount = _accountService.SelectedAccount ?? Accounts.FirstOrDefault();

            FetchDownloadUrls();
        }
        private async void FetchDownloadUrls()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://api.github.com/repos/cobmin/maize/releases");
                var releases = JArray.Parse(response);
                var latestRelease = releases.First;
                var latestVersion = latestRelease?["tag_name"]?.Value<string>();

                if (latestVersion != Version)
                {
                    foreach (var asset in latestRelease["assets"])
                    {
                        var name = asset["name"].ToString();
                        if (name == "osx-x64.zip")
                        {
                            DownloadUrlMac = asset["browser_download_url"].ToString();
                        }
                        else if (name == "win-x64.zip")
                        {
                            DownloadUrlWindows = asset["browser_download_url"].ToString();
                        }
                    }

                    ShowRelevantDownloadUrl();
                    IsUpdateAvailable = true;
                    this.RaisePropertyChanged(nameof(IsUpdateAvailable));
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        private void ShowRelevantDownloadUrl()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                DownloadUrl = DownloadUrlMac;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                DownloadUrl = DownloadUrlWindows;
            }
        }
        private async Task DownloadFileAsync(string downloadUrl, string localPath)
        {
            using (var httpResponse = await _httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                httpResponse.EnsureSuccessStatusCode();

                using (var localFileStream = File.Create(localPath))
                using (var contentStream = await httpResponse.Content.ReadAsStreamAsync())
                {
                    await contentStream.CopyToAsync(localFileStream);
                }
            }
        }
        private void StartUpdaterTool(string localPath)
        {
            string updaterToolPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater.exe");

            var startInfo = new ProcessStartInfo
            {
                FileName = updaterToolPath,
                Arguments = $"\"{localPath}\"",
                UseShellExecute = true
            };

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                // Log or display the exception
                Console.WriteLine("Error starting updater: " + ex.Message);
            }


            // Exit the current application to allow the updater to replace files
            Environment.Exit(0);
        }

        private async void OpenDownloadUrl()
        {
            // Check the OS platform
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var psi = new ProcessStartInfo
                {
                    FileName = DownloadUrl, // Use the URL for the macOS download
                    UseShellExecute = true
                };
                Process.Start(psi);

                //// Define the local path where you want to save the file
                //var localPath = Path.Combine(Path.GetTempPath(), "update.zip");

                //// Call the method to download the file
                //await DownloadFileAsync(DownloadUrl, localPath);

                //// Start the updater tool
                //StartUpdaterTool(localPath);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // For macOS users, simply open the URL in the browser
                var psi = new ProcessStartInfo
                {
                    FileName = DownloadUrlMac, // Use the URL for the macOS download
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
        }
        private void DeleteSelectedAccount()
        {
            if (!string.IsNullOrEmpty(SelectedAccount))
            {
                _accountService.DeleteAccount(SelectedAccount);
            }
        }
        private void OnAccountsListUpdated(string newSelectedAccount)
        {
            SelectedAccount = newSelectedAccount;
            this.RaisePropertyChanged(nameof(SelectedAccount));
        }
        private async void VerifyAppSettings()
        {
            await VerifyOrCreateAppSettings(true);
        }

        private async void CreateAppSettings()
        {
            await VerifyOrCreateAppSettings(false);
        }

        private void HelpFile()
        {
            Maize.Helpers.Things.OpenUrl("https://maizehelps.art/docs");
        }
        public async Task ShowNoticeDialog(string notice, string location, string url)
        {
            var viewModel = new AppsettingsNoticeWindowViewModel(notice, location, new LoopringServiceUI(url), _accountService);
            viewModel.OnSettingsFileSaved += (newAccountAddress) => _accountService.RefreshAccountsList(newAccountAddress);

            var dialog = new AppsettingsNoticeWindow();
            dialog.DataContext = viewModel;

            viewModel.RequestClose += () => dialog.Close();

            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);

            viewModel.OnSettingsFileSaved -= _accountService.RefreshAccountsList;
            viewModel.RequestClose -= () => dialog.Close();
        }
        private async Task VerifyOrCreateAppSettings(bool isVerify)
        {
            if (isVerify)
            {
                (Settings settings, string appSettingsEnvironment) = await _accountService.LoadSettings(_password);
                if (SelectedAccount == _accountService.Accounts[0]) return;
                if (string.IsNullOrEmpty(appSettingsEnvironment))
                {
                    InvalidPasswordMessage = "Invalid password...";
                    return;
                }
                InvalidPasswordMessage = "";
                var environment = Constants.GetNetworkConfig(settings.Environment);
                ILoopringService loopringService = new LoopringServiceUI(environment.Url);
                string signedMessage = EDDSAHelper.EddsaSignUrl(settings.LoopringPrivateKey, HttpMethod.Get, new List<(string Key, string Value)>() { ("accountId", settings.LoopringAccountId.ToString()) }, null, "api/v3/apiKey", environment.Url);

                var apiKey = await loopringService.GetApiKey(settings.LoopringAccountId, signedMessage);
                if (apiKey != settings.LoopringApiKey)
                {
                    await ShowNoticeDialog("Issue with Loopring account information", appSettingsEnvironment, environment.Url);
                    return;
                }
                var ensResult = await loopringService.GetLoopringEns(settings.LoopringApiKey, settings.LoopringAddress);
                string ens = ensResult.data != "" ? $"🙋‍♂ {ensResult.data}" : $"🙋‍♂️ {settings.LoopringAddress.Substring(0, 6) + "..." + settings.LoopringAddress.Substring(settings.LoopringAddress.Length - 4)}";
                ShowMainMenuDialog(settings, environment, SelectedNetwork, Version, Slogan, ens);
            }
            else
            {
                var environmentNumber = _accountService.ExtractNetworkType(SelectedNetwork) == "main" ? 1 : 5;
                var environment = Constants.GetNetworkConfig(environmentNumber);
                await ShowNoticeDialog($"Read the Below to setup an Account on the {SelectedNetwork}net.", null, environment.Url);
                _accountService.LoadAccounts();
            }
        }

        private Window _originalMainWindow;
        private Window _mainMenuWindow;

        private void ShowMainMenuDialog(Settings settings, Constants.Environment environment, string selectedNetwork, string version, string slogan, string ens)
        {
            // Ensure _originalMainWindow is set to the current MainWindow
            _originalMainWindow = (Avalonia.Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow;

            // Check if _originalMainWindow is not null
            if (_originalMainWindow != null)
            {
                _mainMenuWindow = new MainMenuWindow();
                _mainMenuWindow.DataContext = new MainMenuWindowViewModel(() => Logout(), new DialogService(), _mainMenuWindow, _accountService, _password, settings, new LoopringServiceUI(environment.Url))
                {
                    Ens = ens,
                    Slogan = slogan,
                    Version = version,
                    SelectedNetwork = selectedNetwork,
                };
                _mainMenuWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                _mainMenuWindow.Show();

                // Now hide the original main window
                _originalMainWindow.Hide();
            }
            else
            {
                // Handle the case where _originalMainWindow is null
                // For example, you might log an error or show a message to the user
            }
        }

        public void Logout()
        {
            // Close the MainMenuWindow.
            _mainMenuWindow?.Close();
            _originalMainWindow.Show();
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = _originalMainWindow;
            }
        }

    }
}
