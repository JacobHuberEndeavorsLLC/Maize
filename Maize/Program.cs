using CsvHelper;
using Maize;
using Maize.Helpers;
using Maize.Models;
using LoopringSharp;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Diagnostics;
using System.Text;
using Maize.Services;
using Newtonsoft.Json;
using static Maize.Services.NftStorageService;

//Utils.CheckAppsettingsDotJson();
//Console.WindowHeight = 37;
//Console.WindowWidth = 108;
Console.Title = "Maize: read to succeed";
var consoleForegroundColorPrimary = ConsoleColor.DarkYellow;
var consoleForegroundColorSecondary = ConsoleColor.DarkGreen;
var consoleForegroundColorTertiary = ConsoleColor.Green;
Console.ForegroundColor = consoleForegroundColorPrimary;
Font font = new(consoleForegroundColorPrimary, consoleForegroundColorSecondary, consoleForegroundColorTertiary);
Console.WriteLine("Enter mainnet or testnet.");
Console.ResetColor();
var net = Utils.CheckMainnetOrTestnet(font);
var inputPath = "Input";
var environmentPath = "Input/Environment";
var fileName = "Input.txt";
var banishFile = "Banish.txt";

string userEnvironment = $"./{environmentPath}/{net}appsettings.json";
    Console.Title = $"Maize: read to succeed ({net})";
Console.Clear();

//Settings loaded from the appsettings.json file
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile(userEnvironment)
    .AddEnvironmentVariables()
    .Build();
Settings settings = config.GetRequiredSection("Settings").Get<Settings>();
string loopringApiKey = settings.LoopringApiKey;//loopring api key KEEP PRIVATE
string loopringPrivateKey = settings.LoopringPrivateKey; //loopring private key KEEP PRIVATE
var MMorGMEPrivateKey = settings.MMorGMEPrivateKey; //metamask or gamestop private key KEEP PRIVATE
var fromAddress = settings.LoopringAddress; //your loopring address
var fromAccountId = settings.LoopringAccountId; //your loopring account id
var validUntil = settings.ValidUntil; //the examples seem to use this number
var maxFeeTokenId = 1; //0 should be for ETH, 1 is for LRC BUUUUT hardcoding LRC cause LRC
int toAccountId = 0; //leave this as 0 DO NOT CHANGE
int environment = settings.Environment;
string pinataJwt = settings.PinataJwt;
string nftStorageApiKey = settings.NftStorageApiKey;
if (pinataJwt == null || nftStorageApiKey == null)
{
    font.ToRed("Please use the new appsettings files from github: https://github.com/cobmin/Maize/releases. v0.2.0+");
    Environment.Exit(0);
}
int nftType = 0;
string environmentUrl;
string environmentExchange;
string nftFactory;
string nftFactoryCollection;
string maxFeeToken = "LRC";
string myAddress = "0x37EA02537f3A7A7fFC221125245905Be3D5423e6";
int myAccountId;

string accessLogo = "0x08dccae9dac82c69e6836977c932bb55e608d548d19e95addee8817f7edb5f8d";
string maizeLdsLogo= "0x2fa975f47dc5929980a8bc01ad5173302a9f6f246ae219ac7a0a4592547cdf87";
decimal lcrTransactionFee = 0.000000000000000001m;

if (environment == 1)
{
    environmentUrl = "https://api3.loopring.io/";
    environmentExchange = "0x0BABA1Ad5bE3a5C0a66E7ac838a129Bf948f1eA4";
    nftFactory = "0xc852aC7aAe4b0f0a0Deb9e8A391ebA2047d80026";
    nftFactoryCollection = "0x97BE94250AEF1Df307749aFAeD27f9bc8aB911db";
    myAccountId = 79142;
}
else
{
    environmentUrl = "https://uat2.loopring.io/";
    environmentExchange = "0x2e76EBd1c7c0C8e7c2B875b6d505a260C525d25e";
    nftFactory = "0x7Da2849B1E5B9849553328aFe6E187C8621D8D5d";
    nftFactoryCollection = "0xfDDA90dbCc99B3a91e3fB1292991Ba1076d9E281";
    myAccountId = 15504;
}

ILoopringService loopringService = new LoopringService(environmentUrl, font);
ILoopringMintService loopringMintService = new LoopringMintService(environmentUrl, font);
//ILoopExchangeService loopExchangeService = new LoopExchangeService(font);
IEthereumService ethereumService = new EthereumService();
INftMetadataService nftMetadataService = new NftMetadataService("https://ipfs.loopring.io/ipfs/");

List<MintsAndTotal> userMintsAndTotalList = new();
List<NftHolder> nftHoldersAndTotalList = new();
List<NftHolder> nftHoldersList = new();
List<Leaderboard> usersTransactionsAndNftsSent = new();
NftBalance userNftToken = new();
NftMetadata nftMetadata = new();
MinterAndCollection minterAndCollection = new();
AccountInformation userAccountInformation = new();
string nftData;
bool contains = false;
var sw = new Stopwatch();

var signedMessage = EDDSAHelper.EddsaSignUrl(
loopringPrivateKey,
HttpMethod.Get,
new List<(string Key, string Value)>() { ("accountId", fromAccountId.ToString()) },
null,
"api/v3/apiKey",
environmentUrl);
var apiKey = await loopringService.GetApiKey(fromAccountId, signedMessage);

if (apiKey != loopringApiKey)
{
    font.ToRed("The appsettings.json does not appear to be setup correctly.");
    font.ToRed($"Please check the values in the appsetting.json and restart the application.");
    Console.ReadLine();
    Environment.Exit(0);
}
if (environment == 1)
{
    var nftCheck = await loopringService.GetTokenId(loopringApiKey, fromAccountId, $"{accessLogo},{maizeLdsLogo}");
    if (!nftCheck.data.Exists(x => x.nftData == "0x08dccae9dac82c69e6836977c932bb55e608d548d19e95addee8817f7edb5f8d"))
    {
        font.ToRed("In order to use this application you need to own 'Maize Origin Logo'.");
        font.ToDarkGray("You can purchase one on Loopexchange at https://loopexchange.art/collection/maizeorigin.");
        font.ToDarkGray("After obtaining one please be sure to restart the application.");
        Console.ReadLine();
        Environment.Exit(0);
    }
    if (int.Parse(nftCheck.data.Where(x => x.nftData == accessLogo).First().total) == 0)
    {
        font.ToRed("In order to use this application you need to own 'Maize Origin Logo'.");
        font.ToDarkGray("You can purchase one on Loopexchange at https://loopexchange.art/collection/maizeorigin.");
        font.ToDarkGray("After obtaining one please be sure to restart the application.");
        Console.ReadLine();
        Environment.Exit(0);
    }
    if (nftCheck.data.Exists(x => x.nftData == maizeLdsLogo))
    {
        if (int.Parse(nftCheck.data.Where(x => x.nftData == maizeLdsLogo).First().total) > 0)
        {
            consoleForegroundColorPrimary = ConsoleColor.Blue;
            consoleForegroundColorSecondary = ConsoleColor.DarkMagenta;
            consoleForegroundColorTertiary = ConsoleColor.Magenta;
            font = new Font(consoleForegroundColorPrimary, consoleForegroundColorSecondary, consoleForegroundColorTertiary);
        }
    }
    var nftTransfersOverall = await loopringService.GetUserTransactions(loopringApiKey, myAccountId, null, null);
    nftTransfersOverall = nftTransfersOverall.Where(x => x.memo.Contains("Nfts sent")).ToList();
    usersTransactionsAndNftsSent = Leaderboards.GetLeaderBoardContestants(nftTransfersOverall);
}

Menu.BannerForMaize(font, usersTransactionsAndNftsSent);

font.ToTertiary("Ready to start?");
var userResponseReadyToMoveOn = Utils.CheckYesOrNo(font);

