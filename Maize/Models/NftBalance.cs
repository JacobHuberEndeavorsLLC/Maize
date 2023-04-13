using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class Pending
    {
        public string withdraw { get; set; }
        public string deposit { get; set; }
    }

    public class NftBalance
    {
        public int totalNum { get; set; }
        public List<Datum> data { get; set; }
    }

    public class CoinBalance
    {
        public int accountId { get; set; }
        public int tokenId { get; set; }
        public string total { get; set; }
        public string locked { get; set; }
        public Pending pending { get; set; }
    }
    public class NftBase
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

    public class Cached
    {
        public string avatar { get; set; }
        public string banner { get; set; }
        public string tileUri { get; set; }
        public string thumbnail { get; set; }
    }

    public class CollectionInfo
    {
        public int id { get; set; }
        public string owner { get; set; }
        public string name { get; set; }
        public string contractAddress { get; set; }
        public string collectionAddress { get; set; }
        public string baseUri { get; set; }
        public string nftFactory { get; set; }
        public string description { get; set; }
        public string avatar { get; set; }
        public string banner { get; set; }
        public string thumbnail { get; set; }
        public string tileUri { get; set; }
        public Cached cached { get; set; }
        public string deployStatus { get; set; }
        public string nftType { get; set; }
        public Times times { get; set; }
        public Extra extra { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public int accountId { get; set; }
        public int tokenId { get; set; }
        public string nftData { get; set; }
        public string tokenAddress { get; set; }
        public string nftId { get; set; }
        public string nftType { get; set; }
        public string total { get; set; }
        public string locked { get; set; }
        public Pending pending { get; set; }
        public string deploymentStatus { get; set; }
        public bool isCounterFactualNFT { get; set; }
        public Metadata? metadata { get; set; }
        public string? minter { get; set; }
        public int? royaltyPercentage { get; set; }
        public Preference? preference { get; set; }
        public CollectionInfo? collectionInfo { get; set; }
    }

    public class Extra
    {
        public string imageData { get; set; }
        public string externalUrl { get; set; }
        public string attributes { get; set; }
        public string backgroundColor { get; set; }
        public string animationUrl { get; set; }
        public string youtubeUrl { get; set; }
        public string minter { get; set; }
        public Properties properties { get; set; }
        public string mintChannel { get; set; }
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
        public NftBase nftBase { get; set; }
        public ImageSize imageSize { get; set; }
        public Extra extra { get; set; }
        public int status { get; set; }
        public int nftType { get; set; }
        public int network { get; set; }
        public string tokenAddress { get; set; }
        public string nftId { get; set; }
    }

    public class Preference
    {
        public bool favourite { get; set; }
        public bool hide { get; set; }
    }

    public class Properties
    {
        public bool isLegacy { get; set; }
        public bool isPublic { get; set; }
        public bool isCounterFactualNFT { get; set; }
        public bool isMintable { get; set; }
        public bool isEditable { get; set; }
        public bool isDeletable { get; set; }
    }

    public class Times
    {
        public object createdAt { get; set; }
        public object updatedAt { get; set; }
    }

}
