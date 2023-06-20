namespace Maize
{
    public class Fee
    {
        public string token { get; set; }
        public string fee { get; set; }
        public int discount { get; set; }
    }

    public class OffchainFee
    {
        public string gasPrice { get; set; }
        public List<Fee> fees { get; set; }
    }
}