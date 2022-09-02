using AutoMapper;
using Business_Logic.DTO;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic.Services.UserServices
{
    public class UserServices : IUserService
    {
        IRepository<User> _userRepository;
        IMapper _mapper;
        public UserServices(IRepository<User> repo, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = repo;
        }
        public async Task DeleteById(Guid id)
        {
            await _userRepository.Delete(id);
            await _userRepository.Save();
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = _mapper.Map<List<UserDTO>>(await _userRepository.GetAllAsync());
            return users;
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task Post(UserCreateDTO newItem)
        {
            var user = _mapper.Map<User>(newItem);
            await _userRepository.Post(user);
        }

        public async Task Update(UserUpdateDTO item)
        {
            var user = _mapper.Map<User>(item);
            await _userRepository.Update(user);
        }
    }
}
