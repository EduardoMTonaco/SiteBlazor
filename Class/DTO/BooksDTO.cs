using SiteBlazor.Class.Attributes;
using SiteBlazor.Class.Base;
using System.Security.Cryptography;

namespace SiteBlazor.Class.DTO
{
    public class BooksDTO : BaseDTO
    {
        public BooksDTO()
        {
            _id = int.MinValue;
            _title = "";
            _primary_author = "";
        }

        private int _id;       
        private string _title;
        private string _primary_author;
        [DisplayAttributes(true, "id", 0)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }       
        [DisplayAttributes(false, "Title", 1)]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        [DisplayAttributes(false, "primary_author", 2)]
        public string PrimaryAuthor
        {
            get { return _primary_author; }
            set { _primary_author = value; }
        }
        public override string SelectCommand()
        {
            return CreateSelectCommand(this);
        }

        public override string Table()
        {
            return "books";
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
