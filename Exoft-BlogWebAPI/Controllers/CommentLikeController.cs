using AutoMapper;
using Business_Logic.DTO.CommentLikeDTOs;
using Business_Logic.Services.CommentLikeServices;
using Business_Logic.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    //need modify LikeSnapshot when db modified
    [ApiController]
    [Route("api/[controller]")]
    public class CommentLikeController : ControllerBase
    {
        readonly ICommentLikeService _commentLikeService;
        readonly IMapper _mapper;
        readonly IAuthService _authService;

        public CommentLikeController(ICommentLikeService commLikeService, IMapper mapper, IAuthService authService)
        {
            _commentLikeService = commLikeService;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpGet("/comment_likes")]
        public async Task<IActionResult> GetAllPostLikes()
        {
            var postLikes = await _commentLikeService.GetAllAsync();
            return Ok(postLikes);
        }

        [HttpGet("/comment_likes/{id}")]
        public async Task<IActionResult> GetCommentLike(Guid id)
        {
            var user = await _commentLikeService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost, Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> AddCommentLike(CommentLikeCreateDTO postLikeDTO)
        {
            //need author validator
            await _commentLikeService.CreateCommentLike(postLikeDTO);
            return Ok(postLikeDTO);
        }

        [HttpDelete, Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteCommentLike(Guid postLikeId)
        {
            try
            {
                //Too many base calls! Move the validator and entity extraction into each service method!
                var postLike = await _commentLikeService.GetByIdAsync(postLikeId);
                if (await _authService.IsAuthor(postLike.UserId))
                {
                    await _commentLikeService.DeleteById(postLikeId);
                    return Ok();
                }
                else
                {
                    return BadRequest("Can`t delete post like.");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
