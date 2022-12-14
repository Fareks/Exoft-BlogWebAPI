using Business_Logic.Services.CategoryService;
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
    public class CategoryImageController : ControllerBase
    {
        //public IWebHostEnvironment _hostingEnvironment;
        private readonly ICategoryImageService _postImageService;
        private readonly ICategoryService _categoryService;

        public CategoryImageController(ICategoryImageService imageService, ICategoryService categoryService)
        {
            _postImageService = imageService;
            _categoryService = categoryService;
        }

        [HttpPost("upload-image/{categoryId}"), Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UploadImage(IFormFile file, Guid categoryId, CancellationToken ctoken = default)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(categoryId, ctoken);
                if (file != null && category != null)
                {

                    var result = await _postImageService.UploadImage(file, categoryId, ctoken);
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
        public async Task<IActionResult> GetPostImage(Guid imageId, CancellationToken ctoken = default)
        {
            var image = await _postImageService.GetImage(imageId, ctoken);
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
        public async Task<IActionResult> DeletePostImage(Guid categoryId, CancellationToken ctoken = default)
        {
            await _postImageService.DeleteImage(categoryId, ctoken);
            return Ok();
        }


    }
}