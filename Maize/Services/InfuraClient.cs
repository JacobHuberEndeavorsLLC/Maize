using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Text;
using Nethereum.Web3;
using System.Net.NetworkInformation;
using System;
using System.Buffers;

namespace Maize.Services
{
    public class InfuraClient : IInfuraClient, IDisposable
    {
        private readonly RestClient _client;
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly string _apiKeySecret;

        public InfuraClient(string apiKey, string apiKeySecret, string url)
        {
            var options = new RestClientOptions(url)
            {
                Authenticator = new HttpBasicAuthenticator(apiKey, apiKeySecret)
            };
            _client = new RestClient(options);
            _baseUrl = url;
            _apiKey = apiKey;
            _apiKeySecret = apiKeySecret;
        }
        public async Task<FileAddResponse> FileAdd(string filePath)
        {
            //string directoryPath = Path.GetDirectoryName(filePath).Replace("\\", "/");
            //string fileName = Path.GetFileName(filePath);
            try
            {
                var request = new RestRequest($"/api/v0/add");
                request.AddFile("file", filePath);
                request.AddQueryParameter("quite", "true");

                var response = await _client.ExecutePostAsync(request);
                if (response.Content == "basic auth failure: invalid project id or project secret\n")
                {
                    var error = new FileAddResponse
                    {
                        Hash = response.Content
                    };
                    return error;
                }
                var data = JsonConvert.DeserializeObject<FileAddResponse>(response.Content!);

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<PinAddResponse> PinAdd()
        {
            try
            {
                var request = new RestRequest($"/api/v0/pin/add");
                request.AddQueryParameter("arg", "QmPbNQ2QPsqSGuLQ4W3iPddDHhPNdGfjmT4xi83afdKgcq");
                request.AddQueryParameter("recursive", "true");
                request.AddQueryParameter("progress", "true");

                var response = await _client.ExecutePostAsync(request);
                var jsonObjects = response.Content.Split('\n');

                var progressObj = JsonConvert.DeserializeObject<ProgressResponse>(jsonObjects[0]);
                var pinsObj = JsonConvert.DeserializeObject<PinsResponse>(jsonObjects[1]);

                var pinAddResponse = new PinAddResponse
                {
                    Progress = progressObj.Progress,
                    Pins = pinsObj.Pins
                };

                return pinAddResponse;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<PinAddResponse> PinView()
        {
            try
            {
                var request = new RestRequest($"/api/v0/pin/ls");
                request.AddQueryParameter("arg", "QmPbNQ2QPsqSGuLQ4W3iPddDHhPNdGfjmT4xi83afdKgcq");
                request.AddQueryParameter("type ", "all");
                request.AddQueryParameter("quiet", "true");
                request.AddQueryParameter("stream", "false");

                var response = await _client.ExecutePostAsync(request);
                var jsonObjects = response.Content.Split('\n');

                var progressObj = JsonConvert.DeserializeObject<ProgressResponse>(jsonObjects[0]);
                var pinsObj = JsonConvert.DeserializeObject<PinsResponse>(jsonObjects[1]);

                var pinAddResponse = new PinAddResponse
                {
                    Progress = progressObj.Progress,
                    Pins = pinsObj.Pins
                };

                return pinAddResponse;
            }
            catch (Exception e)
            {
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