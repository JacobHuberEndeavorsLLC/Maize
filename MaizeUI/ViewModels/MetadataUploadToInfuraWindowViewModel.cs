using Maize;
using Maize.Services;
using Maize.Helpers;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;
using Maize.Models.ApplicationSpecific;
using System.Text;
using Maize.Models.Responses;
using Newtonsoft.Json;
using ApiCalls.Helpers;
using Microsoft.Extensions.Configuration;
using NBitcoin;
using Avalonia.Media.TextFormatting.Unicode;

namespace MaizeUI.ViewModels
{
    public class MetadataUploadToInfuraWindowViewModel : ViewModelBase
    {
        private bool isCheckedMetadata = false;

        public bool IsCheckedMetadata
        {
            get => isCheckedMetadata;
            set => this.RaiseAndSetIfChanged(ref isCheckedMetadata, value);
        }
        private bool isCheckedMediaFiles = false;

        public bool IsCheckedMediaFiles
        {
            get => isCheckedMediaFiles;
            set => this.RaiseAndSetIfChanged(ref isCheckedMediaFiles, value);
        }
        public string notice;
        public string Notice 
        {
            get => notice;
            set => this.RaiseAndSetIfChanged(ref notice, value);
        }

        public bool isEnabled = true;

        public bool IsEnabled
        {
            get => isEnabled;
            set => this.RaiseAndSetIfChanged(ref isEnabled, value);
        }

        public string log;

        public string Log
        {
            get => log;
            set => this.RaiseAndSetIfChanged(ref log, value);
        }
        string infurasettings = $"{Constants.BaseDirectory}{Constants.EnvironmentPath}Infurasettings.json";

        public ReactiveCommand<Unit, Unit> UploadToInfuraCommand { get; }

        public MetadataUploadToInfuraWindowViewModel()
        {
            Notice = "Use this feature to upload metadata and media files to Infura, associated with the specified CIDs.";
            Log = $"Place the Metadata CIDs here. One per line.\r\n\r\nExample:\r\nQmYFrpNhNQRavJRQfbEekVxHSn2pk7jNpGByiVeM6j3UUS\r\nQmR1kLxD3C8hzFFjxUjQPuNJVKbZ2Z1dDsECdo7QtSQgpG";
            UploadToInfuraCommand = ReactiveCommand.Create(UploadToInfura);
            // Check if the file doesn't exist
            if (!File.Exists(infurasettings))
            {
                var defaultKeys = new
                {
                    _comment1 = "This file contains the API keys for Infura.",
                    _comment2 = "You can obtain these keys by signing up at https://infura.io/",
                    InfuraApiKey = "Your_Infura_Api_Key", 
                    InfuraSecretKey = "Your_Infura_Secret_Key" 
                };

                string defaultContent = JsonConvert.SerializeObject(defaultKeys, Formatting.Indented);

                File.WriteAllText(infurasettings, defaultContent);
                ApplicationUtilitiesUI.OpenFile(infurasettings);
            }
        }

        private async void UploadToInfura()
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile(infurasettings)
            .AddEnvironmentVariables()
            .Build();
            InfuraKeys settings = config.Get<InfuraKeys>();
            if (settings.InfuraApiKey == "Your_Infura_Api_Key" || settings.InfuraSecretKey == "Your_Infura_Secret_Key")
            {
                ApplicationUtilitiesUI.OpenFile(infurasettings);
                return;
            }
            IInfuraClient infuraService = new InfuraClient("2TcjCZ0aM6Y0Y9NqsEdlI1e5awt", "cef7240d0f2b6ce91b1d93119911df84", "https://ipfs.infura.io:5001/");
            INftMetadataService nftMetadataService = new NftMetadataService("https://ipfs.loopring.io/ipfs/");


            string cids = log;
            IsEnabled = false;
            var sw = new Stopwatch();
            List<string> stringList = new List<string>(cids.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            if (stringList.Any(s => !s.StartsWith("Qm")))
            {
                Notice = $"Some of your CIDs do not start with Qm. These are likely invalid and need to be removed.";
                IsEnabled = true;
                return;
            }

            List<string> processedLines = new List<string>();
            StringBuilder buildinvalidLines = new StringBuilder();

            try
            {
                foreach (var cid in stringList)
                {
                    var jsonData = await nftMetadataService.GetMetadataFromCid(cid);
                    if (jsonData == null)
                    {
                        buildinvalidLines.Append($"Error with CID: {cid}.\r\n");
                        continue;
                    }
                    var data = JsonConvert.DeserializeObject<JsonData>(jsonData);

                    if (isCheckedMetadata == true)
                    {
                        var metadata = FormatJson.SaveJsonToDownloadsFolder(jsonData, $"{cid}.json");
                        var addMetadata = await infuraService.FileAdd(metadata);
                        if (addMetadata.Hash == "basic auth failure: invalid project id or project secret\n")
                        {
                            Notice = "There are issues with your Keys. Please check your API Key and Secret Key.";
                            break;
                        }
                        if (addMetadata != null) 
                            processedLines.Add($"{cid} was uploaded");
                    }
                    if (isCheckedMediaFiles == true)
                    {
                        data.image = data.image.Replace("ipfs://", "");
                        data.animation_url = data.animation_url.Replace("ipfs://", "");

                        if (data.image == data.animation_url)
                        {
                            var image = await nftMetadataService.SaveFileFromCid(data.image);
                            var addFile = await infuraService.FileAdd(image);
                            if (addFile != null)
                                processedLines.Add($"{data.image} was uploaded from {cid}");
                        }
                        else
                        {
                            var image = await nftMetadataService.SaveFileFromCid(data.image);
                            var addFile = await infuraService.FileAdd(image);
                            if (addFile != null)
                                processedLines.Add($"{data.image} was uploaded from {cid}");
                            var animation = await nftMetadataService.SaveFileFromCid(data.animation_url);
                            addFile = await infuraService.FileAdd(animation);
                            if (addFile != null)
                                processedLines.Add($"{data.animation_url} was uploaded from {cid}");
                        }
                    }
                }
                if (processedLines.Count() > 0 || buildinvalidLines.Length > 0)
                {
                    string outputFilePath = $"{Constants.BaseDirectory}{Constants.OutputFolder}UploadToInfura_{DateTime.UtcNow:yyyy-MM-dd mHH-mm-ss}.txt";

                    File.WriteAllLines(outputFilePath, processedLines);
                    ApplicationUtilitiesUI.OpenFile(outputFilePath);
                    Log = "Processing complete\r\n\r\nOutput written to: " + outputFilePath + $"\r\n\r\n{buildinvalidLines}";
                }
            }
            catch (IOException e)
            {
                Log = "An error occurred while reading/writing the file: " + e.Message;
            }

            IsEnabled = true;
        }
    }
}
