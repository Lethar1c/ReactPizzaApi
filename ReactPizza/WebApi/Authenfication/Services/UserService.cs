﻿using ReactPizza.DataAccess.Models;
using ReactPizza.DataAccess.Repositories;
using ReactPizza.WebApi.Authenfication.Dtos;

namespace ReactPizza.WebApi.Authenfication.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        private UserDto? UserToDto(User? user)
        {
            if (user == null) return null;
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                HashedPassword = user.HashedPassword,
                Role = new RoleDto(user.Role.Id, user.Role.Name)
            };
        }

        private User? DtoToUser(UserDto? user)
        {
            if (user == null) return null;
            return new User
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                HashedPassword = user.HashedPassword,
                Role = new Role(user.Role.Name)
            };
        }

        public async Task<UserDto?> AddUser(UserDto userDto)
        {
            User? newUser = DtoToUser(userDto);
            if (newUser == null) return null;
            return UserToDto(await _userRepository.Add(newUser));
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<List<UserDto>> GetAll()
        {
            List<User> users = await _userRepository.GetAll();
            List<UserDto> result = [];
            foreach (var user in users)
            {
                UserDto? userDto = UserToDto(user);
                if (userDto == null) continue;
                result.Add(userDto);
            }
            return result;
        }

        public async Task<UserDto?> GetUser(int id)
        {
            User? user = await _userRepository.Get(id);
            if (user == null) return null;
            return UserToDto(user);
        }

        public async Task<UserDto?> UpdateUser(int id, UserDto userDto)
        {
            User? newUser = DtoToUser(userDto);
            if (newUser == null) return null;
            User? newUserDto = await _userRepository.Update(id, newUser);
            return UserToDto(newUserDto);
        }
    }
}
