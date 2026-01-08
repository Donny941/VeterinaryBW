using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Models.Dto_s
{
    public class SaleDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SaleDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(16)]
        public string ClientTaxCode { get; set; } = string.Empty;//codice fiscale x detrazione tasse(?)

        [MaxLength(50)]
        public string? PrescriptionNumber { get; set; }

        [Required]
        public int ProductId { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
