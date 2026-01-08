using System.ComponentModel.DataAnnotations;

namespace Veterinary.Models.Dto_s
{
    public class CreateUpdateSaleDto
    {

        [Required]
        public DateTime SaleDate { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(16)]
        public string ClientTaxCode { get; set; } = string.Empty;//codice fiscale x detrazione tasse(?)
        [MaxLength(50)]
        public string? PrescriptionNumber { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; } = 1;
    }
}
