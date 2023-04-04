using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO.DTOAuth.LoginDTO;
using NZWalks.API.Models.DTO.DTOAuth.RegistersDTO;
using NZWalks.API.Models.DTO.DTOLogin;
using NZWalks.API.Services.Interfaces.ITokens;

namespace NZWalks.API.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepositories tokenRepositories;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepositories tokenRepositories)
        {
            this.userManager = userManager;
            this.tokenRepositories = tokenRepositories;
        }

        // POST : /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                // Add Roles To User
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User Was Register! Please Login!");
                    }
                }
            }
            return BadRequest("Something Went Wrong");
        }

        // POST : /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var userNm = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if (userNm != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(userNm, loginRequestDto.Password);

                // Check Is Password Success
                if (checkPasswordResult)
                {
                    // Get Roles this user
                    var roles = await userManager.GetRolesAsync(userNm);

                    // Check Roles
                    if (roles != null)
                    {
                        // Create Token 

                        var jwtToken = tokenRepositories.CreateJWTToken(userNm, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("UserName Or Password Incorrect");
        }
    }
}
