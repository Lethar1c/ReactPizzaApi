using Microsoft.AspNetCore.Identity;

namespace ReactPizza.WebApi.Authentication.Services
{
    public class PasswordService : IPasswordService
    {
        private PasswordHasher<string> _passwordHasher;
        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<string>();
        }

        public string HashPassword(string user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool Match(string user, string password, string hashed_password)
        {
            return _passwordHasher.VerifyHashedPassword(user, hashed_password, password)
                == PasswordVerificationResult.Success;
        }
    }
}
