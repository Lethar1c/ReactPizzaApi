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
    [Route("api/register")]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegistrationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            User? user = await _userService.FirstOrDefault((User user) => user.Email == userDto.Email);
            if (user != null)
            {
                return Conflict("User with this email already exists");
            }
            UserDto? newUser = await _userService.AddUser(new UserDto
            {
                Email = userDto.Email,
                Name = userDto.Name,
                Password = userDto.Password,
                Role = new RoleDto("user")
            });
            if (newUser == null)
            {
                return StatusCode(500, "Unknown error while registrating user.");
            }
            List<Claim> claims = [
                new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()),
                new Claim(ClaimTypes.Email, newUser.Email),
                new Claim(ClaimTypes.Name, newUser.Name),
                new Claim(ClaimTypes.Role, newUser.Role.Name)
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
