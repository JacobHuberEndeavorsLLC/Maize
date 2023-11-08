using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models.Responses
{
    public class RefreshNftResponse
    {
        public string name { get; set; }
        public string nftId { get; set; }
        public string status { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
    }

}
