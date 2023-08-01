namespace Maize.Models
{
    public class TransferInformation
    {
        public string? NftData { get; set; }
        public int Amount { get; set; }
        public string?  ToAddress { get; set; }
        public string? Memo { get; set; }
        public bool Activated { get; set; }
    }
}
