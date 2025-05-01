using SiteBlazor.Class.Collective;
using SiteBlazor.Class.DTO;

namespace SiteBlazor.Components.Pages.Department
{
    public partial class DepartmentPage
    {
        private List<DepartmentDTO>? DepartmentList;
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
                DepartmentDTO departmentDTO = new DepartmentDTO();
                int id;
                departmentDTO.MaxAmount = 100;
                if (TXT_Id != "" && int.TryParse(TXT_Id, out id))
                {
                    departmentDTO.DepartmentId = id;
                }
                if (TXT_Name != "")
                {
                    if (TXT_Name.Contains("'"))
                    {
                        errorMessage = $"Campo: Nome com erro! \r\n Caractere \"'\" invalido.";
                        showMessageBox = true;
                    }
                    departmentDTO.Name = TXT_Name;
                }
                DepartmentList = new CollectiveDepartment().ObjList(departmentDTO);

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
