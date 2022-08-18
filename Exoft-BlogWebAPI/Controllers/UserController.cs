using Exoft_BlogWebAPI.Models;
using Exoft_BlogWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserServices userService;
       

        public UserController(IUserServices _userService)
        {
            userService = _userService;
        }


        [HttpGet("/users")]
        public IActionResult GetUsers()
        {
            return Ok(userService.GetAll());
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            userService.PostUser(user);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult AddBlogToUser(User user)
        {
            userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            if (userService.GetById(userId) != null)
            {
                userService.DeleteById(userId);
                return Ok();
            } else
            {
                return BadRequest("User not found.");
            }
            
           
        }


    }
}
