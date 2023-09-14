using Newtonsoft.Json;
using SixLabors.ImageSharp.Processing.Processors.Transforms;
using System.Text.RegularExpressions;

namespace MaizeUI.Things
{
    public class Components
    {
        public static HashSet<string> previousHashes = new HashSet<string>(); // Consider persisting this.
        public static List<string> selectedSprites = new List<string>();

        public static void CreateMetadataJsonForSprite(string spriteFilePath, List<string> orderedSprites, string collectionAddress, int royaltyPercentage, string nftName, string nftDescription)
        {
            var properties = ExtractPropertiesFromSprites(orderedSprites);

            properties["series"] = "alpha: mystic maize vault";

            var attributes = properties.Select(p => new { trait_type = p.Key, value = p.Value }).ToArray();

            var nftPropertiesHash = Helpers.HashDictionary(properties);

            // Create metadata object
            var metadata = new
            {
                image = "ipfs://IMAGE_PLACEHOLDER",
                animation_url = "ipfs://ANIMATION_PLACEHOLDER",
                name = nftName,
                royalty_percentage = royaltyPercentage,
                description = nftDescription,
                collection_metadata = $"https://nftinfos.loopring.io/{collectionAddress}",
                mint_channel = "Maize",
                properties = properties,
                attributes = attributes
            };

            // Serialize to JSON and write to file
            string jsonOutput = JsonConvert.SerializeObject(metadata, Formatting.Indented);
            string jsonFilePath = Path.ChangeExtension(spriteFilePath, ".json");
            File.WriteAllText(jsonFilePath, jsonOutput);
        }
        public static bool CheckForDuplicates(List<string> orderedSprites)
        {
            var currentHash = Helpers.HashDictionary(ExtractPropertiesFromSprites(orderedSprites));
            if (previousHashes.Contains(currentHash)) return false;

            previousHashes.Add(currentHash);
            return true;
        }
        public static Dictionary<string, string> ExtractPropertiesFromSprites(List<string> orderedSprites)
        {
            var properties = new Dictionary<string, string>();

            foreach (var spritePath in orderedSprites)
            {
                var directoryName = new DirectoryInfo(Path.GetDirectoryName(spritePath)).Name;
                directoryName = Regex.Replace(directoryName, @"^\s*\d+_|&$", "");
                directoryName = directoryName.Replace("_", " "); // Replace underscore with space

                var spriteName = Path.GetFileNameWithoutExtension(spritePath);
                spriteName = Regex.Replace(spriteName, @"^X#\d{1,2}", "");

                var propertyParts = spriteName.Split(new char[] { '-', '+' });
                for (int i = 0; i < propertyParts.Length; i++)
                {
                    int indexOfEquals = propertyParts[i].IndexOf('=');
                    if (indexOfEquals != -1)
                    {
                        propertyParts[i] = propertyParts[i].Substring(0, indexOfEquals);
                    }
                }

                if (propertyParts.Length >= 3) // Expecting: [property, value, remainder]
                {
                    var propertyName = propertyParts[0].Trim().Replace("_", " ");
                    var propertyValue = propertyParts[1].Trim().Replace("_", " ");
                    var remainder = propertyParts[2].Trim().Replace("_", " ");
                    properties[directoryName] = propertyName;
                    properties[propertyValue] = remainder;
                }
                else if (propertyParts.Length == 2) // Expecting: [property, value]
                {
                    var propertyName = propertyParts[0].Trim().Replace("_", " ");
                    var propertyValue = propertyParts[1].Trim().Replace("_", " ");
                    properties[propertyName] = propertyValue;
                }
                else
                {
                    spriteName = spriteName.Replace("_", " ");
                    properties[directoryName] = spriteName;
                }
            }

            return properties;
        }


