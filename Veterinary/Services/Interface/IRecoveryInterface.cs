using Veterinary.Models.Dto_s;

namespace Veterinary.Services.Interface
{
    public interface IRecoveryInterface
    {

        Task<RecoveryDto> CreateRecoveryAsync(CreateUpdateRecoveryDto createRecoveryDto);
        
        Task<RecoveryDto> UpdateRecoveryAsync(int recoveryId, CreateUpdateRecoveryDto updateRecoveryDto);

        Task<IEnumerable<RecoveryDto>> GetAllRecoveryAsync();
        Task<RecoveryDto> GetRecoveryByIdAsync(int id);
        Task<IEnumerable<RecoveryDto>> GetRecoveryByAnimalIdAsync(int animalId);
    }
}
