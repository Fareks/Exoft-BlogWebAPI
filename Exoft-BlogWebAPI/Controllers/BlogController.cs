using Exoft_BlogWebAPI.Models;
using Exoft_BlogWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class BlogController : ControllerBase
        {
            ICRUDService<Blog> blogService;


            public BlogController(ICRUDService<Blog> _userService)
            {
                blogService = _userService;
            }


            [HttpGet("/blogs")]
            public IActionResult GetUsers()
            {
                return Ok(blogService.GetAll());
            }

            [HttpPost]
            public IActionResult AddBlog([FromBody] Blog blog)
            {
                blogService.Post(blog);
                return Ok(blog);
            }

            [HttpPut]
            public IActionResult UpdateBlog(Blog blog)
            {
                blogService.Update(blog);
                return Ok();
            }

            [HttpDelete]
            public IActionResult DeleteUser(int blogId)
            {
                if (blogService.GetById(blogId) != null)
                {
                    blogService.DeleteById(blogId);
                    return Ok();
                }
                else
                {
                    return BadRequest("Blog not found.");
                }


            }
        }
}
