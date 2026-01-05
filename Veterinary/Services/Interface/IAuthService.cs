using Veterinary.Models.Dto_s;

namespace Veterinary.Services.Interface
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterDto registerRequest);
        Task<AuthResponse> LoginAsync(LoginDto loginRequest);
    }
}