while (userResponseReadyToMoveOn == "yes" || userResponseReadyToMoveOn == "y")
{
    Console.WriteLine();
    font.SetVersionFontColor($"Hey,", $" {fromAddress}.", " I hope you're doing corntastic ^_^");
    var menuAndUtility = Menu.MenuForMaize(font, environment);

    switch (menuAndUtility.userResponseOnUtility)
    {
        #region case 0
        case "0":
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(0).Value} -");
            Console.WriteLine();
            font.ToSecondary("\t What can this application do?");
            font.ToWhite("\t Maize can mass transfer crypto and Nfts.");
            font.ToWhite("\t It also provides certain analytics on Nfts.");
            font.ToWhite("\t Check out the menu for specific functionality.");
            Console.WriteLine();
            font.ToSecondary("\t What is Nft Data used for?");
            font.ToWhite("\t Nft Data is used to find your unique Nft on the blockchain.");
            font.ToWhite("\t Once you have the Nft Data you are able to find Nft Holders, ");
            font.ToWhite("\t lookup analytics, and transfer Nfts.");
            Console.WriteLine();
            font.ToSecondary("\t Is Nft Data and same as Nft Id?");
            font.ToWhite("\t Nft Data is not the same as an Nft Id, but Nft Data comes");
            font.ToWhite("\t from an Nft Id.");
            font.ToWhite("\t You can find the Nft Id on any Loopring Explorer and");
            font.ToWhite("\t typically any marketplace.");
            Console.WriteLine();
            font.ToSecondary("\t What wallet can I use to Airdrop and transfer?");
            font.ToWhite("\t You can use a MetaMask wallet or a GameStop Wallet.");
            font.ToWhite("\t For those wondering, unfortunately, you cannot use a");
            font.ToWhite("\t Loopring wallet to perform Airdrops.");
            Console.WriteLine();
            font.ToSecondary("\t What blockchains does Maize use?");
            font.ToWhite("\t Right now Maize works with Loopring.");
            Console.WriteLine();
            font.ToSecondary("\t What are the transaction fees about?");
            font.ToWhite($"\t The transaction fees are {lcrTransactionFee} {maxFeeToken} per transfer.");
            font.ToWhite($"\t This includes both Nft and {maxFeeToken} transfers.");
            font.ToWhite("\t The transaciton fees are needed to determine transactions and Nfts sent.");
            break;
        #endregion
        #region case 1
        case "1":
            Minter minter = new Minter();
            var minterAddress = fromAddress;
            Menu.UtilityHeader(font, menuAndUtility.allUtilities.ElementAt(1).Value, "Here you will create an Nft Collection.", "You will need The cids of your images.", "This infomation can be found in ipfs.", false);
            var name = "";
            var description = "";
            var avatar = "";
            var banner = "";
            var tileUri = "";

            while (string.IsNullOrEmpty(name))
            {
                font.ToTertiary("Enter name for collection.");
                name = Console.ReadLine().Trim();
            }
            while (string.IsNullOrEmpty(description))
            {
                font.ToTertiary("Enter description for collection.");
                description = Console.ReadLine().Trim();
            }
            while (!avatar.StartsWith("Qm"))
            {
                font.ToTertiary("Enter avatar ipfs cid for collection.");
                avatar = Console.ReadLine().Trim();
            }
            while (!banner.StartsWith("Qm"))
            {
                font.ToTertiary("Enter banner ipfs cid for collection.");
                banner = Console.ReadLine().Trim();
            }
            while (!tileUri.StartsWith("Qm"))
            {
                font.ToTertiary("Enter tileUri ipfs cid for collection.");
                tileUri = Console.ReadLine().Trim();
            }

            var collectionResult = await minter.CreateNftCollection(
                loopringMintService,
                loopringApiKey,
                "ipfs://" + avatar,
                "ipfs://" + banner,
                description,
                name,
                nftFactoryCollection,
                minterAddress,
                "ipfs://" + tileUri,
                loopringPrivateKey,
                false
            );
            break;
        #endregion case 1
        #region case 2
        case "2":
            minter = new Minter();
            var royaltyAddress = "";
            string nftAmount = "";
            string collectionContractAddress = "";
            string done;
            int nftRoyaltyPercentage;
            minterAddress = fromAddress;

            Menu.UtilityHeader(font, menuAndUtility.allUtilities.ElementAt(2).Value, "Here you will Mint Nfts in a Collection.", "You will need The cids of your metadata and the collection address.", "This infomation can be found in ipfs.", true);

            var lineCount = Utils.CheckInputDotTxt(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            var count = 0;

            font.ToPrimary("Your Collections:");
            var userCollectionData = await loopringService.GetNftCollection(loopringApiKey, fromAddress);
            var collections = new List<string>();
            if (userCollectionData.totalNum > 0)
            {
                foreach (var item in userCollectionData.collections)
                {
                    if (item.collection == userCollectionData.collections.Last().collection)
                    {
                        font.ToWhiteInline($"{item.collection.name}");
                    }
                    else
                    {
                        font.ToWhiteInline($"{item.collection.name}, ");
                    }
                    collections.Add(item.collection.name.ToLower());
                }
                Console.WriteLine();
                font.ToTertiary("Enter a collection.");

                collectionContractAddress = Utils.ReadLineWarningNoNullsForceCollection("Please enter a collection.", font, collections);
                collectionContractAddress = userCollectionData.collections.Where(x => x.collection.name.ToLower() == collectionContractAddress).First().collection.collectionAddress;
                //var userCollectionInformation = await loopringService.GetNftCollectionInformation(loopringApiKey, userCollectionData.collections.Where(x => x.collection.name.ToLower() == userCollection).First().collection.id.ToString());

            }
            else
            {
                Console.WriteLine();
                font.ToYellow($"{fromAddress} does not have any collections.");
                break;
            }

            font.ToTertiary("Enter the amount of NFTs to mint for each cid provided. (1 - 100,000)");
            nftAmount = Utils.ReadLineWarningNoNullsForceInt("Enter the amount of NFTs to mint for each cid provided. (1 - 100,000)", font, 1, 100000);

            font.ToTertiary("Would you like a differnt Royalty Address than yours? ");
            var userResponse = Utils.CheckYesOrNo(font);

            if (userResponse == "y" || userResponse == "yes")
            {
                while (!royaltyAddress.StartsWith("0x"))
                {
                    font.ToTertiary("Enter the hex address.");
                    royaltyAddress = Console.ReadLine().Trim();
                }
            }
            else
            {
                royaltyAddress = fromAddress;
            }
            font.ToTertiary("Enter the royalty percentage for each cid provided. (1 - 10)");
            nftRoyaltyPercentage = int.Parse(Utils.ReadLineWarningNoNullsForceInt("Enter the royalty percentage for each cid provided. (1 - 10)", font, 1, 10));
            Console.WriteLine();

            var collectionResultMint = await minter.FindNftCollection(loopringMintService, loopringApiKey, 12, 0, minterAddress, collectionContractAddress, false);
            if (collectionResultMint == null)
            {
                Console.WriteLine($"Could not find collection with contract address {collectionContractAddress}");
                System.Environment.Exit(0);
            }
            var offChainFee = await minter.GetMintFee(loopringMintService, loopringApiKey, fromAccountId, minterAddress, nftFactoryCollection, false, collectionResultMint.collections[0].collection.baseUri);
            var fee = offChainFee.fees[maxFeeTokenId].fee;
            double feeAmount = lineCount * Double.Parse(fee);
            if (maxFeeTokenId == 0)
            {
                font.ToPrimary($"It will cost around {TokenAmountConverter.ToString(feeAmount, 18)} ETH to mint {lineCount} NFTs");
            }
            else if (maxFeeTokenId == 1)
            {
                font.ToPrimary($"It will cost around {TokenAmountConverter.ToString(feeAmount, 18)} LRC to mint {lineCount} NFTs");
            }
            else
            {
                font.ToYellow("Can only use MaxFeeTokenId of 0 for ETH or MaxFeeTokenId of 1 for LRC. Please set this correctly in your appsettings.json file!");
                System.Environment.Exit(0);
            }

            font.ToTertiary("Continue with minting?");
            string continueMinting = Utils.CheckYesOrNo(font);


            if (continueMinting == "n" || continueMinting == "no")
            {
                font.ToTertiary("Minting cancelled");
                System.Environment.Exit(0);
            }
            else if (continueMinting == "y" || continueMinting == "yes")
            {
                Console.WriteLine();
                font.ToPrimary($"Minting started");
            }

            List<MintResponseData> mintResponses = new List<MintResponseData>();
            using (StreamReader sr = new StreamReader($"./{inputPath}/{fileName}"))
            {
                string currentCid;
                //currentCid will be null when the StreamReader reaches the end of file
                while ((currentCid = sr.ReadLine()) != null)
                {
                    currentCid = currentCid.Trim();
                    count++;
                    Console.WriteLine($"Minting Nft: {count}/{lineCount}");
                    Utils.ClearLine();
                    var mintResponse = await minter.MintCollection(loopringMintService, loopringApiKey, loopringPrivateKey, minterAddress, fromAccountId, nftType, nftRoyaltyPercentage, int.Parse(nftAmount), validUntil, maxFeeTokenId, nftFactoryCollection, environmentExchange, currentCid, false, collectionResultMint.collections[0].collection.baseUri, collectionContractAddress, royaltyAddress);
                    mintResponses.Add(mintResponse);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }
                Console.WriteLine();
            }
            if (mintResponses.Where(x=>x.status == "Minted successfully").Count() > 0)
            {
                // transfer to cob
                done = await loopringService.CobTransferTransactionFee(
                    environment,
                    environmentUrl,
                    environmentExchange,
                    loopringApiKey,
                    loopringPrivateKey,
                    MMorGMEPrivateKey,
                    fromAccountId,
                    lcrTransactionFee,
                    mintResponses.Where(x => x.status == "Minted successfully").Count(),
                    maxFeeToken,
                    maxFeeTokenId,
                    myAddress,
                    fromAddress,
                    2
                    );
            }

            string csvName = $"Mints_{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.csv";
            using (var writer = new StreamWriter($"./Output/{csvName}"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(mintResponses);
                Console.WriteLine();
                font.ToWhite($@"CSV can be found in the following location: {AppDomain.CurrentDomain.BaseDirectory}Output\{csvName}");
            }
            break;
        #endregion case 2
        #region case 3
        case "3":
            nftData = "";
            Menu.UtilityHeader(font, menuAndUtility.allUtilities.ElementAt(3).Value, "Here you will Upload an Image to nft.storage, upload Metadata to Pinata, Mint the Nft, and send it to specific wallets.", "You will need an image, metadata, and wallet addresses.", $@"Place your image and metadata in here: {AppDomain.CurrentDomain.BaseDirectory}Input\Files", false);
            string nftImageDirectoryFilePath = "./Input/Files/";
            var imageDirectoryFileNames = await Utils.GetTwoFilesInDirectory(font, nftImageDirectoryFilePath);
            INftStorageService nftStorageService = new NftStorageService();
            font.ToSecondary("Which collection are you minting to?");
            font.ToPrimary("Your Collections:");
            userCollectionData = await loopringService.GetNftCollection(loopringApiKey, fromAddress);
            collections = new List<string>();
            if (userCollectionData.totalNum > 0)
            {
                foreach (var item in userCollectionData.collections)
                {
                    if (item.collection == userCollectionData.collections.Last().collection)
                    {
                        font.ToWhiteInline($"{item.collection.name}");
                    }
                    else
                    {
                        font.ToWhiteInline($"{item.collection.name}, ");
                    }
                    collections.Add(item.collection.name.ToLower());
                }
                Console.WriteLine();
                font.ToTertiary("Enter a collection.");

                collectionContractAddress = Utils.ReadLineWarningNoNullsForceCollection("Please enter a collection.", font, collections);
                Console.WriteLine();
                font.ToPrimary("Starting Uploads:");
                font.ToWhiteInline($"\rGathering information...");
                collectionContractAddress = userCollectionData.collections.Where(x => x.collection.name.ToLower() == collectionContractAddress).First().collection.collectionAddress;
            }
            else
            {
                Console.WriteLine();
                font.ToYellow($"{fromAddress} does not have any collections. Please create one with functionality 1 and then return.");
                break;
            }
            foreach (FileInfo nftFileInfo in imageDirectoryFileNames)
            {
                if (nftFileInfo.Name.Contains(".json"))
                    continue;
                string nftName = nftFileInfo.Name.Split('.')[0]; 

                //Submit image to pinata section
                PinataMetadata imageMetadata
                    = new PinataMetadata
                    {
                        name = nftName + " - image",
                        keyvalues = new KeyValues
                        {
                            nameKey = nftName + " - image"
                        }
                    };
                string pinataImageMetadataJsonString = JsonConvert.SerializeObject(imageMetadata);
                font.ToWhiteInline($"\rUploading {nftFileInfo.Name} to nft.storage");
                NFTStorageUploadResponse? nftStorageImageResponseData = await nftStorageService.UploadDataFromFile(font, nftFileInfo.FullName, nftStorageApiKey);
                Utils.ClearLine();
                font.ToPrimary($"\r{nftName}{nftFileInfo.Extension} uploaded to nft.storage successfully");
                var nftMetadataString = File.ReadAllText($"{nftFileInfo.DirectoryName}\\{nftName}.json").Replace("xxxxxxxxxx", collectionContractAddress).Replace("xxxxx", nftStorageImageResponseData.value.cid);
                font.ToWhiteInline($"Uploading {nftName}.json image to Pinata");
                PinataMetadata metadatajson = new PinataMetadata
                {
                    name = nftName + " - metadata.json",
                    keyvalues = new KeyValues
                    {
                        nameKey = nftName + " - metadata.json"
                    }
                };
                string pinataMetadataJsonString = JsonConvert.SerializeObject(metadatajson);
                byte[] nftMetaDataByteArray = Encoding.ASCII.GetBytes(nftMetadataString);
                IPinataService pinataService = new PinataService();
                string pinataAuthentication = await pinataService.TestAuthentication(pinataJwt);
                if (!pinataAuthentication.Contains("Congratulations"))
                {
                    Utils.ClearLine();
                    font.ToRedInline($"\rError in loading to pinata: {pinataAuthentication}. Check your pinataJwt in the appsettings file. You can get a key here: https://app.pinata.cloud/developers");
                    Environment.Exit(0);
                }
                PinataResponseData? pinataMetadataResponseData = await pinataService.SubmitPin(pinataJwt, nftMetaDataByteArray, "metadata.json", pinataMetadata: pinataMetadataJsonString);
                Utils.ClearLine();
                font.ToPrimaryInline($"\r{nftName}.json metadata uploaded to Pinata successfully");



                //Add nft cid triple to list for later csv generation
                List<NftCidTriplet> metadataCIDTriplets = new List<NftCidTriplet>();
                NftCidTriplet nftCidTriplet = new NftCidTriplet
                {
                    Id = nftName,
                    MetadataCid = pinataMetadataResponseData.IpfsHash,
                    ImageCid = nftStorageImageResponseData.value.cid
                };
                metadataCIDTriplets.Add(nftCidTriplet);
                //Generate nft cid triplet csv here
                if (metadataCIDTriplets.Count > 0)
                {
                    csvName = $"Uploading_{DateTime.Now.ToString("yyyy-mm-dd hh-mm-ss")}.csv";
                    using (var writer = new StreamWriter($"./Output/{csvName}"))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(metadataCIDTriplets);
                        Console.WriteLine();
                        Console.WriteLine();
                        font.ToWhite($"CSV can be found in the following location: {AppDomain.CurrentDomain.BaseDirectory}Output\\{csvName}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Did not generate any Metadata CIDS");
                }

                // START MINTING
                font.ToPrimary("Starting Minting:");
                minter = new Minter();
                royaltyAddress = "";
                nftAmount = "";
                done = "";
                minterAddress = fromAddress;
                count = 0;

                font.ToTertiary($"Enter the amount of editions for your Nft. (1 - 100,000)");
                nftAmount = Utils.ReadLineWarningNoNullsForceInt("Enter the amount of NFTs to mint for your Nft. (1 - 100,000)", font, 1, 100000);

                font.ToTertiary("Would you like a differnt Royalty Address than yours? ");
                userResponse = Utils.CheckYesOrNo(font);

                if (userResponse == "y" || userResponse == "yes")
                {
                    while (!royaltyAddress.StartsWith("0x"))
                    {
                        font.ToTertiary("Enter the hex address.");
                        royaltyAddress = Console.ReadLine().Trim();
                    }
                }
                else
                {
                    royaltyAddress = fromAddress;
                }
                font.ToTertiary("Enter the royalty percentage for this nft (1 - 10).");
                nftRoyaltyPercentage = int.Parse(Utils.ReadLineWarningNoNullsForceInt("Enter the royalty percentage for this nft (1 - 10).", font, 1, 10));
                Console.WriteLine();

                collectionResultMint = await minter.FindNftCollection(loopringMintService, loopringApiKey, 12, 0, minterAddress, collectionContractAddress, false);
                if (collectionResultMint == null)
                {
                    Console.WriteLine($"Could not find collection with contract address {collectionContractAddress}");
                    System.Environment.Exit(0);
                }
                offChainFee = await minter.GetMintFee(loopringMintService, loopringApiKey, fromAccountId, minterAddress, nftFactoryCollection, false, collectionResultMint.collections[0].collection.baseUri);
                fee = offChainFee.fees[maxFeeTokenId].fee;
                feeAmount = 1 * Double.Parse(fee);
                if (maxFeeTokenId == 0)
                {
                    font.ToPrimary($"It will cost around {TokenAmountConverter.ToString(feeAmount, 18)} ETH to mint this NFT");
                }
                else if (maxFeeTokenId == 1)
                {
                    font.ToPrimary($"It will cost around {TokenAmountConverter.ToString(feeAmount, 18)} LRC to mint this NFT");
                }
                else
                {
                    font.ToYellow("Can only use MaxFeeTokenId of 0 for ETH or MaxFeeTokenId of 1 for LRC. Please set this correctly in your appsettings.json file!");
                    System.Environment.Exit(0);
                }

                font.ToTertiary("Continue with minting?");
                continueMinting = Utils.CheckYesOrNo(font);


                if (continueMinting == "n" || continueMinting == "no")
                {
                    font.ToTertiary("Minting cancelled");
                    System.Environment.Exit(0);
                }
                else if (continueMinting == "y" || continueMinting == "yes")
                {
                    Console.WriteLine();
                    font.ToWhite($"Minting started");
                }

                mintResponses = new List<MintResponseData>();

                string currentCid = pinataMetadataResponseData.IpfsHash;

                currentCid = currentCid.Trim();
                count++;
                font.ToPrimaryInline("\rMinting completed successfully");
                Utils.ClearLine();
                var mintResponse = await minter.MintCollection(loopringMintService, loopringApiKey, loopringPrivateKey, minterAddress, fromAccountId, nftType, nftRoyaltyPercentage, int.Parse(nftAmount), validUntil, maxFeeTokenId, nftFactoryCollection, environmentExchange, currentCid, false, collectionResultMint.collections[0].collection.baseUri, collectionContractAddress, royaltyAddress);
                mintResponses.Add(mintResponse);
                nftData = mintResponses.FirstOrDefault().nftData;
                Console.SetCursorPosition(0, Console.CursorTop - 1);

                Console.WriteLine();
                
                if (mintResponses.Where(x => x.status == "Minted successfully").Count() > 0)
                {
                    // transfer to cob
                    done = await loopringService.CobTransferTransactionFee(
                        environment,
                        environmentUrl,
                        environmentExchange,
                        loopringApiKey,
                        loopringPrivateKey,
                        MMorGMEPrivateKey,
                        fromAccountId,
                        lcrTransactionFee,
                        mintResponses.Where(x => x.status == "Minted successfully").Count(),
                        maxFeeToken,
                        maxFeeTokenId,
                        myAddress,
                        fromAddress,
                        2
                        );
                }

                csvName = $"Mints_{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.csv";
                using (var writer = new StreamWriter($"./Output/{csvName}"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(mintResponses);
                    Console.WriteLine();
                    font.ToWhite($@"CSV can be found in the following location: {AppDomain.CurrentDomain.BaseDirectory}Output\{csvName}");
                }
                if (mintResponse.status == "Mint failed")
                {
                    font.ToRed("The mint failed. Please review the output file specified above.");
                    break;
                }
            }
            // START TRANSFER
            int nftTokenId;
            NftData nftdataRequest;
            Console.WriteLine();
            font.ToPrimary("Starting Transfers:");
            var fileAmounts = Utils.CheckInputDotTxtTwoInputsNft(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            font.ToDarkGray($"You will be transfering to {fileAmounts.walletAmount} wallets.");
            font.ToWhite($"Finding Nft. This might take up to a minute. Wait for the next prompt.");
            Console.WriteLine();

            userNftToken = await loopringService.GetTokenIdWithCheck(settings.LoopringApiKey, settings.LoopringAccountId, nftData);
            nftTokenId = userNftToken.data[0].tokenId;
            
            nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, userNftToken.data[0].nftId, userNftToken.data[0].tokenAddress);
            Utils.CheckNftSendAmountTwoInputs(int.Parse(menuAndUtility.userResponseOnUtility), fileAmounts.nftAmount, userNftToken.data[0].total, fileName, inputPath, font);

            var transferMemo = UtilsLoopring.CheckMemoLimit(font);
            Console.WriteLine();
            font.ToDarkGray($"You are about to transfer {fileAmounts.nftAmount} '{nftMetadata.name}' to {fileAmounts.walletAmount} wallets");
            font.ToDarkGray($"with a memo of: {transferMemo}");
            var offChainFeeCheck = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");
            var feeAmountCheck = offChainFeeCheck.fees.Where(w => w.token == maxFeeToken.ToString()).First().fee;
            font.ToDarkGray($"Gas fees will be around {(decimal.Parse(feeAmountCheck) / 1000000000000000000m) * Convert.ToDecimal(fileAmounts.walletAmount)} {maxFeeToken}.");
            font.ToPrimary($"Transaction fee will be around {fileAmounts.walletAmount * lcrTransactionFee} {maxFeeToken}.");

            font.ToTertiary("Enter 'yes' for the transfers to start or 'no' to start over.");
            userResponse = Utils.CheckYesOrNo(font);
            if (userResponse == "no" || userResponse == "n")
            {
                break;
            }

            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Starting airdrop...");

            // nft transfer
            var nftTransferAuditInformation = await loopringService.NftTransfer(
                font,
                loopringService,
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                toAccountId,
                maxFeeToken,
                maxFeeTokenId,
                fromAddress,
                fileName,
                inputPath,
                fileAmounts.walletAmount,
                nftTokenId,
                null,
                validUntil,
                lcrTransactionFee,
                transferMemo,
                nftData
                );

            // transfer to cob
            done = await loopringService.CobTransferTransactionFee(
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                nftTransferAuditInformation.transactionFeeTotal,
                nftTransferAuditInformation.nftSentTotal,
                maxFeeToken,
                maxFeeTokenId,
                myAddress,
                fromAddress,
                0
                );

            var excelFileName = Utils.ShowAirdropAudit(nftTransferAuditInformation.validAddress, nftTransferAuditInformation.invalidAddress, nftTransferAuditInformation.banishAddress, null, nftTransferAuditInformation.alreadyActivatedAddress, nftMetadata.name, nftTransferAuditInformation.gasFeeTotal, maxFeeToken, nftTransferAuditInformation.transactionFeeTotal);
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, nftTransferAuditInformation.validAddress.Count, font);
            break;
        #endregion case 3
        #region case 4
        case "4":
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(4).Value} -");
            font.ToDarkGray("Here you will get Nft Data for an Nft.");
            font.ToDarkGray("You will need your Nft's Id, minter, and collection address.");
            font.ToDarkGray("This infomation can be found on lexplorer.io.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            do
            {
                font.ToTertiary("Enter the Nft Id");
                string nftId = Utils.ReadLineWarningNoNulls("Enter the Nft Id", font);
                minterAndCollection = UtilsLoopring.GetMinterAndCollection(font);

                minterAndCollection.minter = await loopringService.CheckForEthAddress(settings.LoopringApiKey, minterAndCollection.minter);

                nftdataRequest = await loopringService.GetNftData(settings.LoopringApiKey, nftId, minterAndCollection.minter, minterAndCollection.TokenId);
                if (nftdataRequest == null)
                    continue;
                nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, nftId, minterAndCollection.minter);
            } while (nftdataRequest == null);
            Console.WriteLine();
            font.ToPrimaryInline($"{nftMetadata.name} Nft Data is: ");
            font.ToWhite($"{nftdataRequest.nftData}");
            break;
        #endregion case 4
        #region case 5
        case "5":
            var counter = 0;
            var nftDataAndName = new List<NftDataAndName>();
            excelFileName = $"NftDataFromNftId_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.csv";

            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(5).Value} -");
            font.ToDarkGray("Here you will provide Nft Id and get the associated Nft Data.");
            font.ToDarkGray("You will need the minter and collection address as well.");
            font.ToDarkGray("This infomation can be found on lexplorer.io.");
            font.ToDarkGray("Note that all Nft Ids have to be from the same collection.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");

            var howManyLines = Utils.CheckInputDotTxt(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);

            using (StreamReader sr = new($"./{inputPath}/{fileName}"))
            {
                string nftIdFromText;
                nftdataRequest = null;
                minterAndCollection = UtilsLoopring.GetMinterAndCollection(font);
                minterAndCollection.minter = await loopringService.CheckForEthAddress(settings.LoopringApiKey, minterAndCollection.minter);
                sw = Stopwatch.StartNew();
                Console.WriteLine();
                font.ToPrimary("Gathering information...");
                font.ToPrimary($"Looking up {howManyLines} Nft Data");
                while ((nftIdFromText = sr.ReadLine()) != null)
                {
                    nftdataRequest = await loopringService.GetNftData(settings.LoopringApiKey, nftIdFromText, minterAndCollection.minter, minterAndCollection.TokenId);
                    nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, nftIdFromText, minterAndCollection.minter);

                    Utils.ClearLine();
                    font.ToTertiaryInline($"\rChecking Nft: {++counter}/{howManyLines} {nftMetadata.name}");
                    if (nftMetadata != null && nftdataRequest != null)
                    {
                        nftDataAndName.Add(new NftDataAndName
                        {
                            nftData = nftdataRequest.nftData,
                            nftName = nftMetadata.name
                        });
                    }
                }

                using (var writer = new StreamWriter($"./Output/{excelFileName}"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(nftDataAndName);
                }
                sw.Stop();
                Utils.FunctionalityProcessTime(sw, excelFileName, null, font);
            }
            break;
        #endregion case 5
        #region case 6
        case "6":
            string responseOnMinter;
            AccountInformation responseOnAccountId = new();
            nftDataAndName = new List<NftDataAndName>();

            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(6).Value} -");
            font.ToDarkGray("Here you will get Nft Data for the Nfts in a Collection.");
            font.ToDarkGray("You will need the minter and collection address.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            do
            {
                minterAndCollection = UtilsLoopring.GetMinterAndCollection(font);
                responseOnMinter = await loopringService.CheckForEthAddress(settings.LoopringApiKey, minterAndCollection.minter);
                responseOnAccountId = await loopringService.GetUserAccountInformationFromOwner(responseOnMinter);
            }
            while (responseOnAccountId == null);
            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Gathering information...");
            var nftDataList = await loopringService.GetUserMintedNftsWithCollection(font, settings.LoopringApiKey, responseOnAccountId.accountId, minterAndCollection.TokenId);
            font.ToTertiaryInline($"\r{minterAndCollection.minter} has {nftDataList.Count} mints in this Collection.");
            counter = 0;
            Console.WriteLine();
            foreach (var nftDataSingle in nftDataList)
            {
                nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, nftDataSingle.nftId, nftDataSingle.tokenAddress);
                if (nftMetadata != null)
                {
                    Utils.ClearLine();
                    font.ToTertiaryInline($"\rAdding Nft: {++counter}/{nftDataList.Count} {nftMetadata.name}");
                    nftDataAndName.Add(new NftDataAndName
                    {
                        nftData = nftDataSingle.nftData,
                        nftName = nftMetadata.name
                    });
                }
            }

            excelFileName = $"NftDataFromCollection_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.csv";
            using (var writer = new StreamWriter($"./Output/{excelFileName}"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(nftDataAndName);
            }
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, null, font);
            break;
        #endregion case 6
        #region case 7
        case "7":
            nftDataAndName = new List<NftDataAndName>();
            string ensOrWalletAddress;
            counter = 0;

            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(7).Value} -");
            font.ToDarkGray("Here you will get Nft Data of the Nfts in a wallet.");
            font.ToDarkGray("You will need a wallet address.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            do
            {
                font.ToTertiary("Enter the wallet address or ens");
                ensOrWalletAddress = Utils.ReadLineWarningNoNulls("Enter the ens or wallet address", font);
                responseOnMinter = await loopringService.CheckForEthAddress(settings.LoopringApiKey, ensOrWalletAddress);
                responseOnAccountId = await loopringService.GetUserAccountInformationFromOwner(responseOnMinter);
            }
            while (responseOnAccountId == null);
            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Gathering information...");
            var walletsNftBalance = await loopringService.GetWalletsNfts(settings.LoopringApiKey, responseOnAccountId.accountId);
            font.ToPrimary($"{ensOrWalletAddress} has {walletsNftBalance.Count} Nfts in their wallet.");

            foreach (var singleNftBalance in walletsNftBalance)
            {
                nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, singleNftBalance.nftId, singleNftBalance.tokenAddress);
                Utils.ClearLine();
                font.ToTertiaryInline($"\rChecking Nft: {++counter}/{walletsNftBalance.Count} {nftMetadata.name}");
                if (nftMetadata != null)
                {
                    nftDataAndName.Add(new NftDataAndName
                    {
                        nftData = singleNftBalance.nftData,
                        nftName = nftMetadata.name
                    });
                }
            }

            excelFileName = $"NftDataFromWallet_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.csv";
            using (var writer = new StreamWriter($"./Output/{excelFileName}"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(nftDataAndName);
            }
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, null, font);
            break;
        #endregion case 7
        #region case 8
        case "8":
            int currentOverallTotal;
            int currentTotal;
            counter = 0;
            var ownerAndAmount = new List<OwnerAndAmount>();
            var ownerAndTotal = new List<OwnerAndTotal>();

            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(8).Value} -");
            font.ToDarkGray("Here you will get wallet addresses that hold specific Nfts.");
            font.ToDarkGray("You will need the Nft Data.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            howManyLines = Utils.CheckInputDotTxt(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            using (StreamReader sr = new($"./{inputPath}/{fileName}"))
            {
                sw = Stopwatch.StartNew();
                Console.WriteLine();
                font.ToPrimary("Gathering information...");
                while ((nftData = sr.ReadLine()) != null)
                {
                    Utils.ClearLine();
                    font.ToTertiaryInline($"\rNft: {++counter}/{howManyLines}");

                    nftHoldersList = await loopringService.GetNftHoldersMultiple(settings.LoopringApiKey, nftData);

                    var minterFromNftDatas = await loopringService.GetNftInformationFromNftData(settings.LoopringApiKey, nftData);
                    nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, minterFromNftDatas.FirstOrDefault().nftId, minterFromNftDatas.FirstOrDefault().tokenAddress);
                    var holderCounter = 0;
                    foreach (var nftHolder in nftHoldersList)
                    {
                        if (nftHoldersList.FirstOrDefault().accountId == nftHolder.accountId)
                        {
                            Utils.ClearLine();
                        }
                        font.ToTertiaryInline($"\rNft: {counter}/{howManyLines} {nftMetadata.name} Nft Holder: {++holderCounter}/{nftHoldersList.Count}");
                        userAccountInformation = await loopringService.GetUserAccountInformation(nftHolder.accountId.ToString());
                        if (nftMetadata != null)
                        {
                            ownerAndAmount.Add(new OwnerAndAmount
                            {
                                nftData = nftData,
                                nftName = nftMetadata.name,
                                nftOwner = userAccountInformation.owner,
                                ownerAmountOwned = nftHolder.amount
                            });
                            if (!ownerAndTotal.Any(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()))
                            {
                                ownerAndTotal.Add(new OwnerAndTotal
                                {
                                    owner = userAccountInformation.owner,
                                    total = int.Parse(nftHolder.amount)
                                });
                            }
                            else
                            {
                                currentTotal = ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()).total;
                                ownerAndTotal.RemoveAt(ownerAndTotal.IndexOf(ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower())));
                                ownerAndTotal.Add(new OwnerAndTotal
                                {
                                    owner = userAccountInformation.owner,
                                    total = currentTotal += int.Parse(nftHolder.amount)
                                });
                            }
                        }
                    }
                }
                excelFileName = $"NftHolderFromNftData_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.csv";
                using (var writer = new StreamWriter($"./Output/{excelFileName}"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(ownerAndAmount);
                }

                var excelFileNameTwo = $"NftHoldersAndTotals_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.csv";
                using (var writer = new StreamWriter($"./Output/{excelFileNameTwo}"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(ownerAndTotal.OrderByDescending(x=>x.total));
                }
                sw.Stop();
                Utils.FunctionalityProcessTime(sw, excelFileName, null, font);
                Console.WriteLine();
                font.ToWhite($@"An audit file can be found at: {AppDomain.CurrentDomain.BaseDirectory}Output\{excelFileNameTwo}");
            }
            break;
        #endregion case 8
        #region case 9
        case "9":
            string userResponseOnMinter;
            ownerAndAmount = new List<OwnerAndAmount>();
            counter = 0;
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(9).Value} -");
            font.ToDarkGray("Here you will get wallet addresses that hold a minter's Nfts.");
            font.ToDarkGray("You will need the wallet address or ens.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            do
            {
                font.ToTertiary("Enter the wallet address or ens.");
                userResponseOnMinter = Utils.ReadLineWarningNoNulls("Enter the wallet address or ens.", font);
                responseOnMinter = await loopringService.CheckForEthAddress(settings.LoopringApiKey, userResponseOnMinter);
                responseOnAccountId = await loopringService.GetUserAccountInformationFromOwner(responseOnMinter);
            }
            while (responseOnAccountId == null);
            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Gathering information...");
            nftDataList = await loopringService.GetUserMintedNfts(font, settings.LoopringApiKey, responseOnAccountId.accountId);
            font.ToTertiaryInline(str: $"\r{userResponseOnMinter} has {nftDataList.Count} mints");
            foreach (var nftDatas in nftDataList)
            {
                var nftHoldersAndTotal = await loopringService.GetNftHoldersMultiple(settings.LoopringApiKey, nftDatas.nftData);
                nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, nftDatas.nftId, nftDatas.tokenAddress);
                Utils.ClearLine();
                font.ToTertiaryInline($"\rNft: {++counter}/{nftDataList.Count} {nftMetadata.name}");
                var holderCounter = 0;
                foreach (var item in nftHoldersAndTotal)
                {
                    userAccountInformation = await loopringService.GetUserAccountInformation(item.accountId.ToString());
                    font.ToTertiaryInline($"\rNft: {counter}/{nftDataList.Count} {nftMetadata.name} Nft Holder: {++holderCounter}/{nftHoldersAndTotal.Count}");


                    if (nftMetadata != null && userAccountInformation.owner.ToLower() != "0x000000000000000000000000000000000000dead" && userAccountInformation.owner.ToLower() != "0xdead000000000000000042069420694206942069")
                    {
                        ownerAndAmount.Add(new OwnerAndAmount
                        {
                            nftData = nftDatas.nftData,
                            nftName = nftMetadata.name,
                            nftOwner = userAccountInformation.owner,
                            ownerAmountOwned = item.amount
                        });
                    }
                }
            }
            excelFileName = $"NftHolderFromWalletAddress_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.csv";
            using (var writer = new StreamWriter($"./Output/{excelFileName}"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ownerAndAmount);
            }
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, null, font);
            break;
        #endregion case 9
        #region case 10
        case "10":
            var originalalletHolderList = new List<NftHolderAndNftData>();
            var filteredwalletHolderList = new List<NftHolderAndNftData>();
            var allNftData = new List<string>();
            counter = 0;

            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(10).Value} -");
            font.ToDarkGray("Here you will provide the Nft Data and get the Nft Holders who own all Nfts.");
            font.ToDarkGray("You will need nft data.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            howManyLines = Utils.CheckInputDotTxt(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Gathering information...");
            using (StreamReader sr = new($"./{inputPath}/{fileName}"))
            {
                while ((nftData = sr.ReadLine()) != null)
                {
                    font.ToTertiaryInline($"\rGrabbing Nfts: {++counter}/{howManyLines}");
                    allNftData.Add(nftData);
                }
            }
            Utils.ClearLine();
            counter = 0;
            foreach (var data in allNftData)
            {
                font.ToTertiaryInline($"\rNft: {++counter}/{howManyLines}");
                originalalletHolderList.AddRange(await loopringService.GetNftHolderIncludeNftData(font, loopringService, nftMetadataService, ethereumService, settings.LoopringApiKey, data, environmentUrl, counter, howManyLines));
            }
            Utils.ClearLine();
            counter = 0;
            foreach (var item in originalalletHolderList.DistinctBy(x => x.accountId))
            {
                font.ToTertiaryInline($"\rFiltering Holders: {++counter}/{originalalletHolderList.DistinctBy(x => x.accountId).Count()}");
                if (originalalletHolderList.Where(x => x.accountId == item.accountId).Count() == howManyLines)
                {
                    if (nftMetadata != null)
                    {
                        foreach (var record in originalalletHolderList.Where(x => x.accountId == item.accountId))
                        {
                            filteredwalletHolderList.Add(record);
                        }
                    }
                }
            }

            excelFileName = $"AllNftHolders_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.csv";
            using (var writer = new StreamWriter($"./Output/{excelFileName}"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(filteredwalletHolderList.OrderBy(x => x.accountId));
            }
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, null, font);
            break;
        #endregion case 10
        #region case 11
        case "11":
            originalalletHolderList = new List<NftHolderAndNftData>();
            filteredwalletHolderList = new List<NftHolderAndNftData>();
            allNftData = new List<string>();
            counter = 0;

            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(11).Value} -");
            font.ToDarkGray("Here you will provide the Nft Data and get Nft Holders who own a minimum set number.");
            font.ToDarkGray("You will need nft data.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            font.ToTertiary("What is the minimum set number?");
            var minimumSet = Utils.ReadLineWarningNoNullsForceInt("What is the minimum set number?", font, null, null);
            howManyLines = Utils.CheckInputDotTxt(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Gathering information...");
            using (StreamReader sr = new($"./{inputPath}/{fileName}"))
            {
                while ((nftData = sr.ReadLine()) != null)
                {
                    font.ToTertiaryInline($"\rGrabbing Nfts: {++counter}/{howManyLines}");
                    allNftData.Add(nftData);
                }
            }
            Utils.ClearLine();
            counter = 0;
            foreach (var data in allNftData)
            {
                font.ToTertiaryInline($"\rNft: {++counter}/{howManyLines}");
                originalalletHolderList.AddRange(await loopringService.GetNftHolderIncludeNftData(font, loopringService, nftMetadataService, ethereumService, settings.LoopringApiKey, data, environmentUrl, counter, howManyLines));
            }
            Utils.ClearLine();
            counter = 0;
            foreach (var item in originalalletHolderList.DistinctBy(x => x.accountId))
            {
                font.ToTertiaryInline($"\rFiltering Holders: {++counter}/{originalalletHolderList.DistinctBy(x => x.accountId).Count()}");
                if (originalalletHolderList.Where(x => x.accountId == item.accountId).Count() >= int.Parse(minimumSet))
                {
                    if (nftMetadata != null)
                    {
                        foreach (var record in originalalletHolderList.Where(x => x.accountId == item.accountId))
                        {
                            filteredwalletHolderList.Add(record);
                        }
                    }
                }
            }

            excelFileName = $"AllNftHoldersWithMinimum_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.csv";
            using (var writer = new StreamWriter($"./Output/{excelFileName}"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(filteredwalletHolderList.OrderBy(x => x.accountId));
            }
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, null, font);
            break;
        #endregion case 11
        #region case 12
        case "12":
            nftAmount ="";
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(12).Value} -");
            font.ToDarkGray("Here you will drop an Nft to many users.");
            font.ToDarkGray("You will need nft data and wallet address or ens.");
            font.ToPrimary($"Each transfer will cost {lcrTransactionFee} {maxFeeToken}.");
            font.ToPrimary($"An estimate will be provided before starting and a total will be given after completion.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            howManyLines = Utils.CheckInputDotTxt(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            font.ToDarkGray($"You will be transfering to {howManyLines} wallets.");
            font.ToTertiaryInline("Do you know the Nft's Nft Data?");
            font.ToDarkGray(" This is for the Nft you are transfering.");
            var userResponseOnNftData = Utils.CheckYesOrNo(font);
            if (userResponseOnNftData == "yes" || userResponseOnNftData == "y")
            {
                font.ToTertiary("Enter the NftData");
                nftData = Console.ReadLine();
                try
                {
                    userNftToken = await loopringService.GetTokenIdWithCheck(settings.LoopringApiKey, settings.LoopringAccountId, nftData);
                    nftTokenId = userNftToken.data[0].tokenId;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                font.ToDarkGray("You will need your Nft's Id, minter, and collection address.");
                font.ToDarkGray("This infomation can be found on lexplorer.io.");
                do
                {
                    font.ToTertiary("Enter the Nft Id");
                    string nftId = Utils.ReadLineWarningNoNulls("Enter the Nft Id", font);
                    minterAndCollection = UtilsLoopring.GetMinterAndCollection(font);
                    minterAndCollection.minter = await loopringService.CheckForEthAddress(settings.LoopringApiKey, minterAndCollection.minter);
                    nftdataRequest = await loopringService.GetNftData(settings.LoopringApiKey, nftId, minterAndCollection.minter, minterAndCollection.TokenId);
                } while (nftdataRequest == null);
                nftData = nftdataRequest.nftData;

                userNftToken = await loopringService.GetTokenId(settings.LoopringApiKey, settings.LoopringAccountId, nftData);
                nftTokenId = userNftToken.data[0].tokenId;
            }
            nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, userNftToken.data[0].nftId, userNftToken.data[0].tokenAddress);
            font.ToTertiary($"How many '{nftMetadata.name}' do you want to transfer to each address? You own {userNftToken.data[0].total}");
            nftAmount = Utils.CheckNftSendAmount(howManyLines, userNftToken.data[0].total, fileName, inputPath, font);

            transferMemo = UtilsLoopring.CheckMemoLimit(font);
            Console.WriteLine();
            font.ToDarkGray($"You are about to transfer {int.Parse(nftAmount) * howManyLines} '{nftMetadata.name}' to {howManyLines} wallets");
            font.ToDarkGray($"with a memo of: {transferMemo}");
            offChainFeeCheck = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");
            feeAmountCheck = offChainFeeCheck.fees.Where(w => w.token == maxFeeToken.ToString()).First().fee;
            font.ToDarkGray($"Gas fees will be around {(decimal.Parse(feeAmountCheck) / 1000000000000000000m) * Convert.ToDecimal(howManyLines)} {maxFeeToken}.");
            font.ToPrimary($"Transaction fee will be around {howManyLines * lcrTransactionFee} {maxFeeToken}.");
            Console.WriteLine();


            font.ToTertiary("Enter 'yes' for the transfers to start or 'no' to start over.");
            userResponseOnNftData = Utils.CheckYesOrNo(font);
            if (userResponseOnNftData == "no" || userResponseOnNftData == "n")
            {
                break;
            }

            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Starting airdrop...");

            // nft transfer
            nftTransferAuditInformation = await loopringService.NftTransfer(
                font,
                loopringService,
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                toAccountId,
                maxFeeToken,
                maxFeeTokenId,
                fromAddress,
                fileName,
                inputPath,
                howManyLines,
                nftTokenId,
                nftAmount,
                validUntil,
                lcrTransactionFee,
                transferMemo,
                nftData
                );

            // transfer to cob
            done = await loopringService.CobTransferTransactionFee(
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                nftTransferAuditInformation.transactionFeeTotal,
                nftTransferAuditInformation.nftSentTotal,
                maxFeeToken,
                maxFeeTokenId,
                myAddress,
                fromAddress,
                0
                );


            excelFileName = Utils.ShowAirdropAudit(nftTransferAuditInformation.validAddress, nftTransferAuditInformation.invalidAddress, nftTransferAuditInformation.banishAddress, null, nftTransferAuditInformation.alreadyActivatedAddress, nftMetadata.name, nftTransferAuditInformation.gasFeeTotal, maxFeeToken, nftTransferAuditInformation.transactionFeeTotal);
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, nftTransferAuditInformation.validAddress.Count, font);
            break;
        #endregion case 12
        #region case 13
        case "13":
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(13).Value} -");
            font.ToDarkGray("Here you will drop an Nft to many users with different amounts.");
            font.ToDarkGray("You will need nft data and wallet address or ens.");
            font.ToPrimary($"Each transfer will cost {lcrTransactionFee} {maxFeeToken}.");
            font.ToPrimary($"An estimate will be provided before starting and a total will be given after completion.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            fileAmounts = Utils.CheckInputDotTxtTwoInputsNft(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            font.ToDarkGray($"You will be transfering to {fileAmounts.walletAmount} wallets.");

            font.ToTertiaryInline("Do you know the Nft's Nft Data?");
            font.ToDarkGray(" This is for the Nft you are transfering.");
            userResponseOnNftData = Utils.CheckYesOrNo(font);
            if (userResponseOnNftData == "yes" || userResponseOnNftData == "y")
            {
                font.ToTertiary("Enter the NftData");
                nftData = Console.ReadLine();
                try
                {
                    userNftToken = await loopringService.GetTokenIdWithCheck(settings.LoopringApiKey, settings.LoopringAccountId, nftData);
                    nftTokenId = userNftToken.data[0].tokenId;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                font.ToDarkGray("You will need your Nft's Id, minter, and collection address.");
                font.ToDarkGray("This infomation can be found on lexplorer.io.");
                do
                {
                    font.ToTertiary("Enter the Nft Id");
                    string nftId = Utils.ReadLineWarningNoNulls("Enter the Nft Id", font);
                    minterAndCollection = UtilsLoopring.GetMinterAndCollection(font);
                    minterAndCollection.minter = await loopringService.CheckForEthAddress(settings.LoopringApiKey, minterAndCollection.minter);
                    nftdataRequest = await loopringService.GetNftData(settings.LoopringApiKey, nftId, minterAndCollection.minter, minterAndCollection.TokenId);
                } while (nftdataRequest == null);
                nftData = nftdataRequest.nftData;

                userNftToken = await loopringService.GetTokenId(settings.LoopringApiKey, settings.LoopringAccountId, nftData);
                nftTokenId = userNftToken.data[0].tokenId;
            }
            nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, userNftToken.data[0].nftId, userNftToken.data[0].tokenAddress);
            Utils.CheckNftSendAmountTwoInputs(int.Parse(menuAndUtility.userResponseOnUtility), fileAmounts.nftAmount, userNftToken.data[0].total, fileName, inputPath, font);
            transferMemo = UtilsLoopring.CheckMemoLimit(font);
            Console.WriteLine();
            font.ToDarkGray($"You are about to transfer {fileAmounts.nftAmount} '{nftMetadata.name}' to {fileAmounts.walletAmount} wallets");
            font.ToDarkGray($"with a memo of: {transferMemo}");
            offChainFeeCheck = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");
            feeAmountCheck = offChainFeeCheck.fees.Where(w => w.token == maxFeeToken.ToString()).First().fee;
            font.ToDarkGray($"Gas fees will be around {(decimal.Parse(feeAmountCheck) / 1000000000000000000m) * Convert.ToDecimal(fileAmounts.walletAmount)} {maxFeeToken}.");
            font.ToPrimary($"Transaction fee will be around {fileAmounts.walletAmount * lcrTransactionFee} {maxFeeToken}.");

            font.ToTertiary("Enter 'yes' for the transfers to start or 'no' to start over.");
            userResponseOnNftData = Utils.CheckYesOrNo(font);
            if (userResponseOnNftData == "no" || userResponseOnNftData == "n")
            {
                break;
            }

            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Starting airdrop...");

            // nft transfer
            nftTransferAuditInformation = await loopringService.NftTransfer(
                font,
                loopringService,
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                toAccountId,
                maxFeeToken,
                maxFeeTokenId,
                fromAddress,
                fileName,
                inputPath,
                fileAmounts.walletAmount,
                nftTokenId,
                null,
                validUntil,
                lcrTransactionFee,
                transferMemo,
                nftData
                );

            // transfer to cob
            done = await loopringService.CobTransferTransactionFee(
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                nftTransferAuditInformation.transactionFeeTotal,
                nftTransferAuditInformation.nftSentTotal,
                maxFeeToken,
                maxFeeTokenId,
                myAddress,
                fromAddress,
                0
                );

            excelFileName = Utils.ShowAirdropAudit(nftTransferAuditInformation.validAddress, nftTransferAuditInformation.invalidAddress, nftTransferAuditInformation.banishAddress, null, nftTransferAuditInformation.alreadyActivatedAddress, nftMetadata.name, nftTransferAuditInformation.gasFeeTotal, maxFeeToken, nftTransferAuditInformation.transactionFeeTotal);
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, nftTransferAuditInformation.validAddress.Count, font);
            break;
        #endregion case 13
        #region case 14
        case "14":
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(14).Value} -");
            font.ToDarkGray("Here you will drop any Nfts to any users.");
            font.ToDarkGray("You will need nft data and wallet address or ens.");
            font.ToPrimary($"Each transfer will cost {lcrTransactionFee} {maxFeeToken}.");
            font.ToPrimary($"An estimate will be provided before starting and a total will be given after completion.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            fileAmounts = Utils.CheckInputDotTxtTwoInputsNft(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            font.ToDarkGray($"You will be transfering to {fileAmounts.walletAmount} wallets.");

            font.ToTertiary("How many of each Nft do you want to transfer to each address?");
            nftAmount = Utils.ReadLineWarningNoNullsForceInt("How many of each Nft do you want to transfer to each address?", font, null, null);

            transferMemo = UtilsLoopring.CheckMemoLimit(font);
            Console.WriteLine();
            font.ToDarkGray($"You are about to transfer {fileAmounts.walletAmount * int.Parse(nftAmount)} Nfts to {fileAmounts.walletAmount} wallets");
            font.ToDarkGray($"with a memo of: {transferMemo}");
            offChainFeeCheck = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");
            feeAmountCheck = offChainFeeCheck.fees.Where(w => w.token == maxFeeToken.ToString()).First().fee;
            font.ToDarkGray($"Gas fees will be around {(decimal.Parse(feeAmountCheck) / 1000000000000000000m) * Convert.ToDecimal(fileAmounts.walletAmount)} {maxFeeToken}.");
            font.ToPrimary($"Transaction fee will be around {fileAmounts.walletAmount * lcrTransactionFee} {maxFeeToken}.");



            font.ToTertiary("Enter 'yes' for the transfers to start or 'no' to start over.");
            userResponseOnNftData = Utils.CheckYesOrNo(font);
            if (userResponseOnNftData == "no" || userResponseOnNftData == "n")
            {
                break;
            }

            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Starting airdrop...");

            // nft transfer
            nftTransferAuditInformation = await loopringService.NftTransfer(
                font,
                loopringService,
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                toAccountId,
                maxFeeToken,
                maxFeeTokenId,
                fromAddress,
                fileName,
                inputPath,
                fileAmounts.walletAmount,
                0,
                nftAmount,
                validUntil,
                lcrTransactionFee,
                transferMemo,
                null
                );

            // transfer to cob
            done = await loopringService.CobTransferTransactionFee(
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                nftTransferAuditInformation.transactionFeeTotal,
                nftTransferAuditInformation.nftSentTotal,
                maxFeeToken,
                maxFeeTokenId,
                myAddress,
                fromAddress,
                0
                );

            excelFileName = Utils.ShowAirdropAudit(nftTransferAuditInformation.validAddress, nftTransferAuditInformation.invalidAddress, nftTransferAuditInformation.banishAddress, nftTransferAuditInformation.invalidNftData, nftTransferAuditInformation.alreadyActivatedAddress, null, nftTransferAuditInformation.gasFeeTotal, maxFeeToken, nftTransferAuditInformation.transactionFeeTotal);
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, nftTransferAuditInformation.validAddress.Count, font);
            break;
        #endregion case 14
        #region case 15
        case "15":
            transferMemo = "Sent to the Dead Address by Maize";

            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(15).Value} -");
            font.ToDarkGray("Here you will send all Nfts minted by those in the banish file to the dead address.");
            font.ToDarkGray("You will need wallet address or ens.");
            font.ToPrimary($"Each transfer will cost {lcrTransactionFee} {maxFeeToken}.");
            font.ToPrimary($"An estimate will be provided before starting and a total will be given after completion.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            howManyLines = Utils.CheckInputDotTxt(int.Parse(menuAndUtility.userResponseOnUtility), banishFile, inputPath, font);
            font.ToDarkGray($"There are {howManyLines} minters to look for.");

            var walletsNfts = await loopringService.GetWalletsNfts(loopringApiKey, fromAccountId);
            var banishedNfts = new List<Datum>();
            foreach (var nft in walletsNfts)
            {
                var nftInformation = await loopringService.GetNftInformationFromNftData(loopringApiKey, nft.nftData);
                contains = await loopringService.CheckBanishFile(font, settings.LoopringApiKey, nftInformation.FirstOrDefault().minter.ToLower());
                if (contains == true)
                {
                    banishedNfts.Add(nft);
                }
            }
            foreach (var nft in banishedNfts)
            {
                nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, nft.nftId, nft.tokenAddress);
                font.ToPrimary($"{nftMetadata.name} will be transfered.");
            }

            offChainFeeCheck = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");
            feeAmountCheck = offChainFeeCheck.fees.Where(w => w.token == maxFeeToken.ToString()).First().fee;
            Console.WriteLine();
            font.ToDarkGray($"Gas fees will be around {(decimal.Parse(feeAmountCheck) / 1000000000000000000m) * Convert.ToDecimal(banishedNfts.Count)} {maxFeeToken}.");
            font.ToPrimary($"Transaction fee will be around {Convert.ToDecimal(banishedNfts.Count) * lcrTransactionFee} {maxFeeToken}.");

            font.ToTertiary("Would you like to send the above Nfts to the dead Address?");
            font.ToTertiary("Enter 'yes' for the transfers to start or 'no' to start over.");
            userResponseOnNftData = Utils.CheckYesOrNo(font);
            if (userResponseOnNftData == "no" || userResponseOnNftData == "n")
            {
                break;
            }

            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Starting airdrop...");

            // nft transfer
            nftTransferAuditInformation = await loopringService.NftTransferDead(
                font,
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                toAccountId,
                maxFeeToken,
                maxFeeTokenId,
                fromAddress,
                banishFile,
                banishedNfts.Count,
                0,
                "0",
                validUntil,
                lcrTransactionFee,
                transferMemo,
                null,
                walletsNfts,
                banishedNfts,
                nftMetadataService,
                ethereumService
                );

            // transfer to cob
            done = await loopringService.CobTransferTransactionFee(
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                nftTransferAuditInformation.transactionFeeTotal,
                nftTransferAuditInformation.nftSentTotal,
                maxFeeToken,
                maxFeeTokenId,
                myAddress,
                fromAddress,
                0
                );

            excelFileName = Utils.ShowAirdropAuditDead(nftTransferAuditInformation.validAddress, nftTransferAuditInformation.invalidAddress, nftTransferAuditInformation.banishAddress, nftTransferAuditInformation.invalidNftData, nftMetadata.name, nftTransferAuditInformation.gasFeeTotal, maxFeeToken, nftTransferAuditInformation.transactionFeeTotal);
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, nftTransferAuditInformation.validAddress.Count, font);              

            break;
        #endregion case 15
        #region case 16
        case "16":
            decimal amountToTransfer = 0m;
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(16).Value} -");
            font.ToDarkGray("Here you will airdrop LRC to many users.");
            font.ToDarkGray("You will need wallet address or ens.");
            font.ToPrimary($"Each transfer will cost {lcrTransactionFee} {maxFeeToken}.");
            font.ToPrimary($"An estimate will be provided before starting and a total will be given after completion.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            howManyLines = Utils.CheckInputDotTxt(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            font.ToDarkGray($"You will be transfering to {howManyLines} wallets.");

            font.ToTertiary("How much LRC do you want to send to each wallet?");
            amountToTransfer = Utils.ReadLineWarningNoNullsForceDecimal("How much LRC do you want to send to each wallet?", font);

            transferMemo = UtilsLoopring.CheckMemoLimit(font);
            Console.WriteLine();
            font.ToDarkGray($"You are about to transfer {howManyLines * amountToTransfer} LRC to {howManyLines} wallets");
            font.ToDarkGray($"with a memo of: {transferMemo}");
            offChainFeeCheck = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");
            feeAmountCheck = offChainFeeCheck.fees.Where(w => w.token == maxFeeToken.ToString()).First().fee;
            font.ToDarkGray($"Gas fees will be around {(decimal.Parse(feeAmountCheck) / 1000000000000000000m) * Convert.ToDecimal(howManyLines)} {maxFeeToken}.");
            font.ToPrimary($"Transaction fee will be around {howManyLines * lcrTransactionFee} {maxFeeToken}.");



            font.ToTertiary("Enter 'yes' for the transfers to start or 'no' to start over.");
            userResponseOnNftData = Utils.CheckYesOrNo(font);
            if (userResponseOnNftData == "no" || userResponseOnNftData == "n")
            {
                break;
            }

            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Starting airdrop...");

            // crypto transfer
            nftTransferAuditInformation = await loopringService.LrcTransfer(
                font,
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                fromAddress,
                fileName,
                inputPath,
                howManyLines,
                amountToTransfer,
                validUntil,
                lcrTransactionFee,
                transferMemo
                );

            // transfer to cob
            done = await loopringService.CobTransferTransactionFee(
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                nftTransferAuditInformation.transactionFeeTotal,
                validAddressCount: nftTransferAuditInformation.validAddress.Count,
                maxFeeToken,
                maxFeeTokenId,
                myAddress,
                fromAddress,
                1
                );

            excelFileName = Utils.ShowAirdropAudit(nftTransferAuditInformation.validAddress, nftTransferAuditInformation.invalidAddress, nftTransferAuditInformation.banishAddress, nftTransferAuditInformation.invalidNftData, nftTransferAuditInformation.alreadyActivatedAddress, "LRC", nftTransferAuditInformation.gasFeeTotal, maxFeeToken, nftTransferAuditInformation.transactionFeeTotal);
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, nftTransferAuditInformation.validAddress.Count, font);

            break;
        #endregion case 16
        #region case 17
        case "17":
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(17).Value} -");
            font.ToDarkGray("Here you will airdrop LRC to many users with different amounts.");
            font.ToDarkGray("You will need wallet address or ens.");
            font.ToPrimary($"Each transfer will cost {lcrTransactionFee} {maxFeeToken}.");
            font.ToPrimary($"An estimate will be provided before starting and a total will be given after completion.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            var fileAmountLrc = Utils.CheckInputDotTxtTwoInputsLrc(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            font.ToDarkGray($"You will be transfering to {fileAmountLrc.walletAmount} wallets.");

            transferMemo = UtilsLoopring.CheckMemoLimit(font);
            Console.WriteLine();
            font.ToDarkGray($"You are about to transfer {fileAmountLrc.lrcAmount} LRC to {fileAmountLrc.walletAmount} wallets");
            font.ToDarkGray($"with a memo of: {transferMemo}");
            offChainFeeCheck = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");
            feeAmountCheck = offChainFeeCheck.fees.Where(w => w.token == maxFeeToken.ToString()).First().fee;
            font.ToDarkGray($"Gas fees will be around {(decimal.Parse(feeAmountCheck) / 1000000000000000000m) * Convert.ToDecimal(fileAmountLrc.walletAmount)} {maxFeeToken}.");
            font.ToPrimary($"Transaction fee will be around {fileAmountLrc.walletAmount * lcrTransactionFee} {maxFeeToken}.");



            font.ToTertiary("Enter 'yes' for the transfers to start or 'no' to start over.");
            userResponseOnNftData = Utils.CheckYesOrNo(font);
            if (userResponseOnNftData == "no" || userResponseOnNftData == "n")
            {
                break;
            }

            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Starting airdrop...");

            // crypto transfer
            nftTransferAuditInformation = await loopringService.LrcTransfer(
                font,
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                fromAddress,
                fileName,
                inputPath,
                fileAmountLrc.walletAmount,
                0,
                validUntil,
                lcrTransactionFee,
                transferMemo
                );

            // transfer to cob
            done = await loopringService.CobTransferTransactionFee(
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                nftTransferAuditInformation.transactionFeeTotal,
                nftTransferAuditInformation.validAddress.Count,
                maxFeeToken,
                maxFeeTokenId,
                myAddress,
                fromAddress,
                1
                );

            excelFileName = Utils.ShowAirdropAudit(nftTransferAuditInformation.validAddress, nftTransferAuditInformation.invalidAddress, nftTransferAuditInformation.banishAddress, nftTransferAuditInformation.invalidNftData, nftTransferAuditInformation.alreadyActivatedAddress, "LRC", nftTransferAuditInformation.gasFeeTotal, maxFeeToken, nftTransferAuditInformation.transactionFeeTotal);
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, nftTransferAuditInformation.validAddress.Count, font);
            break;
        #endregion case 17
        #region case 18
        case "18":
            amountToTransfer = 0.000000000000000001m;
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(18).Value} -");
            font.ToDarkGray("Here you will pay the activation fee for the given wallet addresses.");
            font.ToDarkGray("A transaction has to be sent to do this. You will be sending 0.000000000000000001 LRC to each wallet.");
            Console.WriteLine();
            font.ToWhite("Let's get started.");
            howManyLines = Utils.CheckInputDotTxt(int.Parse(menuAndUtility.userResponseOnUtility), fileName, inputPath, font);
            font.ToDarkGray($"You will be activating {howManyLines} wallets.");
            transferMemo = UtilsLoopring.CheckMemoLimit(font);
            Console.WriteLine();
            font.ToDarkGray($"You are about to activate {howManyLines} wallets");
            font.ToDarkGray($"with a memo of: {transferMemo}");
            var transferFeeAmountResultCheck = await loopringService.GetOffChainTransferFeeForTransferAndUpdateAccount(loopringApiKey, fromAccountId, 15); 
            feeAmountCheck = transferFeeAmountResultCheck.fees.Where(w => w.token == maxFeeToken.ToString()).First().fee;
            font.ToDarkGray($"Gas fees will be around {(decimal.Parse(feeAmountCheck) / 1000000000000000000m) * Convert.ToDecimal(howManyLines)} {maxFeeToken}.");

            font.ToTertiary("Enter 'yes' for the transfers to start or 'no' to start over.");
            userResponseOnNftData = Utils.CheckYesOrNo(font);
            if (userResponseOnNftData == "no" || userResponseOnNftData == "n")
            {
                break;
            }

            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Starting airdrop...");

            // crypto transfer
            nftTransferAuditInformation = await loopringService.LrcTransferActivation(
                font,
                environment,
                environmentUrl,
                environmentExchange,
                loopringApiKey,
                loopringPrivateKey,
                MMorGMEPrivateKey,
                fromAccountId,
                fromAddress,
                fileName,
                inputPath,
                howManyLines,
                amountToTransfer,
                validUntil,
                lcrTransactionFee,
                transferMemo
                );

            excelFileName = Utils.ShowAirdropAudit(nftTransferAuditInformation.validAddress, nftTransferAuditInformation.invalidAddress, nftTransferAuditInformation.banishAddress, nftTransferAuditInformation.invalidNftData, nftTransferAuditInformation.alreadyActivatedAddress, "LRC", nftTransferAuditInformation.gasFeeTotal, maxFeeToken, nftTransferAuditInformation.transactionFeeTotal);
            sw.Stop();
            Utils.FunctionalityProcessTime(sw, excelFileName, nftTransferAuditInformation.validAddress.Count, font);
            break;
        #endregion case 18
        #region case 19
        case "19":
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(19).Value} -");
            font.ToDarkGray("Here you will get the yearly and monthly transfer leaderboard.");
            font.ToDarkGray("The Airdrop competition will be based on Transactions and not the Nfts Sent.");
            font.ToDarkGray("Top 3 at the end of the month/year will receive the airdrop.");
            font.ToDarkGray("Time will be in UTC time zone.");
            Console.WriteLine();
            font.ToTertiary("Enter yes when ready.");
            var getStarted = Utils.CheckYes(font);

            // UNCOMMENT BELOW ONCE THE YEAR IS OVER AND YOU NEED AN ALL TIME. 
            //var nftTransfers = await loopringService.GetUserTransactions(loopringApiKey, myAccountId, null, null);
            //nftTransfers = nftTransfers.Where(x => x.memo.Contains("Nfts sent")).ToList();
            //var leaderBoardContestants = Leaderboards.GetLeaderBoardContestants(nftTransfers);
            //var userInformation = leaderBoardContestants.Where(x => x.owner.ToLower().Contains(fromAddress.ToLower()));
            Leaderboards.DisplayLeaderboardBanner(font);
            //Leaderboards.DisplayContestants(font, leaderBoardContestants, userInformation, fromAddress, "All time (Top 10)");
            
            var startDatePlease = Utils.GetUnixTimeMillisecondsStart("12/01/2022");
            var endDatePlease = Utils.GetUnixTimeMillisecondsEnd("12/31/2023");
            var nftTransfers = await loopringService.GetUserTransactions(loopringApiKey, myAccountId, startDatePlease, endDatePlease);
            nftTransfers = nftTransfers.Where(x => x.memo.Contains("Nfts sent")).ToList();
            var leaderBoardContestants = Leaderboards.GetLeaderBoardContestants(nftTransfers);
            var userInformation = leaderBoardContestants.Where(x => x.owner.ToLower().Contains(fromAddress.ToLower()));
            Leaderboards.DisplayContestants(font, leaderBoardContestants, userInformation, fromAddress, "Yearly 2023 (Top 10 | includes December 2022)");
            startDatePlease = Utils.GetUnixTimeMillisecondsStart(DateTime.Now.AddDays(-7).ToString("M/dd/yyyy"));
            endDatePlease = Utils.GetUnixTimeMillisecondsEnd(DateTime.Now.ToString("M/dd/yyyy"));
            nftTransfers = await loopringService.GetUserTransactions(loopringApiKey, myAccountId, startDatePlease, endDatePlease);
            nftTransfers = nftTransfers.Where(x => x.memo.Contains("Nfts sent")).ToList();
            leaderBoardContestants = Leaderboards.GetLeaderBoardContestants(nftTransfers);
            userInformation = leaderBoardContestants.Where(x => x.owner.ToLower().Contains(fromAddress.ToLower()));
            Leaderboards.DisplayContestants(font, leaderBoardContestants, userInformation, fromAddress, "Last 7 Days (Top 10)");

            counter = 0;
            var monthNumber = Utils.ReturnMonth(font);
            while (monthNumber != 0)
            {
                if (counter != 0)
                {
                    monthNumber = Utils.ReturnMonth(font);
                }
                counter++;
                if (monthNumber > 0)
                {
                    var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);

                    if (monthNumber == 1)
                    {
                        startDatePlease = Utils.GetUnixTimeMillisecondsStart($"12/01/2022");
                        endDatePlease = Utils.GetUnixTimeMillisecondsEnd($"{monthNumber}/{DateTime.DaysInMonth(2023, monthNumber)}/2023");
                        nftTransfers = await loopringService.GetUserTransactions(loopringApiKey, myAccountId, startDatePlease, endDatePlease);
                        nftTransfers = nftTransfers.Where(x => x.memo.Contains("Nfts sent")).ToList();
                        leaderBoardContestants = Leaderboards.GetLeaderBoardContestants(nftTransfers);
                        userInformation = leaderBoardContestants.Where(x => x.owner.ToLower().Contains(fromAddress.ToLower()));
                        Leaderboards.DisplayContestants(font, leaderBoardContestants, userInformation, fromAddress, $"{monthName} 2023 (Top 10 | includes December 2022)");
                    }
                    else
                    {
                        startDatePlease = Utils.GetUnixTimeMillisecondsStart($"{monthNumber}/01/2023");
                        endDatePlease = Utils.GetUnixTimeMillisecondsEnd($"{monthNumber}/{DateTime.DaysInMonth(2023, monthNumber)}/2023");
                        nftTransfers = await loopringService.GetUserTransactions(loopringApiKey, myAccountId, startDatePlease, endDatePlease);
                        nftTransfers = nftTransfers.Where(x => x.memo.Contains("Nfts sent")).ToList();
                        leaderBoardContestants = Leaderboards.GetLeaderBoardContestants(nftTransfers);
                        userInformation = leaderBoardContestants.Where(x => x.owner.ToLower().Contains(fromAddress.ToLower()));
                        Leaderboards.DisplayContestants(font, leaderBoardContestants, userInformation, fromAddress, $"{monthName} 2023 (Top 10)");
                    }

                }
            }


            break;
        #endregion case 19
        #region case 20
        case "20":
            currentOverallTotal = 0;
            counter = 0;
            int maxAttributeCount = 0;
            var attributeCounter = 0;
            string header = "name~description~image~total~nftData~nftId~minter~tokenAddress~royaltyPercentage";
            ownerAndTotal = new List<OwnerAndTotal>();
            currentOverallTotal = 0;
            StringBuilder collectionNftInformation = new();
            var collectionNftHolders = new List<NftHolder>();
            ownerAndAmount = new List<OwnerAndAmount>();
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(20).Value} -");
            font.ToDarkGray("Here you will get Analytics from your minted collection.");
            font.ToDarkGray("You will need excel or google sheets.");
            Console.WriteLine();

            font.ToPrimary("Your Collections:");
            userCollectionData = await loopringService.GetNftCollection(loopringApiKey, fromAddress);
            collections = new List<string>();
            if (userCollectionData.totalNum > 0)
            {
                foreach (var item in userCollectionData.collections)
                {
                    if (item.collection == userCollectionData.collections.Last().collection)
                    {
                        font.ToWhiteInline($"{item.collection.name}");
                    }
                    else
                    {
                        font.ToWhiteInline($"{item.collection.name}, ");
                    }
                    collections.Add(item.collection.name.ToLower());
                }

                Console.WriteLine();
                font.ToTertiary("Enter a collection.");

                var userCollection = Utils.ReadLineWarningNoNullsForceCollection("Please enter a collection.", font, collections);
                var userCollectionSingle = userCollectionData.collections.Where(x => x.collection.name.ToLower() == userCollection).First().collection;
                var userCollectionInformation = await loopringService.GetNftCollectionInformation(loopringApiKey, userCollectionData.collections.Where(x => x.collection.name.ToLower() == userCollection).First().collection.id.ToString());
                sw = Stopwatch.StartNew();
                Console.WriteLine();
                font.ToPrimary("Gathering information...");
                foreach (var item in userCollectionInformation.nftTokenInfos)
                {
                    var deadAddress = 0;
                    var nftHolders = await loopringService.GetNftHoldersMultiple(loopringApiKey, item.nftData);
                    if ((nftHolders.Where(x => x.accountId == 38482).Count() == 1 || nftHolders.Where(x => x.accountId == 92023).Count() == 1) && nftHolders.Count == 1)
                        continue;
                    currentOverallTotal += item.total;
                    collectionNftHolders.AddRange(nftHolders);
                    nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, item.nftId, item.tokenAddress);
                    Utils.ClearLine();
                    font.ToTertiaryInline($"\rChecking Nft: {++counter}/{userCollectionInformation.nftTokenInfos.Count} {nftMetadata.name}");
                    // added the below
                    var holderCounter = 0;
                    foreach (var nftHolder in nftHolders)
                    {
                        Utils.ClearLine();
                        font.ToTertiaryInline($"\rChecking Nft: {counter}/{userCollectionInformation.nftTokenInfos.Count} {nftMetadata.name} Nft Holder: {++holderCounter}/{nftHolders.Count}");
                        userAccountInformation = await loopringService.GetUserAccountInformation(nftHolder.accountId.ToString());

                        if(nftMetadata != null)
                            if (userAccountInformation.owner.ToLower() != "0x000000000000000000000000000000000000dead" && userAccountInformation.owner.ToLower() != "0xdead000000000000000042069420694206942069")
                            {
                                ownerAndAmount.Add(new OwnerAndAmount
                                {
                                    nftData = item.nftData,
                                    nftName = nftMetadata.name,
                                    nftOwner = userAccountInformation.owner,
                                    ownerAmountOwned = nftHolder.amount
                                });
                                if (!ownerAndTotal.Any(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()))
                                {
                                    ownerAndTotal.Add(new OwnerAndTotal
                                    {
                                        owner = userAccountInformation.owner,
                                        total = int.Parse(nftHolder.amount),
                                        //percentageOwned = (Convert.ToDecimal(nftHolder.amount) / Convert.ToDecimal(userCollectionInformation.nftTokenInfos.Sum(x => x.total))).ToString("0.00")
                                    });
                                }
                                else
                                {
                                    currentTotal = ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()).total;
                                    ownerAndTotal.RemoveAt(ownerAndTotal.IndexOf(ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower())));
                                    ownerAndTotal.Add(new OwnerAndTotal
                                    {
                                        owner = userAccountInformation.owner,
                                        total = currentTotal += int.Parse(nftHolder.amount),
                                        //percentageOwned = (Convert.ToDecimal(currentTotal += int.Parse(nftHolder.amount)) / Convert.ToDecimal(userCollectionInformation.nftTokenInfos.Sum(x => x.total))).ToString("0.00")
                                    });
                                }
                            }
                            else
                            {
                                deadAddress = 1;
                                continue;
                            }
                    }
                    if(deadAddress == 1)
                        continue;
                    // end
                    if (counter == 1)
                    {
                        collectionNftInformation.Append(header);
                        if (nftMetadata.attributes is not null)
                            if (nftMetadata.attributes.Count > 0)
                            {
                                collectionNftInformation.Append('~');
                                header += "~";
                                foreach (var a in nftMetadata.attributes)
                                {
                                    collectionNftInformation.Append($"Attribute {++attributeCounter}");
                                    header += $"Attribute {attributeCounter}";
                                    if (attributeCounter != nftMetadata.attributes.Count)
                                    {
                                        collectionNftInformation.Append('~');
                                        header += "~";
                                    }
                                }
                            }
                        collectionNftInformation.Append($"\r\n");
                        if (nftMetadata.attributes is not null)
                            maxAttributeCount = nftMetadata.attributes.Count;
                    }
                    if (nftMetadata.attributes is not null)
                        if (nftMetadata.attributes.Count > maxAttributeCount)
                        {
                            string newHeader = header;
                            for (int i = maxAttributeCount; i < nftMetadata.attributes.Count; i++)
                            {
                                newHeader += $"~Attribute {++attributeCounter}";
                            }
                            collectionNftInformation.Replace(header, newHeader);
                            maxAttributeCount = nftMetadata.attributes.Count;
                            header = newHeader;
                        }
                    collectionNftInformation.Append($"{nftMetadata.name}~{nftMetadata.description}~{nftMetadata.image}~{item.total}~{item.nftData}~{item.nftId}~{item.minter}~{item.tokenAddress}~{item.royaltyPercentage}");
                    if (nftMetadata.attributes is not null)
                        if (nftMetadata.attributes.Count > 0)
                        {
                            collectionNftInformation.Append('~');
                            foreach (var a in nftMetadata.attributes)
                            {
                                collectionNftInformation.Append($"{a.trait_type}/{a.value}");
                                if (a != nftMetadata.attributes.Last())
                                {
                                    collectionNftInformation.Append('~');
                                }
                            }
                        }
                    if (counter != userCollectionInformation.nftTokenInfos.Count)
                        collectionNftInformation.Append($"\r\n");
                }
                excelFileName = $"{userCollection}_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.xlsx";
                ExcelFile.CreateExcelFile(font, ownerAndTotal,ownerAndAmount, userCollectionSingle, userCollectionInformation, collectionNftHolders, collectionNftInformation, excelFileName);
                Console.WriteLine();
                Console.WriteLine();
                sw.Stop();
                Utils.FunctionalityProcessTime(sw, excelFileName, null, font);
            }
            else
            {
                Console.WriteLine();
                font.ToYellow($"{fromAddress} does not have any collections.");
            }
            break;
        #endregion case 20
        #region case 21
        case "21":
            counter = 0;
            currentOverallTotal = 0;
            header = "name~description~image~total~nftData~nftId~minter~tokenAddress~royaltyPercentage";
            maxAttributeCount = 0;
            attributeCounter = 0;
            collectionNftHolders = new List<NftHolder>();
            ownerAndAmount = new List<OwnerAndAmount>();
            ownerAndTotal = new List<OwnerAndTotal>();
            collectionNftInformation = new StringBuilder();
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(21).Value} -");
            font.ToDarkGray("Here you will get Analytics from your owned collection.");
            font.ToDarkGray("You will need excel or google sheets.");
            Console.WriteLine();

            font.ToPrimary("Your Collections:");
            var userOwnedCollectionData = await loopringService.GetUserNftCollection(loopringApiKey, fromAccountId);
            collections = new List<string>();
            if (userOwnedCollectionData.totalNum > 0)
            {
                foreach (var item in userOwnedCollectionData.collections)
                {
                    if (item.collection == userOwnedCollectionData.collections.Last().collection)
                    {
                        font.ToWhiteInline($"{item.collection.name}");
                    }
                    else
                    {
                        font.ToWhiteInline($"{item.collection.name}, ");
                    }
                    collections.Add(item.collection.name.ToLower());
                }

                Console.WriteLine();
                font.ToTertiary("Enter a collection.");

                var userCollection = Utils.ReadLineWarningNoNullsForceCollection("Please enter a collection.", font, collections);
                var userCollectionSingle = userOwnedCollectionData.collections.Where(x => x.collection.name.ToLower() == userCollection).First().collection;
                var userCollectionInformation = await loopringService.GetNftCollectionInformation(loopringApiKey, userOwnedCollectionData.collections.Where(x => x.collection.name.ToLower() == userCollection).First().collection.id.ToString());
                foreach (var item in userCollectionInformation.nftTokenInfos)
                {
                    var deadAddress = 0;
                    var nftHolders = await loopringService.GetNftHoldersMultiple(loopringApiKey, item.nftData);
                    if ((nftHolders.Where(x => x.accountId == 38482).Count() == 1 || nftHolders.Where(x => x.accountId == 92023).Count() == 1) && nftHolders.Count == 1)
                        continue;
                    currentOverallTotal += item.total;
                    collectionNftHolders.AddRange(nftHolders);
                    nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, item.nftId, item.tokenAddress);
                    Utils.ClearLine();
                    font.ToTertiaryInline($"\rChecking Nft: {++counter}/{userCollectionInformation.nftTokenInfos.Count} {nftMetadata.name}");
                    // added the below
                    var holderCounter = 0;
                    foreach (var nftHolder in nftHolders)
                    {
                        Utils.ClearLine();
                        font.ToTertiaryInline($"\rChecking Nft: {counter}/{userCollectionInformation.nftTokenInfos.Count} {nftMetadata.name} Nft Holder: {++holderCounter}/{nftHolders.Count}");
                        userAccountInformation = await loopringService.GetUserAccountInformation(nftHolder.accountId.ToString());
                        if (nftMetadata != null)
                            if (userAccountInformation.owner.ToLower() != "0x000000000000000000000000000000000000dead" && userAccountInformation.owner.ToLower() != "0xdead000000000000000042069420694206942069")
                            {
                                ownerAndAmount.Add(new OwnerAndAmount
                                {
                                    nftData = item.nftData,
                                    nftName = nftMetadata.name,
                                    nftOwner = userAccountInformation.owner,
                                    ownerAmountOwned = nftHolder.amount
                                });
                                if (!ownerAndTotal.Any(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()))
                                {
                                    ownerAndTotal.Add(new OwnerAndTotal
                                    {
                                        owner = userAccountInformation.owner,
                                        total = int.Parse(nftHolder.amount),
                                        //percentageOwned = ((Convert.ToDecimal(nftHolder.amount) / Convert.ToDecimal(userCollectionInformation.nftTokenInfos.Sum(x => x.total))) * 100).ToString("0.00")
                                    });
                                }
                                else
                                {
                                    currentTotal = ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()).total;
                                    ownerAndTotal.RemoveAt(ownerAndTotal.IndexOf(ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower())));
                                    ownerAndTotal.Add(new OwnerAndTotal
                                    {
                                        owner = userAccountInformation.owner,
                                        total = currentTotal += int.Parse(nftHolder.amount),
                                        //percentageOwned = ((Convert.ToDecimal(currentTotal += int.Parse(nftHolder.amount)) / Convert.ToDecimal(item.total + currentOverallTotal)) * 100).ToString("0.00")
                                    });
                                }
                            }
                            else
                            {
                                deadAddress = 1;
                                continue;
                            }
                    }
                    if (deadAddress == 1)
                        continue;
                    // end
                    if (counter == 1)
                    {
                        collectionNftInformation.Append(header);
                        if (nftMetadata.attributes is not null)
                            if (nftMetadata.attributes.Count > 0)
                            {
                                collectionNftInformation.Append('~');
                                header += "~";
                                foreach (var a in nftMetadata.attributes)
                                {
                                    collectionNftInformation.Append($"Attribute {++attributeCounter}");
                                    header += $"Attribute {attributeCounter}";
                                    if (attributeCounter != nftMetadata.attributes.Count)
                                    {
                                        collectionNftInformation.Append('~');
                                        header += "~";
                                    }
                                }
                            }
                        collectionNftInformation.Append($"\r\n");
                        if (nftMetadata.attributes is not null)
                            maxAttributeCount = nftMetadata.attributes.Count;
                    }
                    if (nftMetadata.attributes is not null)
                        if (nftMetadata.attributes.Count > maxAttributeCount)
                        {
                            string newHeader = header;
                            for (int i = maxAttributeCount; i < nftMetadata.attributes.Count; i++)
                            {
                                newHeader += $"~Attribute {++attributeCounter}";
                            }
                            collectionNftInformation.Replace(header, newHeader);
                            maxAttributeCount = nftMetadata.attributes.Count;
                            header = newHeader;
                        }
                    collectionNftInformation.Append($"{nftMetadata.name}~{nftMetadata.description}~{nftMetadata.image}~{item.total}~{item.nftData}~{item.nftId}~{item.minter}~{item.tokenAddress}~{item.royaltyPercentage}");
                    if(nftMetadata.attributes is not null)
                        if (nftMetadata.attributes.Count > 0)
                        {
                            collectionNftInformation.Append('~');
                            foreach (var a in nftMetadata.attributes)
                            {
                                collectionNftInformation.Append($"{a.trait_type}/{a.value}");
                                if (a != nftMetadata.attributes.Last())
                                {
                                    collectionNftInformation.Append('~');
                                }
                            }
                        }
                    if (counter != userCollectionInformation.nftTokenInfos.Count)
                        collectionNftInformation.Append($"\r\n");

                }
                excelFileName = $"{userCollection}_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.xlsx";
                ExcelFile.CreateExcelFile(font, ownerAndTotal, ownerAndAmount, userCollectionSingle, userCollectionInformation, collectionNftHolders, collectionNftInformation, excelFileName);
                Console.WriteLine();
                Console.WriteLine();
                font.ToWhite($@"Your collection information can be found: {AppDomain.CurrentDomain.BaseDirectory}Output\{excelFileName}");


            }
            else
            {
                Console.WriteLine();

                font.ToYellow($"{fromAddress} does not have any collections.");
            }
            break;
        #endregion case 21
        #region case 22
        case "22":
            counter = 0;
            currentOverallTotal = 0;
            header = "name~description~image~total~nftData~nftId~minter~tokenAddress~royaltyPercentage";
            maxAttributeCount = 0;
            attributeCounter = 0;
            collectionNftHolders = new List<NftHolder>();
            ownerAndAmount = new List<OwnerAndAmount>();
            ownerAndTotal = new List<OwnerAndTotal>();
            collectionNftInformation = new StringBuilder();
            font.ToPrimary($" - {menuAndUtility.allUtilities.ElementAt(22).Value} -");
            font.ToDarkGray("Here you will get Analytics from a specifc collection.");
            font.ToDarkGray("You will need the minter, token/collection address, and excel or google sheets.");
            Console.WriteLine();

            font.ToWhite("Let's get started.");
            do
            {
                minterAndCollection = UtilsLoopring.GetMinterAndCollection(font);
                responseOnMinter = await loopringService.CheckForEthAddress(settings.LoopringApiKey, minterAndCollection.minter);
                responseOnAccountId = await loopringService.GetUserAccountInformationFromOwner(responseOnMinter);
            }
            while (responseOnAccountId == null);
            sw = Stopwatch.StartNew();
            Console.WriteLine();
            font.ToPrimary("Gathering information...");
            nftDataList = await loopringService.GetUserMintedNftsWithCollection(font, settings.LoopringApiKey, responseOnAccountId.accountId, minterAndCollection.TokenId);
            var specificCollectionSingle = await loopringService.GetNftCollectionPublic(loopringApiKey, nftDataList.First().nftData);
            var specificCollectionInformation = await loopringService.GetNftCollectionInformation(loopringApiKey, specificCollectionSingle.id.ToString());
            font.ToTertiaryInline($"\r{minterAndCollection.minter} has {nftDataList.Count} mints in this Collection.");
            counter = 0;
            Console.WriteLine();
            foreach (var nftDataSingle in nftDataList)
            {
                var deadAddress = 0;
                var nftHolders = await loopringService.GetNftHoldersMultiple(loopringApiKey, nftDataSingle.nftData);
                if ((nftHolders.Where(x => x.accountId == 38482).Count() == 1 || nftHolders.Where(x => x.accountId == 92023).Count() == 1) && nftHolders.Count == 1)
                    continue;
                //currentOverallTotal += item.total;
                collectionNftHolders.AddRange(nftHolders);
                nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, nftDataSingle.nftId, nftDataSingle.tokenAddress);
                Utils.ClearLine();
                font.ToTertiaryInline($"\rChecking Nft: {++counter}/{nftDataList.Count} {nftMetadata.name}");
                // added the below
                var holderCounter = 0;
                foreach (var nftHolder in nftHolders)
                {
                    Utils.ClearLine();
                    font.ToTertiaryInline(str: $"\rChecking Nft: {counter}/{nftDataList.Count} {nftMetadata.name} Nft Holder: {++holderCounter}/{nftHolders.Count}");
                    userAccountInformation = await loopringService.GetUserAccountInformation(nftHolder.accountId.ToString());
                    if (nftMetadata != null)
                        if (userAccountInformation.owner.ToLower() != "0x000000000000000000000000000000000000dead" && userAccountInformation.owner.ToLower() != "0xdead000000000000000042069420694206942069")
                        {
                            ownerAndAmount.Add(new OwnerAndAmount
                            {
                                nftData = nftDataSingle.nftData,
                                nftName = nftMetadata.name,
                                nftOwner = userAccountInformation.owner,
                                ownerAmountOwned = nftHolder.amount
                            });
                            if (!ownerAndTotal.Any(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()))
                            {
                                ownerAndTotal.Add(new OwnerAndTotal
                                {
                                    owner = userAccountInformation.owner,
                                    total = int.Parse(nftHolder.amount),
                                    //percentageOwned = ((Convert.ToDecimal(nftHolder.amount) / Convert.ToDecimal(userCollectionInformation.nftTokenInfos.Sum(x => x.total))) * 100).ToString("0.00")
                                });
                            }
                            else
                            {
                                currentTotal = ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower()).total;
                                ownerAndTotal.RemoveAt(ownerAndTotal.IndexOf(ownerAndTotal.First(x => x.owner.ToLower() == userAccountInformation.owner.ToLower())));
                                ownerAndTotal.Add(new OwnerAndTotal
                                {
                                    owner = userAccountInformation.owner,
                                    total = currentTotal += int.Parse(nftHolder.amount),
                                    //percentageOwned = ((Convert.ToDecimal(currentTotal += int.Parse(nftHolder.amount)) / Convert.ToDecimal(item.total + currentOverallTotal)) * 100).ToString("0.00")
                                });
                            }
                        }
                        else
                        {
                            deadAddress = 1;
                            continue;
                        }
                }
                if (deadAddress == 1)
                    continue;
                // end
                if (counter == 1)
                {
                    collectionNftInformation.Append(header);
                    if (nftMetadata.attributes is not null)
                        if (nftMetadata.attributes.Count > 0)
                        {
                            collectionNftInformation.Append('~');
                            header += "~";
                            foreach (var a in nftMetadata.attributes)
                            {
                                collectionNftInformation.Append($"Attribute {++attributeCounter}");
                                header += $"Attribute {attributeCounter}";
                                if (attributeCounter != nftMetadata.attributes.Count)
                                {
                                    collectionNftInformation.Append('~');
                                    header += "~";
                                }
                            }
                        }
                    collectionNftInformation.Append($"\r\n");
                    if (nftMetadata.attributes is not null)
                        maxAttributeCount = nftMetadata.attributes.Count;
                }
                if (nftMetadata.attributes is not null)
                    if (nftMetadata.attributes.Count > maxAttributeCount)
                    {
                        string newHeader = header;
                        for (int i = maxAttributeCount; i < nftMetadata.attributes.Count; i++)
                        {
                            newHeader += $"~Attribute {++attributeCounter}";
                        }
                        collectionNftInformation.Replace(header, newHeader);
                        maxAttributeCount = nftMetadata.attributes.Count;
                        header = newHeader;
                    }
                collectionNftInformation.Append($"{nftMetadata.name}~{nftMetadata.description}~{nftMetadata.image}~{nftHolders.Sum(x=>int.Parse(x.amount))}~{nftDataSingle.nftData}~{nftDataSingle.nftId}~{nftDataSingle.minter}~{nftDataSingle.tokenAddress}~{nftDataSingle.royaltyPercentage}");
                if (nftMetadata.attributes is not null)
                    if (nftMetadata.attributes.Count > 0)
                    {
                        collectionNftInformation.Append('~');
                        foreach (var a in nftMetadata.attributes)
                        {
                            collectionNftInformation.Append($"{a.trait_type}/{a.value}");
                            if (a != nftMetadata.attributes.Last())
                            {
                                collectionNftInformation.Append('~');
                            }
                        }
                    }
                if (counter != nftDataList.Count)
                    collectionNftInformation.Append($"\r\n");
            
            }

            excelFileName = $"{specificCollectionSingle.name.Replace(" ","")}_{DateTime.UtcNow:yyyy-MM-dd HH-mm-ss}.xlsx";
            ExcelFile.CreateExcelFile(font, ownerAndTotal, ownerAndAmount, specificCollectionSingle, specificCollectionInformation, collectionNftHolders, collectionNftInformation, excelFileName);
            Console.WriteLine();
            Console.WriteLine();
            font.ToWhite($@"Your collection information can be found: {AppDomain.CurrentDomain.BaseDirectory}Output\{excelFileName}");
            break;
            #endregion case 22
    }
    Console.WriteLine();
    userResponseReadyToMoveOn = Menu.EndOfMaizeFunctionality(font);
}
Menu.FooterForMaize(font);
Console.ReadLine();