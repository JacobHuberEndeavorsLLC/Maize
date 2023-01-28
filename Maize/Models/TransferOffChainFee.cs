using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class TransferFee
    {
        public string token { get; set; }
        public string fee { get; set; }
        public decimal discount { get; set; }
    }

    public class TransferFeeOffchainFee
    {
        public string gasPrice { get; set; }
        public List<TransferFee> fees { get; set; }
    }
}
