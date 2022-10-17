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
        public async Task DeleteByIdAsync(Guid id, CancellationToken token = default)
        {
            
            await _userRepository.DeleteById(id, token);
            await _userRepository.Save();
        }
        
        public async Task<IEnumerable<UserReadDTO>> GetAllAsync(CancellationToken token = default)
        {
            var users = _mapper.Map<List<UserReadDTO>>(await _userRepository.GetAllAsync(token));
            return users;
        }

        public async Task<UserReadDTO> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            var user = await _userRepository.GetByIdAsync(id, token);
            var userDTO = _mapper.Map<UserReadDTO>(user);
            return userDTO;
        }

        public async Task PostAsync(UserCreateDTO newItem, CancellationToken token = default)
        {
            newItem.CreatedDate = DateTime.UtcNow;
            var user = _mapper.Map<User>(newItem);
            await _userRepository.Post(user, token);
            await _userRepository.Save(token);
        }

        public async Task UpdateAsync(UserUpdateDTO userUpdateDTO, CancellationToken token = default)
        {
            var user = await _userRepository.GetByIdAsync(userUpdateDTO.Id, token);
            var updatedUser = _mapper.Map(userUpdateDTO, user);
            await _userRepository.Update(updatedUser, token);
            await _userRepository.Save(token);
        }
        public async Task<UserReadDTO> GetUserByEmailAsync(string email, CancellationToken token = default)
        {
            var user = await _userRepository.GetByEmailAsync(email, token);
            var userDTO = _mapper.Map<UserReadDTO>(user);
            return userDTO;
        }
        public async Task<bool> BanUserByIdAsync(Guid id, CancellationToken token = default)
        {
            var user = await _userRepository.GetByIdAsync(id, token);
            user.IsBanned = true;
            await _userRepository.Save(token);
            return user.IsBanned;
        }
        public async Task ChangeRole(Guid id, int role, CancellationToken token = default)
        {
            var user = await _userRepository.GetByIdAsync(id, token);
            user.Role = (Roles)role;
            await _userRepository.Save(token);
        }

    }
}
