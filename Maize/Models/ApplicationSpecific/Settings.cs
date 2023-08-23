namespace Maize
{
    public class RootObject
    {
        public Settings Settings { get; set; }
    }
    public class Settings
    {
        public string LoopringApiKey { get; set; }
        public string LoopringPrivateKey { get; set; }
        public string LoopringAddress { get; set; }
        public int LoopringAccountId { get; set; }
        public long ValidUntil { get; set; }
        public int MaxFeeTokenId { get; set; }
        public int Environment { get; set; }
        public string MMorGMEPrivateKey { get; set; }
    }

    public class WalletDetails
    {
        public string Address { get; set; }
        public long AccountId { get; set; }
        public string Level { get; set; }
        public int Nonce { get; set; }
        public string ApiKey { get; set; }
        public string PublicX { get; set; }
        public string PublicY { get; set; }
        public string PrivateKey { get; set; }
    }
    public class InfuraKeys
    {
        public string _comment1 { get; set; }
        public string _comment2 { get; set; }
        public string InfuraApiKey { get; set; }
        public string InfuraSecretKey { get; set; }
    }
}
