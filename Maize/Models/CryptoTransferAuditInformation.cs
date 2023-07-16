using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class CryptoTransferAuditInformation
    {
        public List<string> validAddress { get; set; }
        public List<string> invalidAddress { get; set; }
        public List<string> banishAddress { get; set; }
        public List<string>? alreadyActivatedAddress { get; set; }
        public decimal gasFeeTotal { get; set; }
        public decimal transactionFeeTotal { get; set; }
        public decimal cryptoSentTotal { get; set; }
    }
}
