using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Veterinary.Models
{
    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string? FullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = string.Empty;
    }
}
