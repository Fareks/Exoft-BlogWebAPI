﻿using AutoMapper;
using Business_Logic.DTO.PostLikeDTOs;
using Business_Logic.Services.PostLikesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{

    //need modify LikeSnapshot when db modified
    [ApiController]
    [Route("api/[controller]")]
    public class PostLikeController : ControllerBase
    {
        readonly IPostLikeService _postLikeService;
        readonly IMapper _mapper;

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

        [HttpPost, Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> AddPostLike(PostLikeCreateDTO postLikeDTO)
        {
            //need author validator
            await _postLikeService.Post(postLikeDTO);
            return Ok(postLikeDTO);
        }

        [HttpDelete, Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeletePostLike(Guid postLikeId)
        {
            try
            {
                //need author validator
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