        public static List<string> StackRandomSpritesFromSubdirectories(string baseDirectory)
        {
            List<string> localSelectedSprites = new List<string>(); // Create a new list here

            // Get all directories in the base directory
            var allDirectories = Directory.GetDirectories(baseDirectory).ToList();

            foreach (var directory in allDirectories)
            {
                localSelectedSprites.AddRange(Helpers.SelectSpritesFromDirectory(directory)); // Use local list
            }

            // Replace sprites based on relationships after all have been selected
            var relationships = ExtractRelationshipsFromDirectory(baseDirectory);
            ReplaceSpritesBasedOnRelationships(localSelectedSprites, relationships); // Use local list

            return localSelectedSprites.OrderBy(sprite =>
            {
                var dirInfo = new DirectoryInfo(Path.GetDirectoryName(sprite));

                // Find the directory starting with a number followed by '_'
                while (!Regex.IsMatch(dirInfo.Name, @"^\d+_") && dirInfo.Parent != null)
                {
                    dirInfo = dirInfo.Parent;
                }

                string[] parts = dirInfo.Name.Split('_');
                int number = 0;
                if (parts.Length >= 2 && int.TryParse(parts[0], out number))
                {
                    return number;
                }

                return int.MaxValue;
            })
            .ThenBy(sprite =>
            {
                // Order by the immediate parent directory name alphabetically
                var parentDir = new DirectoryInfo(Path.GetDirectoryName(sprite));
                return parentDir.Name;
            })
            .ToList();
        }
        public static void ProcessSprites(List<string> orderedSprites, string iterationDirectory)
        {
            if (orderedSprites.Count > 0)
            {
                using (var firstSprite = Image.Load(orderedSprites[0]))
                {
                    using (var stackedSprite = new Image<Rgba32>(firstSprite.Width, firstSprite.Height))
                    {
                        var iterationNumber = Helpers.GetIterationNumberFromFilePath(iterationDirectory);
                        //string outputPath = Path.Combine(iterationDirectory, $"metadata{iterationNumber}.png");
                        //var metadataOutput = CreateMetadataJsonForSprite(outputPath, orderedSprites, collectionAddress, royaltyPercentage, nftName, nftDescription);

                        //File.WriteAllText(metadataOutput.filepath, metadataOutput.output);

                        foreach (var spritePath in orderedSprites)
                        {
                            if (!spritePath.Contains("background"))
                            {
                                using (var sprite = Image.Load(spritePath))
                                {
                                    stackedSprite.Mutate(ctx => ctx.DrawImage(sprite, new Point(0, 0), 1f));
                                }
                            }
                        }

                        string outputFileName = $"sprite{iterationNumber}_1x.png";
                        var outputPath = Path.Combine(iterationDirectory, outputFileName);
                        stackedSprite.Save(outputPath);

                        Helpers.SaveResizedSprite(stackedSprite, 2, $"sprite{iterationNumber}_2x.png", iterationDirectory);
                        Helpers.SaveResizedSprite(stackedSprite, 3, $"sprite{iterationNumber}_3x.png", iterationDirectory);

                        var backgroundColor = Helpers.GetDominantColor(orderedSprites.First());
                        CreatePFPImageFromSprite(stackedSprite, backgroundColor, iterationDirectory);
                    }
                }
            }
        }
        public static void ProcessMetadata(List<string> orderedSprites, string iterationDirectory, string collectionAddress, int royaltyPercentage, string nftName, string nftDescription)
        {
            if (orderedSprites.Count > 0)
            {
                using (var firstSprite = Image.Load(orderedSprites[0]))
                {
                    using (var stackedSprite = new Image<Rgba32>(firstSprite.Width, firstSprite.Height))
                    {
                        var iterationNumber = Helpers.GetIterationNumberFromFilePath(iterationDirectory);
                        string outputPath = Path.Combine(iterationDirectory, $"metadata{iterationNumber}.png");
                        CreateMetadataJsonForSprite(outputPath, orderedSprites, collectionAddress, royaltyPercentage, nftName, nftDescription);
                    }
                }
            }
        }

        private static void CreatePFPImageFromSprite(Image<Rgba32> sprite, Rgba32 backgroundColor, string baseDirectory)
        {
            int sectionWidth = 27;
            int sectionHeight = 27;

            using (var pfpImage = new Image<Rgba32>(27, 27, backgroundColor))
            {
                // Crop the section from the sprite
                var spriteSection = sprite.Clone(ctx => ctx.Crop(new Rectangle(6, 28, sectionWidth, sectionHeight)));

                // Overlay the cropped sprite section onto the new image
                pfpImage.Mutate(ctx => ctx.DrawImage(spriteSection, new Point(0, 0), 1f));

                string pfpFileName = $"pfp{Helpers.GetIterationNumberFromFilePath(baseDirectory)}.png";
                string pfpPath = Path.Combine(baseDirectory, pfpFileName);

                pfpImage.Save(pfpPath);
                ResizeImage(pfpPath);
            }
        }



        public static void ReplaceSpritesBasedOnRelationships(List<string> selectedSprites, Dictionary<string, string> relationships)
        {
            // Check relationships
            foreach (var relationship in relationships)
            {
                var mainItem = relationship.Key;
                var relatedItem = relationship.Value;

                // Check if main item and any related item is in selectedSprites
                bool hasMainItem = selectedSprites.Any(s => s.Contains(mainItem) && !s.Contains("="));
                bool hasRelatedItem = selectedSprites.Any(s => s.Contains(relatedItem) && !s.Contains("="));
                bool hasCombinedItem = selectedSprites.Any(s => s.Contains(mainItem + "=" + relatedItem));

                // If both main item and its related part is in list, but the combined item isn't, add the combined one and remove the standalone items
                if (hasMainItem && hasRelatedItem && !hasCombinedItem)
                {
                    var directoryOfMainItem = new DirectoryInfo(Path.GetDirectoryName(selectedSprites.First(s => s.Contains(mainItem) && !s.Contains("=")))).FullName;

                    var combinedSpritePath = Directory.GetFiles(directoryOfMainItem, mainItem + "=" + relatedItem + "*.png").FirstOrDefault();
                    if (combinedSpritePath != null)
                    {
                        // Add combined item
                        selectedSprites.Add(combinedSpritePath);

                        // Remove standalone items
                        selectedSprites.RemoveAll(s => s.Contains(mainItem) && !s.Contains("="));
                    }
                }
            }
        }

        public static Dictionary<string, string> ExtractRelationshipsFromDirectory(string baseDirectory)
        {
            Dictionary<string, string> relationships = new Dictionary<string, string>();

            var allFilesWithDash = Directory.GetFiles(baseDirectory, "*=*.png", SearchOption.AllDirectories);
            foreach (var file in allFilesWithDash)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var parts = fileName.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    relationships[parts[0]] = parts[1];
                }
            }

            return relationships;
        }
        public static void ResizeImage(string filePath)
        {
            using (Image image = Image.Load(filePath))
            {
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(600, 600),
                    Sampler = new NearestNeighborResampler()
                }));
                image.Save(filePath);
            }
        }
    }
}
