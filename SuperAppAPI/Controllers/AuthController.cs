using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperAppAPI.Models.DTO;
using SuperAppAPI.Repositories;

namespace SuperAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            try
            {
                // ✅ Check for empty or null fields before creating the user
                if (string.IsNullOrWhiteSpace(registerRequestDTO.UserName))
                    return BadRequest("User Name cannot be empty.");

                if (string.IsNullOrWhiteSpace(registerRequestDTO.Password))
                    return BadRequest("Password cannot be empty.");

                if (string.IsNullOrWhiteSpace(registerRequestDTO.PhoneNumber))
                    return BadRequest("Phone Number cannot be empty.");

                var identityUser = new IdentityUser
                {
                    UserName = registerRequestDTO.UserName,
                    Email = registerRequestDTO.UserName,
                    PhoneNumber = registerRequestDTO.PhoneNumber
                };

                var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

                if (identityResult.Succeeded)
                {
                    // ✅ Add role if specified
                    if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                    {
                        identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                        if (identityResult.Succeeded)
                            return Ok("User was Registered! Please login.");
                    }
                }

                // ✅ Handle Identity errors like password rules, duplicate email, etc.
                var errorMessages = string.Join(", ", identityResult.Errors.Select(e => e.Description));
                return BadRequest(errorMessages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        //POST : /api/Auth/Login
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.UserName);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

                if (checkPasswordResult)
                {
                    //get Roles for the user
                    var roles = await userManager.GetRolesAsync(user);

                    //Get UserId 
                    

                    if (roles != null)
                    {
                        //Create a token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                        var userIdString = await userManager.GetUserIdAsync(user);
                        var userId = Guid.Parse(userIdString);
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken,
                            UserId = userId
                        };
                        return Ok(response);

                    }

                }
            }
            return BadRequest("UserName or Password is incorrect");
        }
    }
}
