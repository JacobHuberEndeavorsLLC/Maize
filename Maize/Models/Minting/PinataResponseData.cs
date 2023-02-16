using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class PinataResponseData
    {
        public string IpfsHash { get; set; }
        public int PinSize { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
