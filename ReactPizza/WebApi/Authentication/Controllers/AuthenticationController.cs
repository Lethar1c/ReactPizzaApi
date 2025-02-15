using Microsoft.AspNetCore.Mvc;
using ReactPizza.WebApi.Authentication.Services;

namespace ReactPizza.WebApi.Authentication.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class AuthenticationController
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }



    }
}
