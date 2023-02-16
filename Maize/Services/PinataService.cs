using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maize.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Maize.Services
{
    public class PinataService : IPinataService, IDisposable
    {
        const string _baseUrl = "https://api.pinata.cloud";

        readonly RestClient _client;

        public PinataService()
        {
            _client = new RestClient(_baseUrl);
        }
        public async Task<string> TestAuthentication(string jwt)
        {
            RestResponse response = new();
            var request = new RestRequest("data/testAuthentication");
            request.AddHeader("Authorization", $"Bearer {jwt}");
            try
            {
                response = await _client.ExecuteAsync(request);
                var data = JsonConvert.DeserializeObject<PinataAuthenticationSuccess>(response.Content!);
                if (data.message == null)
                {
                    var dataFail = JsonConvert.DeserializeObject<PinataAuthenticationFail>(response.Content!);
                    return dataFail.error.reason;
                }
                return data.message;
            }
            catch (HttpRequestException httpException)
            {
                Console.WriteLine(httpException.Message);
                return httpException.Message;
            }
        }
        public async Task<PinataResponseData?> SubmitPin(string jwt, byte[] fileBytes, string fileName, bool wrapDirectory = false, string pinataMetadata = null)
        {
            var request = new RestRequest("pinning/pinFileToIPFS");
            request.AddHeader("Authorization", $"Bearer {jwt}");
            request.AddFile("file", fileBytes, fileName);
            request.AddParameter("pinataMetadata", pinataMetadata);
            if (wrapDirectory == true)
            {
                request.AddParameter("pinataOptions", "{\"wrapWithDirectory\" :true}");

            }
            try
            {
                var response = await _client.PostAsync(request);
                var data = JsonConvert.DeserializeObject<PinataResponseData>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                if (wrapDirectory == true)
                {
                    Console.WriteLine($"Issue uploading metadata file for {fileName}, Exception message: {httpException.Message}");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Issue uploading image file for {fileName}, Exception message: {httpException.Message}");
                    return null;
                }
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
