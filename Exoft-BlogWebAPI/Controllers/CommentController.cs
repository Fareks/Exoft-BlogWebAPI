using Business_Logic.DTO;
using Business_Logic.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        ICommentService _comService;
        public CommentController(ICommentService comService)
        {
            _comService = comService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllById()
        {
            var comments = await _comService.GetAllAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var comment = await _comService.GetByIdAsync(id);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentCreateDTO newComment)
        {
            try
            {
                await _comService.Post(newComment);
                return Ok();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message); 
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                await _comService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
