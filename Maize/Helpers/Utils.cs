using Maize;
using Maize.Helpers;
using Maize.Models;
using Nethereum.Signer.EIP712;
using Nethereum.Util;
using PoseidonSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Maize
{
    public static class Utils
    {

        public static BigInteger ParseHexUnsigned(string toParse)
        {
            toParse = toParse.Replace("0x", "");
            var parsResult = BigInteger.Parse(toParse, System.Globalization.NumberStyles.HexNumber);
            if (parsResult < 0)
                parsResult = BigInteger.Parse("0" + toParse, System.Globalization.NumberStyles.HexNumber);
            return parsResult;
        }

        public static string UrlEncodeUpperCase(string stringToEncode)
        {
            var reg = new Regex(@"%[a-f0-9]{2}");
            stringToEncode = HttpUtility.UrlEncode(stringToEncode);
            return reg.Replace(stringToEncode, m => m.Value.ToUpperInvariant());
        }
        public static BigInteger CreateSha256Signature(HttpMethod method, List<(string Key, string Value)> queryParams, string postBody, string apiMethod, string apiUrl)
        {
            var signatureBase = "";
            var parameterString = "";
            if (method == HttpMethod.Post)
            {
                signatureBase += "POST&";
                parameterString = postBody;
            }
            else if (method == HttpMethod.Get)
            {
                signatureBase += "GET&";
                if (queryParams != null)
                {
                    int i = 0;
                    foreach (var parameter in queryParams)
                    {
                        parameterString += parameter.Key + "=" + parameter.Value;
                        if (i < queryParams.Count - 1)
                            parameterString += "&";
                        i++;
                    }
                }
            }
            else if (method == HttpMethod.Delete)
            {
                signatureBase += "DELETE&";
                if (queryParams != null)
                {
                    int i = 0;
                    foreach (var parameter in queryParams)
                    {
                        parameterString += parameter.Key + "=" + parameter.Value;
                        if (i < queryParams.Count - 1)
                            parameterString += "&";
                        i++;
                    }
                }
            }
            else
                throw new Exception("Http method type not supported");

            signatureBase += Utils.UrlEncodeUpperCase(apiUrl + apiMethod) + "&";
            signatureBase += Utils.UrlEncodeUpperCase(parameterString);

            return SHA256Helper.CalculateSHA256HashNumber(signatureBase);
        }

        public static string CheckYesOrNo(Font font)
        {
            var userResponse = Console.ReadLine().ToLower();
            while ((userResponse != "yes") && (userResponse != "no") && (userResponse != "y") && (userResponse != "n"))
            {
                font.SetTextToYellow("Please answer yes (y) or no (n).");
                userResponse = Console.ReadLine().ToLower();
            }
            return userResponse;
        }
        public static string CheckYesOrHelp(Font font)
        {
            var userResponse = Console.ReadLine().ToLower();
            while ((userResponse != "yes") && (userResponse != "help") && (userResponse != "y") && (userResponse != "h"))
            {
                font.SetTextToYellow("Please answer yes (y) or help (h).");
                userResponse = Console.ReadLine().ToLower();
            }
            return userResponse;
        }

        public static string CheckOneOrMany(Font font)
        {
            var userResponse = Console.ReadLine().ToLower();
            while ((userResponse != "one") && (userResponse != "many"))
            {
                font.SetTextToYellow("Please answer one or many.");
                userResponse = Console.ReadLine().ToLower();
            }
            return userResponse;
        }
        public static string CheckMainnetOrTestnet(Font font)
        {
            var userResponse = Console.ReadLine().ToLower();
            while ((userResponse != "mainnet") && (userResponse != "m") && (userResponse != "testnet") && (userResponse != "t"))
            {
                font.SetTextToYellow("Please answer mainnet (m) or testnet (t).");
                userResponse = Console.ReadLine().ToLower();
            }
            return userResponse;
        }

        public static string CheckYes(Font font)
        {
            var userResponse = Console.ReadLine().ToLower();
            while (userResponse != "yes" && userResponse != "y")
            {
                font.SetTextToYellow("Please answer yes (y) when you are ready.");
                userResponse = Console.ReadLine().ToLower();
            }
            return userResponse;
        }
        public static string CheckUtilityNumber(int maxUtilityNumber, Font font)
        {
            int userResponse;
            bool checkNumber;
            do
            {
                checkNumber = int.TryParse(Console.ReadLine(), out userResponse);
                if (checkNumber == false || userResponse > maxUtilityNumber || userResponse < 0)
                {
                    font.SetTextToYellow($"Please enter a number between 0 and {maxUtilityNumber}.");

                }
            } while (checkNumber == false || userResponse > maxUtilityNumber || userResponse < 0);
            return userResponse.ToString();
        }
        public static int Check1Or2(int userResponse, Font font)
        {
            bool validOrNot = false;
            var counter = 0;
            do
            {
                if (counter == 0)
                {
                    validOrNot = int.TryParse(Console.ReadLine()?.ToLower().Trim(), out userResponse);
                    counter++;
                }
                else
                {
                    font.SetTextToYellow("Please answer 0 or 1.");
                    validOrNot = int.TryParse(Console.ReadLine()?.ToLower().Trim(), out userResponse);
                }
            } while (((userResponse != 0) && (userResponse != 1)) || validOrNot == false);

            return userResponse;
        }

        public static int CheckInputDotTxt(int utility, string fileName, Font font)
        {
            StreamReader sr;
            string walletAddresses;
            int howManyLines;
            var counter = 0;
            var userResponseOnWalletSetup = "";
            do
            {
                if (counter == 0)
                {
                    font.SetTextToTertiaryInline($"Did you setup your {fileName}? ");
                    font.SetTextToDarkGray("Type help for file setup.");
                    //font.SetREADMEFontColorDarkGray("Check the ", "README", $" for {fileName} setup.");
                    userResponseOnWalletSetup = CheckYesOrHelp(font);
                    if (userResponseOnWalletSetup == "help" || userResponseOnWalletSetup == "h")
                    {
                        InputFileHelp(utility, font);
                        font.SetTextToTertiary($"Did you setup your {fileName}?");
                        userResponseOnWalletSetup = CheckYes(font);
                    }
                    sr = new StreamReader($"./{fileName}");
                    counter++;
                }
                else
                {
                    font.SetREADMEFontColorYellow("It doesn't look like you did. Please refer to the ","README", " and respond yes (y) when you are ready.");
                    userResponseOnWalletSetup = CheckYes(font);
                    sr = new StreamReader($"./{fileName}");
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
        public static FileAmountsNft CheckInputDotTxtTwoInputsNft(int utility, string fileName, Font font)
        {
            StreamReader sr;
            string walletAddresses;
            int totalNftAmount = 0;
            int howManyLines;
            var counter = 0;
            var noDoubleWarning = false;
            string helpSetup;
            do
            {
                if (counter == 0)
                {
                    font.SetTextToTertiaryInline($"Did you setup your {fileName}? ");
                    font.SetTextToDarkGray("Type help for file setup.");
                    //font.SetREADMEFontColorDarkGray("Check the ", "README", $" for {fileName} setup.");
                    helpSetup = CheckYesOrHelp(font);
                    if (helpSetup == "help" || helpSetup == "h")
                    {
                        InputFileHelp(utility, font);
                        font.SetTextToTertiary($"Did you setup your {fileName}?");
                        helpSetup = CheckYes(font);
                    }
                    sr = new StreamReader($"./{fileName}");
                    counter++;
                }
                else
                {
                    if (noDoubleWarning == false)
                    {
                        font.SetREADMEFontColorYellow("It doesn't look like you did. Please refer to the ", "README", " and respond yes (y) when you are ready.");
                    }
                    CheckYes(font);
                    sr = new StreamReader($"./{fileName}");
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
                sr = new StreamReader($"./{fileName}");
                try
                {
                    totalNftAmount = 0;
                    string fileLine;
                    while ((fileLine = sr.ReadLine()) != null)
                    {
                        var line = String.Concat(fileLine.Where(c => !Char.IsWhiteSpace(c)));
                        string[] walletAddressLineArray = line.Split(',');
                        if (!(walletAddressLineArray[1].Trim().StartsWith("0x") || walletAddressLineArray[1].Trim().EndsWith("eth")))
                        {
                            totalNftAmount += int.Parse(walletAddressLineArray[1].Trim());
                        }
                    }
                }
                catch (Exception)
                {
                    font.SetTextToYellow($"It looks like your {fileName} needs the walletAddress,nftAmount.");
                    font.SetTextToTertiary("Respond yes (y) when you are ready.");
                    walletAddresses = "";
                    noDoubleWarning = true;
                }
                sr.Dispose();
            } while (walletAddresses == "");
            var finalAmounts = new FileAmountsNft()
            {
                nftAmount = totalNftAmount,
                walletAmount = howManyLines
            };
            return finalAmounts; 
        }
        public static FileAmountsLrc CheckInputDotTxtTwoInputsLrc(int utility, string fileName, Font font)
        {
            StreamReader sr;
            string walletAddresses;
            decimal totalLrcAmount = 0;
            int howManyLines;
            var counter = 0;
            var noDoubleWarning = false;
            string helpSetup;
            do
            {
                if (counter == 0)
                {
                    font.SetTextToTertiaryInline($"Did you setup your {fileName}? ");
                    font.SetTextToDarkGray("Type help for file setup.");
                    //font.SetREADMEFontColorDarkGray("Check the ", "README", $" for {fileName} setup.");
                    helpSetup = CheckYesOrHelp(font);
                    if (helpSetup == "help" || helpSetup == "h")
                    {
                        InputFileHelp(utility, font);
                        font.SetTextToTertiary($"Did you setup your {fileName}?");
                        helpSetup = CheckYes(font);
                    }
                    sr = new StreamReader($"./{fileName}");
                    counter++;
                }
                else
                {
                    if (noDoubleWarning == false)
                    {
                        font.SetREADMEFontColorYellow("It doesn't look like you did. Please refer to the ", "README", " and respond yes (y) when you are ready.");
                    }
                    CheckYes(font);
                    sr = new StreamReader($"./{fileName}");
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
                sr = new StreamReader($"./{fileName}");
                try
                {
                    totalLrcAmount = 0;
                    string fileLine;
                    while ((fileLine = sr.ReadLine()) != null)
                    {
                        var line = String.Concat(fileLine.Where(c => !Char.IsWhiteSpace(c)));
                        string[] walletAddressLineArray = line.Split(',');
                        if (!(walletAddressLineArray[1].Trim().StartsWith("0x") || walletAddressLineArray[1].Trim().EndsWith("eth")))
                        {
                            totalLrcAmount += decimal.Parse(walletAddressLineArray[1].Trim());
                        }
                    }
                }
                catch (Exception)
                {
                    font.SetTextToYellow($"It looks like your {fileName} needs the walletAddress,nftAmount.");
                    font.SetTextToTertiary("Respond yes (y) when you are ready.");
                    walletAddresses = "";
                    noDoubleWarning = true;
                }
                sr.Dispose();
            } while (walletAddresses == "");
            var finalAmounts = new FileAmountsLrc()
            {
                lrcAmount = totalLrcAmount,
                walletAmount = howManyLines
            };
            return finalAmounts;
        }

        public static int GetInputDotTxtLines(string fileName)
        {
            StreamReader sr;
            string walletAddresses;
            int howManyLines;
            do
            {

                sr = new StreamReader($"./{fileName}");
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

        public static string CheckNftSendAmount(int howManyWallets, string userNftTokentotalNum, string fileName, Font font)
        {
            string nftAmount;
            do
            {
                nftAmount = ReadLineWarningNoNullsForceInt("How many Nfts do you want to transfer to each address?", font);
            } while (nftAmount == null);
            while ((howManyWallets * int.Parse(nftAmount)) > int.Parse(userNftTokentotalNum))
            {
                font.SetTextToRed($"Math Error. You have {userNftTokentotalNum} of this Nft in your wallet and want to " +
                    $"send to {nftAmount} of them to {howManyWallets} wallets each.");
                font.SetTextToYellow("How many of your Nft do you want to transfer to each address?");
                do
                {
                    nftAmount = ReadLineWarningNoNullsForceInt("How many Nfts do you want to transfer to each address?", font);
                } while (nftAmount == null);
                howManyWallets = GetInputDotTxtLines(fileName);
            }
            return nftAmount;
        }        
        public static void CheckNftSendAmountTwoInputs(int utility, int nftTransferAmount, string userNftTokentotalNum, string fileName, Font font)
        {
            while ((nftTransferAmount) > int.Parse(userNftTokentotalNum))
            {
                do
                {
                    font.SetTextToRed($"Math Error. You have {userNftTokentotalNum} of this Nft in your wallet and want to " +
                    $"send to {nftTransferAmount} of them.");
                    font.SetTextToYellow("Please adjust your input file.");
                    var fileAmounts = Utils.CheckInputDotTxtTwoInputsNft(utility, fileName, font);
                    nftTransferAmount = fileAmounts.nftAmount;
                } while ((nftTransferAmount) > int.Parse(userNftTokentotalNum));
                nftTransferAmount = GetInputDotTxtLines(fileName);
            }
            //return nftTransferAmount;
        }
        public static void InputFileHelp(int utility, Font font)
        {
            switch (utility)
            {
                case 2:
                    font.SetTextToSecondary("In the Input.txt located in the project directory add Nft Ids. You will have one Nft Id per line.");
                    Console.WriteLine();
                    break;
                case 5:
                    font.SetTextToSecondary("In the Input.txt located in the project directory add Nft Data. You will have one Nft Data per line.");
                    Console.WriteLine();
                    break;
                case 7:
                    font.SetTextToSecondary("In the Input.txt located in the project directory add Nft Data. You will have one Nft Data per line.");
                    Console.WriteLine();
                    break;
                case 8:
                    font.SetTextToSecondary("In the Input.txt located in the project directory add Nft Data. You will have one Nft Data per line.");
                    Console.WriteLine();
                    break;
                case 9:
                    font.SetTextToSecondary("In the Input.txt located in the project directory add a wallet addresses. You will have one wallet address per line. Each wallet address will be one transfer. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.");
                    Console.WriteLine();
                    break;
                case 10:
                    font.SetTextToSecondary("In the Input.txt located in the project directory add a wallet address a comma and then the amount you want to send (example: 0x4a71e0267207cec67c78df8857d81c508d43b00d,2). You will have one wallet address and one amount per line. Each wallet address will be one transfer. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.");
                    Console.WriteLine();
                    break;
                case 11:
                    font.SetTextToSecondary("In the Input.txt located in the project directory add a wallet address a comma and then the nft data (example: 0x4a71e0267207cec67c78df8857d81c508d43b00d,0x103cb20d3b310873f711d25758d57f18ba77a6b7842ae605d662e0ddd908ed5a). You will have one wallet address and nft data per line. Each wallet address will be one transfer. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.");
                    Console.WriteLine();
                    break;
                case 12:
                    font.SetTextToSecondary("In the Banish.txt located in the project directory add the minter wallet address whose Nfts you want to remove from your wallet. You will have one wallet address per line and you can add a long wallet address or the ENS.");
                    Console.WriteLine();
                    break;
                case 13:
                    font.SetTextToSecondary("In the Input.txt located in the project directory add a wallet addresses. You will have one wallet address per line. Each wallet address will be one transfer of LRC/ETH. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.");
                    Console.WriteLine();
                    break;
                case 15:
                    font.SetTextToSecondary("In the Input.txt located in the project directory add a wallet addresses. You will have one wallet address per line. Each wallet address will be one transfer of LRC/ETH. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.");
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }

            public static string ReadLineWarningNoNulls(string message, Font font)
        {
            var s = Console.ReadLine();
            while (string.IsNullOrEmpty(s))
            {
                font.SetTextToYellow($"Please, {message}");
                s = Console.ReadLine();
            }
            return s;
        }
        public static string ReadLineWarningNoNullsForceInt(string message, Font font)
        
        {
            var s = Console.ReadLine();
            int i;
            bool number = int.TryParse(s, out i);
            while (string.IsNullOrEmpty(s) || number == false)
            {
                font.SetTextToYellow($"Please, {message}");
                s = Console.ReadLine();
                number = int.TryParse(s, out i);
            }
            return i.ToString();
        } 
        public static string ReadLineWarningNoNullsForceCollection(string message, Font font, List<string> collections)

        {
            var s = Console.ReadLine().ToLower();
            var contains = collections.Contains(s);

            while (string.IsNullOrEmpty(s) || contains == false)
            {
                font.SetTextToYellow($"Please, {message}");
                s = Console.ReadLine();
                contains = collections.Contains(s);
            }
            return s;
        }

        public static decimal ReadLineWarningNoNullsForceDecimal(string message, Font font)

        {
            var s = Console.ReadLine().Trim();
            decimal i;
            bool number = decimal.TryParse(s, out i);
            while (string.IsNullOrEmpty(s) || number == false)
            {
                font.SetTextToYellow($"Please, {message}");
                s = Console.ReadLine();
                number = decimal.TryParse(s, out i);
            }
            return i;
        }

        public static int ReturnMonth(Font font)

        {
            int counter = 0;
            int iMonth = -1;
            // loop until iMonth is 0
            while (iMonth != 0)
            {
                if (counter == 0)
                {
                    font.SetTextToTertiary("For a monthly leaderboard enter the month number from 1 to 12. Enter 0 to exit.");
                    counter++;
                }
                string sMonth = Console.ReadLine();

                // try to get a number from the string
                if (!int.TryParse(sMonth, out iMonth))
                {
                    font.SetTextToYellow("You did not enter a number.");
                    iMonth = -1; // so we continue the loop
                    continue;
                }

                // exit the program
                if (iMonth == 0) break;

                // not a month
                if (iMonth < 1 || iMonth > 12)
                {
                    font.SetTextToYellow("The number must be from 1 to 12.");
                    continue;
                }
                return iMonth;
            }
            return iMonth;
        }

        public static string ShowAirdropAudit(List<string> validAddress, List<string> invalidAddress, List<string> banishAddress, List<string> invalidNftData, List<string> alreadyActivatedAddress, string? nftMetadataName, decimal gasFeeTotal, string maxFeeToken, decimal transactionFeeTotal)
        {
            var excelFileName = $"TransferAudit_{DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss")}.csv";
            var csv = new StringBuilder();
            if (nftMetadataName == null)
            {
                nftMetadataName = "their Nft";
            }
            else if (nftMetadataName == "LRC")
            {
                nftMetadataName = "their LRC";
            }
            if (validAddress.Count > 0)
            {
                if (alreadyActivatedAddress.Count > 0)
                {
                    csv.AppendLine($"The following wallets were activated.");
                }
                else
                {
                    csv.AppendLine($"The following received {nftMetadataName}.");
                }
                foreach (var address in validAddress)
                {
                    csv.AppendLine(address);
                }
            }
            if (invalidAddress.Count > 0)
            {
                if (validAddress.Count > 0)
                {
                    csv.AppendLine();
                }
                if (alreadyActivatedAddress.Count > 0)
                {
                    csv.AppendLine($"The following were not activated. They are invalid addresses.");

                }
                else
                {
                    csv.AppendLine($"The following did not receive {nftMetadataName}. They are invalid addresses or do not have an active Loopring account.");
                }
                foreach (var address in invalidAddress)
                {
                    csv.AppendLine(address);
                }
            }
            if (banishAddress.Count > 0)
            {
                if (validAddress.Count > 0 || invalidAddress.Count > 0)
                {
                    csv.AppendLine();
                }
                csv.AppendLine($"The following were banish addresses that did not receive {nftMetadataName}.");
                foreach (var address in banishAddress)
                {
                    csv.AppendLine(address);
                }
            }
            if (invalidNftData != null)
            {
                if(invalidNftData.Count > 0)
                {
                    if (validAddress.Count > 0 || invalidAddress.Count > 0 || banishAddress.Count > 0)
                    {
                        csv.AppendLine();
                    }
                    csv.AppendLine($"The following were invalid Nft Data and the associated wallet did not receive {nftMetadataName}.");
                    foreach (var address in invalidNftData)
                    {
                        csv.AppendLine(address);
                    }
                }
            }
            if (alreadyActivatedAddress != null)
            {
                if (alreadyActivatedAddress.Count > 0)
                {
                    if (validAddress.Count > 0 || invalidAddress.Count > 0 || banishAddress.Count > 0)
                    {
                        csv.AppendLine();
                    }
                    csv.AppendLine($"The following were already activated wallets.");
                    foreach (var address in alreadyActivatedAddress)
                    {
                        csv.AppendLine(address);
                    }
                }
            }
            csv.AppendLine();
            csv.AppendLine($"Total Gas Fee: {(gasFeeTotal / 1000000000000000000m).ToString()} {maxFeeToken}");
            csv.AppendLine($"Total Transaction Fee: {transactionFeeTotal} {maxFeeToken}");
            csv.AppendLine($"Total LRC Spent: {transactionFeeTotal + ((gasFeeTotal / 1000000000000000000m))} {maxFeeToken}");
            File.WriteAllText($"{AppDomain.CurrentDomain.BaseDirectory}OutputFiles\\{excelFileName}", csv.ToString());
            return excelFileName;
        }
        public static string ShowAirdropAuditDead(List<string> validAddress, List<string> invalidAddress, List<string> banishAddress, List<string> invalidNftData, string? nftMetadataName, decimal gasFeeTotal, string maxFeeToken, decimal transactionFeeTotal)
        {
            var excelFileName = $"TransferAudit_{DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss")}.csv";
            var csv = new StringBuilder();
            if (nftMetadataName == null)
            {
                nftMetadataName = "their Nft";
            }
            if (validAddress.Count > 0)
            {
                //var newline = string.Format(address);
                csv.AppendLine($"The following Nfts were sent to the dead address.");
                foreach (var address in validAddress)
                {
                    csv.AppendLine(address);
                }
            }
            if (invalidAddress.Count > 0)
            {
                if (validAddress.Count > 0)
                {
                    csv.AppendLine();
                }
                csv.AppendLine($"The following did not receive get sent to the dead address.");
                foreach (var address in invalidAddress)
                {
                    csv.AppendLine(address);
                }
            }
            if (invalidNftData != null)
            {
                if (invalidNftData.Count > 0)
                {
                    if (validAddress.Count > 0 || invalidAddress.Count > 0 || banishAddress.Count > 0)
                    {
                        csv.AppendLine();
                    }
                    csv.AppendLine($"The following were invalid Nft Data and the associated wallet did not receive {nftMetadataName}.");
                    foreach (var address in invalidNftData)
                    {
                        csv.AppendLine(address);
                    }
                }
            }
            csv.AppendLine();
            csv.AppendLine($"Total Gas Fee: {(gasFeeTotal / 1000000000000000000m).ToString()} {maxFeeToken}");
            csv.AppendLine($"Total Transaction Fee: {transactionFeeTotal} {maxFeeToken}");
            csv.AppendLine($"Total LRC Spent: {transactionFeeTotal + ((gasFeeTotal / 1000000000000000000m))} {maxFeeToken}");
            File.WriteAllText($"{AppDomain.CurrentDomain.BaseDirectory}OutputFiles\\{excelFileName}", csv.ToString());
            return excelFileName;
        }

        public static void FunctionalityProcessTime(Stopwatch sw, string excelFileName, int? validAddresses, Font font)
        {
            if (validAddresses > 0)
            {
                Console.Write($"\r                                                                                                            ");
                font.SetTextToSecondaryInline($"\rFinished ");
                font.SetTextToPrimaryInline($"\rThere were {validAddresses} complete transactions.");
            }
            else
            {
                Console.Write($"\r                                                                                                            ");
                font.SetTextToSecondaryInline($"\rFinished. ");
            }
            font.SetTextToPrimary($"This took {Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m} seconds or {Math.Round(Convert.ToDecimal((sw.ElapsedMilliseconds) / 1000m) / 60, 3)} minutes to complete.");
            Console.WriteLine();
            font.SetTextToWhite($@"An audit file can be found at: {AppDomain.CurrentDomain.BaseDirectory}OutputFiles\{excelFileName}");
        }

        public static int GetUnixTimestamp() => (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        public static DateTime GetUnixTime(Int64 millisec)
        {
            TimeSpan time4 = TimeSpan.FromMilliseconds(millisec);
            DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            result = result.Add(time4);
            return result;
        }
        public static string GetUnixTimeMillisecondsStart(string date)
        {
            DateTime epoch = DateTime.UnixEpoch;
            string pattern = "M/dd/yyyy";
            TimeSpan tsStart = new TimeSpan(00, 00, 00);
            var startDate = DateTime.ParseExact(date, pattern, null) + tsStart;
            TimeSpan tsStarting = startDate.Subtract(epoch);
            string result = tsStarting.TotalMilliseconds.ToString();
            return result;
        }

        public static string GetUnixTimeMillisecondsEnd(string date)
        {
            DateTime epoch = DateTime.UnixEpoch;
            string pattern = "M/dd/yyyy";
            TimeSpan tsFinal = new TimeSpan(23, 59, 59);
            var endDate = DateTime.ParseExact(date, pattern, null) + tsFinal;
            TimeSpan tsEnding = endDate.Subtract(epoch);
            string result = tsEnding.TotalMilliseconds.ToString();
            return result;
        }
    }
}
