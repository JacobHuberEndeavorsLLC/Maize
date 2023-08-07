using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models.Responses
{
    public class Data
    {
        public bool isInCounterFactualStatus { get; set; }
        public bool isContract { get; set; }
        public string loopringWalletContractVersion { get; set; }
    }

    public class WalletTypeResponse
    {
        public ResultInfo resultInfo { get; set; }
        public Data data { get; set; }
    }
}
