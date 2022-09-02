using Business_Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.UserServices
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDTO>> GetAll();
        public Task<UserDTO> GetById(Guid id);
        public Task Update(UserUpdateDTO item);
        public Task DeleteById(Guid id);
        public Task Post(UserCreateDTO newItem);
    }
}
