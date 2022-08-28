using Exoft_BlogWebAPI.Models;
using Exoft_BlogWebAPI.Services;
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


            [HttpGet("/blogs")]
            public IActionResult GetBlogs()
            {
                return Ok(postService.GetAll());
            }

            [HttpGet("/blogs/{id}")]
            public IActionResult GetBlogById(Guid id)
            {
                return Ok(postService.GetById(id));
            }


        [HttpPost]
            public IActionResult AddBlog([FromBody] Post post)
            {
                postService.Post(post);
                return Ok(post);
            }

            [HttpPut]
            public IActionResult UpdateBlog(Post post)
            {
                postService.Update(post);
                return Ok();
            }

            [HttpDelete]
            public IActionResult DeleteUser(Guid postId)
            {
                if (postService.GetById(postId) != null)
                {
                    postService.DeleteById(postId);
                    return Ok();
                }
                else
                {
                    return BadRequest("Blog not found.");
                }


            }
        }
}
