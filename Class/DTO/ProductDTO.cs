using SiteBlazor.Class.Attributes;
using SiteBlazor.Class.Base;
using SiteBlazor.Class.Collective;

namespace SiteBlazor.Class.DTO
{
    public class ProductDTO : BaseDTO
    {
        public ProductDTO()
        {
            _productid = int.MinValue;
            _tagId = int.MinValue;
            _name = "";
            _description = "";
            _genderId = int.MinValue;
        }

        private int _productid;
        private int _tagId;
        private string _name;
        private string _description;
        private int _genderId;
        private DateTime? _dtCreate;
        private DateTime? _dtUpdate;
        private bool? _flDeleted;
        public TagDTO Tag = new TagDTO();
        public GenderDTO Gender = new GenderDTO();
        [DisplayAttributes(true, "Productid", 0)]
        public int Productid
        {
            get { return _productid; }
            set { _productid = value; }
        }
        [DisplayAttributes(false, "TagId", 1)]
        public int TagId
        {
            get { return _tagId; }
            set { _tagId = value; }
        }
        [DisplayAttributes(false, "Name", 2)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [DisplayAttributes(false, "description", 3)]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [DisplayAttributes(false, "genderId", 4)]
        public int GenderId
        {
            get { return _genderId; }
            set { _genderId = value; }
        }
        [DisplayAttributes(false, "DtCreate", 5)]
        public DateTime? DtCreate
        {
            get { return _dtCreate; }
            set { _dtCreate = value; }
        }
        [DisplayAttributes(false, "dtUpdate", 6)]
        public DateTime? DtUpdate
        {
            get { return _dtUpdate; }
            set { _dtUpdate = value; }
        }
        [DisplayAttributes(false, "flDeleted", 7)]
        public bool? FlDeleted
        {
            get { return _flDeleted; }
            set { _flDeleted = value; }
        }
        public override string SelectCommand()
        {
            string selectCommand = CreateSelectCommand(this);
            return selectCommand;
        }

        public override string Table()
        {
            return "product";
        }
        private GenderDTO FindGender(int id)
        {
            GenderDTO objDTO = new GenderDTO();
            objDTO.GenderId = id;
            CollectiveGender collective = new CollectiveGender();
            objDTO = collective.ObjOne(objDTO);
            return objDTO;
        }
        public void FillGender()
        {
            if (this.GenderId > 0) {
                this.Gender = FindGender(this.GenderId);
            }
              
        }
        private TagDTO FindTag(int id)
        {
            TagDTO objDTO = new TagDTO();
            objDTO.TagId = id;
            CollectiveTag collective = new CollectiveTag();
            objDTO = collective.ObjOne(objDTO);
            return objDTO;
        }
        public void FillTag()
        {
            if (this.TagId > 0)
            {
                this.Tag = FindTag(this.TagId);
            }
        }

        public override void FillSubClass()
        {
            FillGender();
            FillTag();
        }
        public override string UpdateCommand()
        {
            string updateCommand = Update(this);
            return updateCommand;
        }

        public override string InsertCommand()
        {
            string insertCommand = Insert(this);
            return insertCommand;
        }
    }
}
