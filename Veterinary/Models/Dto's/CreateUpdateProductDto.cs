using System.ComponentModel.DataAnnotations;

namespace Veterinary.Models.Dto_s
{
    public class CreateUpdateProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string SupplierName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? SupplierAddress { get; set; }

        [Required]
        [MaxLength(500)]
        public string Uses { get; set; } = string.Empty;

        [Required]
        public bool IsMedicine { get; set; }

        [MaxLength(20)]
        public string? CabinetCode { get; set; }

        [Required]
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}
