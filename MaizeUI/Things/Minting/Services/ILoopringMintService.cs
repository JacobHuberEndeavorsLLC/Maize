using LoopMintSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopMintSharp
{
    public interface ILoopringMintService
    {
        Task<StorageId> GetNextStorageId(string apiKey, int accountId, int sellTokenId);
        Task<CounterFactualNft> ComputeTokenAddress(string apiKey, CounterFactualNftInfo counterFactualNftInfo);
        Task<OffchainFee> GetOffChainFee(string apiKey, int accountId, int requestType, string tokenAddress);
        Task<OffchainFee> GetOffChainFeeWithAmount(string apiKey, int accountId, int amount, int requestType, string tokenAddress);
        Task<MintResponseData> MintNft(
            string apiKey,
            string exchange,
            int minterId,
            string minterAddress,
            int toAccountId,
            string toAddress,
            int nftType,
            string tokenAddress,
            string nftId,
            string amount,
            long validUntil,
            int royaltyPercentage,
            int storageId,
            int maxFeeTokenId,
            string maxFeeAmount,
            bool forceToMint,
            CounterFactualNftInfo counterFactualNftInfo,
            string eddsaSignature,
            string royaltyAddress);

        Task<RedPacketNftMintResponse> MintRedPacketNft
        (
            string apiKey,
            string apiSig,
            RedPacketNft redPacketNft
        );

        Task<NftBalance> GetTokenIdWithCheck(string apiKey, int accountId, string nftData);

        Task<CreateCollectionResult> CreateNftCollection(
            string apiKey,
            CreateCollectionRequest createCollectionRequest,
            string apiSig);

        Task<CollectionResult> FindNftCollection(
             string apiKey,
             int limit,
             int offset,
             string owner,
             string tokenAddress);

    }
}
