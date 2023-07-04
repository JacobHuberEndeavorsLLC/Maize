using Newtonsoft.Json;
using RestSharp;


namespace Maize
{
    public class LoopExchangeService : ILoopExchangeService
    {

        readonly RestClient _client;

        public LoopExchangeService(string environmentUrl)
        {
            _client = new RestClient(environmentUrl);
        }
        public async Task<string> GetUser(string owner)
        {
            var request = new RestRequest($"web-v1/resolution/{owner}");
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<string>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                return null;
            }
        }
    }
}
