using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string ObjectiveExamination { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string PrescribedTreatment { get; set; } = string.Empty;

        // Foreign key
        [Required]
        public int AnimalId { get; set; }

        // Navigation property
        [ForeignKey("AnimalId")]
        public Animal Animal { get; set; } = null!;
    }
}
