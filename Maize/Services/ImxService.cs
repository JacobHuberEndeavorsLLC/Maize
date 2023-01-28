//using Maize;
//using Maize.Models;
//using Newtonsoft.Json;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Metrics;
//using System.Linq;
//using System.Reflection.Metadata;
//using System.Text;
//using System.Threading.Tasks;

//namespace Maize
//{
//    public class ImxService : IImxService, IDisposable
//    {
//        const string _baseUrl = "https://api.x.immutable.com";

//        readonly RestClient _client;
//        readonly Font _font;

//        public ImxService(Font font)
//        {
//            _client = new RestClient(_baseUrl);
//            _font = font;
//        }


//        public async Task<List<Result>> GetCollectionAssets(string collectionAddress)
//        {
//            var request = new RestRequest("v1/assets");
//            try
//            {
//                request.AddParameter("collection", collectionAddress);
//                request.AddParameter("page_size", 200);
//                var response = await _client.GetAsync(request);
//                var data = JsonConvert.DeserializeObject<ImxAsset>(response.Content!);

//                var allData = new List<Result>();
//                var remaining = data.remaining;
//                var cursor = data.cursor;

//                allData.AddRange(data.result);

//                while (remaining > 0)
//                {
//                    //Thread.Sleep(500);
//                    request.AddOrUpdateParameter("cursor", cursor);
//                    response = await _client.GetAsync(request);
//                    var moreData = JsonConvert.DeserializeObject<ImxAsset>(response.Content!);
//                    remaining = moreData.remaining;
//                    cursor = moreData.cursor;
//                    allData.AddRange(moreData.result);
//                }

//                return allData;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error getting storage id: {httpException.Message}");
//                return null;
//            }
//        }

//        public async Task<List<MintResult>> GetCollectionMints(string collectionAddress)
//        {
//            var request = new RestRequest("v1/mints");
//            try
//            {
//                request.AddParameter("token_address", collectionAddress);
//                request.AddParameter("page_size", 200);
//                var response = await _client.GetAsync(request);
//                var data = JsonConvert.DeserializeObject<ImxMints>(response.Content!);

//                var allData = new List<MintResult>();
//                var remaining = data.remaining;
//                var cursor = data.cursor;

//                allData.AddRange(data.result);

//                while (remaining > 0)
//                {
//                    //Thread.Sleep(500);
//                    request.AddOrUpdateParameter("cursor", cursor);
//                    response = await _client.GetAsync(request);
//                    var moreData = JsonConvert.DeserializeObject<ImxMints>(response.Content!);
//                    remaining = moreData.remaining;
//                    cursor = moreData.cursor;
//                    allData.AddRange(moreData.result);
//                }

//                return allData;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error getting storage id: {httpException.Message}");
//                return null;
//            }
//        }

//        public async Task<List<MintResult>> GetCollectionMintsFilter(string collectionAddress)
//        {
//            var request = new RestRequest("v1/mints");
//            try
//            {
//                request.AddParameter("token_address", collectionAddress);
//                request.AddParameter("order_by", "created_at");
//                request.AddParameter("direction", "asc");
//                request.AddParameter("page_size", 200);
//                var response = await _client.GetAsync(request);
//                var data = JsonConvert.DeserializeObject<ImxMints>(response.Content!);

//                var allData = new List<MintResult>();
//                var remaining = data.remaining;
//                var cursor = data.cursor;

//                allData.AddRange(data.result);

//                while (remaining > 0)
//                {
//                    //Thread.Sleep(500);
//                    request.AddOrUpdateParameter("cursor", cursor);
//                    response = await _client.GetAsync(request);
//                    var moreData = JsonConvert.DeserializeObject<ImxMints>(response.Content!);
//                    remaining = moreData.remaining;
//                    cursor = moreData.cursor;
//                    allData.AddRange(moreData.result);
//                }

//                return allData;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error getting storage id: {httpException.Message}");
//                return null;
//            }
//        }

