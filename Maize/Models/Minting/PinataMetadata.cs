using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class PinataMetadata
    {
        public string name { get; set; }
        public KeyValues keyvalues { get; set; }
    }

    public class KeyValues
    {
        public string nameKey { get; set; }
    }
}
