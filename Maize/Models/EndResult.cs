using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class ResultInfo
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class EnsResult
    {
        public ResultInfo resultInfo { get; set; }
        public string data { get; set; }
    }
}
