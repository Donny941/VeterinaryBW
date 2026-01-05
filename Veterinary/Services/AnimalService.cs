using Microsoft.EntityFrameworkCore;
using Veterinary.Models;
using Veterinary.Models.Data;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;

namespace Veterinary.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly VetClinicDbContext _context;

        public AnimalService(VetClinicDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalDto> CreateAsync(CreateUpdateAnimalDto createAnimalDto)
        {
            var animal = new Animal
            {
                Name = createAnimalDto.Name,
                Type = createAnimalDto.Type,
                CoatColor = createAnimalDto.CoatColor,
                BirthDate = createAnimalDto.BirthDate,
                HasMicrochip = createAnimalDto.HasMicrochip,
                MicrochipNumber = createAnimalDto.MicrochipNumber,
                OwnerName = createAnimalDto.OwnerName,
                OwnerSurname = createAnimalDto.OwnerSurName,
                RegistrationDate = DateTime.Now
            };

            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type,
                CoatColor = animal.CoatColor,
                BirthDate = animal.BirthDate,
                HasMicrochip = animal.HasMicrochip,
                MicrochipNumber = animal.MicrochipNumber,
                OwnerName = animal.OwnerName,
                OwnerSurname = animal.OwnerSurname,
                OwnerTaxCode = animal.OwnerTaxCode,
                RegistrationDate = animal.RegistrationDate
            };
        }

        public async Task<AnimalDto> UpdateAsync(int id, CreateUpdateAnimalDto updateAnimalDto)
        {
            var animal = _context.Animals
             .Where(a => !a.IsDeleted)
             .FirstOrDefault(a => a.Id == id);

            if (animal == null)
                return null;


            animal.Name = updateAnimalDto.Name;
            animal.Type = updateAnimalDto.Type;
            animal.CoatColor = updateAnimalDto.CoatColor;
            animal.BirthDate = updateAnimalDto.BirthDate;
            animal.HasMicrochip = updateAnimalDto.HasMicrochip;
            animal.MicrochipNumber = updateAnimalDto.MicrochipNumber;
            animal.OwnerName = updateAnimalDto.OwnerName;
            animal.OwnerSurname = updateAnimalDto.OwnerSurName;
            animal.RegistrationDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type,
                CoatColor = animal.CoatColor,
                BirthDate = animal.BirthDate,
                HasMicrochip = animal.HasMicrochip,
                MicrochipNumber = animal.MicrochipNumber,
                OwnerName = animal.OwnerName,
                OwnerSurname = animal.OwnerSurname,
                OwnerTaxCode = animal.OwnerTaxCode,
                RegistrationDate = animal.RegistrationDate
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var animal = _context.Animals
           .Where(a => !a.IsDeleted)
           .FirstOrDefault(a => a.Id == id);

            if (animal == null)
                return false;

            animal.IsDeleted = true;
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<AnimalDto>> GetAllAnimalsAsync()
        {
            return await _context.Animals
                .Where(a => !a.IsDeleted)
                .Select(a => new AnimalDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Type = a.Type,
                    CoatColor = a.CoatColor,
                    BirthDate = a.BirthDate,
                    HasMicrochip = a.HasMicrochip,
                    MicrochipNumber = a.MicrochipNumber,
                    OwnerName = a.OwnerName,
                    OwnerSurname = a.OwnerSurname,
                    OwnerTaxCode = a.OwnerTaxCode,
                    RegistrationDate = a.RegistrationDate
                })
                .ToListAsync();
        }

        public async Task<AnimalDto> GetAnimalById(int id)
        {
            var animal = _context.Animals
            .Where(a => !a.IsDeleted)
            .FirstOrDefault(a => a.Id == id);

            if (animal == null)
                return null;

            return new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type,
                CoatColor = animal.CoatColor,
                BirthDate = animal.BirthDate,
                HasMicrochip = animal.HasMicrochip,
                MicrochipNumber = animal.MicrochipNumber,
                OwnerName = animal.OwnerName,
                OwnerSurname = animal.OwnerSurname,
                OwnerTaxCode = animal.OwnerTaxCode,
                RegistrationDate = animal.RegistrationDate
            };
        }
        public async Task<AnimalDto> GetAnimalByMicrochip(string microchip)
        {
            var animal = _context.Animals
            .Where(a => !a.IsDeleted)
            .FirstOrDefault(a => a.MicrochipNumber == microchip);

            if (animal == null)
                return null;

            return new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type,
                CoatColor = animal.CoatColor,
                BirthDate = animal.BirthDate,
                HasMicrochip = animal.HasMicrochip,
                MicrochipNumber = animal.MicrochipNumber,
                OwnerName = animal.OwnerName,
                OwnerSurname = animal.OwnerSurname,
                OwnerTaxCode = animal.OwnerTaxCode,
                RegistrationDate = animal.RegistrationDate
            };
        }


    }
}
