namespace Maize.Models.Responses
{
        public class Cached
        {
            public string avatar { get; set; }
            public string banner { get; set; }
            public string tileUri { get; set; }
            public string thumbnail { get; set; }
        }
    public class ExtraCollection
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
    public class CollectionInformation
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
        public ExtraCollection extra { get; set; }
    }
    public class Times
    {
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
    }
}
