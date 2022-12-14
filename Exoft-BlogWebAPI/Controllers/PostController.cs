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
            public async Task<IActionResult> GetPosts(CancellationToken token = default)
            {
                return Ok(await _postService.GetAll(token));
            }

            [HttpGet("/get-last-posts")]
            public async Task<IActionResult> GetLastPosts(int skip, int take, CancellationToken token = default)
            {
                return Ok(await _postService.GetLastPosts(skip, take, token));
            }

            [HttpGet("/unverified-posts")]
            public async Task<IActionResult> GetAllUnverifiedPosts(CancellationToken token = default)
            {
                return Ok(await _postService.GetAllUnverifiedPosts(token));
            }

            [HttpGet("/posts-by-user-id/{userId}")]
            public async Task<IActionResult> GetPostsByUserId(Guid userId, CancellationToken token = default)
            {
                return Ok(await _postService.GetAllPostsByUserId(userId, token));
            }

            [HttpGet("/posts/{id}")]
            public async Task<IActionResult> GetPostById(Guid id, CancellationToken token = default)
            {
                return Ok(await _postService.GetById(id, token));
            }

            [HttpPost, Authorize(AuthenticationSchemes = "Bearer")]
            //required return dto with id. 
            public async Task<IActionResult> AddPost(PostCreateDTO post, CancellationToken token = default)
            {
                try
                {
                    var response = await _postService.Create(post, token);
                    return Ok(response);
                } 
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut, Authorize(AuthenticationSchemes = "Bearer")]
            public async Task<IActionResult> UpdatePost(PostUpdateDTO post, CancellationToken token = default)
            {
                if (await _authService.IsAuthor(post.UserId, token))
                {
                    var response = await _postService.Update(post, token);
                    return Ok(response);
                } else
                {
                    return BadRequest("Can`t Update Post.");
                }    
                
            }

            [HttpDelete, Authorize(AuthenticationSchemes = "Bearer")]
            public async Task<IActionResult> DeletePost(Guid postId, CancellationToken token = default)
            {
                try
                {
                //problem:  reach the database too many times
                var post = await _postService.GetById(postId, token);
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

            [HttpDelete("/admin/delete-as-admin"), Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
            public async Task<IActionResult> DeletePostByAdmin(Guid postId, CancellationToken token = default)
            {
                try
                {
                    await _postService.DeleteById(postId, token);
                    return Ok(new { Status = "Post deleted!", PostId = postId });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }


        [HttpPut("/admin/validate-post/{postId}"), Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
            public async Task<IActionResult> ValidatePost(Guid postId, [FromBody]bool setIsValid, CancellationToken token = default)
            {
            try
            {
                await _postService.ValidatePost(postId, setIsValid, token);
                return Ok(new { Response = $"Post is validated.Current valid status: {setIsValid}", ValidStatus = setIsValid });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = $"Can`t validate post." });
            }
            }

            [HttpPut("/admin/set-category"), Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
            public async Task<IActionResult> SetCategory(Guid postId, [FromBody] Guid categoryId,CancellationToken token = default)
            {
                try
                {
                    await _postService.SetCategory(postId, categoryId, token);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Response = $"Can`t validate post." });
                }
            }

            [HttpGet("/post-by-category")]
            public async Task<IActionResult> GetPostsByCategoryId(Guid categoryId,CancellationToken token = default)
            {
                return Ok(await _postService.GetPostsByCategoryId(categoryId, token));
            }

        [HttpGet("/search-by-content")]
        public async Task<IActionResult> SearchByContent(string content,CancellationToken token = default)
        {
            return Ok(await _postService.SearchByContent(content, token));
        }
    }
}
