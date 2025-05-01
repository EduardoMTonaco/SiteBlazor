using SiteBlazor.Class.Base;
using SiteBlazor.Class.DTO;

namespace SiteBlazor.Class.Collective
{
    public class CollectiveGender : BaseCollective
    {
        public List<GenderDTO> ObjList(GenderDTO objDTO)
        {
            try
            {
                List<GenderDTO> objList = new List<GenderDTO>();
                foreach (object[] array in SelectArray(objDTO))
                {
                    GenderDTO obj = FillClass<GenderDTO>(array);
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
        public GenderDTO ObjOne(GenderDTO objDTO)
        {
            try
            {
                foreach (object[] array in SelectArray(objDTO))
                {
                    GenderDTO obj = FillClass<GenderDTO>(array);
                    obj.FillSubClass();
                    return obj;
                }
                return new GenderDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
