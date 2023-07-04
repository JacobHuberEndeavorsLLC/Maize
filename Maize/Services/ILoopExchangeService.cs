using Maize.Models;
using Maize.Models.Responses;

namespace Maize
{
    public interface ILoopExchangeService
    {
        Task<string> GetUser(string owner);
    }
}
