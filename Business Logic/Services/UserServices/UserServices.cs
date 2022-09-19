using AutoMapper;
using Business_Logic.DTO.UserDTOs;
using Business_Logic.Enums;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic.Services.UserServices
{
    public class UserServices : IUserService
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;
        public UserServices(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = repo;
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            
            await _userRepository.DeleteById(id);
            await _userRepository.Save();
        }
        
        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = _mapper.Map<List<UserDTO>>(await _userRepository.GetAllAsync());
            return users;
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task PostAsync(UserCreateDTO newItem)
        {
            newItem.CreatedDate = DateTime.UtcNow;
            var user = _mapper.Map<User>(newItem);
            await _userRepository.Post(user);
            await _userRepository.Save();
        }

        public async Task UpdateAsync(UserUpdateDTO userUpdateDTO)
        {
            var user = await _userRepository.GetByIdAsync(userUpdateDTO.Id);
            var updatedUser = _mapper.Map(userUpdateDTO, user);
            updatedUser.UpdateDate = DateTime.UtcNow;
            await _userRepository.Update(updatedUser);
            await _userRepository.Save();
        }
        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
        public async Task<bool> BanUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            user.IsBanned = true;
            await _userRepository.Save();
            return user.IsBanned;
        }
        public async Task ChangeRole(Guid id, int role)
        {
            var user = await _userRepository.GetByIdAsync(id);
            user.Role = (Roles)role;
            await _userRepository.Save();
        }

    }
}
