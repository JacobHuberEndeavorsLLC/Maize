using Maize.Models;
using Maize.Models.Responses;
using Nethereum.Signer.EIP712;
using Nethereum.Signer;
using Nethereum.Util;
using Newtonsoft.Json;
using PoseidonSharp;
using RestSharp;
using System.Numerics;
using Maize.Helpers;
using Newtonsoft.Json.Linq;
using System.Text;

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
        public async Task<string> PostMetadata(string metadataJson, string metadataFileName)
        {
            var request = new RestRequest("/api/v0/add");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("stream-channels", "true", ParameterType.QueryString);
            request.AddParameter("progress", "false", ParameterType.QueryString);

            byte[] metadataBytes = Encoding.UTF8.GetBytes(metadataJson);

            request.AddFile("file", metadataBytes, metadataFileName, "application/json");

            try
            {
                var response = await _client.PostAsync(request);
                return JObject.Parse(response.Content)["Hash"].ToString();
            }
            catch (HttpRequestException httpException)
            {
                return null;
            }
        }
        public async Task<decimal?> GetRecommendedGasPrice()
        {
            var request = new RestRequest("api/v3/eth/recommendedGasPrice");

            try
            {
                var response = await _client.GetAsync(request);

                if (response.IsSuccessful)
                {
                    var responseData = JsonConvert.DeserializeObject<GasPriceResponse>(response.Content);

                    // Convert the string price to a decimal (or another numeric type)
                    if (decimal.TryParse(responseData?.Price, out var gasPrice))
                    {
                        return gasPrice;
                    }
                }
            }
            catch (HttpRequestException httpException)
            {
                // Handle the exception as needed
            }

            return null;
        }
        public async Task<string> PostImage(string filePath)
        {

            string path = Path.GetDirectoryName(filePath);
            string image = Path.GetFileName(filePath);

            Console.WriteLine("Path: " + path);
            Console.WriteLine("Image: " + image);

            var request = new RestRequest("/api/v0/add");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("stream-channels", "true", ParameterType.QueryString);
            request.AddParameter("progress", "false", ParameterType.QueryString);
            byte[] fileBytes = File.ReadAllBytes(Path.Combine(path, image));

            request.AddFile("file", fileBytes, image);

            try
            {
                var response = await _client.PostAsync(request);

                return "";
            }
            catch (HttpRequestException httpException)
            {
                return null;
            }
        }
        public async Task<List<UserAssetsResponse>> GetUserAssetsForFees(string apiKey, int accountId)
        {
            var request = new RestRequest("api/v3/user/balances");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("fullName", accountId);
            request.AddParameter("tokens", "0,2,272");
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<List<UserAssetsResponse>>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetHexAddress: {httpException.Message}");
                return null;
            }
        }
        public async Task<bool> HasCollectionlessNfts(string apiKey, int accountId)
        {
            var request = new RestRequest("api/v3/nft/collection/unknown");
            request.AddHeader("Content-Type", "application/json");
            try
            {
                var response = await _client.PostAsync(request);
                var data = JsonConvert.DeserializeObject<bool>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetHexAddress: {httpException.Message}");
                return false;
            }
        }
        public async Task<RefreshNftResponse> RefreshNft(string nftId, string collectionAddress)
        {
            var payload = new
            {
                network = "ETHEREUM",
                nftId = "0xeb48f809bc2b6ed80fa2e7f471d238153b41f475c214c852d7d24fe165c6de50",
                nftType = "ERC1155",
                tokenAddress = "0x43c2c25c8a06562dcbfea26cecf9a4d0bd3d5179"
            };
            var request = new RestRequest("api/v3/nft/image/refresh");
            request.AddJsonBody(payload);
            request.AddHeader("Content-Type", "application/json");
            try
            {
                var response = await _client.PostAsync(request);
                var data = JsonConvert.DeserializeObject<RefreshNftResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetHexAddress: {httpException.Message}");
                return null;
            }
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
        public async Task<WalletTypeResponse> GetWalletType(string walletAddress)
        {
            var request = new RestRequest("api/wallet/v3/wallet/type");
            //request.AddHeader("x-api-key", apiKey);
            request.AddParameter("wallet", walletAddress);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<WalletTypeResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToRed($"Error at GetHexAddress: {httpException.Message}");
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
                if (httpException.Message == "Request failed with status code BadRequest")
                    return null;
                _font.ToRedInline($"Error at GetUserAccountInformationFromOwner: {httpException.Message}");
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

        public async Task<NftOffChainFeeResponse> GetNftOffChainFee(string apiKey, int accountId, int requestType)
        {
            var request = new RestRequest("api/v3/user/nft/offchainFee");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("requestType", requestType);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftOffChainFeeResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                return null;
            }
        }
        public async Task<List<TokensResponse>> GetTokens()
        {
            var request = new RestRequest("/api/v3/exchange/tokens");
            try
            {
                var data = new List<TokensResponse>();

                var response = await _client.GetAsync(request);
                data = JsonConvert.DeserializeObject<List<TokensResponse>>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                return (null);
            }
        }
        public async Task<TokenPriceResponse> GetTokenPrice()
        {
            var request = new RestRequest("/api/v3/datacenter/getLatestTokenPrices");
            try
            {
                var data = new TokenPriceResponse();

                var response = await _client.GetAsync(request);
                data = JsonConvert.DeserializeObject<TokenPriceResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                return (null);
            }
        }
        public async Task<NftBalance> GetTokenId(string apiKey, int accountId, string nftData)
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
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }
        public async Task<StorageId> GetNextStorageId(string apiKey, int accountId, int sellTokenId)
        {
            var request = new RestRequest("api/v3/storageId");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("sellTokenId", sellTokenId);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<StorageId>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting storage id: {httpException.Message}");
                return null;
            }
        }
        public async Task<OffchainFee> GetOffChainFee(string apiKey, int accountId, int requestType, string amount)
        {
            var request = new RestRequest("api/v3/user/nft/offchainFee");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("requestType", requestType);
            request.AddParameter("amount", amount);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<OffchainFee>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting off chain fee: {httpException.Message}");
                return null;
            }
        }
        public async Task<string> CheckForEthAddress(ILoopringService LoopringService, string apiKey, string address)
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

        public async Task<NftTransferAuditInformation> NftTransfer(
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
            )
        {
            string toAddressInitial;
            var airdropNumberOn = 0;
            var gasFeeTotal = 0m;
            var transactionFeeTotal = 0m;
            string nftAmountInitial = nftAmount;
            int nftTokenIdInitial = nftTokenId;
            int nftSentTotal = 0;
            List<string> invalidAddress = new();
            List<string> validAddress = new();
            List<string> banishAddress = new();
            List<string> invalidNftData = new();
            List<string> alreadyActivatedAddress = new();


            using (StreamReader sr = new($"./{inputPath}/{fileName}"))
            {

                while ((toAddressInitial = sr.ReadLine()) != null)
                {
                    if (nftAmountInitial == null)
                    {
                        var line = String.Concat(toAddressInitial.Where(c => !Char.IsWhiteSpace(c)));
                        string[] walletAddressLineArray = line.Split(',');
                        toAddressInitial = walletAddressLineArray[0].Trim();
                        nftAmount = walletAddressLineArray[1].Trim();
                    }
                    if (nftTokenIdInitial == 0)
                    {
                        var line = String.Concat(toAddressInitial.Where(c => !Char.IsWhiteSpace(c)));
                        string[] walletAddressLineArray = line.Split(',');
                        toAddressInitial = walletAddressLineArray[0].Trim();
                        nftData = walletAddressLineArray[1].Trim();

                        var userNftToken = await loopringService.GetTokenId(loopringApiKey, fromAccountId, nftData);
                        if (userNftToken.totalNum == 0)
                        {
                            //font.ToTertiaryInline($"\rDrop: {++airdropNumberOn}/{howManyLines} Wallet: {toAddressInitial}");
                            invalidNftData.Add(nftData);
                            continue;
                        }
                        nftTokenId = userNftToken.data[0].tokenId;
                    }

                    //font.ToTertiaryInline($"\rDrop: {++airdropNumberOn}/{howManyLines} Wallet: {toAddressInitial}");

                    toAddress = toAddressInitial.ToLower().Trim();
                    var storageId = await loopringService.GetNextStorageId(loopringApiKey, fromAccountId, nftTokenId);
                    var offChainFee = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");

                    toAddress = await loopringService.CheckForEthAddress(loopringService, loopringApiKey, toAddress);

                    if (toAddress == "invalid eth address")
                    {
                        invalidAddress.Add($"{toAddressInitial}");
                        Thread.Sleep(50); //for a rate limiter just incase multiple invalid ens
                        continue;
                    }
                    var checkValidAddress = await loopringService.GetUserAccountInformationFromOwner(toAddress);
                    if (checkValidAddress == null)
                    {
                        invalidAddress.Add($"{toAddressInitial}");
                        continue;
                    }

                    //var contains = await loopringService.CheckBanishTextFile(font, toAddressInitial, toAddress, loopringApiKey);
                    //if (contains == true)
                    //{
                    //    banishAddress.Add(toAddressInitial);
                    //    continue;
                    //}

                    //Calculate eddsa signautre
                    BigInteger[] poseidonInputs =
                    {
                                    ApplicationUtilities.ParseHexUnsigned(environmentExchange),
                                    (BigInteger) fromAccountId,
                                    (BigInteger) toAccountId,
                                    (BigInteger) nftTokenId,
                                    BigInteger.Parse(nftAmount),
                                    (BigInteger) maxFeeTokenId,
                                    BigInteger.Parse(offChainFee.fees[maxFeeTokenId].fee),
                                    ApplicationUtilities.ParseHexUnsigned(toAddress),
                                    (BigInteger) 0,
                                    (BigInteger) 0,
                                    (BigInteger) validUntil,
                                    (BigInteger) storageId.offchainId
                    };
                    Poseidon poseidon = new(13, 6, 53, "poseidon", 5, _securityTarget: 128);
                    BigInteger poseidonHash = poseidon.CalculatePoseidonHash(poseidonInputs);
                    Eddsa eddsa = new(poseidonHash, loopringPrivateKey);
                    string eddsaSignature = eddsa.Sign();

                    //Calculate ecdsa
                    string primaryTypeName = "Transfer";
                    TypedData eip712TypedData = new()
                    {
                        Domain = new Domain()
                        {
                            Name = "Loopring Protocol",
                            Version = "3.6.0",
                            ChainId = environment,
                            VerifyingContract = environmentExchange,
                        },
                        PrimaryType = primaryTypeName,
                        Types = new Dictionary<string, MemberDescription[]>()
                        {
                            ["EIP712Domain"] = new[]
                            {
                                            new MemberDescription {Name = "name", Type = "string"},
                                            new MemberDescription {Name = "version", Type = "string"},
                                            new MemberDescription {Name = "chainId", Type = "uint256"},
                                            new MemberDescription {Name = "verifyingContract", Type = "address"},
                                        },
                            [primaryTypeName] = new[]
                            {
                                            new MemberDescription {Name = "from", Type = "address"},            // payerAddr
                                            new MemberDescription {Name = "to", Type = "address"},              // toAddr
                                            new MemberDescription {Name = "tokenID", Type = "uint16"},          // token.tokenId 
                                            new MemberDescription {Name = "amount", Type = "uint96"},           // token.volume 
                                            new MemberDescription {Name = "feeTokenID", Type = "uint16"},       // maxFee.tokenId
                                            new MemberDescription {Name = "maxFee", Type = "uint96"},           // maxFee.volume
                                            new MemberDescription {Name = "validUntil", Type = "uint32"},       // validUntill
                                            new MemberDescription {Name = "storageID", Type = "uint32"}         // storageId
                                        },

                        },
                        Message = new[]
                    {
                                    new MemberValue {TypeName = "address", Value = fromAddress},
                                    new MemberValue {TypeName = "address", Value = toAddress},
                                    new MemberValue {TypeName = "uint16", Value = nftTokenId},
                                    new MemberValue {TypeName = "uint96", Value = BigInteger.Parse(nftAmount)},
                                    new MemberValue {TypeName = "uint16", Value = maxFeeTokenId},
                                    new MemberValue {TypeName = "uint96", Value = BigInteger.Parse(offChainFee.fees[maxFeeTokenId].fee)},
                                    new MemberValue {TypeName = "uint32", Value = validUntil},
                                    new MemberValue {TypeName = "uint32", Value = storageId.offchainId},
                                }
                    };

                    TransferTypedData typedData = new()
                    {
                        domain = new TransferTypedData.Domain()
                        {
                            name = "Loopring Protocol",
                            version = "3.6.0",
                            chainId = environment,
                            verifyingContract = environmentExchange,
                        },
                        message = new TransferTypedData.Message()
                        {
                            from = fromAddress,
                            to = toAddress,
                            tokenID = nftTokenId,
                            amount = nftAmount,
                            feeTokenID = maxFeeTokenId,
                            maxFee = offChainFee.fees[maxFeeTokenId].fee,
                            validUntil = (int)validUntil,
                            storageID = storageId.offchainId
                        },
                        primaryType = primaryTypeName,
                        types = new TransferTypedData.Types()
                        {
                            EIP712Domain = new List<Type>()
                                        {
                                            new Type(){ name = "name", type = "string"},
                                            new Type(){ name="version", type = "string"},
                                            new Type(){ name="chainId", type = "uint256"},
                                            new Type(){ name="verifyingContract", type = "address"},
                                        },
                            Transfer = new List<Type>()
                                        {
                                            new Type(){ name = "from", type = "address"},
                                            new Type(){ name = "to", type = "address"},
                                            new Type(){ name = "tokenID", type = "uint16"},
                                            new Type(){ name = "amount", type = "uint96"},
                                            new Type(){ name = "feeTokenID", type = "uint16"},
                                            new Type(){ name = "maxFee", type = "uint96"},
                                            new Type(){ name = "validUntil", type = "uint32"},
                                            new Type(){ name = "storageID", type = "uint32"},
                                        }
                        }
                    };

                    Eip712TypedDataSigner signer = new();
                    var ethECKey = new Nethereum.Signer.EthECKey(MMorGMEPrivateKey.Replace("0x", ""));
                    var encodedTypedData = signer.EncodeTypedData(eip712TypedData);
                    var ECDRSASignature = ethECKey.SignAndCalculateV(Sha3Keccack.Current.CalculateHash(encodedTypedData));
                    var serializedECDRSASignature = EthECDSASignature.CreateStringSignature(ECDRSASignature);
                    var ecdsaSignature = serializedECDRSASignature + "0" + (int)2;

                    //Submit nft transfer
                    var nftTransferResponse = await loopringService.SubmitNftTransfer(
                        apiKey: loopringApiKey,
                        exchange: environmentExchange,
                        fromAccountId: fromAccountId,
                        fromAddress: fromAddress,
                        toAccountId: toAccountId,
                        toAddress: toAddress,
                        nftTokenId: nftTokenId,
                        nftAmount: nftAmount,
                        maxFeeTokenId: maxFeeTokenId,
                        maxFeeAmount: offChainFee.fees[maxFeeTokenId].fee,
                        storageId.offchainId,
                        validUntil: validUntil,
                        eddsaSignature: eddsaSignature,
                        ecdsaSignature: ecdsaSignature,
                        nftData: nftData,
                        transferMemo: transferMemo,
                        payPayeeUpdateAccount : false,
                        isCounterFactual : null
                        );
                    if (nftTransferResponse.Contains("processing"))
                    {
                        validAddress.Add(toAddressInitial);
                        gasFeeTotal += decimal.Parse(offChainFee.fees[maxFeeTokenId].fee);
                        transactionFeeTotal += lcrTransactionFee;
                        nftSentTotal += int.Parse(nftAmount);
                    }
                    else
                    {
                        invalidAddress.Add(toAddressInitial + nftTransferResponse);
                    }
                }
            }
            var nftTransferAuditInformation = new NftTransferAuditInformation()
            {
                validAddress = validAddress,
                invalidAddress = invalidAddress,
                banishAddress = banishAddress,
                invalidNftData = invalidNftData,
                alreadyActivatedAddress = alreadyActivatedAddress,
                gasFeeTotal = gasFeeTotal,
                transactionFeeTotal = transactionFeeTotal,
                nftSentTotal = nftSentTotal,
            };
            return nftTransferAuditInformation;
        }
        public async Task<string> SubmitNftTransfer(
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
    )
        {
            var request = new RestRequest("api/v3/nft/transfer");
            request.AddHeader("x-api-key", apiKey);
            request.AddHeader("x-api-sig", ecdsaSignature);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("exchange", exchange);
            request.AddParameter("fromAccountId", fromAccountId);
            request.AddParameter("fromAddress", fromAddress);
            request.AddParameter("toAccountId", toAccountId);
            request.AddParameter("toAddress", toAddress);
            request.AddParameter("token.tokenId", nftTokenId);
            request.AddParameter("token.amount", nftAmount);
            request.AddParameter("token.nftData", nftData);
            request.AddParameter("maxFee.tokenId", maxFeeTokenId);
            request.AddParameter("maxFee.amount", maxFeeAmount);
            request.AddParameter("storageId", storageId);
            request.AddParameter("validUntil", validUntil);
            request.AddParameter("eddsaSignature", eddsaSignature);
            if (isCounterFactual.accountId != 0)
            {
                request.AddParameter("counterFactualInfo.accountId", fromAccountId);
                request.AddParameter("counterFactualInfo.wallet", isCounterFactual.wallet);
                request.AddParameter("counterFactualInfo.walletFactory", isCounterFactual.walletFactory);
                request.AddParameter("counterFactualInfo.walletSalt", isCounterFactual.walletSalt);
                request.AddParameter("counterFactualInfo.walletOwner", isCounterFactual.walletOwner);
            }
            else
            {
                request.AddParameter("ecdsaSignature", ecdsaSignature);
            }
            request.AddParameter("memo", transferMemo);
            if ( payPayeeUpdateAccount == true)
                request.AddParameter("payPayeeUpdateAccount", "true");
            try
            {
                var response = await _client.ExecutePostAsync(request);
                var data = response.Content;
                return data;
            }
            catch (HttpRequestException httpException)
            {
                if (httpException.Message.Contains("can not transfer nft to payee who has not opened an account"))
                {
                    return $"Can not transfer nft to {toAddress} as it does not have an opened account.";
                }
                _font.ToWhite($"Error submitting nft transfer: {httpException.Message}");
                return null;
            }
        }
        public async Task<CryptoTransferAuditInformation> TokenTransfer(
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
            )
        {
            //ILoopringService loopringService = new LoopringService(environmentUrl, _font);
            //string toAddressInitial;
            //var amountToTransferInitial = amountToTransfer;
            //var airdropNumberOn = 0;
            //var gasFeeTotal = 0m;
            //var transactionFeeTotal = 0m;
            //var transferTokenId = 1;
            //var transferTokenSymbol = "LRC";
            //List<string> invalidAddress = new();
            //List<string> validAddress = new();
            //List<string> banishAddress = new();
            //List<string> invalidNftData = new();
            //List<string> alreadyActivatedAddress = new();


            //using (StreamReader sr = new($"./{inputPath}/{fileName}"))
            //{
            //    while ((toAddressInitial = sr.ReadLine()) != null)
            //    {

            //        //font.ToTertiaryInline($"\rDrop: {++airdropNumberOn}/{howManyLines} Wallet: {toAddressInitial}");

            //        if (amountToTransferInitial == 0)
            //        {
            //            var line = String.Concat(toAddressInitial.Where(c => !Char.IsWhiteSpace(c)));
            //            string[] walletAddressLineArray = line.Split(',');
            //            toAddressInitial = walletAddressLineArray[0].Trim();
            //            amountToTransfer = decimal.Parse(walletAddressLineArray[1].Trim());
            //        }

            //        var toAddress = toAddressInitial.ToLower().Trim();

            //        toAddress = await loopringService.CheckForEthAddress(loopringService, loopringApiKey, toAddress);

            //        if (toAddress == "invalid eth address")
            //        {
            //            invalidAddress.Add($"{toAddressInitial}");
            //            Thread.Sleep(50); //for a rate limiter just incase multiple invalid ens
            //            continue;
            //        }
            //        var checkValidAddress = await loopringService.GetUserAccountInformationFromOwner(toAddress);
            //        if (checkValidAddress == null)
            //        {
            //            invalidAddress.Add($"{toAddressInitial}");
            //            continue;
            //        }

            //        //var contains = await loopringService.CheckBanishTextFile(font, toAddressInitial, toAddress, loopringApiKey);
            //        //if (contains == true)
            //        //{
            //        //    banishAddress.Add(toAddressInitial);
            //        //    continue;
            //        //}


            //        var amount = (amountToTransfer * 1000000000000000000m).ToString("0");
            //        var transferFeeAmountResult = await loopringService.GetOffChainTransferFee(loopringApiKey, fromAccountId, 3, transferTokenSymbol, amount); //3 is the request type for crypto transfers
            //        var feeAmount = transferFeeAmountResult.fees.Where(w => w.token == transferTokenSymbol).First().fee;
            //        var transferStorageId = await loopringService.GetNextStorageId(loopringApiKey, fromAccountId, transferTokenId);

            //        TransferRequest req = new()
            //        {
            //            exchange = environmentExchange,
            //            maxFee = new Token()
            //            {
            //                tokenId = transferTokenId,
            //                volume = feeAmount
            //            },
            //            token = new Token()
            //            {
            //                tokenId = transferTokenId,
            //                volume = amount
            //            },
            //            payeeAddr = toAddress,
            //            payerAddr = fromAddress,
            //            payeeId = 0,
            //            payerId = fromAccountId,
            //            storageId = transferStorageId.offchainId,
            //            validUntil = ApplicationUtilitiesUI.GetUnixTimestamp() + (int)TimeSpan.FromDays(365).TotalSeconds,
            //            tokenName = transferTokenSymbol,
            //            tokenFeeName = transferTokenSymbol
            //        };

            //        BigInteger[] eddsaSignatureinputs = {
            //        ApplicationUtilitiesUI.ParseHexUnsigned(req.exchange),
            //        (BigInteger)req.payerId,
            //        (BigInteger)req.payeeId,
            //        (BigInteger)req.token.tokenId,
            //        BigInteger.Parse(req.token.volume),
            //        (BigInteger)req.maxFee.tokenId,
            //        BigInteger.Parse(req.maxFee.volume),
            //        ApplicationUtilitiesUI.ParseHexUnsigned(req.payeeAddr),
            //        0,
            //        0,
            //        (BigInteger)req.validUntil,
            //        (BigInteger)req.storageId
            //        };

            //        Poseidon poseidonTransfer = new(13, 6, 53, "poseidon", 5, _securityTarget: 128);
            //        BigInteger poseidonTransferHash = poseidonTransfer.CalculatePoseidonHash(eddsaSignatureinputs);
            //        Eddsa eddsaTransfer = new(poseidonTransferHash, loopringPrivateKey);
            //        string transferEddsaSignature = eddsaTransfer.Sign();

            //        //Calculate ecdsa
            //        string primaryTypeNameTransfer = "Transfer";
            //        TypedData eip712TypedDataTransfer = new()
            //        {
            //            Domain = new Domain()
            //            {
            //                Name = "Loopring Protocol",
            //                Version = "3.6.0",
            //                ChainId = environment,
            //                VerifyingContract = environmentExchange,
            //            },
            //            PrimaryType = primaryTypeNameTransfer,
            //            Types = new Dictionary<string, MemberDescription[]>()
            //            {
            //                ["EIP712Domain"] = new[]
            //            {
            //                new MemberDescription {Name = "name", Type = "string"},
            //                new MemberDescription {Name = "version", Type = "string"},
            //                new MemberDescription {Name = "chainId", Type = "uint256"},
            //                new MemberDescription {Name = "verifyingContract", Type = "address"},
            //            },
            //                [primaryTypeNameTransfer] = new[]
            //            {
            //                new MemberDescription {Name = "from", Type = "address"},            // payerAddr
            //                new MemberDescription {Name = "to", Type = "address"},              // toAddr
            //                new MemberDescription {Name = "tokenID", Type = "uint16"},          // token.tokenId 
            //                new MemberDescription {Name = "amount", Type = "uint96"},           // token.volume 
            //                new MemberDescription {Name = "feeTokenID", Type = "uint16"},       // maxFee.tokenId
            //                new MemberDescription {Name = "maxFee", Type = "uint96"},           // maxFee.volume
            //                new MemberDescription {Name = "validUntil", Type = "uint32"},       // validUntill
            //                new MemberDescription {Name = "storageID", Type = "uint32"}         // storageId
            //            },

            //            },
            //            Message = new[]
            //        {
            //            new MemberValue {TypeName = "address", Value = fromAddress},
            //            new MemberValue {TypeName = "address", Value = toAddress},
            //            new MemberValue {TypeName = "uint16", Value = req.token.tokenId},
            //            new MemberValue {TypeName = "uint96", Value = BigInteger.Parse(req.token.volume)},
            //            new MemberValue {TypeName = "uint16", Value = req.maxFee.tokenId},
            //            new MemberValue {TypeName = "uint96", Value = BigInteger.Parse(req.maxFee.volume)},
            //            new MemberValue {TypeName = "uint32", Value = req.validUntil},
            //            new MemberValue {TypeName = "uint32", Value = req.storageId},
            //        }
            //        };

            //        TransferTypedData typedDataTransfer = new()
            //        {
            //            domain = new TransferTypedData.Domain()
            //            {
            //                name = "Loopring Protocol",
            //                version = "3.6.0",
            //                chainId = environment,
            //                verifyingContract = environmentExchange,
            //            },
            //            message = new TransferTypedData.Message()
            //            {
            //                from = fromAddress,
            //                to = toAddress,
            //                tokenID = req.token.tokenId,
            //                amount = req.token.volume,
            //                feeTokenID = req.maxFee.tokenId,
            //                maxFee = req.maxFee.volume,
            //                validUntil = (int)req.validUntil,
            //                storageID = req.storageId
            //            },
            //            primaryType = primaryTypeNameTransfer,
            //            types = new TransferTypedData.Types()
            //            {
            //                EIP712Domain = new List<Type>()
            //                {
            //                    new Type(){ name = "name", type = "string"},
            //                    new Type(){ name="version", type = "string"},
            //                    new Type(){ name="chainId", type = "uint256"},
            //                    new Type(){ name="verifyingContract", type = "address"},
            //                },
            //                Transfer = new List<Type>()
            //                {
            //                    new Type(){ name = "from", type = "address"},
            //                    new Type(){ name = "to", type = "address"},
            //                    new Type(){ name = "tokenID", type = "uint16"},
            //                    new Type(){ name = "amount", type = "uint96"},
            //                    new Type(){ name = "feeTokenID", type = "uint16"},
            //                    new Type(){ name = "maxFee", type = "uint96"},
            //                    new Type(){ name = "validUntil", type = "uint32"},
            //                    new Type(){ name = "storageID", type = "uint32"},
            //                }
            //            }
            //        };

            //        Eip712TypedDataSigner signerTransfer = new();
            //        var ethECKeyTransfer = new Nethereum.Signer.EthECKey(MMorGMEPrivateKey.Replace("0x", ""));
            //        var encodedTypedDataTransfer = signerTransfer.EncodeTypedData(eip712TypedDataTransfer);
            //        var ECDRSASignatureTransfer = ethECKeyTransfer.SignAndCalculateV(Sha3Keccack.Current.CalculateHash(encodedTypedDataTransfer));
            //        var serializedECDRSASignatureTransfer = EthECDSASignature.CreateStringSignature(ECDRSASignatureTransfer);
            //        var transferEcdsaSignature = serializedECDRSASignatureTransfer + "0" + (int)2;

            //        var tokenTransferResult = await loopringService.SubmitTokenTransfer(
            //            loopringApiKey,
            //            environmentExchange,
            //            fromAccountId,
            //            fromAddress,
            //            0,
            //            toAddress,
            //            req.token.tokenId,
            //            req.token.volume,
            //            req.maxFee.tokenId,
            //            req.maxFee.volume,
            //            req.storageId,
            //            req.validUntil,
            //            transferEddsaSignature,
            //            transferEcdsaSignature,
            //            transferMemo);
            //        if (tokenTransferResult.Contains("processing"))
            //        {
            //            validAddress.Add(toAddressInitial);
            //            gasFeeTotal += decimal.Parse(req.maxFee.volume);
            //            transactionFeeTotal += lcrTransactionFee;
            //        }
            //        else
            //        {
            //            invalidAddress.Add(toAddressInitial + tokenTransferResult);
            //        }
            //    }
            //}


            var nftTransferAuditInformation = new CryptoTransferAuditInformation();
            return nftTransferAuditInformation;
        }
        public async Task<TransferFeeOffchainFee> GetOffChainTransferFee(string apiKey, int accountId, int requestType, string feeToken, string amount)
        {
            var request = new RestRequest("api/v3/user/offchainFee");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("requestType", requestType);
            request.AddParameter("tokenSymbol", feeToken);
            request.AddParameter("amount", amount);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<TransferFeeOffchainFee>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                return null;
            }
        }
        public async Task<decimal> CobTransferTransactionFee(
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
                )
        {
            ILoopringService loopringService = new LoopringService(environmentUrl);
            var transferMemo = "";
            if (nftOrLrc == 0)
            {
                transferMemo = $"Nfts sent {nftSentTotal}";

            }
            else if (nftOrLrc == 1)
            {
                transferMemo = $"Crypto sent {nftSentTotal} {maxFeeToken}";
            }
            else if (nftOrLrc == 2)
            {
                transferMemo = $"Nfts minted {nftSentTotal}";
            }
            var amount = (transactionFeeTotal * 1000000000000000000m).ToString("0");
            var transferFeeAmountResult = await loopringService.GetOffChainTransferFee(loopringApiKey, fromAccountId, 3, maizeFee, amount); //3 is the request type for crypto transfers
            var feeAmount = transferFeeAmountResult.fees.Where(w => w.token == maxFeeToken).First().fee;
            var transferStorageId = await loopringService.GetNextStorageId(loopringApiKey, fromAccountId, maizeFeeId);

            TransferRequest req = new()
            {
                exchange = environmentExchange,
                maxFee = new Token()
                {
                    tokenId = maxFeeTokenId,
                    volume = feeAmount
                },
                token = new Token()
                {
                    tokenId = maizeFeeId,
                    volume = amount
                },
                payeeAddr = myAddress,
                payerAddr = fromAddress,
                payeeId = 0,
                payerId = fromAccountId,
                storageId = transferStorageId.offchainId,
                validUntil = ApplicationUtilitiesUI.GetUnixTimestamp() + (int)TimeSpan.FromDays(365).TotalSeconds,
                tokenName = maxFeeToken,
                tokenFeeName = maxFeeToken
            };

            BigInteger[] eddsaSignatureinputs = {
                ApplicationUtilitiesUI.ParseHexUnsigned(req.exchange),
                (BigInteger)req.payerId,
                (BigInteger)req.payeeId,
                (BigInteger)req.token.tokenId,
                BigInteger.Parse(req.token.volume),
                (BigInteger)req.maxFee.tokenId,
                BigInteger.Parse(req.maxFee.volume),
                ApplicationUtilitiesUI.ParseHexUnsigned(req.payeeAddr),
                0,
                0,
                (BigInteger)req.validUntil,
                (BigInteger)req.storageId
            };

            Poseidon poseidonTransfer = new(13, 6, 53, "poseidon", 5, _securityTarget: 128);
            BigInteger poseidonTransferHash = poseidonTransfer.CalculatePoseidonHash(eddsaSignatureinputs);
            Eddsa eddsaTransfer = new(poseidonTransferHash, loopringPrivateKey);
            string transferEddsaSignature = eddsaTransfer.Sign();

            //Calculate ecdsa
            string primaryTypeNameTransfer = "Transfer";
            TypedData eip712TypedDataTransfer = new()
            {
                Domain = new Domain()
                {
                    Name = "Loopring Protocol",
                    Version = "3.6.0",
                    ChainId = environment,
                    VerifyingContract = environmentExchange,
                },
                PrimaryType = primaryTypeNameTransfer,
                Types = new Dictionary<string, MemberDescription[]>()
                {
                    ["EIP712Domain"] = new[]
                    {
                                            new MemberDescription {Name = "name", Type = "string"},
                                            new MemberDescription {Name = "version", Type = "string"},
                                            new MemberDescription {Name = "chainId", Type = "uint256"},
                                            new MemberDescription {Name = "verifyingContract", Type = "address"},
                                        },
                    [primaryTypeNameTransfer] = new[]
                    {
                                            new MemberDescription {Name = "from", Type = "address"},            // payerAddr
                                            new MemberDescription {Name = "to", Type = "address"},              // toAddr
                                            new MemberDescription {Name = "tokenID", Type = "uint16"},          // token.tokenId 
                                            new MemberDescription {Name = "amount", Type = "uint96"},           // token.volume 
                                            new MemberDescription {Name = "feeTokenID", Type = "uint16"},       // maxFee.tokenId
                                            new MemberDescription {Name = "maxFee", Type = "uint96"},           // maxFee.volume
                                            new MemberDescription {Name = "validUntil", Type = "uint32"},       // validUntill
                                            new MemberDescription {Name = "storageID", Type = "uint32"}         // storageId
                                        },

                },
                Message = new[]
            {
                                    new MemberValue {TypeName = "address", Value = fromAddress},
                                    new MemberValue {TypeName = "address", Value = myAddress},
                                    new MemberValue {TypeName = "uint16", Value = req.token.tokenId},
                                    new MemberValue {TypeName = "uint96", Value = BigInteger.Parse(req.token.volume)},
                                    new MemberValue {TypeName = "uint16", Value = req.maxFee.tokenId},
                                    new MemberValue {TypeName = "uint96", Value = BigInteger.Parse(req.maxFee.volume)},
                                    new MemberValue {TypeName = "uint32", Value = req.validUntil},
                                    new MemberValue {TypeName = "uint32", Value = req.storageId},
                                }
            };

            TransferTypedData typedDataTransfer = new()
            {
                domain = new TransferTypedData.Domain()
                {
                    name = "Loopring Protocol",
                    version = "3.6.0",
                    chainId = environment,
                    verifyingContract = environmentExchange,
                },
                message = new TransferTypedData.Message()
                {
                    from = fromAddress,
                    to = myAddress,
                    tokenID = req.token.tokenId,
                    amount = req.token.volume,
                    feeTokenID = req.maxFee.tokenId,
                    maxFee = req.maxFee.volume,
                    validUntil = (int)req.validUntil,
                    storageID = req.storageId
                },
                primaryType = primaryTypeNameTransfer,
                types = new TransferTypedData.Types()
                {
                    EIP712Domain = new List<Type>()
                                        {
                                            new Type(){ name = "name", type = "string"},
                                            new Type(){ name="version", type = "string"},
                                            new Type(){ name="chainId", type = "uint256"},
                                            new Type(){ name="verifyingContract", type = "address"},
                                        },
                    Transfer = new List<Type>()
                                        {
                                            new Type(){ name = "from", type = "address"},
                                            new Type(){ name = "to", type = "address"},
                                            new Type(){ name = "tokenID", type = "uint16"},
                                            new Type(){ name = "amount", type = "uint96"},
                                            new Type(){ name = "feeTokenID", type = "uint16"},
                                            new Type(){ name = "maxFee", type = "uint96"},
                                            new Type(){ name = "validUntil", type = "uint32"},
                                            new Type(){ name = "storageID", type = "uint32"},
                                        }
                }
            };

            Eip712TypedDataSigner signerTransfer = new();
            EthECKey ethECKeyTransfer = new(null);
            if (MMorGMEPrivateKey == "")
                ethECKeyTransfer = new Nethereum.Signer.EthECKey(loopringPrivateKey.Replace("0x", ""));
            else
                ethECKeyTransfer = new Nethereum.Signer.EthECKey(MMorGMEPrivateKey.Replace("0x", ""));

            var encodedTypedDataTransfer = signerTransfer.EncodeTypedData(eip712TypedDataTransfer);
            var ECDRSASignatureTransfer = ethECKeyTransfer.SignAndCalculateV(Sha3Keccack.Current.CalculateHash(encodedTypedDataTransfer));
            var serializedECDRSASignatureTransfer = EthECDSASignature.CreateStringSignature(ECDRSASignatureTransfer);
            var transferEcdsaSignature = serializedECDRSASignatureTransfer + "0" + (int)2;

            var tokenTransferResult = await loopringService.SubmitTokenTransfer(
                loopringApiKey,
                environmentExchange,
                fromAccountId,
                fromAddress,
                0,
                myAddress,
                req.token.tokenId,
                req.token.volume,
                req.maxFee.tokenId,
                req.maxFee.volume,
                req.storageId,
                req.validUntil,
                transferEddsaSignature,
                transferEcdsaSignature,
                transferMemo,
                false,
                isCounterFactual);
            return decimal.Parse(req.maxFee.volume);
        }
        public async Task<string> SubmitTokenTransfer(
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
          )
        {
            var request = new RestRequest("api/v3/transfer");
            request.AddHeader("x-api-key", apiKey);
            request.AddHeader("x-api-sig", ecdsaSignature);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("exchange", exchange);
            request.AddParameter("payerId", fromAccountId);
            request.AddParameter("payerAddr", fromAddress);
            request.AddParameter("payeeId", toAccountId);
            request.AddParameter("payeeAddr", toAddress);
            request.AddParameter("token.tokenId", tokenId);
            request.AddParameter("token.volume", tokenAmount);
            request.AddParameter("maxFee.tokenId", maxFeeTokenId);
            request.AddParameter("maxFee.volume", maxFeeAmount);
            request.AddParameter("storageId", storageId);
            request.AddParameter("validUntil", validUntil);
            request.AddParameter("eddsaSignature", eddsaSignature);
            if (isCounterFactual.accountId != 0)
            {
                request.AddParameter("counterFactualInfo.accountId", fromAccountId);
                request.AddParameter("counterFactualInfo.wallet", isCounterFactual.wallet);
                request.AddParameter("counterFactualInfo.walletFactory", isCounterFactual.walletFactory);
                request.AddParameter("counterFactualInfo.walletSalt", isCounterFactual.walletSalt);
                request.AddParameter("counterFactualInfo.walletOwner", isCounterFactual.walletOwner);
            }
            else
            {
                request.AddParameter("ecdsaSignature", ecdsaSignature);
            }
            request.AddParameter("memo", memo);
            if (payPayeeUpdateAccount == true)
                request.AddParameter("payPayeeUpdateAccount", "true");
            try
            {
                var response = await _client.ExecutePostAsync(request);
                var data = response.Content;
                return data;
            }
            catch (HttpRequestException httpException)
            {
                return null;
            }
        }
        public async Task<CounterFactualInfo> GetCounterFactualInfo(int accountId)
        {
            var request = new RestRequest("api/v3/counterFactualInfo");
            request.AddParameter("accountId", accountId);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<CounterFactualInfo>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                return null;
            }
        }
    }
}
