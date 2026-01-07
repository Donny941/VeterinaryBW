using Veterinary.Models.Dto_s;

namespace Veterinary.Services.Interface
{
    public interface IVisitInterface
    {
        Task<VisitDto> CreateVisitAsync (CreateUpdateVisitDto visit);

        Task<VisitDto> UpdateVisitAsync(CreateUpdateVisitDto visit, int id);
        Task<IEnumerable<VisitDto>> GetAllVisitAsync();
        Task<VisitDto> GetByIdAsync(int id);
        Task<IEnumerable<VisitDto>> GetByNameAsync(string name);
        Task<IEnumerable<VisitDto>> GetAnimalVisitHistoryAsync(int animalId);

    }
}
