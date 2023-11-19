using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using Maize;
using Maize.Models.ApplicationSpecific;
using Maize.Services;
using MaizeUI.ViewModels;
using MaizeUI.Views;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using Nethereum.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace MaizeUI.Helpers
{
    public class AccountService
    {
        public event Action OnAccountsUpdated;
        public event Action<string> AccountsListUpdated;
        public List<string> Networks { get; private set; }
        public ObservableCollection<string> Accounts { get; private set; }
        public List<string> MainnetAccounts { get; private set; }
        public List<string> TestnetAccounts { get; private set; }
        private string _selectedNetwork;
        public string SelectedNetwork
        {
            get => _selectedNetwork;
            set
            {
                if (_selectedNetwork != value)
                {
                    _selectedNetwork = value;
                    LoadAccounts();
                    OnAccountsUpdated?.Invoke();
                }
            }
        }

        public AccountService()
        {
            Networks = new List<string> { "💎 main", "🧪 test" };
            Accounts = new ObservableCollection<string> { "👇 choose" };
            MainnetAccounts = new List<string>();
            TestnetAccounts = new List<string>();

            LoadAccounts();
        }
        private string _selectedAccount;
        public string SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                if (_selectedAccount != value)
                {
                    _selectedAccount = value;
                    OnAccountsUpdated?.Invoke();
                }
            }
        }
        public void LoadAccounts()
        {
            MainnetAccounts.Clear();
            TestnetAccounts.Clear();

            try
            {
                var files = Directory.GetFiles(Constants.BaseDirectory + Constants.EnvironmentPath);
                foreach (var file in files)
                {
                    var filename = Path.GetFileNameWithoutExtension(file);
                    var parts = filename.Split('_');
                    if (parts.Length >= 2)
                    {
                        var address = FormatFileName(parts[0]);
                        if (filename.Contains("_main"))
                        {
                            MainnetAccounts.Add(address);
                        }
                        else if (filename.Contains("_test"))
                        {
                            TestnetAccounts.Add(address);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
            }
            UpdateAccountsList();
        }


        public void DeleteAccount(string accountAddress)
        {
            string fullFileName = FindFullFileName(accountAddress);

            if (fullFileName != null)
            {
                try
                {
                    File.Delete(fullFileName);
                    Accounts.Remove(accountAddress);

                    // Invoke update event
                    AccountsListUpdated?.Invoke(Accounts.FirstOrDefault());
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., file access issues, file not found, etc.)
                }
            }
            else
            {
                // Handle the case where the file is not found or accountAddress is invalid
            }
        }
        public async Task CreateNewAccountAsync(RootObject settings, string userPassword)
        {
            var environment = settings.Settings.Environment == 1 ? "_main" : "_test";
            string updatedJsonString = JsonConvert.SerializeObject(settings);
            string encryptedContent = Encryption.EncryptString(updatedJsonString, userPassword);
            await File.WriteAllTextAsync(Constants.BaseDirectory + Constants.EnvironmentPath + settings.Settings.LoopringAddress + $"{environment}.json", encryptedContent);
            UpdateSelectedAccount(settings.Settings.LoopringAddress);

            // Refresh the accounts list
            RefreshAccountsList(settings.Settings.LoopringAddress);
        }
        public RootObject SetupL2(string log, string location)
        {
            string jsonString = log.Trim();
            if ((jsonString.StartsWith("{") && jsonString.EndsWith("}")) || (jsonString.StartsWith("[") && jsonString.EndsWith("]")))
            {
                WalletDetails walletDetails = JsonConvert.DeserializeObject<WalletDetails>(jsonString);
                //string appSettingsEnvironment = location.Replace("PLACEHOLDER", walletDetails.Address.ToString());
                //EnsureAppSettingsFile(appSettingsEnvironment);
                var environment = _selectedNetwork.Contains("main") == true ? 1 : 5;
                RootObject settings = new RootObject
                {
                    Settings = new Settings
                    {
                        LoopringApiKey = "default_api_key", // Replace with default or empty value
                        LoopringPrivateKey = "default_private_key", // Replace with default or empty value
                        LoopringAddress = "default_address", // Replace with default or empty value
                        LoopringAccountId = 0, // Replace with default or empty value
                        Environment = environment, // Adjust if needed
                        MMorGMEPrivateKey = "default_private_key" // Replace with default or empty value
                    }
                };

                settings.Settings.LoopringAccountId = (int)walletDetails.AccountId;
                settings.Settings.LoopringAddress = walletDetails.Address;
                settings.Settings.LoopringApiKey = walletDetails.ApiKey;
                settings.Settings.LoopringPrivateKey = walletDetails.PrivateKey;

                return settings;
            }

            return null;
        }
        public async Task<(Settings, string)> LoadSettings(string userPassword)
        {
            string appSettingsEnvironment = $"{FindFullFileName(SelectedAccount)}";
            try
            {
                string encryptedContent = await File.ReadAllTextAsync(appSettingsEnvironment);
                string decryptedContent = Encryption.DecryptString(encryptedContent, userPassword);

                IConfiguration config = new ConfigurationBuilder()
                    .AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(decryptedContent)))
                    .AddEnvironmentVariables()
                    .Build();

                return (config.GetRequiredSection("Settings").Get<Settings>(), appSettingsEnvironment);
            }
            catch (Exception)
            {
                // Handle exceptions (e.g., decryption failure, file not found, etc.)
                return (null, null);
            }
        }
        public async Task<(Settings, string)> LoadMainSettingsForPremium(string userPassword, string account)
        {
            string appSettingsEnvironment = FindFullFileName(account, "main");
            try
            {
                string encryptedContent = await File.ReadAllTextAsync(appSettingsEnvironment);
                string decryptedContent = Encryption.DecryptString(encryptedContent, userPassword);

                IConfiguration config = new ConfigurationBuilder()
                    .AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(decryptedContent)))
                    .AddEnvironmentVariables()
                    .Build();

                return (config.GetRequiredSection("Settings").Get<Settings>(), appSettingsEnvironment);
            }
            catch (Exception)
            {
                // Handle exceptions (e.g., decryption failure, file not found, etc.)
                return (null, null);
            }
        }
        private string FindFullFileName(string shortenedAddress, string networkType = null)
        {
            string directoryPath = Constants.BaseDirectory + Constants.EnvironmentPath;
            if (!string.IsNullOrEmpty(shortenedAddress))
            {
                string startPattern = shortenedAddress.Substring(0, 6);
                string endPattern = shortenedAddress.Substring(shortenedAddress.Length - 4);
                string network = networkType ?? ExtractNetworkType(SelectedNetwork);

                try
                {
                    return Directory.GetFiles(directoryPath, $"{startPattern}*{endPattern}_{network}.json").First();
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                }
            }

            return null;
        }

        public void RefreshAccountsList(string newAccountAddress = null)
        {
            LoadAccounts(); // Load accounts if not already done elsewhere

            if (!string.IsNullOrEmpty(newAccountAddress))
            {
                // Ensure the new account exists in the list, this will also raise the OnAccountsUpdated event
                UpdateSelectedAccount(newAccountAddress);
                newAccountAddress = FormatFileName(newAccountAddress);
                // Set the SelectedAccount to the new account if it exists in the list
                if (Accounts.Contains(newAccountAddress))
                {
                    SelectedAccount = newAccountAddress;
                }
            }

            // If newAccountAddress is null, doesn't exist in the list, or the account list is empty, select the first account
            if (string.IsNullOrEmpty(SelectedAccount) || !Accounts.Contains(SelectedAccount))
            {
                SelectedAccount = Accounts.FirstOrDefault();
            }
            AccountsListUpdated?.Invoke(SelectedAccount);
        }

        public void UpdateSelectedAccount(string newAccountAddress)
        {
            string lastFourChars = newAccountAddress.Substring(newAccountAddress.Length - 4);
            var matchingAccount = TestnetAccounts.FirstOrDefault(acc => acc.EndsWith(lastFourChars));
            if (matchingAccount != null)
            {
                SelectedAccount = matchingAccount;
                OnAccountsUpdated?.Invoke();
            }
            else
                OnAccountsUpdated?.Invoke();
        }

        private void UpdateAccountsList()
        {
            Accounts.Clear();
            Accounts.Add("👇 choose");

            var currentAccounts = SelectedNetwork == "💎 main" ? MainnetAccounts : TestnetAccounts;
            foreach (var account in currentAccounts)
            {
                Accounts.Add(account);
            }
            OnAccountsUpdated?.Invoke();
        }

        public void ChangeNetwork(string network)
        {
            SelectedNetwork = network;
            LoadAccounts();
            UpdateAccountsList();
            // Optionally, notify if needed
            OnAccountsUpdated?.Invoke();
        }

        public string FormatFileName(string address)
        {
            if (address.Length > 12)
            {
                return address.Substring(0, 6) + "..." + address.Substring(address.Length - 4);
            }
            return address;
        }
        public string ExtractNetworkType(string networkString)
        {
            // Split the string by space and return the last part
            var parts = networkString.Split(' ');
            return parts.Length > 1 ? parts[parts.Length - 1] : string.Empty;
        }
    }
}
