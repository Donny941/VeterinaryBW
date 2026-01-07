using System.ComponentModel.DataAnnotations;

namespace Veterinary.Models.Dto_s
{
    public class CreateUpdateVisitDto
    {
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
    }
}
