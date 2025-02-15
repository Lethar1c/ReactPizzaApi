namespace ReactPizza.WebApi.Authentication.Services
{
    public interface IPasswordService
    {
        public string HashPassword(string user, string password);
        public bool Match(string user, string password, string hashed_password);
    }
}
