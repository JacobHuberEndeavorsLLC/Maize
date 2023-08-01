using Maize;
using Maize.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReactiveUI;
using static Maize.Models.ApplicationSpecific.Constants;
using System.Reactive;
using System.Text;
using Maize.Models.ApplicationSpecific;

namespace MaizeUI.ViewModels
{
    public class AppsettingsNoticeWindowViewModel : ViewModelBase
    {
        public string notice;
        public string location;
        public string l1Key;

        public string Notice
        {
            get => notice;
            set => this.RaiseAndSetIfChanged(ref notice, value);
        }
        public string Location
        {
            get => location;
            set => this.RaiseAndSetIfChanged(ref location, value);
        }
        public string L1Key
        {
            get => l1Key;
            set => this.RaiseAndSetIfChanged(ref l1Key, value);
        }
        public string log;

        public string Log
        {
            get => log;
            set => this.RaiseAndSetIfChanged(ref log, value);
        }
        public bool isEnabled = true;
        public bool IsEnabled
        {
            get => isEnabled;
            set => this.RaiseAndSetIfChanged(ref isEnabled, value);
        }

        public ReactiveCommand<Unit, Unit> SetupApsettingsFileCommand { get; }

        public AppsettingsNoticeWindowViewModel()
        {
            Notice = "Here you will create an Input file for airdrops that have the same Crypto Amount and Memo. This can be modified after as needed.";
            Log = $"Paste Account Information from Loopring.io > Avatar > Security > Export Account here and the L1 Private Key below.\r\n\r\n Example:\r\n{{\r\n    \"address\": \"0x1fdfef87d387e4basdjfhtyghtugh19cff06a982\",\r\n    \"accountId\": 11233,\r\n    \"level\": \"\",\r\n    \"nonce\": 1,\r\n    \"apiKey\": \"miWgX3jDo5zubs1VwYrPShtF5ythgnbhggmczTOwzUrS280AaNtf6v8CuVmwfP4f\",\r\n    \"publicX\": \"0x12167dbhguty675ud3c11bae8a343c138cfc2574349235688ae2d6ce68320ac8\",\r\n    \"publicY\": \"0x1d7e0c7d92b894dc27943a0fghtyghvnfjb0db0dbcc47d42f2914d9b00b84fd3\",\r\n    \"privateKey\": \"0x2ad857be54b8d02badc842ac54e25f5ythgjt0pol50331cc4894509c09f255b\"\r\n}}\r\n";
            SetupApsettingsFileCommand = ReactiveCommand.Create(SetupApsettingsFile);
        }
        private async void SetupApsettingsFile()
        {
            IsEnabled = false;
            string jsonString = log;
            WalletDetails walletDetails = JsonConvert.DeserializeObject<WalletDetails>(jsonString);
            string appSettingsEnvironment = location;
            RootObject settings = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(appSettingsEnvironment));
            var layerOneKey = l1Key;

            settings.Settings.LoopringAccountId = (int)walletDetails.AccountId;
            settings.Settings.LoopringAddress = walletDetails.Address;
            settings.Settings.LoopringApiKey = walletDetails.ApiKey;
            settings.Settings.LoopringPrivateKey = walletDetails.PrivateKey;
            settings.Settings.MMorGMEPrivateKey = layerOneKey;

            string updatedJsonString = JsonConvert.SerializeObject(settings);

            await File.WriteAllTextAsync(location, updatedJsonString);
            Notice = "Done!";
            Log = "Close this window and click the check mark on the Menu again.";
            L1Key = " ";

        }
    }
}
