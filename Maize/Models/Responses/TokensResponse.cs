using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models.Responses
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class GasAmounts
    {
        public string distribution { get; set; }
        public string deposit { get; set; }
    }

    public class LuckyTokenAmounts
    {
        public string minimum { get; set; }
        public string maximum { get; set; }
        public string dust { get; set; }
    }

    public class OrderAmounts
    {
        public string minimum { get; set; }
        public string maximum { get; set; }
        public string dust { get; set; }
    }

    public class TokensResponse
    {
        public string type { get; set; }
        public int tokenId { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int decimals { get; set; }
        public int precision { get; set; }
        public int precisionForOrder { get; set; }
        public OrderAmounts orderAmounts { get; set; }
        public LuckyTokenAmounts luckyTokenAmounts { get; set; }
        public string fastWithdrawLimit { get; set; }
        public GasAmounts gasAmounts { get; set; }
        public bool enabled { get; set; }
    }


}
