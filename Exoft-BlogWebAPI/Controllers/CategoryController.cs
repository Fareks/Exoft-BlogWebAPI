using Business_Logic.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetCategories(CancellationToken token = default)
        {
            try
            {
                return Ok(await _categoryService.GetAllCategories(token));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("get-by-name")]
        public async Task<IActionResult> GetCategoriesByName(string categoryName, CancellationToken token = default)
        {
            try
            {
                var response = await _categoryService.SearchCategoriesByName(categoryName, token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetCategoryById(Guid categoryId, CancellationToken token = default)
        {
            try
            {
                var response = await _categoryService.GetCategoryById(categoryId, token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpDelete("delete-category"), Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId, CancellationToken token = default)
        {
            try
            {
                await _categoryService.DeleteCategory(categoryId, token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-category"), Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateCategory(string categoryName, CancellationToken token = default)
        {
            try
            { 
                return Ok(await _categoryService.CreateCategory(categoryName, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
