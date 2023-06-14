using Maize.Models.ApplicationSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Helpers
{
    public class Files
    {
        public static int CheckInputFile(int utility, Font font)
        {
            StreamReader sr;
            string walletAddresses;
            int howManyLines;
            var counter = 0;
            string userResponseOnWalletSetup;
            do
            {
                if (counter == 0)
                {
                    userResponseOnWalletSetup = ApplicationUtilities.CheckYesOrHelp(font);
                    if (userResponseOnWalletSetup == "help" || userResponseOnWalletSetup == "h")
                    {
                        InputFileHelp(utility, font);
                        userResponseOnWalletSetup = ApplicationUtilities.CheckYes(font, $"Did you setup your {Constants.InputFile}");
                    }
                    sr = new StreamReader($"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}");
                    counter++;
                }
                else
                {
                    font.ToRed("It doesn't look like you did");
                    InputFileHelp(utility, font);
                    userResponseOnWalletSetup = ApplicationUtilities.CheckYes(font, $"Did you setup your {Constants.InputFile}");
                    sr = new StreamReader($"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}");
                }
                walletAddresses = sr.ReadToEnd().Replace("\r\n", "\r");
                howManyLines = walletAddresses.Split('\r').Length;
                if (walletAddresses.EndsWith('\r'))
                {
                    do
                    {
                        walletAddresses = walletAddresses.Remove(walletAddresses.Length - 1).Remove(walletAddresses.Length - 1);
                        howManyLines--;
                    } while (walletAddresses.EndsWith('\r'));
                }
                sr.Dispose();
            } while (walletAddresses == "");
            return howManyLines;
        }
        public static int CheckInputFile()
        {
            StreamReader sr;
            string walletAddresses;
            int howManyLines;
            var counter = 0;
            string userResponseOnWalletSetup;
            do
            {
                if (counter == 0)
                {
                    sr = new StreamReader($"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}");
                    counter++;
                }
                else
                {
                    sr = new StreamReader($"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}");
                }
                walletAddresses = sr.ReadToEnd().Replace("\r\n", "\r");
                howManyLines = walletAddresses.Split('\r').Length;
                if (walletAddresses.EndsWith('\r'))
                {
                    do
                    {
                        walletAddresses = walletAddresses.Remove(walletAddresses.Length - 1).Remove(walletAddresses.Length - 1);
                        howManyLines--;
                    } while (walletAddresses.EndsWith('\r'));
                }
                sr.Dispose();
            } while (walletAddresses == "");
            return howManyLines;
        }
        public static void InputFileHelp(int utility, Font font)
        {
            switch (utility)
            {
                //                case 2:
                //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add CIDs from your json files. You will have one CID per line.");
                //                    Console.WriteLine();
                //                    break;
                //                case 3:
                //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add a wallet address a comma and then the amount you want to send (example: 0x4a71e0267207cec67c78df8857d81c508d43b00d,2). You will have one wallet address and one amount per line. Each wallet address will be one transfer. Be sure to have enough LRC for each transfer. You can add a long wallet address or the ENS.");
                //                    Console.WriteLine();
                //                    break;
                //                case 5:
                //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add Nft Ids. You will have one Nft Id per line.");
                //                    Console.WriteLine();
                //                    break;
                case 3:
                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt file add your Nft Data. You will have one Nft Data per line.");
                    Console.WriteLine();
                    break;
                    //                case 10:
                    //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add Nft Data. You will have one Nft Data per line.");
                    //                    Console.WriteLine();
                    //                    break;
                    //                case 11:
                    //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add Nft Data. You will have one Nft Data per line.");
                    //                    Console.WriteLine();
                    //                    break;
                    //                case 12:
                    //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add wallet addresses. You will have one wallet address per line. Each wallet address will be one transfer. Be sure to have enough LRC for each transfer. You can add a long wallet address or the ENS.");
                    //                    Console.WriteLine();
                    //                    break;
                    //                case 13:
                    //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add a wallet address a comma and then the amount you want to send (example: 0x4a71e0267207cec67c78df8857d81c508d43b00d,2). You will have one wallet address and one amount per line. Each wallet address will be one transfer. Be sure to have enough LRC for each transfer. You can add a long wallet address or the ENS.");
                    //                    Console.WriteLine();
                    //                    break;
                    //                case 14:
                    //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add a wallet address a comma and then the nft data (example: 0x4a71e0267207cec67c78df8857d81c508d43b00d,0x103cb20d3b310873f711d25758d57f18ba77a6b7842ae605d662e0ddd908ed5a). You will have one wallet address and nft data per line. Each wallet address will be one transfer. Be sure to have enough LRC for each transfer. You can add a long wallet address or the ENS.");
                    //                    Console.WriteLine();
                    //                    break;
                    //                case 15:
                    //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Banish.txt located in the project directory add the minter wallet address whose Nfts you want to remove from your wallet. You will have one wallet address per line and you can add a long wallet address or the ENS.");
                    //                    Console.WriteLine();
                    //                    break;
                    //                case 16:
                    //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add a wallet addresses. You will have one wallet address per line. Each wallet address will be one transfer of LRC. Be sure to have enough LRCfor each transfer. You can add a long wallet address or the ENS.");
                    //                    Console.WriteLine();
                    //                    break;
                    //                case 18:
                    //                    font.ToSecondary($"In the {AppDomain.CurrentDomain.BaseDirectory}Input\\Input.txt located in the project directory add a wallet addresses. You will have one wallet address per line. Each wallet address will be one transfer of LRC. Be sure to have enough LRC for each transfer. You can add a long wallet address or the ENS.");
                    //                    Console.WriteLine();
                    //                    break;
                    //                default:
                    //                    break;
            }
        }
    }
}
