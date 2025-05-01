using SiteBlazor.Class.Base;
using SiteBlazor.Class.DTO;

namespace SiteBlazor.Class.Collective
{
    public class CollectiveTokenType : BaseCollective
    {
        public List<TokenTypeDTO> ObjList(TokenTypeDTO objDTO)
        {
            try
            {
                List<TokenTypeDTO> objList = new List<TokenTypeDTO>();
                foreach (object[] array in SelectArray(objDTO))
                {
                    TokenTypeDTO obj = FillClass<TokenTypeDTO>(array);
                    obj.FillSubClass();
                    objList.Add(obj);
                }
                return objList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TokenTypeDTO ObjOne(TokenTypeDTO objDTO)
        {
            try
            {
                foreach (object[] array in SelectArray(objDTO))
                {
                    TokenTypeDTO obj = FillClass<TokenTypeDTO>(array);
                    obj.FillSubClass();
                    return obj;
                }
                return new TokenTypeDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
