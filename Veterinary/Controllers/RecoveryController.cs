using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;

namespace Veterinary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecoveryController : ControllerBase
    {
        private readonly IRecoveryInterface _recoveryService;

        public RecoveryController(IRecoveryInterface recoveryInterface)
        {
            _recoveryService = recoveryInterface;
        }

        [HttpPost]
        [Authorize(Roles="Vet")]
        public async Task<IActionResult> CreateRecovery([FromBody] CreateUpdateRecoveryDto createRecoveryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var recovery = await _recoveryService.CreateRecoveryAsync(createRecoveryDto);
            return Ok(recovery);
           
        }

        [HttpPut]
        [Authorize(Roles = "Vet")]
        public async Task<IActionResult> UpdateRecovery([FromBody] CreateUpdateRecoveryDto updateRecoveryDto, int recoveryId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var recovery = await _recoveryService.UpdateRecoveryAsync(recoveryId, updateRecoveryDto);
                return Ok(recovery);
            }
            catch
            {
                return NotFound(new { message = "Recovery Not Found" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Vet")]
        public async Task<IActionResult> GetAllRecovery()
        {
            var recovery = await _recoveryService.GetAllRecoveryAsync();
            return Ok(recovery);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Vet")]
        public async Task<IActionResult> GetRecoveryById(int id)
        {
            
            var recovery = await _recoveryService.GetRecoveryByIdAsync(id);
            
            if (recovery is null)
                return NotFound(new { message = "Recovery Not Found" });
            
            return Ok(recovery);
            
        }

        [HttpGet("animal")]
        [Authorize(Roles = "Vet")]
        public async Task<IActionResult> GetRecoveryByAnimalId(int animalId)
        {
            var recovery = await _recoveryService.GetRecoveryByAnimalIdAsync(animalId);

            if (recovery is null)
                return NotFound(new { message = "Recovery Not Found" });

            return Ok(recovery);
        }

    }
}
