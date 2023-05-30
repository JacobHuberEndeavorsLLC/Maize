namespace Maize.Models
{
    public class ResultInfo
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class ResolveEnsOrNameResponse
    {
        public ResultInfo resultInfo { get; set; }
        public string data { get; set; }
    }


}
