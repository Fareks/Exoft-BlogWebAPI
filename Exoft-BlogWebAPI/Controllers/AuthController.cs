﻿using Business_Logic.DTO.UserDTOs;
using Business_Logic.Services.UserServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {

        readonly IConfiguration _configuration;
        readonly IAuthService _authService;
        readonly IUserService _userService;
        

        public AuthController(IUserService userService, IConfiguration configuration, IAuthService authService)
        {
            _userService = userService;
            _configuration = configuration;
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserCreateDTO userDTO)
        {
            if (await _authService.EmailIsExist(userDTO.Email))
            {
                return BadRequest("Email is already registered.");
            } else
            {
                await _authService.RegisterUser(userDTO);
                return Ok(userDTO);
            }
                
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(UserLoginDTO userDTO)
        {
            
            var user = await _authService.LoginUser(userDTO);
            if (user == null)
            {
                return BadRequest("Wrong user or password");
            } else
                return Ok(user);
       
        }
        [HttpGet, Authorize]
        public async Task<IActionResult> GetMe()
        {
            var currentUser = await _authService.GetMe();
            return Ok(currentUser);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            var refreshToken = Request.Cookies["refreshToken"];
            if(user == null)
            {
                return BadRequest("Bad Request. User Not Found.");
            } else
            if(!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = await _authService.CreateToken(user);
            var newRefreshToken = _authService.GenerateRefreshToken();
            await _authService.SetRefreshToken(newRefreshToken, user);

            return Ok(token);
        }
    }
}
