using Veterinary.Models.Dto_s;

namespace Veterinary.Services.Interface
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDto>> GetAllAnimalsAsync();
        Task<AnimalDto?> GetAnimalById(int id);
        Task<AnimalDto?> GetAnimalByMicrochip(string microchipNumber);
        Task<AnimalDto> CreateAsync(CreateUpdateAnimalDto createAnimalDto);
        Task<AnimalDto?> UpdateAsync(int id, CreateUpdateAnimalDto updateAnimalDto);
        Task<bool> DeleteAsync(int id);
    }
}
