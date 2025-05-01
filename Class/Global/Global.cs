using SiteBlazor.Class.Collective;
using SiteBlazor.Class.DTO;

namespace SiteBlazor.Class.Global
{
    public class Global
    {
        public Global GlobalFill(string conection)
        {
           
            SQLHandler sql = new SQLHandler(conection);
            FillToken();

            return this;
        }
        private Global FillToken()
        {
            RandomKey randomKey = new RandomKey();
            TokenHash token = new TokenHash(randomKey.GenerateTokenHash());
            TokenDTO tokenDTO = new TokenDTO();
            tokenDTO.TokenTypeiD = 1;
            CollectiveToken collectiveToken = new CollectiveToken();
            List<TokenDTO> tokenDTOs = new List<TokenDTO>();
            tokenDTOs = collectiveToken.ObjList(tokenDTO);
            foreach (TokenDTO item in tokenDTOs)
            {
                item.FlDeleted = true;
                collectiveToken.Update(item);
            }
            tokenDTO = new TokenDTO();          
            tokenDTO.TokenKey = TokenHash.FileToken;
            tokenDTO.TokenTypeiD = 1;
            collectiveToken.Insert(tokenDTO);

            return this; 
        
        }
    }
}
