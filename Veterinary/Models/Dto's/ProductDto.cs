namespace Veterinary.Models.Dto_s
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string? SupplierAddress { get; set; }
        public string Uses { get; set; } = string.Empty;
        public bool IsMedicine { get; set; }
        public string? CabinetCode { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}
