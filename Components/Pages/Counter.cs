using SiteBlazor.Class.DTO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace SiteBlazor.Components.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        private string space = "";
        private List<BooksDTO>? BookList;        
        protected string TextBoxValue { get; set; } = "";     

        void SomeStartupMethod()
        {
            // currentCount++;
        }

        Task SomeStartupTask()
        {
            // Do some task based work
            return Task.CompletedTask;
        }

        protected override async Task OnInitializedAsync()
        {
            SomeStartupMethod();
            await SomeStartupTask();
            // IncrementCount();
        }
        private void IncrementCount()
        {
            currentCount++;
           
        }



    }
}
