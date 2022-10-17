using Business_Logic.Services.ImageServices;
using Business_Logic.Services.UserServices;
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
        private readonly IUserService _userService;
        public UserImageController(IUserImageService imageService, IUserService userService)
        {
            _imageService = imageService;
            _userService = userService;
        }

        [HttpPost("upload-image/{userId}"), Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UploadImage (IFormFile image, Guid userId )
        {
            try
            {
                var user = await _userService.GetByIdAsync(userId);
                if (image != null && user != null)
                {
                   var result = await _imageService.UploadImage(image, userId);
                    return Ok(result);
                } else { return BadRequest("Wrong input!"); }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);  
            }
        }


        [HttpGet("get-image/{imageId}")]
        public async Task<IActionResult> GetUserImage (Guid imageId)
        {
            var image = await _imageService.GetImage(imageId);
            if (image != null && (System.IO.File.Exists(image.ImagePath)))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(image.ImagePath);
                return File(bytes, "image/png");
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete"), Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteUserImage (Guid userId)
        {
            await _imageService.DeleteImage(userId);
            return Ok();
        }


    }
}
