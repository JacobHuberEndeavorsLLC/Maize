using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class Price
    {
        public string symbol { get; set; }
        public string price { get; set; }
        public int updatedAt { get; set; }
    }

    public class Prices
    {
        public List<Price> prices { get; set; }
    }

}
