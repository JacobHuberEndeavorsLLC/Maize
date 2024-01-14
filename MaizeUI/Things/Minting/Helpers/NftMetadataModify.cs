using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

public class MetadataModifier
{
    public static (int, string, string) UpdateAndFetchRoyalty(string metadataFilePath, string nftCid, string animationCid, string selectedCollectionAddress)
    {
        // Read the JSON metadata file into a string
        string jsonMetadata = File.ReadAllText(metadataFilePath);

        // Deserialize the JSON string to a Metadata object
        Metadata metadataObj = JsonConvert.DeserializeObject<Metadata>(jsonMetadata);

        // Replace the placeholders
        metadataObj.image = $"ipfs://{nftCid}";
        metadataObj.animation_url = animationCid == null ? $"ipfs://{nftCid}" : $"ipfs://{animationCid}";
        metadataObj.collection_metadata = $"https://nftinfos.loopring.io/{selectedCollectionAddress}";

        // Extract the royalty percentage and name
        int royaltyPercentage = metadataObj.royalty_percentage;
        string name = metadataObj.name;

        // Serialize the updated Metadata object back to a JSON string
        string updatedJsonMetadata = JsonConvert.SerializeObject(metadataObj, Formatting.Indented);

        // Return the extracted royalty percentage, name, and updatedJsonMetadata
        return (royaltyPercentage, name, updatedJsonMetadata);
    }
    public static string RemoveCollectionMetadataAndMintChannel(string metadataTemplate)
    {
        try
        {
            // Parse the JSON string into a JObject
            JObject metadataObject = JObject.Parse(metadataTemplate);

            // Remove the "collection_metadata" and "mint_channel" properties
            metadataObject.Remove("collection_metadata");
            metadataObject.Remove("mint_channel");

            // Convert the modified JObject back to a JSON string
            string modifiedMetadata = metadataObject.ToString();

            return modifiedMetadata;
        }
        catch (JsonReaderException)
        {
            // Handle JSON parsing errors
            return null;
        }
    }
    public class Metadata
    {
        public string image { get; set; }
        public string animation_url { get; set; }
        public string name { get; set; }
        public int royalty_percentage { get; set; }
        public string description { get; set; }
        public string collection_metadata { get; set; }
        public string mint_channel { get; set; }
        public Dictionary<string, string> properties { get; set; }
        public List<Dictionary<string, string>> attributes { get; set; }
    }
}
