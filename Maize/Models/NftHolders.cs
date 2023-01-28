using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class NftHolder
    {
        public int accountId { get; set; }
        public int tokenId { get; set; }
        public string amount { get; set; }
    }

    public class NftHoldersAndTotal
    {
        public int totalNum { get; set; }
        public List<NftHolder> nftHolders { get; set; }
    }
    public class NftHolderAndNftData
    {

        public string walletAddress { get; set; }
        public string nftName { get; set; }
        public string amount { get; set; }
        public string nftData { get; set; }
        public int accountId { get; set; }
        public int tokenId { get; set; }
    }

}
