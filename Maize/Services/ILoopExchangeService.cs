using Maize;
using Maize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public interface ILoopExchangeService
    {
        Task<LoopExchange> GetLoopPhunksData();
        
    }
}
