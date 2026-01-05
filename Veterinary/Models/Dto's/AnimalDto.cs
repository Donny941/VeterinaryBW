namespace Veterinary.Models.Dto_s
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? CoatColor { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool HasMicrochip { get; set; }
        public string? MicrochipNumber { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public string OwnerSurname { get; set; } = string.Empty;
        public string OwnerTaxCode { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
    }
}
