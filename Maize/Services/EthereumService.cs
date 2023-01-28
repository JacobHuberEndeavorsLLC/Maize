using Nethereum.Web3;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Nethereum.ENS;
using Nethereum.JsonRpc.Client;

namespace Maize
{

    public class EthereumService : IEthereumService
    {
        public const string CF_NFTTokenAddress = "0xB25f6D711aEbf954fb0265A3b29F7b9Beba7E55d";
        private Web3 web3 = new("https://mainnet.infura.io/v3/53173af3389645d18c3bcac2ee9a751c");

        public async Task<string?> GetMetadataLink(string? tokenId, string? tokenAddress, int? nftType)
        {
            if (tokenId == null) return null;
            //call erc1155 or erc 721 contract depending on type 
            string? metadataLink = nftType == 0
                ? await GetMetadataLink(tokenId, tokenAddress, "function uri(uint256 id) external view returns (string memory)", "uri") 
                : await GetMetadataLink(tokenId, tokenAddress, "function tokenURI(uint256 tokenId) public view virtual override returns (string memory)", "tokenURI");
            if (metadataLink == null)
                metadataLink = await GetMetadataLink(tokenId, CF_NFTTokenAddress, "function uri(uint256 id) external view returns (string memory)", "uri"); //call counterfactual nft contract

            return metadataLink;
        }

        public async Task<string?> GetMetadataLink(string? tokenId, string? tokenAddress, string? contractABI, string? functionName)
        {
            try
            {
                var contract = web3.Eth.GetContract(contractABI, tokenAddress);
                var function = contract.GetFunction(functionName);
                object[] parameters = new object[1] { tokenId! };
                var uri = await function.CallAsync<string>(parameters);
                return uri;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.StackTrace + "\n" + e.Message);
                return null;
            }
        }

        public async Task<string?> GetEthAddressFromEns(string? ens)
        {

            var ensService = new ENSService(web3);
           
            try
            {
                return await ensService.ResolveAddressAsync(ens);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.StackTrace + "\n" + e.Message);
                return null;
            }
        }

        public async Task<string?> GetTokenNameFromAddress(string address)
        {
            try
            {
                const string abi = "function name() public view returns (string)";
                var tokenContract = web3.Eth.GetContract(abi, address);
                var function = tokenContract.GetFunction("name");
                string tokenName = "";
                try
                {
                    tokenName = await function.CallAsync<string>();
                }
                catch (Exception)
                {
                    //try alternative ABI returning bytes32?! See maker token
                    var tempResBytes = await function.CallRawAsync(function.CreateCallInput());
                    tokenName = System.Text.Encoding.ASCII.GetString(tempResBytes).TrimEnd((Char)0);
                }
                return tokenName;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.StackTrace + "\n" + e.Message);
                return null;
            }
        }

        public async Task<string?> GetTokenSymbolFromAddress(string address)
        {
            try
            {
                const string abi = "function symbol() public view returns (string)";
                var tokenContract = web3.Eth.GetContract(abi, address);
                var function = tokenContract.GetFunction("symbol");
                string tokenSymbol = "";
                try
                {
                    tokenSymbol = await function.CallAsync<string>();
                }
                catch (Exception)
                {
                    //try alternative ABI returning bytes32?! See maker token
                    var tempResBytes = await function.CallRawAsync(function.CreateCallInput());
                    tokenSymbol = System.Text.Encoding.ASCII.GetString(tempResBytes).TrimEnd((Char)0);
                }

                return tokenSymbol;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.StackTrace + "\n" + e.Message);
                return null;
            }
        }
    }
}
