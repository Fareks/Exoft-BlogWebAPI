using Business_Logic.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/get-all")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                return Ok(await _categoryService.GetAllCategories());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("/delete-category")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            try
            {
                await _categoryService.DeleteCategory(categoryId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/create-category")]
        public async Task<IActionResult> CreateCategory(string categoryName)
        {
            try
            { 
                return Ok(await _categoryService.CreateCategory(categoryName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
