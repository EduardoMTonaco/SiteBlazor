using SiteBlazor.Class.Collective;
using SiteBlazor.Class.DTO;
using SiteBlazor.Components.Pages.GenericModal;

namespace SiteBlazor.Components.Pages.Product
{
    public partial class ProdutctPage
    {
        private List<ProductDTO>? ProductList;
        private ProductModal productModal;
        private ConfirmModal confirmModal;
        protected string TXT_Id { get; set; } = "";
        protected string TXT_Name { get; set; } = "";
        protected string TXT_Description { get; set; } = "";
        protected string TXT_Department { get; set; } = "";
        protected int ProductId { get; set; } = 0;

        private string errorMessage = "";
        private bool showMessageBox = false;
        private bool grayRow = false;
        private bool isOpenProductModal = false;
        private bool isOpenConfirmModal = false;
        private string DeleteImage = $"/images/remove.png";
        private string EditImage = $"/images/edit.png";

        protected override bool ShouldRender()
        {
            grayRow = false;
            return base.ShouldRender();
        }
        Task OpenProductModal(int product = 0)
        {
            ProductId = product;
            isOpenConfirmModal = false;
            isOpenProductModal = false;
            isOpenProductModal = true;
            return Task.CompletedTask;
        }
        public void CloseProductModal()
        {
            isOpenProductModal = false;
            ProductId = 0;
        }
        void SomeStartupMethod()
        {
            isOpenProductModal = false;
            Search();
        }

        Task SomeStartupTask()
        {
            Search();
            return Task.CompletedTask;
        }
        //protected override async Task OnInitializedAsync()
        //{
        //    //SomeStartupMethod();
        //    // await SomeStartupTask();
        //    // IncrementCount();
        //}
        protected async Task BTN_OpenModal(int product = 0)
        {
            await OpenProductModal(product);
        }
        protected async Task BTN_Search()
        {
            await SomeStartupTask();
        }
        private void Search()
        {
            isOpenConfirmModal = false;
            isOpenProductModal = false;
            grayRow = false;
            try
            {
                ProductDTO product = new ProductDTO();

                int id;
                product.MaxAmount = 100;
                if (TXT_Id != "" && int.TryParse(TXT_Id, out id))
                {
                    product.Productid = id;
                }
                if (TXT_Name != "")
                {
                    if (TXT_Name.Contains("'"))
                    {
                        errorMessage = $"Campo: Nome com erro! \r\n Caractere \"'\" invalido.";
                        showMessageBox = true;
                    }
                    product.Name = TXT_Name;
                }
                if (TXT_Description != "")
                {
                    product.Description = TXT_Description;
                }
                product.FlDeleted = false;
                ProductList = new CollectiveProduct().ObjList(product);
                if (ProductList.Count == 0)
                {
                    errorMessage = $"Pesquisa não retornou nenhum resultado";
                    showMessageBox = true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Error: {ex.Message}";
                showMessageBox = true;
            }
        }
        private void CloseMessageBox()
        {
            // Close the message box
            showMessageBox = false;
        }
        private bool GrayColumn()
        {
            if (grayRow)
            {
                grayRow = false;
                return true;
            }
            else
            {
                grayRow = true;
                return false;
            }

        }
        protected void BTN_DeleteModal(int product)
        {
            isOpenProductModal = false;
            isOpenConfirmModal = false;
            isOpenConfirmModal = true;
            ProductId = product;
        }
        private void DeleteProduct()
        {
            CollectiveProduct collectiveProduct = new CollectiveProduct();           
            ProductDTO productDTO = new ProductDTO
            {
                Productid = ProductId,
                FlDeleted = true,
                DtUpdate = DateTime.Now,
            };
            collectiveProduct.Update(productDTO);
            isOpenConfirmModal = false;
            errorMessage = $"Exclusão realizada com sucesso!";
            showMessageBox = true;
            Search();
        }
        //public async ValueTask DisposeAsync()
        //{
        //    // Dispose any resources if needed
        //}


    }
}
