using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class Settings
    {
        public string LoopringApiKey { get; set; }
        public string LoopringPrivateKey { get; set; }
        public string LoopringAddress { get; set; }
        public int LoopringAccountId { get; set; }
        public long ValidUntil { get; set; }
        public int MaxFeeTokenId { get; set; }
        public int Environment { get; set; }
        public string MMorGMEPrivateKey { get; set; }
        public string PinataJwt { get; set; }
        public string NftStorageApiKey { get; set; }
    }
}
