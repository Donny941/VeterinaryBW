namespace Veterinary.Models.Dto_s
{
    public class AuthResponse
    {
        
        public string? Token { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? FullName { get; set; }
        public DateTime Expiration { get; set; }

    }
}
