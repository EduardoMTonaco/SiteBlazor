using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using SiteBlazor.Class.Collective;
using SiteBlazor.Class.DTO;
using SiteBlazor.Class.Global;
using SiteBlazor.Components.Pages.Product;
using SiteBlazor.InternAPI.Utility;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SiteBlazor.Components.Pages
{
    public partial class HomePage
    {
        
        private bool isOpen = false;

        private void OpenModal()
        {
            isOpen = false;
            isOpen = true;
        }
        public void CloseModal()
        {
            isOpen = false;
        }

        #region "Anexar Arquivo"

        private string message = string.Empty;
        private string imageBase64 = string.Empty;
        private IBrowserFile selectedImage;

        private string imagemUrl = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var baseUrl = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")?.Split(';')[0];
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                };
                //FILES\imagens

                FileApiParmeters fileApiParmeters = new FileApiParmeters();

                fileApiParmeters.Token = TokenHash.FileToken;
                fileApiParmeters.Path = "imagens";
                fileApiParmeters.FileName = "c9b.jpg";
                var response = await httpClient.GetAsync($"api/file{fileApiParmeters.QueryString()}");

                if (response.IsSuccessStatusCode)
                {
                    var imagemStream = await response.Content.ReadAsStreamAsync();
                    var memoriaStream = new MemoryStream();
                    await imagemStream.CopyToAsync(memoriaStream);
                    var imagemBytes = memoriaStream.ToArray();
                    imagemUrl = $"data:image/jpeg;base64,{Convert.ToBase64String(imagemBytes)}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task SelecionarImagem(IBrowserFile file)
        {
            selectedImage = file;

            using (var stream = new MemoryStream())
            {
                await file.OpenReadStream().CopyToAsync(stream);
                stream.Position = 0;

                var imagemBytes = stream.ToArray();
                imageBase64 = Convert.ToBase64String(imagemBytes);

                imageBase64 = $"data:image/{file.ContentType.Split('/')[1]};base64,{imageBase64}";
            }

            AlterState();
        }

        private void UpdateImage()
        {
            AlterState();
        }

        private async Task SaveImage()
        {
            if (selectedImage != null)
            {

                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FILES");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                folderPath = Path.Combine(folderPath, "imagens");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string pathImage = Path.Combine(folderPath, selectedImage.Name);
                using (var stream = new FileStream(pathImage, FileMode.Create))
                {
                    using (var imageStream = selectedImage.OpenReadStream())
                    {
                        await imageStream.CopyToAsync(stream);
                    }
                }
                 message = $"Imagem {selectedImage.Name} salva com sucesso!";              
            }
            else
            {
                message = "Nenhuma imagem selecionada.";
            }
        }

        private void AlterState()
        {
            InvokeAsync(StateHasChanged);
        }
        #endregion
    }
}
