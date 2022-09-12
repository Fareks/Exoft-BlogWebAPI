using AutoMapper;
using Business_Logic.DTO;
using Business_Logic.Services.PostLikesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostLikeController : ControllerBase
    {
        IPostLikeService _postLikeService;
        IMapper _mapper;

        public PostLikeController(IPostLikeService postLikeService, IMapper mapper)
        {
            _postLikeService = postLikeService;
            _mapper = mapper;
        }

        [HttpGet("/post_likes")]
        public async Task<IActionResult> GetAllPostLikes()
        {
            var postLikes = await _postLikeService.GetAllAsync();
            return Ok(postLikes);
        }

        [HttpGet("/post_likes/{id}")]
        public async Task<IActionResult> GetPostLike(Guid id)
        {
            var user = await _postLikeService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddPostLike(PostLikeCreateDTO postLikeDTO)
        {
            await _postLikeService.Post(postLikeDTO);
            return Ok(postLikeDTO);
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> DeletePostLike(Guid postLikeId)
        {
            try
            {
                await _postLikeService.DeleteById(postLikeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
