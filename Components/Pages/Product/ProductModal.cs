using Microsoft.AspNetCore.Components;
using SiteBlazor.Class.Collective;
using SiteBlazor.Class.DTO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace SiteBlazor.Components.Pages.Product
{
    public partial class ProductModal
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment FooterContent { get; set; }

        [Parameter]
        public bool IsOpen { get; set; }
        [Parameter]
        public int Width { get; set; }
        [Parameter]
        public int Height { get; set; }
        [Parameter]
        public ProductDTO Product { get; set; }
        [Parameter]
        public int ProductId { get; set; }
        protected string TXT_Name { get; set; } = "";
        protected string TXT_Description { get; set; } = "";
        private bool showMessageBox = false;
        private string Message = "";
        private int SelectedTagValue { get; set; }
        private List<TagDTO> TagList = new CollectiveTag().ObjList(new TagDTO());
        private int SelectedGenderValue { get; set; }
        private List<GenderDTO> GenderList = new CollectiveGender().ObjList(new GenderDTO());
        private string Size => Width > 0 && Height > 0 ? $"width: {Width}px;height: {Height}px; " : "";
        private string ModalStyle => IsOpen ? "display: block;" : "display: none;";       
        protected override async Task OnInitializedAsync()
        {
            SelectedTagValue = int.MinValue;
            SelectedGenderValue = int.MinValue;

        }
        protected override bool ShouldRender()
        {

            if (ProductId > 0)
            {
                ProductDTO product = new ProductDTO { Productid = ProductId };
                product = new CollectiveProduct().ObjOne(product);
                if (product.Productid > 0)
                {
                    Product = product;
                    TXT_Name = Product.Name;
                    TXT_Description = Product.Description;
                    SelectedTagValue = Product.TagId;
                    SelectedGenderValue = Product.GenderId;
                }
                ProductId = 0;
            }
            return base.ShouldRender();
        }
        protected override Task OnParametersSetAsync()
        {

            return base.OnParametersSetAsync();
        }
        public void CloseModal()
        {
            IsOpen = false;
            showMessageBox = false;
        }
        public void BTN_Confirm()
        {
            CollectiveProduct collectiveProduct = new CollectiveProduct();
            string message = string.Empty;
            int productId = int.MinValue;
            if (Product.Productid > 0)
            {
                productId = Product.Productid;
            }
            Product = new ProductDTO
            {
                Productid = productId,
                Name = TXT_Name,
                Description = TXT_Description,
                TagId = SelectedTagValue,
                GenderId = SelectedGenderValue,
            };
            if (Product != null)
            {

                if (Product.Productid > 0)
                {
                    Product.DtUpdate = DateTime.Now;
                    collectiveProduct.Update(Product);
                    message = "Produto Alterado com Sucesso!";
                }
                else
                {
                    Product.DtCreate = DateTime.Now;
                    collectiveProduct.Insert(Product);
                    message = "Produto Cadastrado com Sucesso!";
                }

            }
            ProductId = 0;
            IsOpen = false;
            showMessageBox = true;
            Message = message;
        }

    }
}
