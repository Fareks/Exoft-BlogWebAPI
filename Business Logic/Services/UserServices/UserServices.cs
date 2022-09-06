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
        IUserRepository _userRepository;
        IMapper _mapper;
        public UserServices(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = repo;
        }
        public async Task DeleteById(Guid id)
        {
            
            await _userRepository.DeleteById(id);
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
            newItem.CreatedDate = DateTime.UtcNow;
            var user = _mapper.Map<User>(newItem);
            await _userRepository.Post(user);
            await _userRepository.Save();
        }

        public async Task Update(UserUpdateDTO userUpdateDTO)
        {
            var user = await _userRepository.GetByIdAsync(userUpdateDTO.Id);
            var updatedUser = _mapper.Map(userUpdateDTO, user);
            updatedUser.UpdateDate = DateTime.UtcNow;
            await _userRepository.Update(updatedUser);
            await _userRepository.Save();
        }
    }
}
