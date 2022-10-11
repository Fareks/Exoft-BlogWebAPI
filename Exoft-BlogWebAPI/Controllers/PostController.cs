using DataLayer.Models;
using Business_Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Business_Logic.Services.PostServices;
using Microsoft.AspNetCore.Authorization;
using Business_Logic.Services.UserServices;
using Business_Logic.DTO.PostDTOs;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
        {
            readonly IPostService _postService;
            readonly IAuthService _authService;

            public PostController(IPostService postService, IAuthService authService)
            {
                _postService = postService;
                _authService = authService;
            }


            [HttpGet("/posts")]
            public async Task<IActionResult> GetPosts()
            {
                return Ok(await _postService.GetAll());
            }

            [HttpGet("/unverified-posts")]
            public async Task<IActionResult> GetAllUnverifiedPosts()
            {
                return Ok(await _postService.GetAllUnverifiedPosts());
            }
            [HttpGet("/posts-by-user-id/{userId}")]
            public async Task<IActionResult> GetPostsByUserId(Guid userId)
            {
                return Ok(await _postService.GetAllPostsByUserId(userId));
            }
            [HttpGet("/posts/{id}")]
            public async Task<IActionResult> GetPostById(Guid id)
            {
                return Ok(await _postService.GetById(id));
            }

            [HttpPost, Authorize(AuthenticationSchemes = "Bearer")]
            //required return dto with id. 
            public async Task<IActionResult> AddPost(PostCreateDTO post)
            {
                try
                {
                    var response = await _postService.Create(post);
                    return Ok(response);
                } 
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut, Authorize(AuthenticationSchemes = "Bearer")]
            public async Task<IActionResult> UpdatePost(PostUpdateDTO post)
            {
                if (await _authService.IsAuthor(post.UserId))
                {
                    var response = await _postService.Update(post);
                    return Ok(response);
                } else
                {
                    return BadRequest("Can`t Update Post.");
                }    
                
            }

            [HttpDelete, Authorize(AuthenticationSchemes = "Bearer")]
            public async Task<IActionResult> DeletePost(Guid postId)
            {
                try
                {
                //problem:  reach the database too many times
                var post = await _postService.GetById(postId);
                    if(await _authService.IsAuthor(post.UserId))
                        {
                            await _postService.DeleteById(postId);
                            return Ok(new {Status="Post deleted!", PostId=postId });
                        } else
                        {
                            return BadRequest($"Can`t delete post by id: {postId}");
                        }
                    
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
           [HttpPut("/admin/validate-post/{postId}"), Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
            public async Task<IActionResult> ValidatePost(Guid postId, [FromBody]bool setIsValid)
            {
            try
            {
                await _postService.ValidatePost(postId, setIsValid);
                return Ok(new { Response = $"Post is validated.Current valid status: {setIsValid}", ValidStatus = setIsValid });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = $"Can`t validate post." });
            }
            }
        }
}
