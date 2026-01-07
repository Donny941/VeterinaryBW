using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.Models;
using Veterinary.Models.Data;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;

namespace Veterinary.Services
{
    public class VisitService : IVisitInterface
    {
        private readonly VetClinicDbContext _context;

        public VisitService(VetClinicDbContext context)
        {
            _context = context;
        }

        public async Task<VisitDto> CreateVisitAsync(CreateUpdateVisitDto visit)
        {
            var visitForm = new Visit
            {
                AnimalId = visit.AnimalId,
                VisitDate = visit.VisitDate,
                ObjectiveExamination = visit.ObjectiveExamination,
                PrescribedTreatment = visit.PrescribedTreatment
            };
            _context.Visits.Add(visitForm);
            await _context.SaveChangesAsync();
            await _context.Entry(visitForm).Reference(v => v.Animal).LoadAsync();
            return new VisitDto
            {
                Id = visitForm.Id,
                VisitDate = visitForm.VisitDate,
                ObjectiveExamination = visitForm.ObjectiveExamination,
                PrescribedTreatment = visitForm.PrescribedTreatment,
                AnimalId = visitForm.AnimalId,
                AnimalName = visitForm.Animal.Name
            };

        }
        public async Task<VisitDto> UpdateVisitAsync(CreateUpdateVisitDto visitDto, int id)
        {
            var visitForm = _context.Visits.Include(v => v.Animal)
              .FirstOrDefault(v => v.Id == id);

            if (visitForm == null)
                return null;

            visitForm.VisitDate = visitDto.VisitDate;
            visitForm.ObjectiveExamination = visitDto.ObjectiveExamination;
            visitForm.PrescribedTreatment = visitDto.PrescribedTreatment;

            await _context.SaveChangesAsync();

            return new VisitDto
            {
                Id = visitForm.Id,
                VisitDate = visitForm.VisitDate,
                ObjectiveExamination = visitForm.ObjectiveExamination,
                PrescribedTreatment = visitForm.PrescribedTreatment,
                AnimalId = visitForm.AnimalId,
                AnimalName = visitForm.Animal.Name
            };

        }

        public async Task<IEnumerable<VisitDto>> GetAllVisitAsync()
        {
            return await _context.Visits.Include(v => v.Animal).Select(v => new VisitDto
            {
                Id = v.Id,
                VisitDate = v.VisitDate,
                ObjectiveExamination = v.ObjectiveExamination,
                PrescribedTreatment = v.PrescribedTreatment,
                AnimalId = v.AnimalId,
                AnimalName = v.Animal.Name
            }).ToListAsync();

        }

        public async Task<IEnumerable<VisitDto>> GetAnimalVisitHistoryAsync(int animalId)
        {

            return await _context.Visits.Where(v => v.AnimalId == animalId).Include(v => v.Animal).Select(v => new VisitDto
            {
                Id = v.Id,
                VisitDate = v.VisitDate,
                ObjectiveExamination = v.ObjectiveExamination,
                PrescribedTreatment = v.PrescribedTreatment,
                AnimalId = v.AnimalId,
                AnimalName = v.Animal.Name
            }).ToListAsync();
        }

        public async Task<VisitDto> GetByIdAsync(int id)
        {
            var visit = _context.Visits.
                 Include(v => v.Animal)
                 .FirstOrDefault(v => v.Id == id);
            return new VisitDto
            {
                Id = visit.Id,
                VisitDate = visit.VisitDate,
                ObjectiveExamination = visit.ObjectiveExamination,
                PrescribedTreatment = visit.PrescribedTreatment,
                AnimalId = visit.AnimalId,
                AnimalName = visit.Animal.Name
            };

        }

        public async Task<IEnumerable<VisitDto>> GetByNameAsync(string name)
        {
            return await _context.Visits.Where(v => v.Animal.Name == name).
                 Include(v => v.Animal).
                 Select(v => new VisitDto
                 {
                     Id = v.Id,
                     VisitDate = v.VisitDate,
                     ObjectiveExamination = v.ObjectiveExamination,
                     PrescribedTreatment = v.PrescribedTreatment,
                     AnimalId = v.AnimalId,
                     AnimalName = v.Animal.Name
                 }).ToListAsync();



        }

    }
}
