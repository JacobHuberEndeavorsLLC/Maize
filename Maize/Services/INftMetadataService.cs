using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using Maize.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Maize
{
    public interface INftMetadataService
    {
        public string? MakeIPFSLink(string? link);

        Task<NftCollectionMetadata?> GetCollectionMetadata(string URL, CancellationToken cancellationToken = default);

        Task<NftMetadata?> GetMetadata(string link, CancellationToken cancellationToken = default);

        public NftMetadata? GetMetadataFromResponse(string response);

        Task<string?> GetContentTypeFromURL(string link, CancellationToken cancellationToken = default);

    }
}
