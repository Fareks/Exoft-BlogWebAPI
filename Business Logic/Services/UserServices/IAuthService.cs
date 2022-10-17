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
        public Task<bool> UserIsExist(string email, string username, CancellationToken token = default);
        public Task RegisterUser(UserCreateDTO userCreateDTO,CancellationToken token = default);
        public Task<string> LoginUser(UserLoginDTO userLoginDTO,CancellationToken token = default);
        public Task<UserReadDTO> GetMe(CancellationToken token = default);
        public Task<Guid> GetMyId(CancellationToken token = default);
        public Task<bool> IsAuthor(Guid authorId,CancellationToken token = default);
        public Task<string> CreateToken(UserReadDTO userDTO,CancellationToken token = default);
        public RefreshToken GenerateRefreshToken();
        public Task SetRefreshToken(RefreshToken newRefreshToken, UserReadDTO userDTO,CancellationToken token = default);
    }
}
