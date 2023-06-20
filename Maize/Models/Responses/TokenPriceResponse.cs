using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models.Responses
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class TokenPrice
    {
        public string token { get; set; }
        public string price { get; set; }
    }

    public class ResultInfo
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class TokenPriceResponse
    {
        public ResultInfo resultInfo { get; set; }
        public List<TokenPrice> data { get; set; }
    }


}
