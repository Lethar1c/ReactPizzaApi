using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReactPizza.DataAccess.Models;
using ReactPizza.WebApi.Authentication.Dtos;
using ReactPizza.WebApi.Authentication.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ReactPizza.WebApi.Authentication.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserAuthDto userDto)
        {
            User? user = await _userService.MatchPassword(userDto.Email, userDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            List<Claim> claims = [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.Name)
            ];
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.AddMonths(3),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
