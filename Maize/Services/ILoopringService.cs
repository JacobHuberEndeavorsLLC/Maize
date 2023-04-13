using Maize;
using Maize.Helpers;
using Maize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public interface ILoopringService
    {
        Task<List<BlockInformation>> GetBlocks();
        Task<CoinBalance> GetUserEthBalance(string apiKey, int accountId);
        Task<StorageId> GetNextStorageId(string apiKey, int accountId, int sellTokenId);
        Task<OffchainFee> GetOffChainFee(string apiKey, int accountId, int requestType, string amount);
        Task<UserCollections> GetNftCollection(string apiKey, string owner);
        Task<UserOwnedCollections> GetUserNftCollection(string apiKey, int accountId);
        Task<Collection> GetNftCollectionPublic(string apiKey, string nftHash);
        Task<CollectionInformation> GetNftCollectionInformation(string apiKey, string id);

        Task<TransferFeeOffchainFee> GetOffChainTransferFee(string apiKey, int accountId, int requestType, string feeToken, string amount);
        Task<TransferFeeOffchainFee> GetOffChainTransferFeeForTransferAndUpdateAccount(string apiKey, int accountId, int requestType);
        Task<string> SubmitNftTransfer(
            string apiKey,
            string exchange,
            int fromAccountId,
            string fromAddress,
                 int toAccountId,
                 string toAddress,
                 int nftTokenId,
                 string nftAmount,
                 int maxFeeTokenId,
                 string maxFeeAmount,
                 int storageId,
                 long validUntil,
                 string eddsaSignature,
                 string ecdsaSignature,
                 string nftData, 
                 string transferMemo
                 );
        Task<string> SubmitTokenTransfer(
          string apiKey,
              string exchange,
              int fromAccountId,
              string fromAddress,
                   int toAccountId,
                   string toAddress,
                   int tokenId,
                   string tokenAmount,
                   int maxFeeTokenId,
                   string maxFeeAmount,
                   int storageId,
                   long validUntil,
                   string eddsaSignature,
                   string ecdsaSignature,
                   string memo
                 );
        Task<string> SubmitPayPayeeUpdateAccountFee(
  string apiKey,
      string exchange,
      int fromAccountId,
      string fromAddress,
           int toAccountId,
           string toAddress,
           int tokenId,
           string tokenAmount,
           int maxFeeTokenId,
           string maxFeeAmount,
           int storageId,
           long validUntil,
           string eddsaSignature,
           string ecdsaSignature,
           string memo,
           string payPayeeUpdateAccount
         );
        Task<EnsResult> GetHexAddress(string apiKey, string ens);
        Task<ResolveEns> GetLoopringEns(string apiKey, string owner);
        Task<string> CheckForEthAddress(string apiKey, string address);
        Task<NftBalance> GetTokenId(string apiKey, int accountId, string nftData);
        Task<NftBalance> GetTokenIdWithCheck(string apiKey, int accountId, string nftData);
        Task<List<Datum>> GetWalletsNfts(string apiKey, int accountId);
        Task<NftData> GetNftData(string apiKey, string nftId, string minter, string tokenAddress);
        Task<List<NftHolder>> GetNftHoldersMultiple(string apiKey, string nftData);
        Task<NftBalance> FindCollectionIdFromHolder(string apiKey, int accountId, string nftData);
        Task<List<NftHolderAndNftData>> GetNftHolderIncludeNftData(Font font, ILoopringService loopringService, INftMetadataService nftMetadataService,
            IEthereumService ethereumService, string apiKey, string nftData, string environmentalUrl, int counter, int max);
        Task<List<NftHoldersAndTotal>> GetNftHoldersMultipleAndTotal(string apiKey, string nftData);
        Task<NftHoldersAndTotal> GetNftHolderSingle(string apiKey, string nftData);
        Task<AccountInformation> GetUserAccountInformation(string accountId);
        Task<AccountInformation> GetUserAccountInformationFromOwner(string owner);
        Task<AccountInformation> CheckUserAccountInformationFromOwner(string owner);
        Task<string> GetApiKey(int accountId, string xApiSig);
        Task<List<NftData>> GetUserMintedNfts(Font font, string apiKey, int accountId);
        Task<List<NftData>> GetUserMintedNftsWithCollection(Font font, string apiKey, int accountId, string collectionId);
        Task<List<NftData>> GetNftInformationFromNftData(string apiKey, string nftData);
        Task<Prices> GetTokenFiatPrices(string legal);
        Task<List<Transfer>> GetUserNftTransfer(string apikey, int accountId);
        Task<List<Transaction>> GetUserTransactions(string apikey, int accountId, string? startDate, string? endDate);
        Task<bool> CheckBanishTextFile(Font font, string toAddressInitial, string toAddress, string loopringApiKey);
        Task<bool> CheckBanishFile(Font font, string loopringApiKey, string toAddress);
        Task<string> CobTransferTransactionFee(
            int environment,
            string environmentUrl,
            string environmentExchange,
            string loopringApiKey, 
            string loopringPrivateKey,
            string MMorGMEPrivateKey,
            int fromAccountId, 
            decimal transactionFeeTotal, 
            int validAddressCount,
            string maxFeeToken,
            int maxFeeTokenId,
            string myAddress,
            string fromAddress,
            int nftOrLrc
            );
        Task<NftTransferAuditInformation> NftTransfer(
            Font font, 
            ILoopringService loopringService,
            int environment,
            string environmentUrl,
            string environmentExchange,
            string loopringApiKey,
            string loopringPrivateKey,
            string MMorGMEPrivateKey,
            int fromAccountId,
            int toAccountId,
            string maxFeeToken,
            int maxFeeTokenId,
            string fromAddress, 
            string fileName,
            string inputPath,
            int howManyLines,
            int nftTokenId,
            string? nftAmount,
            long validUntil,
            decimal lcrTransactionFee,
            string transferMemo,
            string? nftData
            );
        Task<NftTransferAuditInformation> NftTransferDead(
            Font font,
            int environment,
            string environmentUrl,
            string environmentExchange,
            string loopringApiKey,
            string loopringPrivateKey,
            string MMorGMEPrivateKey,
            int fromAccountId,
            int toAccountId,
            string maxFeeToken,
            int maxFeeTokenId,
            string fromAddress,
            string fileName,
            int howManyLines,
            int nftTokenId,
            string? nftAmount,
            long validUntil,
            decimal lcrTransactionFee,
            string transferMemo,
            string? nftData,
            List<Datum> walletsNfts,
            List<Datum> banishedNfts,
            INftMetadataService nftMetadataService,
            IEthereumService ethereumService
            );
        Task<NftTransferAuditInformation> LrcTransfer(
            Font font,
            int environment,
            string environmentUrl,
            string environmentExchange,
            string loopringApiKey,
            string loopringPrivateKey,
            string MMorGMEPrivateKey,
            int fromAccountId,
            string fromAddress,
            string fileName,
            string inputPath,
            int howManyLines,
            decimal amountToTransfer,
            long validUntil,
            decimal lcrTransactionFee,
            string transferMemo
            );        
        Task<NftTransferAuditInformation> LrcTransferActivation(
            Font font,
            int environment,
            string environmentUrl,
            string environmentExchange,
            string loopringApiKey,
            string loopringPrivateKey,
            string MMorGMEPrivateKey,
            int fromAccountId,
            string fromAddress,
            string fileName,
            string inputPath,
            int howManyLines,
            decimal amountToTransfer,
            long validUntil,
            decimal lcrTransactionFee,
            string transferMemo
            );

        Task<List<UserCollections>> GetNftCollectionsOfOwnAccount(string apiKey, string owner);

        Task<List<NftCollectionItemsWithMetadata>> GetNftCollectionItemsOfOwnAccount(string apiKey, string collectionId);
    }
}
