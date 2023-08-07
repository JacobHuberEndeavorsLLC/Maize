using Maize;
using Maize.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReactiveUI;
using static Maize.Models.ApplicationSpecific.Constants;
using System.Reactive;
using System.Text;
using Maize.Models.ApplicationSpecific;
using Maize.Services;
using Maize.Models.Responses;
using System.Security.Cryptography;
using LoopringSmartWalletRecoveryPhraseExtractor;
using NBitcoin.Secp256k1;
using System;
using OpenCvSharp;
using Nethereum.HdWallet;
using Avalonia.Media.TextFormatting.Unicode;

namespace MaizeUI.ViewModels
{
    public class AppsettingsNoticeWindowViewModel : ViewModelBase
    {
        WalletTypeResponse walletType;

        public string notice;
        public string location;
        public string eoal1Key;
        public string loopringAppPassCode;
        public LoopringServiceUI loopringService;

        public LoopringServiceUI LoopringService
        {
            get => loopringService;
            set => this.RaiseAndSetIfChanged(ref loopringService, value);
        }
        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set => this.RaiseAndSetIfChanged(ref imagePath, value);
        }
        public string Location
        {
            get => location;
            set => this.RaiseAndSetIfChanged(ref location, value);
        }
        public string Notice
        {
            get => notice;
            set => this.RaiseAndSetIfChanged(ref notice, value);
        }
        private bool isEoaTextBoxVisible;
        public bool IsEoaTextBoxVisible
        {
            get => isEoaTextBoxVisible;
            set => this.RaiseAndSetIfChanged(ref isEoaTextBoxVisible, value);
        }
        private bool isLswTextBoxVisible;
        public bool IsLswTextBoxVisible
        {
            get => isLswTextBoxVisible;
            set => this.RaiseAndSetIfChanged(ref isLswTextBoxVisible, value);
        }
        public string EoaL1Key
        {
            get => eoal1Key;
            set => this.RaiseAndSetIfChanged(ref eoal1Key, value);
        }
        public string LoopringAppPassCode
        {
            get => loopringAppPassCode;
            set => this.RaiseAndSetIfChanged(ref loopringAppPassCode, value);
        }
        public string log;
        public string Log
        {
            get => log;
            set
            {
                if (log != value)
                {
                    this.RaiseAndSetIfChanged(ref log, value);
                    UpdateTextBoxVisibilityAsync();
                }
            }
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
            Log = $"Paste Account Information from Loopring.io > Avatar > Security > Export Account here and then the L1 Private Key/Image below.\r\n\r\n Example:\r\n{{\r\n    \"address\": \"0x1fdfef87d387e4basdjfhtyghtugh19cff06a982\",\r\n    \"accountId\": 11233,\r\n    \"level\": \"\",\r\n    \"nonce\": 1,\r\n    \"apiKey\": \"miWgX3jDo5zubs1VwYrPShtF5ythgnbhggmczTOwzUrS280AaNtf6v8CuVmwfP4f\",\r\n    \"publicX\": \"0x12167dbhguty675ud3c11bae8a343c138cfc2574349235688ae2d6ce68320ac8\",\r\n    \"publicY\": \"0x1d7e0c7d92b894dc27943a0fghtyghvnfjb0db0dbcc47d42f2914d9b00b84fd3\",\r\n    \"privateKey\": \"0x2ad857be54b8d02badc842ac54e25f5ythgjt0pol50331cc4894509c09f255b\"\r\n}}\r\n";
            IsLswTextBoxVisible = false; 
            IsEoaTextBoxVisible = false;
            SetupApsettingsFileCommand = ReactiveCommand.Create(SetupApsettingsFile);
        }
        private async void SetupApsettingsFile()
        {

            IsEnabled = false;
            RootObject settings = SetupL2();

            if (walletType.data.isInCounterFactualStatus == false && walletType.data.isContract == false)
            {
                if (string.IsNullOrEmpty(eoal1Key))
                {
                    IsEnabled = true;
                    return;
                }
                var layerOneKey = eoal1Key;
                settings.Settings.MMorGMEPrivateKey = layerOneKey;
            }
            else
            {
                if (string.IsNullOrEmpty(loopringAppPassCode) || string.IsNullOrEmpty(imagePath))
                {
                    IsEnabled = true;
                    return;
                }

                QrCodeJson qrCodeJson = null;

                // Read the image from the file
                using Mat image = Cv2.ImRead(imagePath);

                // Initialize the QR code detector
                QRCodeDetector qrCodeDetector = new QRCodeDetector();

                // Detect the QR code
                string decodedInfo = qrCodeDetector.DetectAndDecode(image, out Point2f[] points);

                // Check if the QR code has been detected
                if (points != null && points.Length > 0)
                {
                    // Draw a polygon around the detected QR code
                    Cv2.Polylines(image, new Point[][] { points.Select(p => p.ToPoint()).ToArray() }, isClosed: true, color: OpenCvSharp.Scalar.Red);

                    // Display the detected and decoded information
                    Notice = "QR Code Detected: " + decodedInfo;
                    if (decodedInfo.Trim().Length > 0)
                    {
                        qrCodeJson = JsonConvert.DeserializeObject<QrCodeJson>(decodedInfo);
                    }
                }
                else
                {
                    Notice = "QR Code Not Detected. Try a different image...";
                    IsEnabled = true;
                    return;
                }

                byte[] mnemonic = Encoding.ASCII.GetBytes(qrCodeJson.mnemonic);
                byte[] iv = Encoding.ASCII.GetBytes(qrCodeJson.iv);
                byte[] salt = Encoding.ASCII.GetBytes(qrCodeJson.salt);

                var layerOneKey = QRCodeDecrypt(mnemonic, iv, salt, loopringAppPassCode);

                if (layerOneKey == "You have entered the wrong passcode... try again!")
                {
                    Notice = layerOneKey;
                    IsEnabled = true;
                    return;
                }
                else
                {
                    settings.Settings.MMorGMEPrivateKey = layerOneKey;
                }
            }
            string updatedJsonString = JsonConvert.SerializeObject(settings);

            await File.WriteAllTextAsync(location, updatedJsonString);
            Notice = "Done!";
            Log = "Close this window and click the check mark on the Menu again.";
            IsLswTextBoxVisible = false;
            IsEoaTextBoxVisible = false;

        }
        private RootObject SetupL2()
        {
            string jsonString = log.Trim();
            if ((jsonString.StartsWith("{") && jsonString.EndsWith("}")) || //For object
        (jsonString.StartsWith("[") && jsonString.EndsWith("]"))) //For array
            {
                WalletDetails walletDetails = JsonConvert.DeserializeObject<WalletDetails>(jsonString);
                string appSettingsEnvironment = location;
                RootObject settings = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(appSettingsEnvironment));

                settings.Settings.LoopringAccountId = (int)walletDetails.AccountId;
                settings.Settings.LoopringAddress = walletDetails.Address;
                settings.Settings.LoopringApiKey = walletDetails.ApiKey;
                settings.Settings.LoopringPrivateKey = walletDetails.PrivateKey;
                
                return settings;
            }

