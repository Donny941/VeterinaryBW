using System.ComponentModel.DataAnnotations;

namespace Veterinary.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty; // cane, gatto, etc.

        [MaxLength(50)]
        public string? CoatColor { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool HasMicrochip { get; set; }

        [MaxLength(20)]
        public string? MicrochipNumber { get; set; }

        // Owner information
        [Required]
        [MaxLength(100)]
        public string OwnerName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string OwnerSurname { get; set; } = string.Empty;

        [Required]
        [MaxLength(16)]
        public string OwnerTaxCode { get; set; } = string.Empty;

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
        public Recovery? Recovery { get; set; }
    }
}
