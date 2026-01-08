using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;

namespace Veterinary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitInterface _visitService;
        public VisitController(IVisitInterface visitInterface)
        {
            _visitService = visitInterface;
        }
        [Authorize(Roles ="Vet")]
        [HttpPost]
        public async Task<IActionResult> CreateVisit([FromBody] CreateUpdateVisitDto createVisitDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var visit = await _visitService.CreateVisitAsync(createVisitDto);
            return Ok(visit);

        }


        [Authorize(Roles = "Vet")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisit([FromBody] CreateUpdateVisitDto updateVisitDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
            var visit = await _visitService.UpdateVisitAsync(updateVisitDto, id);
                
            return Ok(visit);
            }
            catch
            {
               return NotFound(new { message = "Id Vist Not Found" });
            }
        }


        [Authorize(Roles = "Vet")]
        [HttpGet]
        public async Task<IActionResult> GetAllVisit()
        {
            var visit = await _visitService.GetAllVisitAsync();
            return Ok(visit);
        }
      
        [Authorize(Roles = "Vet")]
        [HttpGet("history/{animalId}")]
        public async Task<IActionResult> GetAnimalVistHistory(int animalId)
        {
            var visit = await _visitService.GetAnimalVisitHistoryAsync(animalId);
            if (visit == null)
                return NotFound(new { message = "Visit not Found" });
            return Ok(visit);
        }
      
        
        [Authorize(Roles = "Vet")]
        [HttpGet("visitbyid/{visitId}")]
        public async Task<IActionResult> GetVisitById(int visitId)
        {
            var visit = await _visitService.GetByIdAsync(visitId);
            if (visit == null)
                return NotFound(new { message = "Visit not Found" });
            return Ok(visit);
        }
        [Authorize(Roles = "Vet")]
        [HttpGet("byname/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var visit = await _visitService.GetByNameAsync(name);
            if (visit == null)
                return NotFound(new { message = $"Visit for {name} not Found" });
            return Ok(visit);
        }


    }
}
