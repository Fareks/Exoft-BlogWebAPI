using DataLayer.Models;
using Business_Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Business_Logic.DTO;
using Business_Logic.Services.UserServices;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        IMapper _mapper; 
       

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }   


        [HttpGet("/users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser(UserCreateDTO user)
        {
            _userService.Post(user);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult UpdateUser(UserUpdateDTO user)
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
