using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models.Responses
{
    public class Fee
    {
        public string token { get; set; }
        public int tokenId { get; set; }
        public string fee { get; set; }
        public int discount { get; set; }
    }

    public class NftOffChainFeeResponse
    {
        public string gasPrice { get; set; }
        public List<Fee> fees { get; set; }
    }
}
