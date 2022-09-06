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

        public AuthService(IConfiguration configuration,IUserRepository userRepository, IMapper mapper)
        {
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
                var token = CreateToken(targetUser);
                return token;
            }
            else return null;   
        }
        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
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
    }
}
