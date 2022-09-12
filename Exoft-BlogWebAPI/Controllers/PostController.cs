using DataLayer.Models;
using Business_Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Business_Logic.Services.PostServices;
using Business_Logic.DTO;
using Microsoft.AspNetCore.Authorization;
using Business_Logic.Services.UserServices;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
        {
            IPostService _postService;
            IAuthService _authService;

            public PostController(IPostService postService, IAuthService authService)
            {
                _postService = postService;
                _authService = authService;
            }


            [HttpGet("/posts")]
            public async Task<IActionResult> GetBlogs()
            {
                return Ok(await _postService.GetAll());
            }

            [HttpGet("/posts/{id}")]
            public async Task<IActionResult> GetPostById(Guid id)
            {
                return Ok(await _postService.GetById(id));
            }

            [HttpPost, Authorize]
        //required return dto with id. (CreateDTO does not contain id)
        public async Task<IActionResult> AddPost(PostCreateDTO post)
            {
                try
                {
                    await _postService.Create(post);
                    return Ok(post);
                } 
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
        }

            [HttpPut, Authorize]
            public async Task<IActionResult> UpdatePost(PostUpdateDTO post)
            {
                if (await _authService.GetMyId() == post.UserId)
                {
                    await _postService.Update(post);
                    return Ok(post);
                } else
                {
                    return BadRequest("Can`t Update Post.");
                }    
                
            }

            [HttpDelete, Authorize]
            public async Task<IActionResult> DeletePost(Guid postId)
            {
                try
                {
                    var post = await _postService.GetById(postId);
                    if(await _authService.isAuthor(post.UserId))
                        {
                            await _postService.DeleteById(postId);
                            return Ok();
                        } else
                        {
                            return BadRequest("Can`t delete user");
                        }
                    
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        [HttpPut("/admin/validate-post"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> ValidatePost(Guid postId, bool setIsValid)
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
