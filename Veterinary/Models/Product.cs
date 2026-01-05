using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

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

        public bool IsMedicine { get; set; }

        [MaxLength(20)]
        public string? CabinetCode { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
