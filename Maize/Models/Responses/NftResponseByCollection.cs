using Newtonsoft.Json;

namespace Maize.Models.Responses
{
    public class Base
    {
        public string name { get; set; }
        public int decimals { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string properties { get; set; }
        public string localization { get; set; }
        public object createdAt { get; set; }
        public object updatedAt { get; set; }
    }

    public class ExtraNft
    {
        public string imageData { get; set; }
        public string externalUrl { get; set; }
        public string attributes { get; set; }
        public string backgroundColor { get; set; }
        public string animationUrl { get; set; }
        public string youtubeUrl { get; set; }
        public string minter { get; set; }
    }

    public class ImageSize
    {
        [JsonProperty("240-240")]
        public string _240240 { get; set; }

        [JsonProperty("332-332")]
        public string _332332 { get; set; }
        public string original { get; set; }
    }

    public class Metadata
    {
        public string uri { get; set; }
        [JsonProperty("base")]
        public Base basename { get; set; }
        public ImageSize imageSize { get; set; }
        public ExtraNft extra { get; set; }
        public int status { get; set; }
        public int nftType { get; set; }
        public int network { get; set; }
        public string tokenAddress { get; set; }
        public string nftId { get; set; }
    }

    public class NftTokenInfo
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
        public object createdAt { get; set; }
        public Metadata metadata { get; set; }
        public int total { get; set; }
    }

    public class NftResponseFromCollection
    {
        public int totalNum { get; set; }
        public List<NftTokenInfo> nftTokenInfos { get; set; }
    }




}


