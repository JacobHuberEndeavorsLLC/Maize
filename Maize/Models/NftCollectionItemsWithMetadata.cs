using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class Base
    {
        public string name { get; set; }
        public int decimals { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string properties { get; set; }
        public string localization { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
    }

    public class Metadata
    {
        public string uri { get; set; }
        [JsonProperty(PropertyName = "base")]
        public Base basename { get; set; }
        public int status { get; set; }
        public int nftType { get; set; }
        public int network { get; set; }
        public string tokenAddress { get; set; }
        public string nftId { get; set; }
    }

    public class NftTokenInfoItemWithMetadata
    {
        public string nftData { get; set; }
        public string minter { get; set; }
        public string nftType { get; set; }
        public string tokenAddress { get; set; }
        public string nftId { get; set; }
        public int creatorFeeBips { get; set; }
        public int royaltyPercentage { get; set; }
        public int originalRoyaltyPercentage { get; set; }
        public bool status { get; set; }
        public string nftFactory { get; set; }
        public string nftOwner { get; set; }
        public string nftBaseUri { get; set; }
        public string royaltyAddress { get; set; }
        public string originalMinter { get; set; }
        public long createdAt { get; set; }
        public Metadata metadata { get; set; }
        public int total { get; set; }
    }

    public class NftCollectionItemsWithMetadata
    {
        public int totalNum { get; set; }
        public List<NftTokenInfoItemWithMetadata> nftTokenInfos { get; set; }
    }
}
