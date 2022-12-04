using CryptoApp.API.Dtos.Authentication;
using CryptoApp.API.Models;
using CryptoApp.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CryptoApp.API.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            var existingUser = await _userManager.FindByNameAsync(registerDto.UserName);

            if (existingUser != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Status = "Error", Message = "User creation failed. There is a user registered with this email or username." });
            }

            var newUser = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var creationResult = await _userManager.CreateAsync(newUser, registerDto.Password);
            var roleResult = await _userManager.AddToRoleAsync(newUser, UserRoles.AppUser);

            if (!creationResult.Succeeded || !roleResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Status = "Error", Message = "Error during user creation.", InnerException = $"{creationResult.Errors.FirstOrDefault()}" });
            }

            return Ok(new { Status = "Success", Message = "User successfully created." });
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginAsync([FromQuery] LoginDto loginDto)
        {
            // Find user by email
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            // If user exists and password is correct, authorize, give claims, token
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                return Ok(new LoginVM
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expires = token.ValidTo
                });
            }

            return Unauthorized();
        }
    }
}
