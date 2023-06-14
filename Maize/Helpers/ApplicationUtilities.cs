using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Maize.Models;
using Maize.Models.ApplicationSpecific;
using Maize.Models.Responses;
using Nethereum.BlockchainProcessing.BlockStorage.Entities.Mapping;
using Nethereum.Signer.EIP712;
using Nethereum.Util;
using Org.BouncyCastle.Asn1.X509.Qualified;
using PoseidonSharp;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Web;

namespace Maize.Helpers
{
    public class ApplicationUtilities
    {
        public static BigInteger ParseHexUnsigned(string toParse)
        {
            toParse = toParse.Replace("0x", "");
            var parsResult = BigInteger.Parse(toParse, System.Globalization.NumberStyles.HexNumber);
            if (parsResult < 0)
                parsResult = BigInteger.Parse("0" + toParse, System.Globalization.NumberStyles.HexNumber);
            return parsResult;
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

            signatureBase += UrlEncodeUpperCase(apiUrl + apiMethod) + "&";
            signatureBase += UrlEncodeUpperCase(parameterString);

            return SHA256Helper.CalculateSHA256HashNumber(signatureBase);
        }
        public static string UrlEncodeUpperCase(string stringToEncode)
        {
            var reg = new Regex(@"%[a-f0-9]{2}");
            stringToEncode = HttpUtility.UrlEncode(stringToEncode);
            return reg.Replace(stringToEncode, m => m.Value.ToUpperInvariant());
        }
        public static async Task<Font> NftChecks(Settings s, ILoopringService loopringService, Font font)
        {
            if (s.Environment == 1)
            {
                var nfts = await loopringService.GetNfts(s.LoopringApiKey, s.LoopringAccountId, $"{Constants.AccessLogo},{Constants.MaizeLdsLogo}");

                //AccessNftCheck(font, nfts);
                font = LDSNftCheck(font, nfts);
            }
            return font;
        }
        public static void AccessNftCheck(Font font, NftBalance nfts)
        {
            if (!nfts.data.Exists(x => x.nftData == Constants.AccessLogo))
                AccessNftDisclaimer(font);
            if (int.Parse(nfts.data.Where(x => x.nftData == Constants.AccessLogo).First().total) == 0)
                AccessNftDisclaimer(font);
        }
        public static Font LDSNftCheck(Font font, NftBalance nfts)
        {
            if (nfts.data.Exists(x => x.nftData == Constants.MaizeLdsLogo))
            {
                if (int.Parse(nfts.data.Where(x => x.nftData == Constants.MaizeLdsLogo).First().total) > 0) { }
                    return font = new Font(ConsoleColor.Blue, ConsoleColor.DarkMagenta, ConsoleColor.Magenta);
            }
            return font;
        }
        public static void AccessNftDisclaimer(Font font)
        {
            font.ToRed("In order to use this application you need to own 'Maize Origin Logo'.");
            font.ToSecondary("You can purchase one on Loopexchange at https://loopexchange.art/collection/maizeorigin.");
            font.ToTertiary("After obtaining one please be sure to restart the application.");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public static async Task<List<Leaderboard>> LeaderBoardForMenu(Settings s, ILoopringService loopringService, Constants.Environment environment)
        {
            List<Leaderboard> usersTransactionsAndNftsSent = new();
            if (s.Environment == 1)
            {
                var nftTransfersOverall = await loopringService.GetUserTransactions(s.LoopringApiKey, environment.MyAccountId, null, null);
                //usersTransactionsAndNftsSent = Leaderboards.GetLeaderBoardContestants(nftTransfersOverall.Where(x => x.memo.Contains("Nfts sent")).ToList());
            }
            return usersTransactionsAndNftsSent;
        }
        public static Stopwatch StartUtilityCalculationsTimer(Font font)
        {
            var sw = Stopwatch.StartNew();
            return sw;
        }
        public static async Task<(string userInput, AccountInformationResponse accountInformation)> GetAndCheckWalletAddress(ILoopringService loopringService, Font font, Settings s)
        {
            bool isSecondIteration = false;
            string userResponse;
            AccountInformationResponse accountInformation;
            var statement = "Enter the wallet address or ENS: ";
            do
            {
                userResponse = StatementCheck(isSecondIteration, statement, "Invalid input", font);
                accountInformation = await loopringService.GetUserAccountInformationFromOwner(await CheckForEthAddress(loopringService, s.LoopringApiKey, userResponse));
                isSecondIteration = true;
            }
            while (accountInformation == null);

            return (userResponse, accountInformation);
        }
        public static async Task<(string userInput, NftResponseFromCollection nftCollectionInformation)> CheckCollectionMintedOrOwnedAndGetNfts(ILoopringService loopringService, Font font, Settings s)
        {
            bool isSecondIteration = false;
            string userResponse;
            List<CollectionMinted> userMintedCollections;
            List<CollectionOwned> userOwnedCollections;
            var statement = "Enter the collection address: ";
            do
            {
                userResponse = StatementCheck(isSecondIteration, statement, null, font);
                userMintedCollections = await loopringService.GetUserMintedCollections(s.LoopringApiKey, s.LoopringAddress);

                if (userMintedCollections.Any(x => x.collection.collectionAddress == userResponse))
                {
                    var mintedCollectionNfts = await loopringService.GetCollectionNfts(s.LoopringApiKey, userMintedCollections.Where(x=>x.collection.collectionAddress == userResponse).First().collection.id.ToString());
                    
                    if (mintedCollectionNfts != null)
                        return (userResponse, mintedCollectionNfts);
                }
                userOwnedCollections = await loopringService.GetUserOwnedCollections(s.LoopringApiKey, s.LoopringAccountId);
                if (userOwnedCollections.Any(x => x.collection.collectionAddress == userResponse))
                {
                    var ownedCollectionNfts = await loopringService.GetCollectionNfts(s.LoopringApiKey, userOwnedCollections.Where(x => x.collection.collectionAddress == userResponse).First().collection.id.ToString());

                    if (ownedCollectionNfts != null)
                        return (userResponse, ownedCollectionNfts);
                }

                isSecondIteration = true;
            }
            while (userMintedCollections == null);
            return (userResponse, null);
        }
        public static async Task<(string userInput, NftResponseFromCollection nftCollectionInformation)> CheckCollectionAndGetNfts(ILoopringService loopringService, Font font, Settings s, string collectionAddress)
        {
            bool isSecondIteration = false;
            string userResponse;
            string userResponseTwo;
            List<CollectionMinted> userMintedCollections;
            List<CollectionOwned> userOwnedCollections;
            Font.ClearLine();
            font.ToSecondary("This collection is not minted or owned by you. Additional information is required.");
            var statement = "Enter the minter of the collection: ";
            var statementTwo = "Enter an NFT Id from the collection: ";

            userResponse = StatementCheck(isSecondIteration, statement, null, font);
            var address = await CheckForEthAddress(loopringService, s.LoopringApiKey, userResponse);
            userResponseTwo = StatementCheck(isSecondIteration, statementTwo, null, font);
            var nftdataRequest = await loopringService.GetNftData(s.LoopringApiKey, userResponseTwo, address.ToString(), collectionAddress);
            if (nftdataRequest == null)
                return (userResponse, null);
            var singleHolder = await loopringService.GetNftHolderSingle(s.LoopringApiKey, nftdataRequest.nftData);
            var collectionId = await loopringService.FindCollectionIdFromHolder(s.LoopringApiKey, singleHolder.nftHolders.First().accountId, nftdataRequest.nftData);
            var collectionNfts = await loopringService.GetCollectionNfts(s.LoopringApiKey, collectionId.data.First().collectionInfo.id.ToString());

            isSecondIteration = true;
            return (userResponse, collectionNfts);
        }
        public static string ReadLineWarningNoNulls(string message, Font font)
        {
            var s = Console.ReadLine();
            while (string.IsNullOrEmpty(s))
            {
                TryAgain(font, message, null);
                s = Console.ReadLine();
            }
            return s;
        }
        public static async Task<string> CheckForEthAddress(ILoopringService LoopringService, string apiKey, string address)
        {
            address = address.Trim().ToLower();
            if (address.Contains(".eth"))
            {
                var varHexAddress = await LoopringService.GetHexAddress(apiKey, address);
                if (!String.IsNullOrEmpty(varHexAddress.data))
                    return varHexAddress.data;
                else
                    return null;
            }
            return address;
        }
        public static void FunctionalityProcessTime(Stopwatch sw, string excelFileName, string? excelFileNameTwo, int? completedTransactions, Font font)
        {
            if (completedTransactions >= 0)
            {
                Font.ClearLine();
                FinshedDisplay(font);
                font.ToPrimaryInline($"\rThere were {completedTransactions} complete transactions.");
            }
            else
            {
                Font.ClearLine();
                FinshedDisplay(font);
            }
            font.ToSecondary($" This took {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? Math.Round(Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m / 60, 3) : Convert.ToDecimal(sw.ElapsedMilliseconds) / 1000m)} {(sw.ElapsedMilliseconds > (1 * 60 * 1000) ? "minutes" : "seconds")} to complete.");

            Console.WriteLine();
            if (excelFileNameTwo != null)
            {
                PrintStringCharacters("Your files are here: ", font);
                font.ToWhite(@$"{AppDomain.CurrentDomain.BaseDirectory}Output\{excelFileName}");
                Console.WriteLine();
                font.ToWhite(@$"{AppDomain.CurrentDomain.BaseDirectory}Output\{excelFileNameTwo}");
            }
            else
            {
                PrintStringCharacters("Your file is here: ", font);
                font.ToWhite(@$"{AppDomain.CurrentDomain.BaseDirectory}Output\{excelFileName}");
            }
        }
        public static void FinshedDisplay(Font font)
        {
            string line1 = "  _                              ";
            string line2 = "_|_  o  ._   o   _  |_    _    _|";
            string line3 = " |   |  | |  |  _>  | |  (/_  (_|";

            for (int i = 0; i < Math.Max(line1.Length, line2.Length); i++)
            {
                if (i < line1.Length)
                {
                    if (i > 0)
                        Console.SetCursorPosition(i, Console.CursorTop - 2);
                    font.ToPrimaryInline(line1[i].ToString());
                }

                if (i < line2.Length)
                {
                    Console.SetCursorPosition(i, Console.CursorTop + 1);
                    font.ToPrimaryInline(line2[i].ToString());
                }
                if (i < line3.Length)
                {
                    Console.SetCursorPosition(i, Console.CursorTop + 1);
                    font.ToPrimaryInline(line3[i].ToString());
                }
                Thread.Sleep(69);
            }
        }
        static void PrintStringCharacters(string input, Font font)
        {
            foreach (char c in input)
            {
                font.ToTertiaryInline(c.ToString());
                System.Threading.Thread.Sleep(42);
            }

            Console.WriteLine();
        }
        public static void EnvironmentCheck(Font font, int userAccountId, string loopringApiKey, string net, string userEnvironment)
        {
            if (userAccountId == 1234 || loopringApiKey == "asdfasdfasdfasdfasdfasdf")
            {
                ApiDisclaimer(font, net, userEnvironment);
            }
        }
        public static void ApiKeyCheck(Font font, string apiKey, string loopringApiKey, string net, string userEnvironment)
        {
            if (apiKey != loopringApiKey)
            {
                ApiDisclaimer(font, net, userEnvironment);
            }
        }
        static void ApiDisclaimer(Font font, string net, string userEnvironment)
        {
            font.ToRedInline($"Please check your {net}appsetting.json file located: {userEnvironment}. ");
            font.ToYellow("It it not correct <3");
            Console.WriteLine();
            font.ToSecondary("Reference this article for help: https://maizehelps.art/getstarted");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public static async Task<NftMetadata> GetNftMetadata(Font font, IEthereumService ethereumService,
           INftMetadataService nftMetadataService, string nftId, string collectionAddress)
        {
            NftMetadata nftMetadata;
            do
            {
                var nftMetaDataLink = await ethereumService.GetMetadataLink(nftId, collectionAddress, 0);
                nftMetadata = await nftMetadataService.GetMetadata(nftMetaDataLink);
                CheckIpfsForbidden(font, nftMetadata);
            } while (nftMetadata == null);
            return nftMetadata;
        }
        public static async Task<NftMetadata> GetNftMetadataUI(IEthereumService ethereumService,
        INftMetadataService nftMetadataService, string nftId, string collectionAddress)
        {
            NftMetadata nftMetadata;
            do
            {
                var nftMetaDataLink = await ethereumService.GetMetadataLink(nftId, collectionAddress, 0);
                nftMetadata = await nftMetadataService.GetMetadata(nftMetaDataLink);
                //CheckIpfsForbidden(font, nftMetadata);
            } while (nftMetadata == null);
            return nftMetadata;
        }
        public static void CheckIpfsForbidden(Font font, NftMetadata nftMetadata)
        {
            if (nftMetadata == null)
            {
                Font.ClearLine();
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 5 min.");
                Thread.Sleep(60000);
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 4 min.");
                Thread.Sleep(60000);
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 3 min.");
                Thread.Sleep(60000);
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 2 min.");
                Thread.Sleep(60000);
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 1 min.");
                Thread.Sleep(60000);
            }

        }
        public static string CheckYes(Font font, string statement)
        {
            bool isSecondIteration = false;
            string userResponse;
            statement = $"{statement}: ";
            do
            {
                userResponse = StatementCheck(isSecondIteration, statement, "yes", font);
                isSecondIteration = true;
            } while ((userResponse != "yes") && (userResponse != "y"));
            return userResponse;
        }
        public static string CheckYesOrNo(Font font, string statement)
        {
            bool isSecondIteration = false;
            string userResponse;
            statement = $"{statement}: ";
            do
            {
                userResponse = StatementCheck(isSecondIteration, statement, "yes or no", font);
                isSecondIteration = true;
            } while ((userResponse != "yes") && (userResponse != "no") && (userResponse != "y") && (userResponse != "n"));
            return userResponse;
        }
        public static string CheckYesOrHelp(Font font)
        {
            bool isSecondIteration = false;
            string userResponse;
            var statement = $"Did you setup your {Constants.InputFile}? (help for file setup): ";
            do
            {
                userResponse = StatementCheck(isSecondIteration, statement, "yes or help", font);
                isSecondIteration = true;
            } while ((userResponse != "yes") && (userResponse != "help") && (userResponse != "y") && (userResponse != "h"));
            return userResponse;
        }
        public static string CheckMainnetOrTestnet(Font font)
        {
            bool isSecondIteration = false;
            string userResponse;
            var statement = "Enter mainnet or testnet: ";
            do
            {
                userResponse = StatementCheck(isSecondIteration, statement, null, font);
                isSecondIteration = true;
            } while ((userResponse != "mainnet") && (userResponse != "m") && (userResponse != "testnet") && (userResponse != "t"));

            if (userResponse == "m")
                userResponse = "mainnet";
            else if (userResponse == "t")
                userResponse = "testnet";
            return userResponse;
        }
        public static int CheckUtilityNumber(int maxUtilityNumber, Font font)
        {
            bool isSecondIteration = false;
            string userResponse;
            int number;
            bool userResponseInt;
            var statement = "Which would you like to do: ";
            do
            {
                userResponse = StatementCheck(isSecondIteration, statement, $"0 - {maxUtilityNumber}", font);
                userResponseInt = int.TryParse(userResponse, out number);
                isSecondIteration = true;
            } while (number > maxUtilityNumber || number < 0 || userResponseInt == false);
            return number;
        }
        public static string WriteDataToCsvFile<T>(string filePath, IEnumerable<T> data)
        {
            var fileName = $"{filePath}_{DateTime.UtcNow:yyyy-MM-dd mHH-mm-ss}.csv";
            using (var writer = new StreamWriter($"{Constants.BaseDirectory}{Constants.OutputFolder}{fileName}"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }
            return fileName;
        }


        public static void TryAgain(Font font, string message, string? helpText)
        {
            Font.ClearLineAbove();
            if (helpText == null)
                font.ToRedInline("Try again");
            else font.ToRedInline(helpText);
            font.ToTertiaryInline($" | {message}");
        }
        public static string StatementCheck(bool isSecondIteration, string statement, string helpText, Font font)
        {
            if (isSecondIteration)
                TryAgain(font, statement, helpText);
            else
                font.ToTertiaryInline(statement);

            return ReadLineWarningNoNulls(statement, font);
        }
    }
}