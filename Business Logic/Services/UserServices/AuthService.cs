using AutoMapper;
using Business_Logic.DTO;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        IUserRepository _userRepository;
        IMapper _mapper;
        IConfiguration _configuration;
        IHttpContextAccessor _contextAccessor;

        public AuthService(IHttpContextAccessor contextAccessor,IConfiguration configuration,IUserRepository userRepository, IMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task RegisterUser (UserCreateDTO userCreateDTO)
        {

            var newUser = _mapper.Map<User>(userCreateDTO);
            CreatePasswordHash(userCreateDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            await _userRepository.Post(newUser);
            await _userRepository.Save();
        }
        public async Task<string> LoginUser(UserLoginDTO userLoginDTO)
        {
            var targetUser = await _userRepository.GetByEmailAsync(userLoginDTO.Email);
            if (targetUser != null && VerifyPasswordHash(userLoginDTO.Password, targetUser.PasswordHash, targetUser.PasswordSalt))
            {
                var token =await CreateToken(_mapper.Map<UserDTO>(targetUser));
                return token;
            }
            else return null;   
        }
        public async Task<UserDTO> GetMe()
        {
            if (_contextAccessor != null)
            {
                var userEmail = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
                var user = _mapper.Map<UserDTO>(await _userRepository.GetByEmailAsync(userEmail));
                return user;
            }
            else return null;
        }
        public async Task<Guid> GetMyId()
        {
                var userEmail = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
                var user = _mapper.Map<UserDTO>(await _userRepository.GetByEmailAsync(userEmail));
                return user.Id;
        }
        public async Task<string> CreateToken(UserDTO userDTO)
        {
            var user = await _userRepository.GetByIdAsync(userDTO.Id);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = GenerateRefreshToken();
            await SetRefreshToken(refreshToken, userDTO);

            return jwt;
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        public RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
            return refreshToken;
        }
        public async Task SetRefreshToken (RefreshToken newRefreshToken, UserDTO userDTO)
        {
            var user = await _userRepository.GetByIdAsync(userDTO.Id);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            _contextAccessor.HttpContext.Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);
            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
            await _userRepository.Save();
        }
        public async Task<bool> EmailIsExist(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return (user != null ? true : false);
        }
    }
}
