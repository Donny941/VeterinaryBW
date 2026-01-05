using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Models;
using Veterinary.Models.Data;
using Veterinary.Models.Dto_s;
using Veterinary.Services;
using Veterinary.Services.Interface;
using RegisterDto = Veterinary.Models.Dto_s.RegisterDto;

namespace Veterinary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterAsync(registerRequest);

            if (result == null)
            {
                return BadRequest(new { message = "Username or Email already exist" });
            }
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.LoginAsync(loginRequest);

            if (result == null)
            {
                return BadRequest(new { message = "Invalid Username or Email" });
            }
            return Ok(result);

        }
    }

}
