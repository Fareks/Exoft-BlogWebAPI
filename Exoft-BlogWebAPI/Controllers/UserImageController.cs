using Business_Logic.Services.ImageServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("/api/[controller]")]
    public class UserImageController : ControllerBase
    {
        //public IWebHostEnvironment _hostingEnvironment;
        private readonly IUserImageService _imageService;

        public UserImageController(IUserImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage (IFormFile file, Guid userId )
        {
            try
            {
                //var file = HttpContext.Request.Form.Files[0];
                if (file != null)
                {
                   var result = await _imageService.UploadImage(file, userId);
                    return Ok(result);
                } else { return BadRequest("Empty input!"); }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);  
            }
        }

        [HttpGet("user-image")]
        public async Task<IActionResult> GetUserImage (Guid userId)
        {
            var image = await _imageService.GetImage(userId);
            if(System.IO.File.Exists(image.ImagePath))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(image.ImagePath);
                return File(bytes, "image/png");
            }
            return Ok();
            
        }


    }
}
