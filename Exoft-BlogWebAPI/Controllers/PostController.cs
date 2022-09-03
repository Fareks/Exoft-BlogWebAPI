using DataLayer.Models;
using Business_Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Business_Logic.Services.PostServices;
using Business_Logic.DTO;

namespace Exoft_BlogWebAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class PostController : ControllerBase
        {
            IPostService _postService;


            public PostController(IPostService postService)
            {
                _postService = postService;
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


            [HttpPost]
            public async Task<IActionResult> AddPost(PostCreateDTO post)
            {
                
                await _postService.Create(post);
                return Ok(post);
            }

            [HttpPut]
            public async Task<IActionResult> UpdatePost(PostUpdateDTO post)
            {
                await _postService.Update(post);
                return Ok();
            }

            [HttpDelete]
            public IActionResult DeletePost(Guid postId)
            {
                try
                {
                _postService.DeleteById(postId);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


            }
        }
}
