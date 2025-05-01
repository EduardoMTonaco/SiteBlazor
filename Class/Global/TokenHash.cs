namespace SiteBlazor.Class.Global
{
    public class TokenHash
    {
        public TokenHash(string fileToken)
        {
            FileToken = fileToken;
        }
        public static string FileToken {  get; set; }
    }
}
