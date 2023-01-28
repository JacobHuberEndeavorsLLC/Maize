using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class BlockIdInfo
    {
        public int blockId { get; set; }
        public int indexInBlock { get; set; }
    }

    public class Mint
    {
        public int id { get; set; }
        public int requestId { get; set; }
        public string hash { get; set; }
        public string txHash { get; set; }
        public int accountId { get; set; }
        public string owner { get; set; }
        public string status { get; set; }
        public string nftData { get; set; }
        public string amount { get; set; }
        public string feeTokenSymbol { get; set; }
        public string feeAmount { get; set; }
        public UInt64 createdAt { get; set; }
        public UInt64 updatedAt { get; set; }
        public string memo { get; set; }
        public int minterId { get; set; }
        public string minterAddress { get; set; }
        public BlockIdInfo blockIdInfo { get; set; }
        public StorageInfo storageInfo { get; set; }
    }

    public class MintsAndTotal
    {
        public int totalNum { get; set; }
        public List<Mint> mints { get; set; }
    }

    public class StorageInfo
    {
        public int accountId { get; set; }
        public int tokenId { get; set; }
        public int storageId { get; set; }
    }


}
