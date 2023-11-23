using Maize.Models;
namespace Maize
{
    public interface INftMetadataService
    {
        public string? MakeIPFSLink(string? link);

        Task<NftCollectionMetadata?> GetCollectionMetadata(string URL, CancellationToken cancellationToken = default);

        Task<NftMetadata?> GetMetadata(string link, CancellationToken cancellationToken = default);

        public NftMetadata? GetMetadataFromResponse(string response);
        Task<string> GetMetadataFromCid(string cid);
        Task<string> SaveFileFromCid(string cid);

        Task<string?> GetContentTypeFromURL(string link, CancellationToken cancellationToken = default);

    }
}