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
        public async Task<IActionResult> UploadImage(IFormFile file, Guid categoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(categoryId);
                if (file != null && category != null)
                {

                    var result = await _postImageService.UploadImage(file, categoryId);
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
        public async Task<IActionResult> GetPostImage(Guid imageId)
        {
            var image = await _postImageService.GetImage(imageId);
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
        public async Task<IActionResult> DeletePostImage(Guid categoryId)
        {
            await _postImageService.DeleteImage(categoryId);
            return Ok();
        }


    }
}