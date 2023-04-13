using Maize;
using Maize.Helpers;
using Maize.Models;
using Nethereum.Signer.EIP712;
using Nethereum.Signer;
using Nethereum.Util;
using Newtonsoft.Json;
using PoseidonSharp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;

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

        public async Task<CoinBalance> GetUserEthBalance(string apiKey, int accountId)
        {
            var request = new RestRequest("api/v3/user/balances");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("tokens", 1);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<CoinBalance>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting storage id: {httpException.Message}");
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
        public async Task<UserCollections> GetNftCollection(string apiKey, string owner)
        {
            var request = new RestRequest("/api/v3/nft/collection");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("owner", owner);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<UserCollections>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting off chain fee: {httpException.Message}");
                return null;
            }
        }
        public async Task<UserOwnedCollections> GetUserNftCollection(string apiKey, int accountId)
        {
            var request = new RestRequest("/api/v3/user/collection/details");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<UserOwnedCollections>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting off chain fee: {httpException.Message}");
                return null;
            }
        }
        public async Task<List<BlockInformation>> GetBlocks()
        {
            var allBlockInformation = new List<BlockInformation>();
            var counter = 0;
            var request = new RestRequest("/api/v3/block/getBlock");
            try
            {
                request.AddOrUpdateParameter("id", ++counter);
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<BlockInformation>(response.Content!);
                allBlockInformation.Add(data);
                return allBlockInformation;
            }
            catch (HttpRequestException httpException)
            {
                if (httpException.Message == "Request failed with status code BadRequest")
                {
                    return allBlockInformation;
                }
                _font.ToWhite($"Error getting block: {httpException.Message}");
                return null;
            }
        }
        public async Task<Collection> GetNftCollectionPublic(string apiKey, string nftHash)
        {
            var request = new RestRequest("/api/v3/nft/public/collection");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("nftHash", nftHash);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<Collection>(response.Content!);
                var total = data;
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting collection: {httpException.Message}");
                return null;
            }
        }

        public async Task<List<UserCollections>> GetNftCollectionsOfOwnAccount(string apiKey, string owner)
        {
            List<UserCollections> collections = new List<UserCollections>();
            var request = new RestRequest("/api/v3/nft/collection");
            int offset = 0;
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("owner", owner);
            request.AddParameter("limit", 12);
            request.AddParameter("offset", offset);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<UserCollections>(response.Content!);
                if (data.collections.Count != 0)
                {
                    collections.Add(data);
                }
                while (data.collections.Count != 0)
                {
                    offset += 12;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    data = JsonConvert.DeserializeObject<UserCollections>(response.Content!);
                    if (data.collections.Count != 0)
                    {
                        collections.Add(data);
                    }
                }
                return collections;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting collection: {httpException.Message}");
                return null;
            }
        }
        public async Task<CollectionInformation> GetNftCollectionInformation(string apiKey, string id)
        {
            var request = new RestRequest("/api/v3/nft/public/collection/items");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("id", id);
            request.AddParameter("limit", 50);
            try
            {
                var offset = 50;
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<CollectionInformation>(response.Content!);
                var total = data.totalNum;


                while (total > 50)
                {
                    total -= 50;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<CollectionInformation>(response.Content!);
                    data.nftTokenInfos.AddRange(moreData.nftTokenInfos);
                    offset += 50;
                }
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting collection: {httpException.Message}");
                return null;
            }
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
                 string transferMemo
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
            request.AddParameter("ecdsaSignature", ecdsaSignature);
            request.AddParameter("memo", transferMemo);
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
               string memo
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
            request.AddParameter("ecdsaSignature", ecdsaSignature);
            request.AddParameter("memo", memo);
            try
            {
                var response = await _client.ExecutePostAsync(request);
                var data = response.Content;
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error submitting token transfer: {httpException.Message}");
                return null;
            }
        }
        public async Task<string> SubmitPayPayeeUpdateAccountFee(
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
            request.AddParameter("ecdsaSignature", ecdsaSignature);
            request.AddParameter("memo", memo);
            request.AddParameter("payPayeeUpdateAccount", payPayeeUpdateAccount);
            try
            {
                var response = await _client.ExecutePostAsync(request);
                var data = response.Content;
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error submitting token transfer: {httpException.Message}");
                return null;
            }
        }

        public async Task<EnsResult> GetHexAddress(string apiKey, string ens)
        {
            var request = new RestRequest("api/wallet/v3/resolveEns");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("fullName", ens);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<EnsResult>(response.Content!);
                Thread.Sleep(100);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting ens: {httpException.Message}");
                return null;
            }
        }


        public async Task<ResolveEns> GetLoopringEns(string apiKey, string owner)
        {
            Thread.Sleep(500);
            var request = new RestRequest("api/wallet/v3/resolveName");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("owner", owner);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<ResolveEns>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting ens: {httpException.Message}");
                return null;
            }
        }
        public async Task<string> CheckForEthAddress(string apiKey, string address)
        {
            address = address.Trim().ToLower();
            if (address.Contains(".eth"))
            {
                var varHexAddress = await GetHexAddress(apiKey, address);
                if (!String.IsNullOrEmpty(varHexAddress.data))
                {
                    address = varHexAddress.data;
                    return address;
                }
                else
                {
                    return "invalid eth address";
                }
            }
            return address;
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

        public async Task<NftBalance> GetTokenIdWithCheck(string apiKey, int accountId, string nftData)
        {
            var counter = 0;
            var request = new RestRequest("/api/v3/user/nft/balances");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("nftDatas", nftData);
            try
            {
                var data = new NftBalance();
                do
                {
                    if (counter != 0)
                    {
                        _font.ToYellow("This is not an NftData or this Nft isn't in your wallet. Please enter a correct one.");
                        nftData = Console.ReadLine();
                        request.AddOrUpdateParameter("nftDatas", nftData);
                    }
                    var response = await _client.GetAsync(request);
                    data = JsonConvert.DeserializeObject<NftBalance>(response.Content!);
                    counter++;
                } while (data.data.Count == 0);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }
        public async Task<NftBalance> FindCollectionIdFromHolder(string apiKey, int accountId, string nftData)
        {
            var request = new RestRequest("/api/v3/user/nft/balances");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("nftDatas", nftData);
            request.AddParameter("metadata", "true");
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
                    Console.Write($"{allData.Count}/{data.totalNum} retrieved...");
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
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write($"{allData.Count}/{data.totalNum} retrieved...");
                    }
                }
                Console.SetCursorPosition(0, Console.CursorTop);
                return allData;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }

        public async Task<NftData> GetNftData(string apiKey, string nftId, string minter, string tokenAddress)
        {
            var request = new RestRequest("/api/v3/nft/info/nftData");
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("nftId", nftId);
            request.AddParameter("minter", minter);
            request.AddParameter("tokenAddress", tokenAddress);
            try
            {
                    var response = await _client.GetAsync(request);
                    var data = JsonConvert.DeserializeObject<NftData>(response.Content!);
                Thread.Sleep(75);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                if (httpException.Message == "Request failed with status code BadRequest")
                {
                    _font.ToRed($"Nft Data not found for {nftId}, {minter}, {tokenAddress}");
                    return null;
                }
                _font.ToWhite($"Error getting NftData: {httpException.Message}");
                return null;
            }
        }

        public async Task<List<NftHolder>> GetNftHoldersMultiple(string apiKey, string nftData)
        {
            var allData = new List<NftHolder>();
            var request = new RestRequest("/api/v3/nft/info/nftHolders");
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("nftData", nftData);
            request.AddParameter("limit", 100);
            try
            {
                var offset = 100;
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftHoldersAndTotal>(response.Content!);
                var total = data.totalNum;

                allData.AddRange(data.nftHolders);
                while (total > 100)
                {
                    total -= 100;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<NftHoldersAndTotal>(response.Content!);
                    allData.AddRange(moreData.nftHolders);
                    offset += 100;
                }
                Thread.Sleep(75);
                return allData;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }
        public async Task<List<NftHolderAndNftData>> GetNftHolderIncludeNftData(Font font, ILoopringService loopringService, INftMetadataService nftMetadataService,
            IEthereumService ethereumService, string apiKey, string nftData, string environmentalUrl, int counter, int max)
        {
            var holderCounter = 0;
            var allData = new List<NftHolder>();
            var allDataAndHolders = new List<NftHolderAndNftData>();
            var request = new RestRequest("/api/v3/nft/info/nftHolders");

            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("nftData", nftData);
            request.AddParameter("limit", 100);
            try
            {
                var offset = 100;
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftHoldersAndTotal>(response.Content!);
                var total = data.totalNum;
                allData.AddRange(data.nftHolders);
                while (total > 100)
                {
                    total -= 100;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<NftHoldersAndTotal>(response.Content!);
                    allData.AddRange(moreData.nftHolders);
                    offset += 100;
                }
                var nftInformation = await loopringService.GetNftInformationFromNftData(apiKey, nftData);
                var nftMetadata = await Utils.GetNftMetadata(font, ethereumService, nftMetadataService, nftInformation.FirstOrDefault().nftId, nftInformation.FirstOrDefault().tokenAddress);
                foreach (var item in allData)
                {
                    Utils.ClearLine();
                    font.ToTertiaryInline($"\rNft: {counter}/{max} {nftMetadata.name} Nft Holder: {++holderCounter}/{allData.Count}");
                    var walletAddress = await loopringService.GetUserAccountInformation(item.accountId.ToString());
                    allDataAndHolders.Add(new NftHolderAndNftData
                    {
                        accountId = item.accountId,
                        walletAddress = walletAddress.owner,
                        nftName = nftMetadata.name,
                        tokenId = item.tokenId,
                        amount = item.amount,
                        nftData= nftData
    });             }
                return allDataAndHolders;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }
        public async Task<List<NftHoldersAndTotal>> GetNftHoldersMultipleAndTotal(string apiKey, string nftData)
        {
            var allData = new List<NftHoldersAndTotal>();
            var request = new RestRequest("/api/v3/nft/info/nftHolders");
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("nftData", nftData);
            request.AddParameter("limit", 100);
            try
            {
                var offset = 100;
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftHoldersAndTotal>(response.Content!);
                var total = data.totalNum;
                allData.Add(data);
                while (total > 100)
                {
                    total -= 100;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<NftHoldersAndTotal>(response.Content!);
                    allData.Add(moreData);
                    offset += 100;
                }
                return allData;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }
        public async Task<NftHoldersAndTotal> GetNftHolderSingle(string apiKey, string nftData)
        {
            var request = new RestRequest("/api/v3/nft/info/nftHolders");
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("nftData", nftData);
            request.AddParameter("limit", 1);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftHoldersAndTotal>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }

        public async Task<AccountInformation> GetUserAccountInformation(string accountId)
        {
            var request = new RestRequest("/api/v3/account");
            request.AddParameter("accountId", accountId);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<AccountInformation>(response.Content!);
                Thread.Sleep(75);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }

        public async Task<AccountInformation> GetUserAccountInformationFromOwner(string owner)
        {
            var request = new RestRequest("/api/v3/account");
            request.AddParameter("owner", owner);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<AccountInformation>(response.Content!);
                Thread.Sleep(75);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                if (httpException.Message == "Request failed with status code BadRequest")
                {
                    return null;
                }
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }

        public async Task<AccountInformation> CheckUserAccountInformationFromOwner(string owner)
        {
            var request = new RestRequest("/api/v3/account");
            request.AddParameter("owner", owner);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<AccountInformation>(response.Content!);
                Thread.Sleep(75);
                return data;
            }
            catch (HttpRequestException)
            {
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
                var data = JsonConvert.DeserializeObject<ApiKey>(response.Content!);
                return data.apiKey;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }

        public async Task<List<NftData>> GetUserMintedNfts(Font font, string apiKey, int accountId)
        {
            _font.ToPrimary("This may take a while depending on the minter and collection.");
            var allDataMintsAndTotal = new List<MintsAndTotal>();
            var allDataMints = new List<Mint>();
            var allDataMintsAndTotalInCollection = new List<NftData>();
            var request = new RestRequest("/api/v3/user/nft/mints");
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("limit", 50);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<MintsAndTotal>(response.Content!);
                var total = data.totalNum;
                allDataMintsAndTotal.Add(data);
                allDataMints.AddRange(data.mints);
                Utils.ClearLine();
                font.ToTertiaryInline($"\rGrabbing all mints");
                while (total >= 50)
                {
                    total -= 50;
                    var createdAt = allDataMintsAndTotal.LastOrDefault().mints.LastOrDefault().createdAt;
                    request.AddOrUpdateParameter("end", createdAt);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<MintsAndTotal>(response.Content!);
                    allDataMintsAndTotal.Add(moreData);
                    allDataMints.AddRange(moreData.mints);
                }
                var counter = 0;
                foreach (var mint in allDataMints)
                {
                    allDataMintsAndTotalInCollection.AddRange(await GetNftInformationFromNftData(apiKey, mint.nftData));
                    font.ToTertiaryInline($"\rGrabbing Nft: {++counter}/{allDataMints.Count}");
                }
                //allDataMintsAndTotalInCollection = allDataMintsAndTotalInCollection.Where(x => x.tokenAddress.ToLower() == collectionId.ToLower()).ToList();

                return allDataMintsAndTotalInCollection;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
        }

        public async Task<List<NftData>> GetUserMintedNftsWithCollection(Font font, string apiKey, int accountId, string collectionId)
        {
            var allDataMintsAndTotal = new List<MintsAndTotal>();
            var allDataMints = new List<Mint>();
            var allDataMintsAndTotalInCollection = new List<NftData>();
            var request = new RestRequest("/api/v3/user/nft/mints");
            request.AddHeader("X-API-KEY", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("limit", 50);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<MintsAndTotal>(response.Content!);
                var total = data.totalNum;
                allDataMintsAndTotal.Add(data);
                allDataMints.AddRange(data.mints);
                Utils.ClearLine();
                font.ToTertiaryInline($"\rGrabbing all mints");
                while (total >= 50)
                {
                    total -= 50;
                    var createdAt = allDataMintsAndTotal.LastOrDefault().mints.LastOrDefault().createdAt;
                    request.AddOrUpdateParameter("end", createdAt);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<MintsAndTotal>(response.Content!);
                    allDataMintsAndTotal.Add(moreData);
                    allDataMints.AddRange(moreData.mints);
                }
                var counter = 0;
                foreach (var mint in allDataMints)
                {
                    allDataMintsAndTotalInCollection.AddRange(await GetNftInformationFromNftData(apiKey, mint.nftData));
                    font.ToTertiaryInline($"\rChecking Nft: {++counter}/{allDataMints.Count}");
                }
                allDataMintsAndTotalInCollection = allDataMintsAndTotalInCollection.Where(x => x.tokenAddress.ToLower() == collectionId.ToLower()).ToList();

                return allDataMintsAndTotalInCollection;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
                return null;
            }
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
                _font.ToWhite($"Error getting transfer off chain fee: {httpException.Message}");
                return null;
            }
        }
        public async Task<TransferFeeOffchainFee> GetOffChainTransferFeeForTransferAndUpdateAccount(string apiKey, int accountId, int requestType)
        {
            var request = new RestRequest("api/v3/user/offchainFee");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("accountId", accountId);
            request.AddParameter("requestType", requestType);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<TransferFeeOffchainFee>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting transfer off chain fee: {httpException.Message}");
                return null;
            }
        }

        public async Task<List<NftData>> GetNftInformationFromNftData(string apiKey, string nftData)
        {
            var request = new RestRequest("/api/v3/nft/info/nfts");
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("nftDatas", nftData);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<List<NftData>>(response.Content!);
                Thread.Sleep(150);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting transfer off chain fee: {httpException.Message}");
                return null;
            }
        }
        public async Task<Prices> GetTokenFiatPrices(string legal)
        {
            var request = new RestRequest("/api/v3/price");
            request.AddParameter("legal", legal);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<Prices>(response.Content!);
                Thread.Sleep(75);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting transfer off chain fee: {httpException.Message}");
                return null;
            }
        }

        public async Task<bool> CheckBanishTextFile(Font font, string toAddressInitial, string toAddress, string loopringApiKey)
        {
            List<string> banishAddresses = new();
            bool banned;
            string banishAddress;
            using (StreamReader sr = new("./Input/Banish.txt"))
            {
                while ((banishAddress = sr.ReadLine()) != null)
                {
                    if (banishAddress.Contains(".eth"))
                    {
                        Thread.Sleep(75);
                        var varHexAddress = await GetHexAddress(loopringApiKey, banishAddress);
                        if (!String.IsNullOrEmpty(varHexAddress.data))
                        {
                            banishAddress = varHexAddress.data.ToLower().Trim();
                        }
                        else
                        {
                            //invalidAddress.Add(toAddressInitial);
                            font.ToTertiary($"Invalid address: {banishAddress}. Could not find an associated wallet.");
                            //continue;
                        }
                    }
                    banishAddresses.Add(banishAddress.ToLower().Trim());
                }
            }
            if (banishAddresses.Contains(toAddress) || banishAddresses.Contains(toAddressInitial.Trim().ToLower()))
            {
                banned = true;
            }
            else
            {
                banned = false;
            }
            return banned;
        }

        public async Task<bool> CheckBanishFile(Font font, string loopringApiKey, string toAddress)
        {
            List<string> banishAddresses = new();
            bool banned;

            using (StreamReader sr = new("./Input/Banish.txt"))
            {
                string banishAddress;
                while ((banishAddress = sr.ReadLine()) != null)
                {
                    if (banishAddress.Contains(".eth"))
                    {
                        Thread.Sleep(75);
                        var varHexAddress = await GetHexAddress(loopringApiKey, banishAddress);
                        if (!String.IsNullOrEmpty(varHexAddress.data))
                        {
                            banishAddress = varHexAddress.data.ToLower().Trim();
                        }
                        else
                        {
                            //invalidAddress.Add(toAddressInitial);
                            font.ToTertiary($"Invalid address: {banishAddress}. Could not find an associated wallet.");
                            //continue;
                        }
                    }
                    banishAddresses.Add(banishAddress.ToLower().Trim());
                }
            }
            if (banishAddresses.Contains(toAddress))
            {
                banned = true;
            }
            else
            {
                banned = false;
            }
            return banned;
        }

        public async Task<List<Transfer>> GetUserNftTransfer(string apikey, int accountId)
        {
            var transfers = new List<Transfer>();
            var request = new RestRequest("/api/v3/user/nft/transfers");
            request.AddParameter("accountId", accountId);
            request.AddHeader("x-api-key", apikey);
            request.AddParameter("limit", 50);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<Root>(response.Content!);
                var total = data.totalNum;
                transfers.AddRange(data.transfers);
                while (total > 50)
                {
                    total -= 50;
                    var createdAt = transfers.LastOrDefault().createdAt.ToString();
                    request.AddOrUpdateParameter("end", createdAt);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<Root>(response.Content!);
                    transfers.AddRange(moreData.transfers);
                }
                return transfers;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting TokenId: {httpException.Message}");
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
                var data = JsonConvert.DeserializeObject<UserTransactions>(response.Content!);
                var total = data.totalNum;
                allData.AddRange(data.transactions);
                while (total > 50)
                {
                    total -= 50;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    var moreData = JsonConvert.DeserializeObject<UserTransactions>(response.Content!);
                    allData.AddRange(moreData.transactions);
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

        public async Task<string> CobTransferTransactionFee(
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
            int nftOrLrc
            )
        {
            ILoopringService loopringService = new LoopringService(environmentUrl, _font);
            var transferMemo = "";
            if (nftOrLrc == 0)
            {
                transferMemo = $"Nfts sent {nftSentTotal}";

            }
            else if (nftOrLrc == 1)
            {
                transferMemo = $"Crypto sent {nftSentTotal}";
            }
            else if (nftOrLrc == 2)
            {
                transferMemo = $"Nfts minted {nftSentTotal}";
            }
            var amount = (transactionFeeTotal * 1000000000000000000m).ToString("0");
            var transferFeeAmountResult = await loopringService.GetOffChainTransferFee(loopringApiKey, fromAccountId, 3, maxFeeToken, amount); //3 is the request type for crypto transfers
            var feeAmount = transferFeeAmountResult.fees.Where(w => w.token == maxFeeToken).First().fee;
            var transferStorageId = await loopringService.GetNextStorageId(loopringApiKey, fromAccountId, maxFeeTokenId);

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
                    tokenId = maxFeeTokenId,
                    volume = amount
                },
                payeeAddr = myAddress,
                payerAddr = fromAddress,
                payeeId = 0,
                payerId = fromAccountId,
                storageId = transferStorageId.offchainId,
                validUntil = Utils.GetUnixTimestamp() + (int)TimeSpan.FromDays(365).TotalSeconds,
                tokenName = maxFeeToken,
                tokenFeeName = maxFeeToken
            };

            BigInteger[] eddsaSignatureinputs = {
                Utils.ParseHexUnsigned(req.exchange),
                (BigInteger)req.payerId,
                (BigInteger)req.payeeId,
                (BigInteger)req.token.tokenId,
                BigInteger.Parse(req.token.volume),
                (BigInteger)req.maxFee.tokenId,
                BigInteger.Parse(req.maxFee.volume),
                Utils.ParseHexUnsigned(req.payeeAddr),
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
            var ethECKeyTransfer = new Nethereum.Signer.EthECKey(MMorGMEPrivateKey.Replace("0x", ""));
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
                transferMemo);
            return "done";
        }

        public async Task<NftTransferAuditInformation> NftTransfer(
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
                            font.ToTertiaryInline($"\rDrop: {++airdropNumberOn}/{howManyLines} Wallet: {toAddressInitial}");
                            invalidNftData.Add(nftData);
                            continue;
                        }
                        nftTokenId = userNftToken.data[0].tokenId;
                    }

                    font.ToTertiaryInline($"\rDrop: {++airdropNumberOn}/{howManyLines} Wallet: {toAddressInitial}");

                    var toAddress = toAddressInitial.ToLower().Trim();
                    var storageId = await loopringService.GetNextStorageId(loopringApiKey, fromAccountId, nftTokenId);
                    var offChainFee = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");

                    toAddress = await loopringService.CheckForEthAddress(loopringApiKey, toAddress);

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

                    var contains = await loopringService.CheckBanishTextFile(font, toAddressInitial, toAddress, loopringApiKey);
                    if (contains == true)
                    {
                        banishAddress.Add(toAddressInitial);
                        continue;
                    }

                    //Calculate eddsa signautre
                    BigInteger[] poseidonInputs =
                    {
                                    Utils.ParseHexUnsigned(environmentExchange),
                                    (BigInteger) fromAccountId,
                                    (BigInteger) toAccountId,
                                    (BigInteger) nftTokenId,
                                    BigInteger.Parse(nftAmount),
                                    (BigInteger) maxFeeTokenId,
                                    BigInteger.Parse(offChainFee.fees[maxFeeTokenId].fee),
                                    Utils.ParseHexUnsigned(toAddress),
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
                        transferMemo: transferMemo
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
            var nftTransferAuditInformation = new NftTransferAuditInformation() {
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

        public async Task<NftTransferAuditInformation> NftTransferDead(
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
            )
        {
            ILoopringService loopringService = new LoopringService(environmentUrl, _font);
            var airdropNumberOn = 0;
            var gasFeeTotal = 0m;
            var transactionFeeTotal = 0m;
            int nftSentTotal = 0;
            string nftAmountInitial = nftAmount;
            int nftTokenIdInitial = nftTokenId;
            List<string> invalidAddress = new();
            List<string> validAddress = new();
            List<string> banishAddress = new();
            List<string> invalidNftData = new();
            List<string> alreadyActivatedAddress = new();


            foreach (var banishedNft in banishedNfts)
            {
                nftTokenId = banishedNft.tokenId;
                nftAmount = walletsNfts.Where(x => x.nftData == banishedNft.nftData).First().total;

                var storageId = await loopringService.GetNextStorageId(loopringApiKey, fromAccountId, nftTokenId);
                var offChainFee = await loopringService.GetOffChainFee(loopringApiKey, fromAccountId, 11, "0");
                var nftMetadataLink = await ethereumService.GetMetadataLink(banishedNft.nftId, banishedNft.tokenAddress, 0);
                var nftMetadata = await nftMetadataService.GetMetadata(nftMetadataLink);
                font.ToTertiaryInline($"\rDrop: {++airdropNumberOn}/{howManyLines} Nft: {nftMetadata.name}");

                var toAddress = "0xdEAD000000000000000042069420694206942069";

                var checkValidAddress = await loopringService.GetUserAccountInformationFromOwner(toAddress);
                if (checkValidAddress == null)
                {
                    invalidAddress.Add($"{toAddress}");
                    continue;
                }

                //Calculate eddsa signautre
                BigInteger[] poseidonInputs =
                {
                    Utils.ParseHexUnsigned(environmentExchange),
                    (BigInteger) fromAccountId,
                    (BigInteger) toAccountId,
                    (BigInteger) nftTokenId,
                    BigInteger.Parse(nftAmount),
                    (BigInteger) maxFeeTokenId,
                    BigInteger.Parse(offChainFee.fees[maxFeeTokenId].fee),
                    Utils.ParseHexUnsigned(toAddress),
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
                var ethECKey = new EthECKey(MMorGMEPrivateKey.Replace("0x", ""));
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
                    nftData: banishedNft.nftData,
                    transferMemo: transferMemo
                    );
                if (nftTransferResponse.Contains("processing"))
                {
                    validAddress.Add(nftMetadata.name);
                    gasFeeTotal += decimal.Parse(offChainFee.fees[maxFeeTokenId].fee);
                    transactionFeeTotal += lcrTransactionFee;
                    nftSentTotal += int.Parse(nftAmount);
                }
                else
                {
                    invalidAddress.Add(nftMetadata.name + nftTransferResponse); 
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
        public async Task<NftTransferAuditInformation> LrcTransfer(
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
            )
        {
            ILoopringService loopringService = new LoopringService(environmentUrl, _font);
            string toAddressInitial;
            var amountToTransferInitial = amountToTransfer;
            var airdropNumberOn = 0;
            var gasFeeTotal = 0m;
            var transactionFeeTotal = 0m;
            var transferTokenId = 1;
            var transferTokenSymbol = "LRC";
            List<string> invalidAddress = new();
            List<string> validAddress = new();
            List<string> banishAddress = new();
            List<string> invalidNftData = new();
            List<string> alreadyActivatedAddress = new();


            using (StreamReader sr = new($"./{inputPath}/{fileName}"))
            {
                while ((toAddressInitial = sr.ReadLine()) != null)
                {

                    font.ToTertiaryInline($"\rDrop: {++airdropNumberOn}/{howManyLines} Wallet: {toAddressInitial}");

                    if (amountToTransferInitial == 0)
                    {
                        var line = String.Concat(toAddressInitial.Where(c => !Char.IsWhiteSpace(c)));
                        string[] walletAddressLineArray = line.Split(',');
                        toAddressInitial = walletAddressLineArray[0].Trim();
                        amountToTransfer = decimal.Parse(walletAddressLineArray[1].Trim());
                    }

                    var toAddress = toAddressInitial.ToLower().Trim();

                    toAddress = await loopringService.CheckForEthAddress(loopringApiKey, toAddress);

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

                    var contains = await loopringService.CheckBanishTextFile(font, toAddressInitial, toAddress, loopringApiKey);
                    if (contains == true)
                    {
                        banishAddress.Add(toAddressInitial);
                        continue;
                    }


                    var amount = (amountToTransfer * 1000000000000000000m).ToString("0");
                    var transferFeeAmountResult = await loopringService.GetOffChainTransferFee(loopringApiKey, fromAccountId, 3, transferTokenSymbol, amount); //3 is the request type for crypto transfers
                    var feeAmount = transferFeeAmountResult.fees.Where(w => w.token == transferTokenSymbol).First().fee;
                    var transferStorageId = await loopringService.GetNextStorageId(loopringApiKey, fromAccountId, transferTokenId);

                    TransferRequest req = new()
                    {
                        exchange = environmentExchange,
                        maxFee = new Token()
                        {
                            tokenId = transferTokenId,
                            volume = feeAmount
                        },
                        token = new Token()
                        {
                            tokenId = transferTokenId,
                            volume = amount
                        },
                        payeeAddr = toAddress,
                        payerAddr = fromAddress,
                        payeeId = 0,
                        payerId = fromAccountId,
                        storageId = transferStorageId.offchainId,
                        validUntil = Utils.GetUnixTimestamp() + (int)TimeSpan.FromDays(365).TotalSeconds,
                        tokenName = transferTokenSymbol,
                        tokenFeeName = transferTokenSymbol
                    };

                    BigInteger[] eddsaSignatureinputs = {
                    Utils.ParseHexUnsigned(req.exchange),
                    (BigInteger)req.payerId,
                    (BigInteger)req.payeeId,
                    (BigInteger)req.token.tokenId,
                    BigInteger.Parse(req.token.volume),
                    (BigInteger)req.maxFee.tokenId,
                    BigInteger.Parse(req.maxFee.volume),
                    Utils.ParseHexUnsigned(req.payeeAddr),
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
                        new MemberValue {TypeName = "address", Value = toAddress},
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
                            to = toAddress,
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
                    var ethECKeyTransfer = new Nethereum.Signer.EthECKey(MMorGMEPrivateKey.Replace("0x", ""));
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
                        toAddress,
                        req.token.tokenId,
                        req.token.volume,
                        req.maxFee.tokenId,
                        req.maxFee.volume,
                        req.storageId,
                        req.validUntil,
                        transferEddsaSignature,
                        transferEcdsaSignature,
                        transferMemo);
                    if (tokenTransferResult.Contains("processing"))
                    {
                        validAddress.Add(toAddressInitial);
                        gasFeeTotal += decimal.Parse(req.maxFee.volume);
                        transactionFeeTotal += lcrTransactionFee;
                    }
                    else
                    {
                        invalidAddress.Add(toAddressInitial + tokenTransferResult);
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
            };
            return nftTransferAuditInformation;
        }
        public async Task<NftTransferAuditInformation> LrcTransferActivation(
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
            string transferMemo)
        {
            ILoopringService loopringService = new LoopringService(environmentUrl, _font);
            string toAddressInitial;
            var amountToTransferInitial = amountToTransfer;
            var airdropNumberOn = 0;
            var gasFeeTotal = 0m;
            var transactionFeeTotal = 0m;
            var transferTokenId = 1;
            var transferTokenSymbol = "LRC";
            List<string> invalidAddress = new();
            List<string> validAddress = new();
            List<string> banishAddress = new();
            List<string> invalidNftData = new();
            List<string> alreadyActivatedAddress = new();

            using (StreamReader sr = new($"./{inputPath}/{fileName}"))
            {
                while ((toAddressInitial = sr.ReadLine()) != null)
                {
                    font.ToTertiaryInline($"\rDrop: {++airdropNumberOn}/{howManyLines} Wallet: {toAddressInitial}");

                    var toAddress = toAddressInitial.ToLower().Trim();

                    toAddress = await loopringService.CheckForEthAddress(loopringApiKey, toAddress);

                    if (toAddress == "invalid eth address")
                    {
                        invalidAddress.Add($"{toAddressInitial}");
                        Thread.Sleep(50); //for a rate limiter just incase multiple invalid ens
                        continue;
                    }

                    var contains = await loopringService.CheckBanishTextFile(font, toAddressInitial, toAddress, loopringApiKey);
                    if (contains == true)
                    {
                        banishAddress.Add(toAddressInitial);
                        continue;
                    }

                    var accountInformation = await loopringService.CheckUserAccountInformationFromOwner(toAddress);
                    if (accountInformation != null)
                    {
                        if (accountInformation.nonce == 1 || accountInformation.tags == "FirstUpdateAccountPaid")
                        {
                            alreadyActivatedAddress.Add(toAddressInitial);
                            continue;
                        }
                    }

                    // start activation
                    var amount = (amountToTransfer * 1000000000000000000m).ToString("0");
                    var transferFeeAmountResult = await loopringService.GetOffChainTransferFeeForTransferAndUpdateAccount(loopringApiKey, fromAccountId, 15); //3 is the request type for crypto transfers
                    var feeAmount = transferFeeAmountResult.fees.Where(w => w.token == transferTokenSymbol).First().fee;
                    var transferStorageId = await loopringService.GetNextStorageId(loopringApiKey, fromAccountId, transferTokenId);

                    TransferRequest req = new()
                    {
                        exchange = environmentExchange,
                        maxFee = new Token()
                        {
                            tokenId = transferTokenId,
                            volume = feeAmount
                        },
                        token = new Token()
                        {
                            tokenId = transferTokenId,
                            volume = amount
                        },
                        payeeAddr = toAddress,
                        payerAddr = fromAddress,
                        payeeId = 0,
                        payerId = fromAccountId,
                        storageId = transferStorageId.offchainId,
                        validUntil = Utils.GetUnixTimestamp() + (int)TimeSpan.FromDays(365).TotalSeconds,
                        tokenName = transferTokenSymbol,
                        tokenFeeName = transferTokenSymbol,
                    };

                    BigInteger[] eddsaSignatureinputs = {
                    Utils.ParseHexUnsigned(req.exchange),
                    (BigInteger)req.payerId,
                    (BigInteger)req.payeeId,
                    (BigInteger)req.token.tokenId,
                    BigInteger.Parse(req.token.volume),
                    (BigInteger)req.maxFee.tokenId,
                    BigInteger.Parse(req.maxFee.volume),
                    Utils.ParseHexUnsigned(req.payeeAddr),
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
                            new MemberDescription {Name = "from", Type = "address"},
                            new MemberDescription {Name = "to", Type = "address"},
                            new MemberDescription {Name = "tokenID", Type = "uint16"},
                            new MemberDescription {Name = "amount", Type = "uint96"},
                            new MemberDescription {Name = "feeTokenID", Type = "uint16"},
                            new MemberDescription {Name = "maxFee", Type = "uint96"},
                            new MemberDescription {Name = "validUntil", Type = "uint32"},
                            new MemberDescription {Name = "storageID", Type = "uint32"}
                        },
                        },
                        Message = new[]
                    {
                        new MemberValue {TypeName = "address", Value = fromAddress},
                        new MemberValue {TypeName = "address", Value = toAddress},
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
                            to = toAddress,
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
                    var ethECKeyTransfer = new Nethereum.Signer.EthECKey(MMorGMEPrivateKey.Replace("0x", ""));
                    var encodedTypedDataTransfer = signerTransfer.EncodeTypedData(eip712TypedDataTransfer);
                    var ECDRSASignatureTransfer = ethECKeyTransfer.SignAndCalculateV(Sha3Keccack.Current.CalculateHash(encodedTypedDataTransfer));
                    var serializedECDRSASignatureTransfer = EthECDSASignature.CreateStringSignature(ECDRSASignatureTransfer);
                    var transferEcdsaSignature = serializedECDRSASignatureTransfer + "0" + (int)2;

                    var tokenTransferResult = await loopringService.SubmitPayPayeeUpdateAccountFee(
                        loopringApiKey,
                        environmentExchange,
                        fromAccountId,
                        fromAddress,
                        0,
                        toAddress,
                        req.token.tokenId,
                        req.token.volume,
                        req.maxFee.tokenId,
                        req.maxFee.volume,
                        req.storageId,
                        req.validUntil,
                        transferEddsaSignature,
                        transferEcdsaSignature,
                        transferMemo,
                        "true");

                    if (tokenTransferResult.Contains("processing"))
                    {
                        validAddress.Add(toAddressInitial);
                        gasFeeTotal += decimal.Parse(req.maxFee.volume);
                    }
                    else
                    {
                        invalidAddress.Add(toAddressInitial + tokenTransferResult);
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
            };
            return nftTransferAuditInformation;
        }


        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<List<NftCollectionItemsWithMetadata>> GetNftCollectionItemsOfOwnAccount(string apiKey, string collectionId)
        {
            List<NftCollectionItemsWithMetadata> collections = new List<NftCollectionItemsWithMetadata>();
            var request = new RestRequest("/api/v3/nft/public/collection/items");
            int offset = 0;
            request.AddHeader("x-api-key", apiKey);
            request.AddParameter("id", Int32.Parse(collectionId));
            request.AddParameter("metadata", "true");
            request.AddParameter("limit", 50);
            request.AddParameter("offset", offset);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<NftCollectionItemsWithMetadata>(response.Content!);
                if (data.nftTokenInfos.Count != 0)
                {
                    collections.Add(data);
                    Console.Write($"{collections.Sum(x=> x.nftTokenInfos.Count)}/{data.totalNum} retrieved...");
                }
                while (data.nftTokenInfos.Count != 0)
                {
                    offset += 50;
                    request.AddOrUpdateParameter("offset", offset);
                    response = await _client.GetAsync(request);
                    data = JsonConvert.DeserializeObject<NftCollectionItemsWithMetadata>(response.Content!);
                    if (data.nftTokenInfos.Count != 0)
                    {
                        collections.Add(data);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write($"{collections.Sum(x => x.nftTokenInfos.Count)}/{data.totalNum} retrieved...");
                    }
                }
                return collections;
            }
            catch (HttpRequestException httpException)
            {
                _font.ToWhite($"Error getting collection items: {httpException.Message}");
                return null;
            }
        }
    }
}
