using DataLayer.Models;
using Business_Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Business_Logic.DTO;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        ICRUDService<User> _userService;
        IMapper _mapper; 
       

        public UserController(ICRUDService<User> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }   


        [HttpGet("/users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAll();
            var usersDto = _mapper.Map<ICollection<UserDTO>>(users);
            return Ok(usersDto);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _userService.Post(user);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult AddBlogToUser(User user)
        {

            _userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(Guid userId)
        {
            if (_userService.GetById(userId) != null)
            {
                _userService.DeleteById(userId);
                return Ok();
            } else
            {
                return BadRequest("User not found.");
            }
            
           
        }


    }
}
