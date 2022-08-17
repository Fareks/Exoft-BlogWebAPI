using Exoft_BlogWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        DBContext dbContext;
       

        public UserController(DBContext _db)
        {
            dbContext = _db;

        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var a = dbContext.Users.Include(u => u.Blog.ToList().First());
            return Ok(a);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return Ok(dbContext.Users);
        }

        //[HttpPut]
        //public IActionResult AddBlogToUser()
        
    }
}
