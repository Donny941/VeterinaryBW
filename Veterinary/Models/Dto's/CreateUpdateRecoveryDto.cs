using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Models.Dto_s
{
    public class CreateUpdateRecoveryDto
    {
        

        [Required]
        public DateTime RecoveryStartDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string AnimalDescription { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? ShelterDetails { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? RecoveryEndDate { get; set; }

        // Foreign key
        [Required]
        public int AnimalId { get; set; }

       
    }
}
