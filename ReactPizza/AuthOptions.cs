using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ReactPizza
{
    public static class AuthOptions
    {
        public const string ISSUER = "ReactPizzaIss";
        public const string AUDIENCE = "ReactPizzaAud";
        private const string SECURITY_KEY = "123412341234123412341234123412341234asdfqwerjsdjksalafheruurgdjfsdsncnndjjfjsd";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECURITY_KEY));
        }
    }
}
