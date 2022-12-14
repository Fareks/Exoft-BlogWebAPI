using Business_Logic.DTO.AuthDTOs;
using Business_Logic.DTO.UserDTOs;
using Business_Logic.Services.UserServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Exoft_BlogWebAPI.Controllers
{
    [AllowAnonymous]
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
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]UserCreateDTO userDTO, CancellationToken ctoken = default)
        {
            if (await _authService.UserIsExist(userDTO.Email, userDTO.UserName, ctoken))
            {
                return BadRequest("User is already registered.");
            } else
            {
                await _authService.RegisterUser(userDTO, ctoken);
                return Ok(userDTO);
            }
                
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(UserLoginDTO userDTO, CancellationToken ctoken = default)
        {
            var user = await _userService.GetUserByEmailAsync(userDTO.Email, ctoken);
            var token = await _authService.LoginUser(userDTO, ctoken);  
            var refreshToken = _authService.GenerateRefreshToken();
            await _authService.SetRefreshToken(refreshToken, user, ctoken);

            AuthDTO response = new AuthDTO(){
                Token = token,
                UserId = user?.Id,
                RefreshToken = refreshToken.Token,
            };
            if (token == null)
            {
                return BadRequest("Wrong user or password");
            } else
                return Ok(response);
       
        }
        [HttpGet("Get-Current-User"), Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetCurrentUser(CancellationToken ctoken = default)
        {
            var currentUser = await _authService.GetMe(ctoken);
            return Ok(currentUser);
        }
        [HttpPost("Refresh-token")]
        public async Task<IActionResult> RefreshToken(Guid userId, string refreshToken, CancellationToken ctoken = default)
        {
            var user = await _userService.GetByIdAsync(userId, ctoken);
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

            string token = await _authService.CreateToken(user, ctoken);
            var newRefreshToken = _authService.GenerateRefreshToken();
            await _authService.SetRefreshToken(newRefreshToken, user, ctoken);

            AuthDTO response = new AuthDTO()
            {
                Token = token,
                UserId = user.Id,
                RefreshToken = newRefreshToken.Token
            };

            return Ok(response);
        }
    }
}
