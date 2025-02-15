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
        public Task<bool> MatchPassword(int id, string password);
    }
}
