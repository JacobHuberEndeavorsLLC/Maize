using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Models
{
    public class PinataAuthenticationSuccess
    {
        public string message { get; set; }
    }
    public class Error
    {
        public string reason { get; set; }
        public string details { get; set; }
    }

    public class PinataAuthenticationFail
    {
        public Error error { get; set; }
    }


}
