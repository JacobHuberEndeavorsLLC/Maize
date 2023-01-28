using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class Cached
    {
        public string avatar { get; set; }
        public string banner { get; set; }
        public string tileUri { get; set; }
        public string thumbnail { get; set; }
    }

    public class Collections
    {
        public Collection collection { get; set; }
        public int count { get; set; }
    }

    public class Collection
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

    public class Extra
    {
        public Properties properties { get; set; }
        public string mintChannel { get; set; }
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

    public class UserCollections
    {
        public List<Collections> collections { get; set; }
        public int totalNum { get; set; }
    }

    public class Times
    {
        public object createdAt { get; set; }
        public object updatedAt { get; set; }
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
        public int total { get; set; }
    }

    public class CollectionInformation
    {
        public int totalNum { get; set; }
        public List<NftTokenInfo> nftTokenInfos { get; set; }
    }

    public class NftInformation
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public int total { get; set; }
        public string nftData { get; set; }
        public string nftId { get; set; }
        public string minter { get; set; }
        public string tokenAddress { get; set; }
        public int royaltyPercentage { get; set; }
        public List<NftAttribute>? attributes { get; set; }
    }
    public class OwnedCollection
    {
        public Collection collection { get; set; }
        public int count { get; set; }
    }
    public class UserOwnedCollections
    {
        public List<OwnedCollection> collections { get; set; }
        public int totalNum { get; set; }
    }

}
