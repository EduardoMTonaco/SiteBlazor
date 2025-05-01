using SiteBlazor.Class.Attributes;
using SiteBlazor.Class.Base;

namespace SiteBlazor.Class.DTO
{
    public class GenderDTO : BaseDTO
    {
        public GenderDTO()
        {
            _genderId = int.MinValue;
            _genderName = "";
        }

        private int _genderId;
        private string _genderName;
        [DisplayAttributes(true, "GenderId", 0)]
        public int GenderId
        {
            get { return _genderId; }
            set { _genderId = value; }
        }
        [DisplayAttributes(false, "GenderName", 1)]
        public string GenderName
        {
            get { return _genderName; }
            set { _genderName = value; }
        }
        public override string SelectCommand()
        {
            return CreateSelectCommand(this);
        }

        public override string Table()
        {
            return "gender";
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
