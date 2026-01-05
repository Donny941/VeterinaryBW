namespace Veterinary.Models.Dto_s
{
    public class CreateUpdateAnimalDto
    {
        public required string? Name { get; set; }

        public required string? Type { get; set; }
        public string? CoatColor { get; set; }
        public DateTime BirthDate { get; set; }

        public bool HasMicrochip { get; set; }

        public string? MicrochipNumber { get; set; }

        public required string OwnerName { get; set; }
        public required string OwnerSurName { get; set; }
        public required string OwnerTaxCode { get; set; }

    }
}
