using AutoMapper;
using Business_Logic.DTO;
using Business_Logic.Services.CommentLikeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentLikeController : ControllerBase
    {
        ICommentLikeService _commentLikeService;
        IMapper _mapper;

        public CommentLikeController(ICommentLikeService commLikeService, IMapper mapper)
        {
            _commentLikeService = commLikeService;
            _mapper = mapper;
        }

        [HttpGet("/comment_likes")]
        public async Task<IActionResult> GetAllPostLikes()
        {
            var postLikes = await _commentLikeService.GetAllAsync();
            return Ok(postLikes);
        }

        [HttpGet("/comment_likes/{id}")]
        public async Task<IActionResult> GetPostLike(Guid id)
        {
            var user = await _commentLikeService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddPostLike(CommentLikeCreateDTO postLikeDTO)
        {
            await _commentLikeService.Post(postLikeDTO);
            return Ok(postLikeDTO);
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> DeletePostLike(Guid postLikeId)
        {
            try
            {
                await _commentLikeService.DeleteById(postLikeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
