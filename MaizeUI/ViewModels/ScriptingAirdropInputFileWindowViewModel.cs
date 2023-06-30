using Maize;
using Maize.Services;
using Maize.Helpers;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;
using Maize.Models.ApplicationSpecific;
using System.Text;

namespace MaizeUI.ViewModels
{
    public class ScriptingAirdropInputFileWindowViewModel : ViewModelBase
    {
        public string Notice { get; set; }
        public Constants.Environment environment;
        public Constants.Environment Environment
        {
            get => environment;
            set => this.RaiseAndSetIfChanged(ref environment, value);
        }
        public string nftData;
        public string NftData
        {
            get => nftData;
            set => this.RaiseAndSetIfChanged(ref nftData, value);
        }
        public string nftAmount;
        public string NftAmount
        {
            get => nftAmount;
            set => this.RaiseAndSetIfChanged(ref nftAmount, value);
        }
        public string memo;
        public string Memo
        {
            get => memo;
            set => this.RaiseAndSetIfChanged(ref memo, value);
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

        public LoopringServiceUI loopringService;

        public LoopringServiceUI LoopringService
        {
            get => loopringService;
            set => this.RaiseAndSetIfChanged(ref loopringService, value);
        }

        public Settings settings;

        public Settings Settings
        {
            get => settings;
            set => this.RaiseAndSetIfChanged(ref settings, value);
        }

        public ReactiveCommand<Unit, Unit> CreateInputFileCommand { get; }

        public ScriptingAirdropInputFileWindowViewModel()
        {
            Notice = "This screen will help you create an Input file for Airdrops that have the same NFT Data, Amount, and Memo. You will provide wallet addresses in the below file.";
            Log = $"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}";
            CreateInputFileCommand = ReactiveCommand.Create(CreateInputFile);
        }

        private async void CreateInputFile()
        {
            Log = "Checking Information, please give me a moment...";
            IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();
            StringBuilder buildinvalidLines = new StringBuilder();

            var nftDataCheck = await LoopringService.GetNftInformationFromNftData(Settings.LoopringApiKey, nftData);
            if (nftDataCheck.Count == 0)
                buildinvalidLines.Append($"Error with NFT Data: Invalid NFT Data.\r\n");
            if (!int.TryParse(nftAmount, out int number) || nftAmount == null)
                buildinvalidLines.Append("Error with Amount of NFTs: Please enter a number\r\n");
            if (memo?.Length > 120)
                buildinvalidLines.Append($"Error with Memo: Length greater than 120 characters.\r\n");
            if (buildinvalidLines.ToString().Contains("Error"))
            {
                Log = $"{buildinvalidLines}\r\nPlease fix the above errors in your Input file and then press Next.";
                IsEnabled = true;
                return;
            }

            string inputFilePath = $"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}";
            string outputFilePath = $"{Constants.BaseDirectory}{Constants.OutputFolder}/{nftData}_Input.txt";

            try
            {
                List<string> processedLines = new List<string>();
                string[] lines = File.ReadAllLines(inputFilePath);

                foreach (string line in lines)
                {
                    string processedLine = $"{nftData},{nftAmount},{line},{memo}";
                    processedLines.Add(processedLine);
                }

                File.WriteAllLines(outputFilePath, processedLines);

                Log = "Processing complete. Output written to: " + outputFilePath;
            }
            catch (IOException e)
            {
                Log = "An error occurred while reading/writing the file: " + e.Message;
            }

            IsEnabled = true;
        }
    }
}
