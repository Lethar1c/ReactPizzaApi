using ReactPizza.DataAccess.Models;
using ReactPizza.DataAccess.Repositories;
using ReactPizza.WebApi.Authentication.Dtos;

namespace ReactPizza.WebApi.Authentication.Services
{
    public interface IUserService
    {
        public Task<UserDto?> AddUser(UserDto userDto);
        public Task<UserDto?> GetUser(int id);
        public Task<List<UserDto>> GetAll();
        public Task<UserDto?> UpdateUser(int id, UserDto userDto);
        public Task DeleteUser(int id);
        public Task<User?> MatchPassword(int id, string password);
        public Task<User?> MatchPassword(string email, string password);
        public Task<User?> FirstOrDefault(FilterFunction filter);
    }
}