//        public async Task<List<TradeResult>> GetCollectionTrades(string collectionAddress)
//        {
//            var request = new RestRequest("v1/trades");
//            try
//            {
//                request.AddParameter("party_b_token_address", collectionAddress);
//                request.AddParameter("page_size", 200);
//                //request.AddParameter("min_timestamp", "2022-11-13T16:00:00Z");
//                //request.AddParameter("max_timestamp", "2022-11-14T3:30:00Z");
//                var response = await _client.GetAsync(request);
//                var data = JsonConvert.DeserializeObject<TradeResults>(response.Content!);

//                var allData = new List<TradeResult>();
//                var remaining = data.remaining;
//                var cursor = data.cursor;

//                allData.AddRange(data.result);

//                while (remaining > 0)
//                {
//                    //Thread.Sleep(250);
//                    request.AddOrUpdateParameter("cursor", cursor);
//                    response = await _client.GetAsync(request);
//                    var moreData = JsonConvert.DeserializeObject<TradeResults>(response.Content!);
//                    remaining = moreData.remaining;
//                    cursor = moreData.cursor;
//                    allData.AddRange(moreData.result);
//                }

//                return allData;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error getting storage id: {httpException.Message}");
//                return null;
//            }
//        }

//        public async Task<List<TradeResult>> GetCollectionTradesWithToken(string collectionAddress, string tokenId)
//        {
//            var request = new RestRequest("v1/trades");
//            try
//            {
//                //Thread.Sleep(250);
//                request.AddParameter("party_b_token_address", collectionAddress);
//                request.AddParameter("party_b_token_id", tokenId);
//                request.AddParameter("page_size", 200);
//                //request.AddParameter("min_timestamp", "2022-11-13T16:00:00Z");
//                //request.AddParameter("max_timestamp", "2022-11-14T3:30:00Z");
//                var response = await _client.GetAsync(request);
//                var data = JsonConvert.DeserializeObject<TradeResults>(response.Content!);

//                var allData = new List<TradeResult>();
//                var remaining = data.remaining;
//                var cursor = data.cursor;

//                allData.AddRange(data.result);

//                while (remaining > 0)
//                {
//                    //Thread.Sleep(250);
//                    request.AddOrUpdateParameter("cursor", cursor);
//                    response = await _client.GetAsync(request);
//                    var moreData = JsonConvert.DeserializeObject<TradeResults>(response.Content!);
//                    remaining = moreData.remaining;
//                    cursor = moreData.cursor;
//                    allData.AddRange(moreData.result);
//                }

//                return allData;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error getting storage id: {httpException.Message}");
//                return null;
//            }
//        }

//        public async Task<List<TransferResult>> GetCollectionTransfers(string collectionAddress)
//        {
//            var request = new RestRequest("v1/transfers");
//            try
//            {
//                request.AddParameter("token_address", collectionAddress);
//                request.AddParameter("page_size", 200);
//                var response = await _client.GetAsync(request);
//                var data = JsonConvert.DeserializeObject<ImxTransfer>(response.Content!);

//                var allData = new List<TransferResult>();
//                var remaining = data.remaining;
//                var cursor = data.cursor;

//                allData.AddRange(data.result);

//                while (remaining > 0)
//                {
//                    //Thread.Sleep(500);
//                    request.AddOrUpdateParameter("cursor", cursor);
//                    response = await _client.GetAsync(request);
//                    var moreData = JsonConvert.DeserializeObject<ImxTransfer>(response.Content!);
//                    remaining = moreData.remaining;
//                    cursor = moreData.cursor;
//                    allData.AddRange(moreData.result);
//                }

//                return allData;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error getting storage id: {httpException.Message}");
//                return null;
//            }
//        }

//        public async Task<ImxUserEth> GetUserEthBalance(string walletAddress)
//        {
//            var request = new RestRequest($"v1/balances/{walletAddress}");
//            try
//            {
//                var response = await _client.GetAsync(request);
//                var data = JsonConvert.DeserializeObject<ImxUserEth>(response.Content!);

