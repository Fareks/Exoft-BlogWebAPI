using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("/api/[controller]")]
    public class ImageController : ControllerBase
    {
        public IWebHostEnvironment _hostingEnvironment;

        public ImageController (IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage ()
        {
            try
            {
                var file = HttpContext.Request.Form.Files[0];
                if (file != null)
                {
                    FileInfo fileInfo = new FileInfo(file.FileName);
                    var newFilename = "Image_" + DateTime.Now.TimeOfDay + fileInfo.Extension;
                    var path = Path.Combine("",_hostingEnvironment.ContentRootPath+"/Images/"+newFilename);
                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

    }
}
