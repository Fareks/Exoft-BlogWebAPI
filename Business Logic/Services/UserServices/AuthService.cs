using AutoMapper;
using Business_Logic.DTO.UserDTOs;
using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;


namespace Business_Logic.Services.UserServices
{
    public class AuthService : IAuthService
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;
        readonly IHttpContextAccessor _contextAccessor;
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly ITokenService _tokenService;

        public AuthService(IHttpContextAccessor contextAccessor,IConfiguration configuration, IUserRepository userRepository, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task RegisterUser (UserCreateDTO userCreateDTO)
        {

            var newUser = _mapper.Map<User>(userCreateDTO);
            var result = await _userManager.CreateAsync(newUser, userCreateDTO.Password);
            //await _userRepository.Post(newUser);
            await _userRepository.Save();

        }
        public async Task<string> LoginUser(UserLoginDTO userLoginDTO)
        {
            User targetUser = await _userRepository.GetByEmailAsync(userLoginDTO.Email);
            if (targetUser != null)
            {
                var result = await _signInManager.CanSignInAsync(targetUser);
                if (result)
                {
                    var token = await _tokenService.CreateToken(_mapper.Map<UserReadDTO>(targetUser));
                    return (token);
                }
                else return null;
            }
            else return null;   
        }
        public async Task<UserReadDTO> GetMe()
        {
            if (_contextAccessor != null)
            {
                var userEmail = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
                var user = _mapper.Map<UserReadDTO>(await _userRepository.GetByEmailAsync(userEmail));
                return user;
            }
            else return null;
        }
        public async Task<Guid> GetMyId()
        {
                var userEmail = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
                var user = _mapper.Map<UserReadDTO>(await _userRepository.GetByEmailAsync(userEmail));
                return user.Id;
        }
        public async Task<bool> IsAuthor(Guid authorId)
        {
            return (await GetMyId() ==  authorId);
        }
        
        public async Task<bool> EmailIsExist(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return (user != null);
        }


        public async Task<string> CreateToken(UserReadDTO userDTO)
        {
            var result = await _tokenService.CreateToken(userDTO);
            return result;
        }
        public RefreshToken GenerateRefreshToken()
        {
            return _tokenService.GenerateRefreshToken();
        }
        public async Task SetRefreshToken(RefreshToken newRefreshToken, UserReadDTO userDTO)
        {
            await _tokenService.SetRefreshToken(newRefreshToken, userDTO);
        }
    }
}
