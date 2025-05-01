namespace SiteBlazor.InternAPI.Utility
{
    public class FileApiParmeters
    {
        public string Token { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }


        public string QueryString()
        { 
            return $"?Token={Token}&Path={Path}&FileName={FileName}";
        }
    }
}
