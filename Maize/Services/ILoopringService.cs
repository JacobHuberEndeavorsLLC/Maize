using Maize.Models;
using Maize.Models.Responses;
using RestSharp;

namespace Maize
{
    public interface ILoopringService
    {
        Task<RefreshNftResponse> RefreshNft(string nftId, string collectionAddress);
        Task<string> PostImage(string filePath);
        Task<string> PostMetadata(string metadataJson, string metadataFileName);
        Task<decimal?> GetRecommendedGasPrice();
        Task<List<UserAssetsResponse>> GetUserAssetsForFees(string apiKey, int accountId);
        Task<List<CollectionMinted>> GetUserMintedCollections(string apiKey, string owner);
        Task<List<CollectionOwned>> GetUserOwnedCollections(string apiKey, int accountId);
        Task<NftResponseFromCollection> GetCollectionNfts(string apiKey, string id);
        Task<ResolveEnsOrNameResponse> GetHexAddress(string apiKey, string ens);
        Task<ResolveEnsOrNameResponse> GetLoopringEns(string apiKey, string owner);
        Task<WalletTypeResponse> GetWalletType(string walletAddress);
        Task<NftBalance> GetNfts(string apiKey, int accountId, string nftData);
        Task<List<Datum>> GetWalletsNfts(string apiKey, int accountId);
        Task<AccountInformationResponse> GetUserAccountInformationFromOwner(string owner);
        Task<AccountInformationResponse> GetUserAccountInformationFromId(string accountid);
        Task<string> GetApiKey(int accountId, string xApiSig);
        Task<List<Transaction>> GetUserTransactions(string apikey, int accountId, string? startDate, string? endDate);
        Task<NftDataResponse> GetNftData(string apiKey, string nftId, string minter, string tokenAddress);
        Task<NftHoldersResponse> GetNftHolderSingle(string apiKey, string nftData);
        Task<List<NftHolder>> GetNftHoldersMultiple(string apiKey, string nftData);
        Task<List<NftInformationResponse>> GetNftInformationFromNftData(string apiKey, string nftData);
        Task<NftBalance> FindCollectionIdFromHolder(string apiKey, int accountId, string nftData);
        Task<NftOffChainFeeResponse> GetNftOffChainFee(string apiKey, int accountId, int requestType);
        Task<List<TokensResponse>> GetTokens();
        Task<TokenPriceResponse> GetTokenPrice();
        Task<NftBalance> GetTokenId(string apiKey, int accountId, string nftData);
        Task<StorageId> GetNextStorageId(string apiKey, int accountId, int sellTokenId);
        Task<OffchainFee> GetOffChainFee(string apiKey, int accountId, int requestType, string amount);
        Task<string> CheckForEthAddress(ILoopringService LoopringService, string apiKey, string address);
        Task<TransferFeeOffchainFee> GetOffChainTransferFee(string apiKey, int accountId, int requestType, string feeToken, string amount);
        Task<NftTransferAuditInformation> NftTransfer(
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
            string nftAmount,
            long validUntil,
            decimal lcrTransactionFee,
            string transferMemo,
            string? nftData,
            string toAddress,
            bool payPayeeUpdateAccount,
        CounterFactualInfo? isCounterFactual
            );
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
             string transferMemo,
             bool payPayeeUpdateAccount,
        CounterFactualInfo? isCounterFactual
            );
        Task<decimal> CobTransferTransactionFee(
        int environment,
        string environmentUrl,
        string environmentExchange,
        string loopringApiKey,
        string loopringPrivateKey,
        string MMorGMEPrivateKey,
        int fromAccountId,
        decimal transactionFeeTotal,
        int nftSentTotal,
        string maxFeeToken,
        int maxFeeTokenId,
        string myAddress,
string fromAddress,
int nftOrLrc,
        int maizeFeeId,
        string maizeFee,
               CounterFactualInfo? isCounterFactual
        );
        Task<CryptoTransferAuditInformation> TokenTransfer(
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
            long validUntil,
            decimal lcrTransactionFee,
            string transferMemo,
            decimal amountToTransfer,
            string toAddress,
            bool payPayeeUpdateAccount,
               CounterFactualInfo? isCounterFactual
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
               string memo,
               bool payPayeeUpdateAccount,
               CounterFactualInfo? isCounterFactual
          );
        Task<CounterFactualInfo> GetCounterFactualInfo(int accountId);
    }
}
