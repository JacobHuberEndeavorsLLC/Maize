using Maize.Models.ApplicationSpecific;
using Maize.Models.Responses;
using System.Diagnostics;
using static Maize.Models.NftHolders;

namespace Maize.Helpers
{
    public class ApplicationFunctionalities
    {
        public static async Task<(string fileName, Stopwatch sw)> NftDataFromWallet(Font font, ILoopringService loopringService, Settings s)
        {
            var sw = ApplicationUtilities.StartUtilityCalculationsTimer(font);
            var wallet = await ApplicationUtilities.GetAndCheckWalletAddress(loopringService, font, s);
            var walletsNfts = await loopringService.GetWalletsNfts(s.LoopringApiKey, wallet.accountInformation.accountId);
            Font.ClearLine();
            font.ToSecondary($"{wallet.userInput} has {walletsNfts.Count} NFTs in their wallet.");

            var walletsNftsBasicInformation = walletsNfts.Select(m => new { m.metadata.nftBase.name, m.nftData, m.nftId, m.minter, m.tokenAddress }).ToList();

            var fileName = ApplicationUtilities.WriteDataToCsvFile("NftDataFromWallet", walletsNftsBasicInformation);
            sw.Stop();
            return (fileName, sw);
        }
        public static async Task<(string fileName, Stopwatch sw)> NftDataFromCollection(Font font, ILoopringService loopringService, Settings s)
        {
            NftResponseFromCollection nftCollectionInformation = new();
            var sw = ApplicationUtilities.StartUtilityCalculationsTimer(font);
            do
            {
                var collectionAndNfts = await ApplicationUtilities.CheckCollectionMintedOrOwnedAndGetNfts(loopringService, font, s);
                if (collectionAndNfts.nftCollectionInformation == null)
                    collectionAndNfts = await ApplicationUtilities.CheckCollectionAndGetNfts(loopringService, font, s, collectionAndNfts.userInput);
                if (collectionAndNfts.nftCollectionInformation == null)
                    font.ToSecondary("No information was found, try again.");
                nftCollectionInformation = collectionAndNfts.nftCollectionInformation;
            } while (nftCollectionInformation == null);
            Font.ClearLine();
            font.ToSecondary($"{nftCollectionInformation.nftTokenInfos.First().tokenAddress} has {nftCollectionInformation.totalNum} NFTs in its collection.");

            var collectionsNftsInformation = nftCollectionInformation.nftTokenInfos.Select(m => new { m.metadata.basename.name, m.metadata.basename.description, m.nftData, m.nftId, m.minter, m.tokenAddress, m.metadata.basename.properties }).ToList();

            var fileName = ApplicationUtilities.WriteDataToCsvFile("NftDataFromWallet", collectionsNftsInformation);
            
            sw.Stop();
            return (fileName, sw);
        }
        public static async Task<(string fileName, string fileNameTwo, Stopwatch sw)> NftHoldersFromNftData(Font font, ILoopringService loopringService, INftMetadataService nftMetadataService, IEthereumService ethereumService, Settings s, int utility)
        {
            int currentTotal;
            var counter = 0;
            var ownerAndAmount = new List<OwnerAndAmount>();
            var ownerAndTotal = new List<OwnerAndTotal>();

            var howManyLines = Files.CheckInputFile(utility, font);
            var sw = ApplicationUtilities.StartUtilityCalculationsTimer(font);

            using (StreamReader sr = new($"{Constants.BaseDirectory}{Constants.InputFolder}{Constants.InputFile}"))
            {
                Console.WriteLine();
                string nftData;
                while ((nftData = sr.ReadLine()) != null)
                {
                    Font.ClearLine();
                    font.ToTertiaryInline($"\rNft: {++counter}/{howManyLines}");

                    var nftHoldersList = await loopringService.GetNftHoldersMultiple(s.LoopringApiKey, nftData);

                    var minterFromNftDatas = await loopringService.GetNftInformationFromNftData(s.LoopringApiKey, nftData);
                    var nftMetadata = await ApplicationUtilities.GetNftMetadata(font, ethereumService, nftMetadataService, minterFromNftDatas.FirstOrDefault().nftId, minterFromNftDatas.FirstOrDefault().tokenAddress);
                    var holderCounter = 0;
                    foreach (var nftHolder in nftHoldersList)
                    {
                        if (nftHoldersList.FirstOrDefault().accountId == nftHolder.accountId)
                        {
                            Font.ClearLine();
                        }
                        font.ToTertiaryInline($"\rNft: {counter}/{howManyLines} {nftMetadata.name} Nft Holder: {++holderCounter}/{nftHoldersList.Count}");
                        var userAccountInformation = await loopringService.GetUserAccountInformationFromId(nftHolder.accountId.ToString());
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
                var fileName = ApplicationUtilities.WriteDataToCsvFile("NftHolderFromNftData", ownerAndAmount);
                var fileNameTwo = ApplicationUtilities.WriteDataToCsvFile("NftHoldersAndTotals", ownerAndTotal.OrderByDescending(x => x.total));

                sw.Stop();
                return (fileName, fileNameTwo, sw);
            }
        }
    }
}
