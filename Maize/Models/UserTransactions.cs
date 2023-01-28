using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class UserTransactionsBlockIdInfo
    {
        public int blockId { get; set; }
        public int indexInBlock { get; set; }
    }

    public class UserTransactions
    {
        public int totalNum { get; set; }
        public List<Transaction> transactions { get; set; }
    }

    public class UserTransactionsStorageInfo
    {
        public int accountId { get; set; }
        public int tokenId { get; set; }
        public int storageId { get; set; }
    }

    public class Transaction
    {
        public int id { get; set; }
        public string txType { get; set; }
        public string hash { get; set; }
        public string symbol { get; set; }
        public string amount { get; set; }
        public int receiver { get; set; }
        public string txHash { get; set; }
        public string feeTokenSymbol { get; set; }
        public string feeAmount { get; set; }
        public string status { get; set; }
        public string progress { get; set; }
        public object timestamp { get; set; }
        public int blockNum { get; set; }
        public object updatedAt { get; set; }
        public string receiverAddress { get; set; }
        public string senderAddress { get; set; }
        public string memo { get; set; }
        public int requestId { get; set; }
        public WithdrawalInfo withdrawalInfo { get; set; }
        public UserTransactionsBlockIdInfo blockIdInfo { get; set; }
        public UserTransactionsStorageInfo storageInfo { get; set; }
    }

    public class WithdrawalInfo
    {
        public string recipient { get; set; }
        public string fastStatus { get; set; }
        public string distributeHash { get; set; }
    }


}
