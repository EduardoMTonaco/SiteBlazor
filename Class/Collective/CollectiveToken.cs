using SiteBlazor.Class.Base;
using SiteBlazor.Class.DTO;

namespace SiteBlazor.Class.Collective
{
    public class CollectiveToken : BaseCollective
    {
        public List<TokenDTO> ObjList(TokenDTO objDTO)
        {
            try
            {
                List<TokenDTO> objList = new List<TokenDTO>();
                foreach (object[] array in SelectArray(objDTO))
                {
                    TokenDTO obj = FillClass<TokenDTO>(array);
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
        public TokenDTO ObjOne(TokenDTO objDTO)
        {
            try
            {
                foreach (object[] array in SelectArray(objDTO))
                {
                    TokenDTO obj = FillClass<TokenDTO>(array);
                    obj.FillSubClass();
                    return obj;
                }
                return new TokenDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
