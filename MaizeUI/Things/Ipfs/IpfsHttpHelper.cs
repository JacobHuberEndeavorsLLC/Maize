using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MaizeUI.Things
{
    public class IpfsHttpHelper
    {
        public static async Task<(string collectionAddress, int royaltyPercentage, List<string> cids)> GetFolderDetails(string folderCid)
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5001") })
            {
                var cids = new List<string>();
                string collectionAddress = null;
                string royaltyPercentage = null;

                string url = $"/api/v0/ls?arg=/ipfs/{folderCid}";
                HttpResponseMessage response = await httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);

                    foreach (var obj in json["Objects"][0]["Links"])
                    {
                        cids.Add(obj["Hash"].ToString());
                    }

                    if (cids.Count > 0)
                    {
                        string firstCid = cids[0];
                        (collectionAddress, royaltyPercentage) = await GetCollectionMetadata(httpClient, firstCid);
                    }
                }

                return (collectionAddress, int.Parse(royaltyPercentage), cids);
            }
        }

        private static async Task<(string collectionAddress, string royaltyPercentage)> GetCollectionMetadata(HttpClient httpClient, string cid)
        {
            string url = $"/api/v0/cat?arg={cid}";
            HttpResponseMessage response = await httpClient.PostAsync(url, null);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(jsonContent);
                string collectionMetadata = json["collection_metadata"]?.ToString();
                string lastPart = collectionMetadata?.Substring(collectionMetadata.LastIndexOf('/') + 1);
                return (lastPart, json["royalty_percentage"]?.ToString());
            }
            return (null, null);
        }
    }
}
