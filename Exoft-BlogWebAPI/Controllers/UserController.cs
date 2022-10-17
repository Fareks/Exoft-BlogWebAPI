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
        readonly IUserService _userService;
        readonly IAuthService _authService;
        readonly IMapper _mapper; 
       

        public UserController(IUserService userService, IMapper mapper, IAuthService authService)
        {
            _userService = userService;
            _mapper = mapper;
            _authService = authService;
        }


        [HttpGet("users")]
        public async Task<IActionResult> GetUsers(CancellationToken token = default)
        {
            var users = await _userService.GetAllAsync(token);
            return Ok(users);
        }

        [HttpGet("/users/{id}")]
        public async Task<IActionResult> GetUser(Guid id, CancellationToken token = default)
        {
            var user = await _userService.GetByIdAsync(id, token);
            return Ok(user);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO user, CancellationToken token = default)
        {
            if (await _authService.GetMyId() == user.Id || user.Role.ToString() == "Admin")
            {
                await _userService.UpdateAsync(user, token);
                return Ok();
            } else
            {
                return BadRequest("Can`t update user.");
            }
            
        }

        [HttpDelete("/admin/delete-user")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteUser(Guid userId, CancellationToken token = default)
        {
            try
            {
                await _userService.DeleteByIdAsync(userId, token);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/admin/ban-user")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> BanUser(Guid id, CancellationToken token = default)
        {
            var user = await _userService.GetByIdAsync(id, token);
            if (user.Role == Roles.Admin)
            {
                await _userService.BanUserByIdAsync(id, token);
                return Ok("User is deleted.");
            }
            else
            {
                return BadRequest("Can`t delete user.");
            }
        }

        [HttpPut("admin/change-role")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> ChangeRole(Guid id, int role, CancellationToken token = default)
        {
            var user = await _userService.GetByIdAsync(id, token);
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
