using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopringSmartWalletRecoveryPhraseExtractor
{
    public class QrCodeJson
    {
        public string? wallet { get; set; }
        public string? iv { get; set; }
        public string? mnemonic { get; set; }
        public string? ens { get; set; }
        public bool isCounterFactual { get; set;}
        public string register { get; set; }
        public string? type { get; set; }
        public int setting { get; set; }
        public string? salt { get; set; }
        public string? network { get; set; }
    }
}
