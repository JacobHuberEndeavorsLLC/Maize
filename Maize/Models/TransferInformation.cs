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

    public class UserTransferInformation
    {
        public string NftData { get; set; }
        public string WalletAddress { get; set; }
        public int Amount { get; set; }

        private decimal gasFee;
        public decimal GasFee
        {
            get => gasFee;
            set => gasFee = value / 1000000000000000000M; // Divide by 1,000,000,000
        }

        public bool TransferFail { get; set; }
        public string? ErrorMessage { get; set; }
    }

}
