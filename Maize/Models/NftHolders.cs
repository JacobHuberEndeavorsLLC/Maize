using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class NftHolders
    {
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
        }
    }
}
