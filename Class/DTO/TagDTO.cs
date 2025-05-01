using SiteBlazor.Class.Attributes;
using SiteBlazor.Class.Base;
using SiteBlazor.Class.Collective;
using System.Security.Cryptography;

namespace SiteBlazor.Class.DTO
{
    public class TagDTO : BaseDTO
    {

        public TagDTO()
        {
            _tagId = int.MinValue;
            _name = "";
            _departmentId = int.MinValue;
        }
        private int _tagId;
        private string _name;
        private int _departmentId;
        public DepartmentDTO Department = new DepartmentDTO();
        public List<DepartmentDTO> DepartmentList = new List<DepartmentDTO>();

        [DisplayAttributes(true, "TagId", 0)]
        public int TagId
        {
            get { return _tagId; }
            set { _tagId = value; }
        }
        [DisplayAttributes(false, "Name", 1)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [DisplayAttributes(false, "DepartmentId", 2)]
        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
       
        public override string SelectCommand()
        {
            return CreateSelectCommand(this);
        }

        public override string Table()
        {
            return "Tag";
        }
        private DepartmentDTO FindDepartment(int id)
        {
            DepartmentDTO objDTO = new DepartmentDTO();
            objDTO.DepartmentId = id;
            CollectiveDepartment collective = new CollectiveDepartment();
            objDTO = collective.ObjOne(objDTO);
            return objDTO;
        }
        private TagDTO FillDepartmentList(string departmentName)
        {
            DepartmentDTO objDTO = new DepartmentDTO();
            objDTO.Name = departmentName;
            CollectiveDepartment collective = new CollectiveDepartment();
            DepartmentList = new CollectiveDepartment().ObjList(objDTO);
            return this;
        }
        public void FillDepartment()
        {
            this.Department = FindDepartment(this.DepartmentId);
        }
        public override void FillSubClass()
        {
            FillDepartment();
        }
        public override string UpdateCommand()
        {
            return Update(this);
        }

        public override string InsertCommand()
        {
            return Insert(this);
        }
    }
}
