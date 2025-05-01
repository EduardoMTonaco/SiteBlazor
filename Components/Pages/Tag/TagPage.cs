using SiteBlazor.Class.Collective;
using SiteBlazor.Class.DTO;
using SiteBlazor.Components.Pages.GenericModal;
using SiteBlazor.Components.Pages.Product;

namespace SiteBlazor.Components.Pages.Tag
{
    public partial class TagPage
    {

        private List<TagDTO>? TagList;
        protected string TXT_Id { get; set; } = "";
        protected string TXT_Name { get; set; } = "";
        protected string TXT_Department { get; set; } = "";
        protected int ProductId { get; set; } = 0;

        private string errorMessage = "";
        private bool showMessageBox = false;
        private bool grayRow = false;
        private string DeleteImage = $"/images/remove.png";
        private string EditImage = $"/images/edit.png";

        protected override bool ShouldRender()
        {
            grayRow = false;
            return base.ShouldRender();
        }

        void SomeStartupMethod()
        {

            Search();
        }

        Task SomeStartupTask()
        {
            Search();
            return Task.CompletedTask;
        }
        protected async Task BTN_Search()
        {
            await SomeStartupTask();
        }
        private void Search()
        {
            try
            {
                grayRow = false;
                TagDTO tagDTO = new TagDTO();
                int id;
                tagDTO.MaxAmount = 100;
                if (TXT_Id != "" && int.TryParse(TXT_Id, out id))
                {
                    tagDTO.TagId = id;
                }
                if (TXT_Name != "")
                {
                    if (TXT_Name.Contains("'"))
                    {
                        errorMessage = $"Campo: Nome com erro! \r\n Caractere \"'\" invalido.";
                        showMessageBox = true;
                    }
                    tagDTO.Name = TXT_Name;
                }
                if (TXT_Department != "")
                {
                    if (TXT_Department.Contains("'"))
                    {
                        errorMessage = $"Campo: Nome com erro! \r\n Caractere \"'\" invalido.";
                        showMessageBox = true;
                    }
                    tagDTO.Department.Name = TXT_Department;
                }
                TagList = new CollectiveTag().FillDepartmentList(tagDTO.Department.Name).ObjList(tagDTO);

            }
            catch (Exception ex)
            {
                errorMessage = $"Error: {ex.Message}";
                showMessageBox = true;
            }
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
        private void CloseMessageBox()
        {
            // Close the message box
            showMessageBox = false;
        }
    }
}
