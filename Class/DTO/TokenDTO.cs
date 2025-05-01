using SiteBlazor.Class.Attributes;
using SiteBlazor.Class.Base;
using SiteBlazor.Class.Collective;

namespace SiteBlazor.Class.DTO
{
    public class TokenDTO : BaseDTO
    {
        public TokenDTO()
        {
            _tokenId = int.MinValue;
            _tokenKey = "";
            _tokenTypeiD = int.MinValue;


        }
        private int _tokenId;
        private int _tokenTypeiD;
        private string _tokenKey;
        private bool? _flDeleted;
        public TokenTypeDTO TokenType = new TokenTypeDTO();

        [DisplayAttributes(true, "TokenId", 0)]
        public int TokenId
        {
            get { return _tokenId; }
            set { _tokenId = value; }
        }
        [DisplayAttributes(false, "TokenKey", 1)]
        public string TokenKey
        {
            get { return _tokenKey; }
            set { _tokenKey = value; }
        }
        [DisplayAttributes(false, "TokenTypeiD", 2)]
        public int TokenTypeiD
        {
            get { return _tokenTypeiD; }
            set { _tokenTypeiD = value; }
        }
        [DisplayAttributes(false, "flDeleted", 3)]
        public bool? FlDeleted
        {
            get { return _flDeleted; }
            set { _flDeleted = value; }
        }
        public override string SelectCommand()
        {
            return CreateSelectCommand(this);
        }

        public override string Table()
        {
            return "Token";
        }

        public override void FillSubClass()
        {
            this.TokenType = FindTokenType(this.TokenTypeiD);
        }
        private TokenTypeDTO FindTokenType(int id)
        {
            TokenTypeDTO objDTO = new TokenTypeDTO();
            objDTO.TokenTypeId = id;
            CollectiveTokenType collective = new CollectiveTokenType();
            objDTO = collective.ObjOne(objDTO);
            return objDTO;
        }

        public override string UpdateCommand()
        {
            return Update(this);
        }

        public override string InsertCommand()
        {
            return Insert(this);
        }

        protected override string StringCondition(string alias, DisplayAttributes? displayNameAttribute, object value)
        {
            return $" {alias}.{displayNameAttribute.Name} COLLATE Latin1_General_CS_AS = '{value}' ";
        }
    }
}
