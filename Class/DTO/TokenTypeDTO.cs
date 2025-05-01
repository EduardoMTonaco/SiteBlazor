using SiteBlazor.Class.Attributes;
using SiteBlazor.Class.Base;
using System.Security.Cryptography;

namespace SiteBlazor.Class.DTO
{
    public class TokenTypeDTO : BaseDTO
    {
        public TokenTypeDTO()
        {
            _tokenTypeId = int.MinValue;
            _tokenTypeName = "";
            
        }
        private int _tokenTypeId;
        private string _tokenTypeName;

        [DisplayAttributes(true, "tokenTypeiD", 0)]
        public int TokenTypeId
        {
            get { return _tokenTypeId; }
            set { _tokenTypeId = value; }       
        }
        
        [DisplayAttributes(false, "TokenTypeName", 1)]
        public string TokenTypeName
        {
            get { return _tokenTypeName; }
            set { _tokenTypeName = value; }
        }
        public override string SelectCommand()
        {
            return CreateSelectCommand(this);
        }

        public override string Table()
        {
            return "TokenType";
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
