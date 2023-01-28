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
    public class NftMetadataService : INftMetadataService, IDisposable
    {
        private string _ipfsBaseUrl;

        readonly RestClient _client;

        public NftMetadataService(IConfiguration config) : this("")
        {
            _ipfsBaseUrl = config.GetSection("services:pinata:endpoint").Value;
        }

        public NftMetadataService(string ipfsBaseUrl)
        {
            _client = new RestClient(ipfsBaseUrl);
            _ipfsBaseUrl = ipfsBaseUrl;
            _client.AddDefaultHeader("Accept", "Accept: text/plain");
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public string IPFSBaseUrl { get { return _ipfsBaseUrl; } }

        public string? MakeIPFSLink(string? link)
        {
            if (link == null) return null;

            var modLink = 
                link.StartsWith("ipfs://ipfs/") ? _ipfsBaseUrl + link.Remove(0, 12) : //handle ERC721 uri glitches with extra /ipfs prefix
                    link.StartsWith("ipfs://") ? _ipfsBaseUrl + link.Remove(0, 7) : link; //remove the ipfs portion and add base

            //try to recover from mismints by escaping the filename part of the URL
            //unfortunately Uri() will not fix this as it's not considered part of the data string, so we have to explicitly
            //split at the last slash and explicitly escape the filename portion
            var idx = modLink.LastIndexOf("/");
            if (idx != -1)
            {
                var fileNamePortion = modLink.Substring(idx + 1);
                if (!Uri.IsWellFormedUriString(fileNamePortion, UriKind.Relative))
                    fileNamePortion = Uri.EscapeDataString(Uri.UnescapeDataString(fileNamePortion));
                modLink = modLink.Substring(0, idx + 1) + fileNamePortion;
            }

            return modLink;
        }

        public async Task<NftCollectionMetadata?> GetCollectionMetadata(string URL, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest(URL);
            try
            {
                request.Timeout = 10000; //we can't afford to wait forever here, 10s must be enough
                var response = await _client.GetAsync(request, cancellationToken);
                var token = JToken.Parse(response.Content!);
                var metadata = token.ToObject<NftCollectionMetadata>();
                if ((token != null) && (metadata != null))
                    metadata.JSONContent = token.ToString(Formatting.Indented);
                return metadata;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.StackTrace + "\n" + e.Message);
                return null;
            }
        }

        public async Task<NftMetadata?> GetMetadata(string link, CancellationToken cancellationToken = default)
        {
            link = MakeIPFSLink(link)!;
            //there is a fallback for if the metadata fails on the first try because
            //loopring deployed two different contracts for the nfts so some
            //metadata.json needs to be referenced directly while others are in a folder in ipfs
            NftMetadata? nmd = await GetMetadataFromURL(link, cancellationToken);
            if (nmd != null)
            {
                var forbidden = (nmd.description == "Request failed with status code Forbidden");
                if (forbidden)
                    return nmd;
            }
            var trySubFolder = (nmd == null);
            if (!trySubFolder)
                trySubFolder = ((nmd?.Error != null) && (nmd.JSONContent?.Contains("metadata.json") ?? false));
            if (trySubFolder)
                nmd = await GetMetadataFromURL(link + "/metadata.json", cancellationToken);
            return nmd;
        }

        public NftMetadata? GetMetadataFromResponse(string response)
        {
            try
            {
                JToken? token = null;
                try
                {
                    token = JToken.Parse(response!);
                }
                catch (Exception e)
                {
                    var metadataError = new NftMetadata();
                    metadataError.Error = e.Message;
                    metadataError.JSONContent = response;
                    return metadataError;
                }
                var metadata = token?.ToObject<NftMetadata>();
                if ((token != null) && (metadata != null))
                {
                    metadata.JSONContent = token.ToString(Formatting.Indented);
                    var propToken = token["properties"];
                    try
                    {
                        if (propToken is JObject)
                            metadata.properties = propToken.ToObject<Dictionary<string, object>>();
                        else if (propToken is JArray jarr)
                        {
                            metadata.properties = new();
                            foreach (var arrToken in jarr)
                            {
                                try
                                {
                                    if (arrToken is JObject obj)
                                        metadata.properties.Add(obj["key"]!.ToString(), obj["value"]!.ToObject<object>()!);
                                }
                                catch
                                {
                                    return null;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e.StackTrace + "\n" + e.Message);
                    }
                }
                return metadata;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.StackTrace + "\n" + e.Message);
                return null;
            }
        }

        private async Task<NftMetadata?> GetMetadataFromURL(string URL, CancellationToken cancellationToken = default)
        {
            var requestUrl = URL.Split('/');
            var request = new RestRequest($"{requestUrl[4]}");
            try
            {
                request.Timeout = 10000; //we can't afford to wait forever here, 10s must be enough
                var response = await _client.GetAsync(request, cancellationToken);
                return GetMetadataFromResponse(response.Content!);
            }
            catch (Exception e)
            {
                if (e.Message == "Request failed with status code Forbidden")
                {
                    var info = new NftMetadata() { description = e.Message };
                    return info;
                }
                Trace.WriteLine(e.StackTrace + "\n" + e.Message);
                return null;
            }
        }

        public async Task<string?> GetContentTypeFromURL(string link, CancellationToken cancellationToken = default)
        {
            link = MakeIPFSLink(link)!;
            var request = new RestRequest(link, Method.Head);

            request.Timeout = 20000; //we can't afford to wait forever here, 20s must be enough
            var response = await _client.HeadAsync(request, cancellationToken); //Send head request so we only get header not the content

            //in case of an error, make a full request with a shorter timeout to get the actual error message in response.Content
            if (!response.IsSuccessful)
            {
                request.Timeout = 1000;
                response = await _client.GetAsync(request, cancellationToken);
                var errMsg = response.Content;
                if (string.IsNullOrEmpty(errMsg))
                    errMsg = response.StatusDescription;
                throw new Exception(errMsg);
            }
            return response?.ContentType;
        }

    }
}
