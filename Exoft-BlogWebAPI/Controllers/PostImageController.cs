using Business_Logic.Services.ImageServices;
using Business_Logic.Services.PostServices;
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
        private readonly IPostService _postService;

        public PostImageController(IPostImageService imageService, IPostService postService, CancellationToken token = default)
        {
            _postImageService = imageService;
            _postService = postService;
        }

        [HttpPost("upload-image/{postId}"), Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UploadImage(IFormFile file, Guid postId, CancellationToken token = default)
        {
            try
            {
                    var post = await _postService.GetById(postId, token);
                if (file != null && post != null)
                {
                    
                    var result = await _postImageService.UploadImage(file, postId, token);
                    return Ok(result);
                }
                else { return BadRequest("Invalid input!"); }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("get-image/{imageId}")]
        public async Task<IActionResult> GetPostImage(Guid imageId, CancellationToken token = default)
        {
            var image = await _postImageService.GetImage(imageId, token);
            if (image != null && System.IO.File.Exists(image.ImagePath))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(image.ImagePath);
                return File(bytes, "image/png");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete"), Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeletePostImage(Guid postId, CancellationToken token = default)
        {
            await _postImageService.DeleteImage(postId, token);
            return Ok();
        }


    }
}
