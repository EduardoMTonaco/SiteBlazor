using SiteBlazor.Class.Base;
using SiteBlazor.Class.DTO;

namespace SiteBlazor.Class.Collective
{
    public class CollectiveDepartment : BaseCollective
    {
        public List<DepartmentDTO> ObjList(DepartmentDTO objDTO)
        {
            try
            {
                List<DepartmentDTO> objList = new List<DepartmentDTO>();
                foreach (object[] array in SelectArray(objDTO))
                {
                    DepartmentDTO obj = FillClass<DepartmentDTO>(array);
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
        public DepartmentDTO ObjOne(DepartmentDTO objDTO)
        {
            try
            {
                foreach (object[] array in SelectArray(objDTO))
                {
                    DepartmentDTO obj = FillClass<DepartmentDTO>(array);
                    obj.FillSubClass();
                    return obj;
                }
                return new DepartmentDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
