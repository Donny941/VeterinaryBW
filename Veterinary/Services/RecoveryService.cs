using Microsoft.EntityFrameworkCore;
using Veterinary.Models;
using Veterinary.Models.Data;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;

namespace Veterinary.Services
{

    public class RecoveryService : IRecoveryInterface
    {
        private readonly VetClinicDbContext _context;

        public RecoveryService(VetClinicDbContext context)
        {
            _context = context;
        }
        public async Task<RecoveryDto> CreateRecoveryAsync(CreateUpdateRecoveryDto createRecoveryDto)
        {
            var recovery = new Recovery
            {
                RecoveryStartDate = createRecoveryDto.RecoveryStartDate,
                RecoveryEndDate = createRecoveryDto.RecoveryEndDate,
                AnimalDescription = createRecoveryDto.AnimalDescription,
                ShelterDetails = createRecoveryDto.ShelterDetails,
                IsActive = createRecoveryDto.IsActive,
                AnimalId = createRecoveryDto.AnimalId
            };
            _context.Recoveries.Add(recovery);
            await _context.SaveChangesAsync();

            return new RecoveryDto
            {
                Id = recovery.Id,
                RecoveryStartDate = recovery.RecoveryStartDate,
                RecoveryEndDate = recovery.RecoveryEndDate,
                AnimalDescription = recovery.AnimalDescription,
                ShelterDetails = recovery.ShelterDetails,
                IsActive = recovery.IsActive,
                AnimalId = recovery.AnimalId

            };
        }

        public async Task<RecoveryDto> UpdateRecoveryAsync(int recoveryId,CreateUpdateRecoveryDto updateRecoveryDto)
        {
            var recovery =await _context.Recoveries.FindAsync(recoveryId);
            
            recovery.RecoveryStartDate = updateRecoveryDto.RecoveryStartDate;
            recovery.RecoveryEndDate = updateRecoveryDto.RecoveryEndDate;
            recovery.AnimalDescription = updateRecoveryDto.AnimalDescription;
            recovery.ShelterDetails = updateRecoveryDto.ShelterDetails;
            recovery.IsActive = updateRecoveryDto.IsActive;
            recovery.AnimalId = updateRecoveryDto.AnimalId;

            await _context.SaveChangesAsync();

            return new RecoveryDto
            {
                Id = recovery.Id,
                RecoveryStartDate = recovery.RecoveryStartDate,
                RecoveryEndDate = recovery.RecoveryEndDate,
                AnimalDescription = recovery.AnimalDescription,
                ShelterDetails = recovery.ShelterDetails,
                IsActive = recovery.IsActive,
                AnimalId = recovery.AnimalId
            };
        }
        public async Task<IEnumerable<RecoveryDto>> GetAllRecoveryAsync()
        {
            return await _context.Recoveries.Select(recovery => new RecoveryDto
            {
                Id = recovery.Id,
                RecoveryStartDate = recovery.RecoveryStartDate,
                RecoveryEndDate = recovery.RecoveryEndDate,
                AnimalDescription = recovery.AnimalDescription,
                ShelterDetails = recovery.ShelterDetails,
                IsActive = recovery.IsActive,
                AnimalId = recovery.AnimalId
            }).ToListAsync();        
        }

        public async Task<RecoveryDto> GetRecoveryByIdAsync(int id)
        {
            var recovery = await _context.Recoveries.FindAsync(id);

            if (recovery is null)
                return null;
            return new RecoveryDto
            {
                Id = recovery.Id,
                RecoveryStartDate = recovery.RecoveryStartDate,
                RecoveryEndDate = recovery.RecoveryEndDate,
                AnimalDescription = recovery.AnimalDescription,
                ShelterDetails = recovery.ShelterDetails,
                IsActive = recovery.IsActive,
                AnimalId = recovery.AnimalId
            };
        }
        public async Task<IEnumerable<RecoveryDto>> GetRecoveryByAnimalIdAsync(int animalId)
        {
            var recovery = await _context.Recoveries.
                Where(recovery => recovery.AnimalId == animalId).
                Select(recovery => new RecoveryDto
                {
                    Id = recovery.Id,
                    RecoveryStartDate = recovery.RecoveryStartDate,
                    RecoveryEndDate = recovery.RecoveryEndDate,
                    AnimalDescription = recovery.AnimalDescription,
                    ShelterDetails = recovery.ShelterDetails,
                    IsActive = recovery.IsActive,
                    AnimalId = recovery.AnimalId
                }).ToListAsync();

            return recovery;
        }
    }
}
