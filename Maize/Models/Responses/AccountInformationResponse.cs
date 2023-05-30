using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class PublicKey
    {
        public string x { get; set; }
        public string y { get; set; }
    }

    public class AccountInformationResponse
    {
        public int accountId { get; set; }
        public string owner { get; set; }
        public bool frozen { get; set; }
        public PublicKey publicKey { get; set; }
        public string tags { get; set; }
        public int nonce { get; set; }
        public int keyNonce { get; set; }
        public string keySeed { get; set; }
    }

}
