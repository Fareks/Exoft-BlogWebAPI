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
        public Task<bool> BanUserByIdAsync(Guid id);
        public Task<IEnumerable<UserDTO>> GetAllAsync();
        public Task<UserDTO> GetByIdAsync(Guid id);
        public Task UpdateAsync(UserUpdateDTO item);

        //Must accept id, call repository.Delete(repository.GetById)
        public Task DeleteByIdAsync(Guid id);
        public Task PostAsync(UserCreateDTO newItem);
        public Task<UserDTO> GetUserByEmailAsync(string email);
        public Task ChangeRole(Guid id, int role);
    }
}
