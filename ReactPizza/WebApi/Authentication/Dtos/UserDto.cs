namespace ReactPizza.WebApi.Authentication.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public RoleDto Role { get; set; } = null!;
        public UserDto() { }
    }
}
