using Business_Logic.Services.ImageServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("/api/[controller]")]
    public class PostImageController : ControllerBase
    {
        //public IWebHostEnvironment _hostingEnvironment;
        private readonly IPostImageService _postImageService;

        public PostImageController(IPostImageService imageService)
        {
            _postImageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file, Guid postId)
        {
            try
            {
                //var file = HttpContext.Request.Form.Files[0];
                if (file != null)
                {
                    var result = await _postImageService.UploadImage(file, postId);
                    return Ok(result);
                }
                else { return BadRequest("Empty input!"); }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("post-image")]
        public async Task<IActionResult> GetUserImage(Guid userId)
        {
            var image = await _postImageService.GetImage(userId);
            if (System.IO.File.Exists(image.ImagePath))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(image.ImagePath);
                return File(bytes, "image/png");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("user-image/delete")]
        public async Task<IActionResult> DeleteUserImage(Guid postId)
        {
            await _postImageService.DeleteImage(postId);
            return Ok();
        }


    }
}
