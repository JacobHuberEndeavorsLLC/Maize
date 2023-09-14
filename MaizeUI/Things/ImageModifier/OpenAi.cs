using Newtonsoft.Json;
using RestSharp;
using System.Text;

namespace MaizeUI.Things
{
    public class OpenAi
    {
        readonly RestClient _client;
        public OpenAi()
        {
            _client = new RestClient("https://api.openai.com/v1/chat/completions");
        }

        private const string OpenAiApiKey = "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";
        public async Task<OpenAiResponse> QueryOpenAi(string prompt)
        {
            var request = new RestRequest();

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {OpenAiApiKey}");
            var payload = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                },
                temperature = 0.7
            };
            request.AddJsonBody(payload);
            try
            {
                var response = await _client.GetAsync(request);
                var data = JsonConvert.DeserializeObject<OpenAiResponse>(response.Content!);
                return data;
            }
            catch (HttpRequestException httpException)
            {
                Console.WriteLine(httpException.Message);
                return null;
            }
        }

        public class Choice
        {
            public int index { get; set; }
            public Message message { get; set; }
            public string finish_reason { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }

        public class OpenAiResponse
        {
            public string id { get; set; }
            public string @object { get; set; }
            public int created { get; set; }
            public string model { get; set; }
            public List<Choice> choices { get; set; }
            public Usage usage { get; set; }
        }

        public class Usage
        {
            public int prompt_tokens { get; set; }
            public int completion_tokens { get; set; }
            public int total_tokens { get; set; }
        }
        public static string GenerateNamePrompt(Dictionary<string, string> attributes)
        {
            StringBuilder prompt = new StringBuilder("Given the following attributes, what would be a fitting name for a character?\n");

            foreach (var entry in attributes)
            {
                prompt.AppendLine($"{entry.Key}: {entry.Value}");
            }

            return prompt.ToString();
        }
        public static string GenerateDescriptionPrompt(Dictionary<string, string> attributes)
        {
            StringBuilder prompt = new StringBuilder("Describe a character with the following attributes:\n");

            foreach (var entry in attributes)
            {
                prompt.AppendLine($"{entry.Key}: {entry.Value}");
            }

            return prompt.ToString();
        }


    }


}
