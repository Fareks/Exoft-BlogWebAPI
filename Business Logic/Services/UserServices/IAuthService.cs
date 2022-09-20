using Business_Logic.DTO.UserDTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.UserServices
{
    public interface IAuthService
    {
        public Task<bool> EmailIsExist(string email);
        public Task RegisterUser(UserCreateDTO userCreateDTO);
        public Task<string> LoginUser(UserLoginDTO userLoginDTO);
        public Task<UserReadDTO> GetMe();
        public Task<Guid> GetMyId();
        //public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        //public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public Task<string> CreateToken(UserReadDTO userDTO);
        public Task SetRefreshToken(RefreshToken newRefreshToken, UserReadDTO userDTO);
        public RefreshToken GenerateRefreshToken();
        public Task<bool> IsAuthor(Guid authorId);

    }
}
