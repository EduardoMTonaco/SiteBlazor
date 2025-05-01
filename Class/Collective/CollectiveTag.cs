using SiteBlazor.Class.Base;
using SiteBlazor.Class.DTO;
using System.Diagnostics.Eventing.Reader;

namespace SiteBlazor.Class.Collective
{
    public class CollectiveTag : BaseCollective
    {
        public List<DepartmentDTO> DepartmentList = new List<DepartmentDTO>();
        public List<TagDTO> ObjList(TagDTO objDTO)
        {
            try
            {
                List<TagDTO> objList = new List<TagDTO>();
                if (DepartmentList.Count > 0)
                {
                    foreach (DepartmentDTO department in DepartmentList)
                    {
                        objDTO.DepartmentId = department.DepartmentId;
                        foreach (object[] array in SelectArray(objDTO))
                        {
                            TagDTO obj = FillClass<TagDTO>(array);
                            obj.FillSubClass();
                            objList.Add(obj);
                        }
                    }                    
                }
                else
                {
                    foreach (object[] array in SelectArray(objDTO))
                    {
                        TagDTO obj = FillClass<TagDTO>(array);
                        obj.FillSubClass();
                        objList.Add(obj);
                    }
                }

                return objList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TagDTO ObjOne(TagDTO objDTO)
        {
            try
            {
                foreach (object[] array in SelectArray(objDTO))
                {
                    TagDTO obj = FillClass<TagDTO>(array);
                    obj.FillSubClass();
                    return obj;
                }
                return new TagDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CollectiveTag FillDepartmentList(string departmentName = "")
        {
            if (string.IsNullOrEmpty(departmentName))
            {
                return this;
            }
            DepartmentDTO objDTO = new DepartmentDTO();
            objDTO.Name = departmentName;
            CollectiveDepartment collective = new CollectiveDepartment();
            DepartmentList = new CollectiveDepartment().ObjList(objDTO);
            return this;
        }
    }
}
