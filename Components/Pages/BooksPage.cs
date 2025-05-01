using SiteBlazor.Class.Base;
using SiteBlazor.Class.Collective;
using SiteBlazor.Class.DTO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace SiteBlazor.Components.Pages
{
    public partial class BooksPage
    {
        private List<BooksDTO>? BookList;

        protected string TXT_Id { get; set; } = "";
        protected string TXT_Title { get; set; } = "";
        protected string Txt_PrimaryAuthor { get; set; } = "";

        private string errorMessage = "";
        private bool showMessageBox = false;
        private bool grayRow = false;
        void SomeStartupMethod()
        {
            SearchBook();
        }

        Task SomeStartupTask()
        {
            SearchBook();
            return Task.CompletedTask;
        }
        protected override async Task OnInitializedAsync()
        {
            //SomeStartupMethod();
            // await SomeStartupTask();
            // IncrementCount();
        }
        protected async Task BTN_Search()
        {
            SomeStartupMethod();
            await SomeStartupTask();
            // IncrementCount();
        }
        private void SearchBook()
        {
            grayRow = false;
            try
            {
                BooksDTO book = new BooksDTO();

                int id;
                book.MaxAmount = 100;
                if (TXT_Id != "" && int.TryParse(TXT_Id, out id))
                {
                    book.Id = id;
                }
                if (TXT_Title != "")
                {
                    TXT_Title = TXT_Title;
                    book.Title = TXT_Title;
                }
                if (Txt_PrimaryAuthor != "")
                {
                    Txt_PrimaryAuthor = Txt_PrimaryAuthor;
                    book.PrimaryAuthor = Txt_PrimaryAuthor;
                }

                BookList = new CollectiveBook().ObjList(book); ;
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
        //public async ValueTask DisposeAsync()
        //{
        //    // Dispose any resources if needed
        //}


    }
}
