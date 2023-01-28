using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class Leaderboard
    {
        public string owner { get; set; }
        public int transactionCount { get; set; }
        public int nftAmountSent { get; set; }
    }
}
