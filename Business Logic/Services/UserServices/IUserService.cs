using Business_Logic.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.UserServices
{
    public interface IUserService
    {
        public Task<bool> BanUserByIdAsync(Guid id,CancellationToken token = default);
        public Task<IEnumerable<UserReadDTO>> GetAllAsync(CancellationToken token = default);
        public Task<UserReadDTO> GetByIdAsync(Guid id,CancellationToken token = default);
        public Task UpdateAsync(UserUpdateDTO item, CancellationToken token = default);

        //Must accept id, call repository.Delete(repository.GetById)
        public Task DeleteByIdAsync(Guid id,CancellationToken token = default);
        public Task PostAsync(UserCreateDTO newItem,CancellationToken token = default);
        public Task<UserReadDTO> GetUserByEmailAsync(string email,CancellationToken token = default);
        public Task ChangeRole(Guid id, int role,CancellationToken token = default);
    }
}
