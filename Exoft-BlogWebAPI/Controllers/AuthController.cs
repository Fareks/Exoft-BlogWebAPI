using Business_Logic.DTO;
using Business_Logic.Services.UserServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;


namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        IConfiguration _configuration;
        IAuthService _authService;
        IUserService _userService;

        public AuthController(IUserService userService, IConfiguration configuration, IAuthService authService)
        {
            _userService = userService;
            _configuration = configuration;
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> registerUser(UserCreateDTO userDTO)
        {
                await _authService.RegisterUser(userDTO);
                return Ok(userDTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> loginUser(UserLoginDTO userDTO)
        {
            
            var user = await _authService.LoginUser(userDTO);
            if (user == null)
            {
                return BadRequest("User not found");
            } else
                return Ok(user);
       
        }
    }
}
