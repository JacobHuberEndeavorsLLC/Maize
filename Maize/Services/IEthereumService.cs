using Nethereum.Web3;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Nethereum.ENS;

namespace Maize
{

    public interface IEthereumService
    {

        Task<string?> GetMetadataLink(string? tokenId, string? tokenAddress, int? nftType);

        Task<string?> GetMetadataLink(string? tokenId, string? tokenAddress, string? contractABI, string? functionName);

        Task<string?> GetEthAddressFromEns(string? ens);

        Task<string?> GetTokenNameFromAddress(string address);

        Task<string?> GetTokenSymbolFromAddress(string address);
    }
}
