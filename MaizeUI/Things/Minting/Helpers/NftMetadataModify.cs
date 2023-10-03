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
}