            return null;
        }
        private async void UpdateTextBoxVisibilityAsync()
        {
            RootObject settings = SetupL2();
            if (settings != null)
            {
                walletType = await loopringService.GetWalletType(settings.Settings.LoopringAddress);
                if (walletType.data.isInCounterFactualStatus == false && walletType.data.isContract == false)
                {
                    IsEoaTextBoxVisible = true;
                    IsLswTextBoxVisible = false;
                    IsEnabled = true;
                }
                else if (walletType.data.isInCounterFactualStatus == true)
                {
                    Log = "This LSW L1 is not active. Please Activate it and retry.";
                    IsEoaTextBoxVisible = false;
                    IsLswTextBoxVisible = false;
                    IsEnabled = false;
                }
                else
                {
                    IsLswTextBoxVisible = true;
                    IsEoaTextBoxVisible = false;
                    IsEnabled = true;
                }
            }
        }
        static string QRCodeDecrypt(byte[] mnemonic, byte[] iv, byte[] salt, string passphrase)
        {
            mnemonic = Convert.FromBase64String(Encoding.UTF8.GetString(mnemonic));
            iv = Convert.FromBase64String(Encoding.UTF8.GetString(iv));
            salt = Convert.FromBase64String(Encoding.UTF8.GetString(salt));

            string password = string.Format("0x{0}", BitConverter.ToString(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("LOOPRING HEBAO Wallet " + passphrase))).Replace("-", "").ToLower());
            byte[] key = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), salt, 4096, HashAlgorithmName.SHA256).GetBytes(32);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.None;

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(mnemonic, 0, mnemonic.Length);
                    int paddingLength = decryptedBytes[decryptedBytes.Length - 1];
                    try
                    {
                        byte[] result = new byte[decryptedBytes.Length - paddingLength];
                        Array.Copy(decryptedBytes, result, result.Length);
                        string decryptedMnemonic = Encoding.UTF8.GetString(result);
                        Wallet wallet = new Wallet(decryptedMnemonic, null);
                        string walletPrivateKey = BitConverter.ToString(wallet.GetPrivateKey(0)).Replace("-", string.Empty).ToLower();

                        return walletPrivateKey;

                    }
                    catch (Exception)
                    {
                        return "You have entered the wrong passcode... try again!";
                    }
                }
            }
        }
    }
}
