using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCalls.Helpers
{
    public static class FormatJson
    {
        public static string SaveJsonToDownloadsFolder(string jsonData, string fileName)
        {
            var downloadsPath = GetDownloadsFolderPath();
            var fullPath = Path.Combine(downloadsPath, fileName);

            File.WriteAllText(fullPath, jsonData);
            return fullPath;
        }
        public static string GetDownloadsFolderPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        }
    }

    public class JsonData
    {
        public string image { get; set; }
        public string animation_url { get; set; }
    }
}
