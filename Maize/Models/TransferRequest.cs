using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class TransferRequest
    {
        // ESSENTIAL TRANSFER INFO
        public string exchange { get; set; }
        public int payerId { get; set; }
        public string payerAddr { get; set; }
        public int payeeId { get; set; } = 0;           // Default of 0 if unknown is fine
        public string payeeAddr { get; set; }
        public Token token { get; set; }
        public Token maxFee { get; set; }
        public int storageId { get; set; }
        public int validUntil { get; set; }
        public string tokenName { get; set; }
        public string tokenFeeName { get; set; }
    }
}
