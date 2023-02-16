using System.Net.Http.Headers;
using Maize.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Maize.Services
{
    public class NftStorageService : INftStorageService, IDisposable
    {
        const string _baseUrl = "https://api.nft.storage";

        readonly RestClient _client;

        public NftStorageService()
        {
            _client = new RestClient(_baseUrl);
        }

        public async Task<PinataResponseData?> SubmitPin(string nftStorageApiKey, byte[] fileBytes, string fileName)
        {
            var request = new RestRequest("/upload");
            request.AddHeader("Authorization", $"Bearer {nftStorageApiKey}");
            request.AddFile("file", fileBytes, fileName);
            try
            {
                var response = await _client.PostAsync(request);
                var data = JsonConvert.DeserializeObject<PinataResponseData>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                return null;
            }
        }

        // nft.storage API endpoint
        private static readonly string nftStorageApiUrl = "https://api.nft.storage/";

        // HTTP client to communicate with nft.storage
        private static readonly HttpClient nftClient = new HttpClient();

        // http client to communicate with IPFS API
        private static readonly HttpClient ipfsClient = new HttpClient();

        // nft.storage API key
        public string apiToken;


        public async Task<NFTStorageUploadResponse> UploadDataFromFile(Font font, string path, string jwt)
        {
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();
            reader.Close();
            return await UploadDataFromString(font, path, jwt);
        }


        public async Task<NFTStorageUploadResponse> UploadDataFromString(Font font, string data, string jwt)
        {
            string requestUri = nftStorageApiUrl + "upload";
            string rawResponse = await Upload(font, requestUri, data, jwt);
            NFTStorageUploadResponse parsedResponse = JsonConvert.DeserializeObject<NFTStorageUploadResponse>(rawResponse);
            return parsedResponse;
        }

        public static async Task<string> Upload(Font font, string uri, string pathFile, string jwt)
        {

            byte[] bytes = System.IO.File.ReadAllBytes(pathFile);

            using (var content = new ByteArrayContent(bytes))
            {
                try
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("*/*");
                    nftClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwt);
                    nftClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    //Send it
                    var response = await nftClient.PostAsync(uri, content);
                    response.EnsureSuccessStatusCode();
                    Stream responseStream = await response.Content.ReadAsStreamAsync();
                    StreamReader reader = new StreamReader(responseStream);
                    return reader.ReadToEnd();
                }
                catch (Exception e)
                {
                    if(e.ToString().Contains("401 (Unauthorized)"))
                    {
                        font.ToRedInline($"\rError in loading to nft.storage: Check your nftStorageApiKey in the appsettings file. You can get a key here: https://nft.storage/manage/");
                        Environment.Exit(0);
                    }
                    else
                    {
                        font.ToRedInline($"\rError in loading to nft.storage: {e}");
                        Environment.Exit(0);
                    }
                    return null;
                }
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
        [Serializable]
        public class NFTStorageError
        {
            public string name;
            public string message;
        }

        [Serializable]
        public class NFTStorageFiles
        {
            public string name;
            public string type;
        }

        [Serializable]
        public class NFTStorageDeal
        {
            public string batchRootCid;
            public string lastChange;
            public string miner;
            public string network;
            public string pieceCid;
            public string status;
            public string statusText;
            public int chainDealID;
            public string dealActivation;
            public string dealExpiration;
        }

        [Serializable]
        public class NFTStoragePin
        {
            public string cid;
            public string name;
            public string status;
            public string created;
            public int size;
            // TODO: add metadata parsing ('meta' property)
        }

        [Serializable]
        public class NFTStorageNFTObject
        {
            public string cid;
            public int size;
            public string created;
            public string type;
            public string scope;
            public NFTStoragePin pin;
            public NFTStorageFiles[] files;
            public NFTStorageDeal[] deals;
        }


        [Serializable]
        public class NFTStorageCheckValue
        {
            public string cid;
            public NFTStoragePin pin;
            public NFTStorageDeal[] deals;
        }

        [Serializable]
        public class NFTStorageGetFileResponse
        {
            public bool ok;
            public NFTStorageNFTObject value;
            public NFTStorageError error;
        }

        [Serializable]
        public class NFTStorageCheckResponse
        {
            public bool ok;
            public NFTStorageCheckValue value;
            public NFTStorageError error;
        }

        [Serializable]
        public class NFTStorageListFilesResponse
        {
            public bool ok;
            public NFTStorageNFTObject[] value;
            public NFTStorageError error;
        }

        [Serializable]
        public class NFTStorageUploadResponse
        {
            public bool ok;
            public NFTStorageNFTObject value;
            public NFTStorageError error;
        }

        [Serializable]
        public class NFTStorageDeleteResponse
        {
            public bool ok;
        }
    }
}
