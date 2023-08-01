namespace Maize
{
    public class TransferInformationCrypto
    {
        public decimal Amount { get; set; }
        public string? ToAddress { get; set; }
        public string? Memo { get; set; }
        public bool Activated { get; set; }
    }
}