//                data.imx = (Convert.ToDecimal(data.imx) * Convert.ToDecimal(10 ^ 18)).ToString();
//                return data;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error getting storage id: {httpException.Message}");
//                return null;
//            }
//        }

//        public async Task<OrderInformation> GetOrderInformation(string orderId)
//        {
//            var request = new RestRequest($"v1/orders/{orderId}");
//            try
//            {
//                Thread.Sleep(200);
//                var response = await _client.GetAsync(request);
//                var data = JsonConvert.DeserializeObject<OrderInformation>(response.Content!);
//                return data;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error getting storage id: {httpException.Message}");
//                return null;
//            }
//        }

//        public async Task<List<ResultIMX>> GetOrderInformationFilter(string collectionAddress)
//        {
//            var request = new RestRequest($"v1/orders");
//            request.AddParameter("sell_token_address", collectionAddress);
//            request.AddParameter("status", "filled");
//            request.AddParameter("order_by", "created_at");
//            request.AddParameter("direction", "asc");
//            request.AddParameter("page_size", 200);
//            try
//            {
//                //Thread.Sleep(200);
//                var response = await _client.GetAsync(request);
//                var data = JsonConvert.DeserializeObject<RootIMX>(response.Content!);

//                var allData = new List<ResultIMX>();
//                var remaining = data.remaining;
//                var cursor = data.cursor;

//                allData.AddRange(data.result);

//                while (remaining > 0)
//                {
//                    //Thread.Sleep(500);
//                    request.AddOrUpdateParameter("cursor", cursor);
//                    response = await _client.GetAsync(request);
//                    var moreData = JsonConvert.DeserializeObject<RootIMX>(response.Content!);
//                    remaining = moreData.remaining;
//                    cursor = moreData.cursor;
//                    allData.AddRange(moreData.result);
//                }

//                return allData;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error getting storage id: {httpException.Message}");
//                return null;
//            }
//        }

//        public async Task<SignableTransfer> GetSignableTransfer(SignableTransferRequest signableTransferRequest)
//        {
//            var request = new RestRequest("/v1/signable-transfer-details", Method.Post);

//            try
//            {
//                request.AddHeader("Content-Type", "text/plain");
//                request.AddHeader("Connection", "keep-alive");
//                var body = @"{ ""amount"": ""1"",
//                                ""receiver"": ""0x6458CC5902D4F9e466B599E220D1663C4718625A"",
//                                ""sender"": ""0xc528Acbc94E79Aa04C08D108B11AF52F21167294"",
//                                ""token"": {
//                                            ""type"": ""ERC721"",
//                                            ""data"": {
//                                                        ""token_address"": ""0x9998eae8ab9f8bfd0204df4bca8ca012f9b9d783"",
//                                                       ""token_id"": ""22""
//                              }}}";
//                request.AddParameter("text/plain", body, ParameterType.RequestBody);
//                //request.AddParameter("amount", signableTransferRequest.amount);
//                //request.AddParameter("receiver", signableTransferRequest.receiver);
//                //request.AddParameter("sender", signableTransferRequest.sender);
//                //request.AddParameter("token.type", signableTransferRequest.token.type);
//                //request.AddParameter("token.data.token_address", signableTransferRequest.token.data.token_address);
//                //request.AddParameter("token.data.token_id", signableTransferRequest.token.data.token_id);
//                var response = await _client.ExecutePostAsync(request);
//                var data = JsonConvert.DeserializeObject<SignableTransfer>(response.Content!);
//                return data;
//            }
//            catch (HttpRequestException httpException)
//            {
//                _font.SetTextToWhite($"Error submitting nft transfer: {httpException.Message}");
//                return null;
//            }
//        }

//        public void Dispose()
//        {
//            _client?.Dispose();
//            GC.SuppressFinalize(this);
//        }


//    }
//}
