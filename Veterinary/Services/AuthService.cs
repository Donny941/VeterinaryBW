using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Veterinary.Models;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;

namespace Veterinary.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;

        private readonly IConfiguration _configuration;
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        private string GenerateTokenJWT(User user)
        {
            var setting = _configuration.GetSection("JwtSettings");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting["SecretKey"]!));

            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.FullName),
           };

            var token = new JwtSecurityToken(
                issuer: setting["Issuer"],
                audience: setting["Audience"],
                claims: claims,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }



        public async Task<AuthResponse> RegisterAsync(RegisterDto request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);

            if (existingUser != null)
                return null;


            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail != null)
                return null;

            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                FullName = request.FullName,
                Role = request.Role

            };//metto la password nel create async e non quando istanzio l'user perchè il create asyn mi hasha la password

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return null;

            var token = GenerateTokenJWT(user);

            return new AuthResponse
            {
                Token = token,
                Username = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                Expiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtSettings:ExpirationMinutes"]!))
            };

        }

        public async Task<AuthResponse> LoginAsync(LoginDto loginRequest)
        {
            //l'EF tracca da solo, quindi quando diciamo che user è uguale allo Username in realtà va all'account o comunqeu all'entità e gli da tutte le proprietà di User
            var user = await _userManager.FindByNameAsync(loginRequest.Username);

            if (user == null)
                return null;

            var password = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (password == null)
                return null;

            var token = GenerateTokenJWT(user);

            return new AuthResponse
            {
                Token = token,
                Username = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                Expiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtSettings:ExpirationMinutes"]!))
            };

        }


    }
}
