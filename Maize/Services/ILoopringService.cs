using Maize.Models;
using Maize.Models.Responses;

namespace Maize
{
    public interface ILoopringService
    {
        Task<List<CollectionMinted>> GetUserMintedCollections(string apiKey, string owner);
        Task<List<CollectionOwned>> GetUserOwnedCollections(string apiKey, int accountId);
        Task<NftResponseFromCollection> GetCollectionNfts(string apiKey, string id);
        Task<ResolveEnsOrNameResponse> GetHexAddress(string apiKey, string ens);
        Task<ResolveEnsOrNameResponse> GetLoopringEns(string apiKey, string owner);
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
    }
}
