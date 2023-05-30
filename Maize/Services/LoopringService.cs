using Maize.Models;
using Maize.Models.Responses;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace Maize
{
    public class LoopringService : ILoopringService, IDisposable
    {

        readonly RestClient _client;
        readonly Font _font;

        public LoopringService(string environmentUrl, Font font)
        {
            _client = new RestClient(environmentUrl);
            _font = font;
        }
        public LoopringService(string environmentUrl)
        {
            _client = new RestClient(environmentUrl);
        }
        public async Task<List<CollectionOwned>> GetUserOwnedCollections(string apiKey, int accountId)
        {
            List<CollectionOwned> allData = new();
            var request = new RestRequest("/api/v3/user/collection/details");
            int offset = 0;
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("limit", 50);
            request.AddParameter("offset", offset);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<UserOwnedCollectionResponse>(response.Content!);
                if (data.collections.Count != 0) 
                {
                    allData.AddRange(data.collections);
                    Font.ClearLine();
                    _font.ToSecondaryInline($"{allData.Count}/{data.totalNum} Owned Collections retrieved...");
                }
                while (data.collections.Count != 0)
                {
                    offset += 50;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    data = JsonConvert.DeserializeObject<UserOwnedCollectionResponse>(response.Content!);
                    if (data.collections.Count != 0)
                    {
                        allData.Add(data.collections.First());
                        Font.ClearLine();
                        _font.ToSecondaryInline($"{allData.Count}/{data.totalNum} Owned Collections retrieved...");
                    }
                }
                return allData;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetUserOwnedCollections: {httpException.Message}");
                return null;
            }
        }

        public async Task<List<CollectionMinted>> GetUserMintedCollections(string apiKey, string owner)
        {
            List<CollectionMinted> allData = new();
            var request = new RestRequest("/api/v3/nft/collection");
            int offset = 0;
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("owner", owner);
            request.AddParameter("limit", 12);
            request.AddParameter("offset", offset);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<UserMintedCollectionResponse>(response.Content!);
                if (data.collections.Count != 0)
                {
                    allData.AddRange(data.collections.ToList());
                    _font.ToSecondaryInline($"{allData.Count}/{data.totalNum} Minted Collections retrieved...");
                }
                while (data.collections.Count != 0)
                {
                    offset += 12;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    data = JsonConvert.DeserializeObject<UserMintedCollectionResponse>(response.Content!);
                    if (data.collections.Count != 0)
                    {
                        allData.AddRange(data.collections.ToList());
                        Font.ClearLine();
                        _font.ToSecondaryInline($"{allData.Count}/{data.totalNum} Minted Collections retrieved...");
                    }
                }
                return allData;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetUserMintedCollections: {httpException.Message}");
                return null;
            }
        }
        public async Task<NftResponseFromCollection> GetCollectionNfts(string apiKey, string id)
        {
            var request = new RestRequest("/api/v3/nft/public/collection/items");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("id", id);
            request.AddParameter("metadata", "true");
            request.AddParameter("limit", 50);
            try
            {
                var offset = 50;
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftResponseFromCollection>(response.Content!);
                var total = data.totalNum;
                Font.ClearLine();
                _font.ToSecondaryInline($"{data.nftTokenInfos.Count()}/{data.totalNum} Collections NFTs retrieved...");

                while (total > 50)
                {
                    total -= 50;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<NftResponseFromCollection>(response.Content!);
                    data.nftTokenInfos.AddRange(moreData.nftTokenInfos);
                    Font.ClearLine();
                    _font.ToSecondaryInline($"{data.nftTokenInfos.Count()}/{data.totalNum} Collections NFTs retrieved...");
                    offset += 50;
                }
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetCollectionNfts: {httpException.Message}");
                return null;
            }
        }

        public async Task<ResolveEnsOrNameResponse> GetHexAddress(string apiKey, string ens)
        {
            var request = new RestRequest("api/wallet/v3/resolveEns");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("fullName", ens);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<ResolveEnsOrNameResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetHexAddress: {httpException.Message}");
                return null;
            }
        }

        public async Task<ResolveEnsOrNameResponse> GetLoopringEns(string apiKey, string owner)
        {
            var request = new RestRequest("api/wallet/v3/resolveName");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("owner", owner);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<ResolveEnsOrNameResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetLoopringEns: {httpException.Message}");
                return null;
            }
        }
        public async Task<NftBalance> GetNfts(string apiKey, int accountId, string nftData)
        {
            var counter = 0;
            var request = new RestRequest("/api/v3/user/nft/balances");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("nftDatas", nftData);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftBalance>(response.Content!);
                counter++;
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetNfts: {httpException.Message}");
                return null;
            }
        }
        public async Task<List<Datum>> GetWalletsNfts(string apiKey, int accountId)
        {
            List<Datum> allData = new();
            var request = new RestRequest("/api/v3/user/nft/balances");
            int offset = 0;
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("metadata", "true");
            request.AddParameter("limit", 50);
            request.AddParameter("offset", offset);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftBalance>(response.Content!);
                if (data.data.Count != 0)
                {
                    allData.AddRange(data.data);
                    Font.ClearLine();
                    _font.ToSecondaryInline($"{allData.Count}/{data.totalNum} Wallets Nfts retrieved...");
                }
                while (data.data.Count != 0)
                {
                    offset += 50;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    data = JsonConvert.DeserializeObject<NftBalance>(response.Content!);
                    if (data.data.Count != 0)
                    {
                        allData.AddRange(data.data);
                        Font.ClearLine();
                        _font.ToSecondaryInline($"{allData.Count}/{data.totalNum} Wallets Nfts retrieved...");
                    }
                }
                return allData;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetWalletsNfts: {httpException.Message}");
                return null;
            }
        }
        public async Task<AccountInformationResponse> GetUserAccountInformationFromOwner(string owner)
        {
            var request = new RestRequest("/api/v3/account");
            request.AddParameter("owner", owner);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<AccountInformationResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetUserAccountInformationFromOwner: {httpException.Message}");
                return null;
            }
        }
        public async Task<AccountInformationResponse> GetUserAccountInformationFromId(string accountId)
        {
            var request = new RestRequest("/api/v3/account");
            request.AddParameter("accountId", accountId);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<AccountInformationResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpexception)
            {
                _font.ToRed($"error at GetUserAccountInformationFromId: {httpexception.Message}");
                return null;
            }
        }
        public async Task<string> GetApiKey(int accountId, string xApiSig)
        {
            var request = new RestRequest("api/v3/apiKey");
            request.AddHeader("X-API-SIG", xApiSig);
            request.AddParameter("accountId", accountId);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<ApiKeyResponse>(response.Content!);
                return data.apiKey;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetApiKey: {httpException.Message}");
                return null;
            }
        }
        public async Task<List<Transaction>> GetUserTransactions(string apikey, int accountId, string? startDate, string? endDate)
        {
            var allData = new List<Transaction>();
            var request = new RestRequest("/api/v3/user/transactions");
            request.AddParameter("accountId", accountId);
            request.AddHeader("x-api-key", apikey);
            request.AddParameter("limit", 50);
            request.AddParameter("start", startDate);
            request.AddParameter("end", endDate);
            try
            {
                var offset = 50;
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<UserTransactionResponse>(response.Content!);
                var total = data.totalNum;
                allData.AddRange(data.transactions);
                while (total > 50)
                {
                    total -= 50;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<UserTransactionResponse>(response.Content!);
                    allData.AddRange(moreData.transactions);
                    offset += 50;
                }
                return allData;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetUserTransactions: {httpException.Message}");
                return null;
            }
        }
        public async Task<NftDataResponse> GetNftData(string apiKey, string nftId, string minter, string tokenAddress)
        {
            var request = new RestRequest("/api/v3/nft/info/nftData");
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("nftId", nftId);
            request.AddParameter("minter", minter);
            request.AddParameter("tokenAddress", tokenAddress);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftDataResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                if (httpException.Message == "Request failed with status code BadRequest")
                {
                    //_font.ToRed($"Nft Data not found for {nftId}, {minter}, {tokenAddress}");
                    return null;
                }
                _font.ToRed($"Error at GetNftData: {httpException.Message}");
                return null;
            }
        }
        public async Task<NftHoldersResponse> GetNftHolderSingle(string apiKey, string nftData)
        {
            var request = new RestRequest("/api/v3/nft/info/nftHolders");
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("nftData", nftData);
            request.AddParameter("limit", 1);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftHoldersResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetNftHolderSingle: {httpException.Message}");
                return null;
            }
        }
        public async Task<List<NftHolder>> GetNftHoldersMultiple(string apiKey, string nftData)
        {
            var allData = new List<NftHolder>();
            var request = new RestRequest("/api/v3/nft/info/nftHolders");
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("nftData", nftData);
            request.AddParameter("limit", 50);
            try
            {
                var offset = 50;
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftHoldersResponse>(response.Content!);
                var total = data.totalNum;

                allData.AddRange(data.nftHolders);
                while (total > 50)
                {
                    total -= 50;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<NftHoldersResponse>(response.Content!);
                    allData.AddRange(moreData.nftHolders);
                    offset += 50;
                }
                return allData;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }
        public async Task<List<NftInformationResponse>> GetNftInformationFromNftData(string apiKey, string nftData)
        {
            var request = new RestRequest("/api/v3/nft/info/nfts");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("nftDatas", nftData);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<List<NftInformationResponse>>(response.Content!);
                Thread.Sleep(150);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting transfer off chain fee: {httpException.Message}");
                return null;
            }
        }
        public async Task<NftBalance> FindCollectionIdFromHolder(string apiKey, int accountId, string nftData)
        {
            var request = new RestRequest("/api/v3/user/nft/balances");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("nftDatas", nftData);
            try
            {
                var data = new NftBalance();

                var response = await _client.GetAsync(request);
                data = JsonConvert.DeserializeObject<NftBalance>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
