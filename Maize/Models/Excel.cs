using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class NftDataAndName
    {
        public string nftData { get; set; }
        public string nftName { get; set; }
    }
    public class OwnerAndAmount
    {
        public string nftData { get; set; }
        public string nftName { get; set; }
        public string nftOwner { get; set; }
        public string ownerAmountOwned { get; set; }
    }
    public class OwnerAndTotal
    {
        public string owner { get; set; }
        public int total { get; set; }
        //public string percentageOwned { get; set; }
    }
    public class AmountChart
    {
        public int amount1 { get; set; }
        public int amount2To5 { get; set; }
        public int amount6To10 { get; set; }
        public int amount11To19 { get; set; }
        public int amount20Plus { get; set; }
    }
}
