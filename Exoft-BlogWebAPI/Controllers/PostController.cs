using DataLayer.Models;
using Business_Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class PostController : ControllerBase
        {
            ICRUDService<Post> postService;


            public PostController(ICRUDService<Post> _serviceService)
            {
                postService = _serviceService;
            }


            [HttpGet("/posts")]
            public IActionResult GetBlogs()
            {
                return Ok(postService.GetAll());
            }

            [HttpGet("/posts/{id}")]
            public IActionResult GetPostById(Guid id)
            {
                return Ok(postService.GetById(id));
            }


        [HttpPost]
            public IActionResult AddPost([FromBody] Post post)
            {
                postService.Post(post);
                return Ok(post);
            }

            [HttpPut]
            public IActionResult UpdatePost(Post post)
            {
                postService.Update(post);
                return Ok();
            }

            [HttpDelete]
            public IActionResult DeletePost(Guid postId)
            {
                if (postService.GetById(postId) != null)
                {
                    postService.DeleteById(postId);
                    return Ok();
                }
                else
                {
                    return BadRequest("Post not found.");
                }


            }
        }
}
