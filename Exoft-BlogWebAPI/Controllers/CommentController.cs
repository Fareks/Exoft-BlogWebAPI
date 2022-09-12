using Business_Logic.DTO;
using Business_Logic.Services.CommentServices;
using Business_Logic.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;
        IAuthService _authService;
        public CommentController(ICommentService commentService, IAuthService authService)
        {
            _commentService = commentService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllById()
        {
            var comments = await _commentService.GetAllAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var comment = await _commentService.GetByIdAsync(id);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost,Authorize]
        public async Task<IActionResult> AddComment(CommentCreateDTO newComment)
        {
            try
            {
                //need author validator
                await _commentService.Post(newComment);
                return Ok();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message); 
            }
        }
        [HttpDelete, Authorize]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                //problem:  reach the database too many times
                var comment = await _commentService.GetByIdAsync(id);
                if (await _authService.isAuthor(comment.UserId))
                {
                    await _commentService.DeleteById(id);
                    return Ok();
                }else
                {
                    return BadRequest("Can`t Delete Comment");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
