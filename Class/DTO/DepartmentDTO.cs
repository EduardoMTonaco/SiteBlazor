using SiteBlazor.Class.Attributes;
using SiteBlazor.Class.Base;

namespace SiteBlazor.Class.DTO
{
    public class DepartmentDTO :BaseDTO
    {
        public DepartmentDTO()
        {
            _departmentId = int.MinValue;
            _name = "";
        }

        private int _departmentId;
        private string _name;
        [DisplayAttributes(true, "DepartmentId", 0)]
        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
        [DisplayAttributes(false, "Name", 1)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public override string SelectCommand()
        {
            return CreateSelectCommand(this);
        }

        public override string Table()
        {
            return "department";
        }
        public override void FillSubClass()
        {

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
