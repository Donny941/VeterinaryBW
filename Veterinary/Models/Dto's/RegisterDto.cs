using System.ComponentModel.DataAnnotations;

namespace Veterinary.Models.Dto_s
{
    public class RegisterDto
    {
        public required string Username { get; set; }
        [EmailAddress]
        public required string Email { get; set; }

        public required string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public required string ConfirmPassword { get; set; }
        public required string Role { get; set; }
        public required string FullName { get; set; }

    }
}
