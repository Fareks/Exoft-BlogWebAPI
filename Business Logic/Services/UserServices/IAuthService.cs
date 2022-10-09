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
        public Task<bool> UserIsExist(string email, string username);
        public Task RegisterUser(UserCreateDTO userCreateDTO);
        public Task<string> LoginUser(UserLoginDTO userLoginDTO);
        public Task<UserReadDTO> GetMe();
        public Task<Guid> GetMyId();
        public Task<bool> IsAuthor(Guid authorId);
        public Task<string> CreateToken(UserReadDTO userDTO);
        public RefreshToken GenerateRefreshToken();
        public Task SetRefreshToken(RefreshToken newRefreshToken, UserReadDTO userDTO);
    }
}
