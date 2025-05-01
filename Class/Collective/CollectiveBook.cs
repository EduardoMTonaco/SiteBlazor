using SiteBlazor.Class.Base;
using SiteBlazor.Class.DTO;

namespace SiteBlazor.Class.Collective
{
    public class CollectiveBook : BaseCollective
    {
        public List<BooksDTO> ObjList(BooksDTO objDTO)
        {
            try
            {
                List<BooksDTO> objList = new List<BooksDTO>();
                foreach (object[] array in SelectArray(objDTO))
                {
                    BooksDTO obj = FillClass<BooksDTO>(array);
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
        public BooksDTO ObjOne(BooksDTO objDTO)
        {
            try
            {
                foreach (object[] array in SelectArray(objDTO))
                {
                    BooksDTO obj = FillClass<BooksDTO>(array);
                    obj.FillSubClass();
                    return obj;
                }
                return new BooksDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
