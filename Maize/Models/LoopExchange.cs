using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class LoopExchange
    {
        public int id { get; set; }
        public int chainID { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public int count { get; set; }
        public bool hasRarity { get; set; }
        public bool verified { get; set; }
        public string profileImage { get; set; }
        public string bannerImage { get; set; }
        public string featuredImage { get; set; }
        public string floorPrice1 { get; set; }
        public string volume1 { get; set; }
        public string minter { get; set; }
        public string minterDomain { get; set; }
        public string minterDisplayName { get; set; }
        public bool minterVerified { get; set; }
    }
}
