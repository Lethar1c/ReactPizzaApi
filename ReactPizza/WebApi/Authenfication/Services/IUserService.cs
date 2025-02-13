using ReactPizza.WebApi.Authenfication.Dtos;

namespace ReactPizza.WebApi.Authenfication.Services
{
    public interface IUserService
    {
        public Task<UserDto?> AddUser(UserDto userDto);
        public Task<UserDto?> GetUser(int id);
        public Task<List<UserDto>> GetAll();
        public Task<UserDto?> UpdateUser(int id, UserDto userDto);
        public Task DeleteUser(int id);
    }
}
