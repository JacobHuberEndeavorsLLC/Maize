using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Maize.Models
{
    public class NftMetadata
    {
        public string? description { get; set; }
        public string? image { get; set; }
        public string? name { get; set; }
        public int royalty_percentage { get; set; }
        public string? animation_url { get; set; }
        public string? contentType { get; set; }

        //found with GME minted NFTs
        public string? collection_metadata { get; set; }

        public List<NftAttribute>? attributes { get; set; }

        [JsonIgnore] //we read this manually to be fail-safe
        public Dictionary<string, object>? properties { get; set; }

        public string? JSONContent { get; set; }
        public string? Error { get; set; }
    }

    public class NftAttribute
    {
        public string? trait_type { get; set; }
        public object? value { get; set; } //value can be either string or int
    }

    public class NftCollectionMetadata
    {
        public string? name { get; set; }
        public string? description { get; set; }

        public string? thumbnail_uri { get; set; }
        public string? banner_uri { get; set; }
        public string? avatar_uri { get; set; }
        public string? tile_uri { get; set; }

        public string? JSONContent { get; set; }
    }
}
