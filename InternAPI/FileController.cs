using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteBlazor.Class.Collective;
using SiteBlazor.Class.DTO;
using SiteBlazor.Class.Global;
using SiteBlazor.InternAPI.Utility;

namespace SiteBlazor.InternAPI
{
    [ApiController]
    [Route("api")]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("file")]
        public IActionResult GetArquivo([FromQuery] FileApiParmeters fileApiParmeters)
        {
            if (fileApiParmeters.Token.Length != 100)
            {
                return Unauthorized();
            }
            TokenDTO tokenDTO = new TokenDTO();
            tokenDTO.TokenTypeiD = 1;
            tokenDTO.FlDeleted = false;
            tokenDTO.TokenKey = fileApiParmeters.Token;
            CollectiveToken collectiveToken = new CollectiveToken();
            tokenDTO = collectiveToken.ObjOne(tokenDTO);
          
            if (tokenDTO == null)
            {
                return Unauthorized();
            }
            if (string.Compare(tokenDTO.TokenKey, TokenHash.FileToken, StringComparison.Ordinal) == 0)
            {
                var caminhoArquivo = Path.Combine("FILES", fileApiParmeters.Path, fileApiParmeters.FileName);

                if (System.IO.File.Exists(caminhoArquivo))
                {
                    var arquivo = System.IO.File.OpenRead(caminhoArquivo);
                    return File(arquivo, "image/jpeg");
                }
                else
                {
                    return NotFound();
                }
            }            
            else
            {
                return Unauthorized(); ;
            }
        }
    }
}

