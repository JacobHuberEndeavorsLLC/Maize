using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class BlockFee
    {
        public int tokenId { get; set; }
        public string amount { get; set; }
    }

    public class BlockInformation
    {
        public int blockId { get; set; }
        public int blockSize { get; set; }
        public string exchange { get; set; }
        public string txHash { get; set; }
        public string status { get; set; }
        public long createdAt { get; set; }
        public List<BlockTransaction> transactions { get; set; }
    }

    public class BlockToken
    {
        public int tokenId { get; set; }
        public string amount { get; set; }
    }

    public class BlockTransaction
    {
        public string txType { get; set; }
        public int accountId { get; set; }
        public string owner { get; set; }
        public BlockFee fee { get; set; }
        public long validUntil { get; set; }
        public int nonce { get; set; }
        public BlockToken token { get; set; }
    }



}
