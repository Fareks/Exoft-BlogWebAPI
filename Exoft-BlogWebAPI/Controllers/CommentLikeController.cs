﻿using AutoMapper;
using Business_Logic.DTO;
using Business_Logic.Services.CommentLikeServices;
using Business_Logic.Services.UserServices;
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
        IAuthService _authService;

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
                //Too many base calls! Move the validator and entity extraction into each service method!
                var postLike = await _commentLikeService.GetByIdAsync(postLikeId);
                if (await _authService.isAuthor(postLike.UserId))
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
