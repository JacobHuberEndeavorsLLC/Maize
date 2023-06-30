namespace Maize
{
    public class NftHolder
    {
        public int accountId { get; set; }
        public string address { get; set; }
        public int tokenId { get; set; }
        public string amount { get; set; }
    }

    public class NftHoldersResponse
    {
        public int totalNum { get; set; }
        public List<NftHolder> nftHolders { get; set; }
    }
    //public class NftHolderAndNftData
    //{

    //    public string walletAddress { get; set; }
    //    public string nftName { get; set; }
    //    public string amount { get; set; }
    //    public string nftData { get; set; }
    //    public int accountId { get; set; }
    //    public int tokenId { get; set; }
    //}

}
