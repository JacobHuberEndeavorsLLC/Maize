using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models.Responses
{
    public class CounterFactualInfo
    {
        public int accountId { get; set; }
        public string wallet { get; set; }
        public string walletFactory { get; set; }
        public string walletSalt { get; set; }
        public string walletOwner { get; set; }
    }
}
