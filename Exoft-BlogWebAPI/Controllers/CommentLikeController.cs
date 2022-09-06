using AutoMapper;
using Business_Logic.DTO;
using Business_Logic.Services.CommentLikeServices;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentLikeController : ControllerBase
    {
        ICommentLikeService _commLikeService;
        IMapper _mapper;

        public CommentLikeController(ICommentLikeService commLikeService, IMapper mapper)
        {
            _commLikeService = commLikeService;
            _mapper = mapper;
        }

        [HttpGet("/comment_likes")]
        public async Task<IActionResult> GetAllPostLikes()
        {
            var postLikes = await _commLikeService.GetAllAsync();
            return Ok(postLikes);
        }

        [HttpGet("/comment_likes/{id}")]
        public async Task<IActionResult> GetPostLike(Guid id)
        {
            var user = await _commLikeService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddPostLike(CommentLikeCreateDTO postLikeDTO)
        {
            await _commLikeService.Post(postLikeDTO);
            return Ok(postLikeDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePostLike(Guid postLikeId)
        {
            try
            {
                await _commLikeService.DeleteById(postLikeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
