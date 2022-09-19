using DataLayer.Models;
using Business_Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Business_Logic.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Business_Logic.Enums;
using Business_Logic.DTO.UserDTOs;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        IAuthService _authService;
        IMapper _mapper; 
       

        public UserController(IUserService userService, IMapper mapper, IAuthService authService)
        {
            _userService = userService;
            _mapper = mapper;
            _authService = authService;
        }


        [HttpGet("/admin/users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("/users/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO user)
        {
            if (await _authService.GetMyId() == user.Id || user.Role.ToString() == "Admin")
            {
                await _userService.UpdateAsync(user);
                return Ok();
            } else
            {
                return BadRequest("Can`t update user.");
            }
            
        }

        [HttpDelete("/admin/delete-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                await _userService.DeleteByIdAsync(userId);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/admin/ban-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BanUser(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user.Role == Roles.Admin)
            {
                await _userService.BanUserByIdAsync(id);
                return Ok("User is deleted.");
            }
            else
            {
                return BadRequest("Can`t delete user.");
            }
        }

        [HttpPut("admin/change-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(Guid id, int role)
        {
            var user = await _userService.GetByIdAsync(id);
            var currentUser = User.Claims;
            if (Enum.IsDefined(typeof(Roles), role))
            {
                await _userService.ChangeRole(id,role);
                return Ok("Role changed");
            }
            else
            {
                return BadRequest("Can`t change role.");
            }
        }

    }
}
