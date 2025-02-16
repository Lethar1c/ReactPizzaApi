namespace ReactPizza.WebApi.Authentication.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Name { get; set; } = "";
    }
}
