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
            public IActionResult GetPostById(Guid id)
            {
                return Ok(_postService.GetById(id));
            }


        [HttpPost]
            public IActionResult AddPost(PostCreateDTO post)
            {
                _postService.Create(post);
                return Ok(post);
            }

            [HttpPut]
            public IActionResult UpdatePost(PostUpdateDTO post)
            {
                _postService.Update(post);
                return Ok();
            }

            [HttpDelete]
            public IActionResult DeletePost(Guid postId)
            {
                if (_postService.GetById(postId) != null)
                {
                    _postService.DeleteById(postId);
                    return Ok();
                }
                else
                {
                    return BadRequest("Post not found.");
                }


            }
        }
}
