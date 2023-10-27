using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

public class MetadataModifier
{
    public static void UpdateMetadataFiles(string folderPath, string ipfsFolder)
    {
        foreach (var file in Directory.GetFiles(folderPath, "*.json"))
        {
            var content = File.ReadAllText(file);

            // Deserialize JSON content to JObject
            var jsonObject = JObject.Parse(content);

            // Extract the number from the "name" property
            var name = jsonObject["name"].ToString();
            var numberMatch = Regex.Match(name, @"#(\d+)");
            if (numberMatch.Success)
            {
                var number = numberMatch.Groups[1].Value;

                // Update 'image' and 'animation_url' properties with the extracted number
                jsonObject["image"] = $"ipfs://{ipfsFolder}/nft{number}.png";
                jsonObject["animation_url"] = $"ipfs://{ipfsFolder}/nft{number}.png";

                // Serialize the updated JObject back to string
                var updatedContent = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

                // Save the updated content back to the file
                File.WriteAllText(file, updatedContent);
            }
        }
    }
    public static (int, string, string) UpdateAndFetchRoyalty(string metadataFilePath, string nftCid, string selectedCollectionAddress)
    {
        // Read the JSON metadata file into a string
        string jsonMetadata = File.ReadAllText(metadataFilePath);

        // Deserialize the JSON string to a Metadata object
        Metadata metadataObj = JsonConvert.DeserializeObject<Metadata>(jsonMetadata);

        // Replace the placeholders
        metadataObj.image = $"ipfs://{nftCid}";
        metadataObj.animation_url = $"ipfs://{nftCid}";
        metadataObj.collection_metadata = $"https://nftinfos.loopring.io/{selectedCollectionAddress}";

        // Extract the royalty percentage and name
        int royaltyPercentage = metadataObj.royalty_percentage;
        string name = metadataObj.name;

        // Serialize the updated Metadata object back to a JSON string
        string updatedJsonMetadata = JsonConvert.SerializeObject(metadataObj, Formatting.Indented);

        // Return the extracted royalty percentage, name, and updatedJsonMetadata
        return (royaltyPercentage, name, updatedJsonMetadata);
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
