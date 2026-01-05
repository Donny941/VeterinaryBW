using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;

namespace Veterinary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Vet")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await _animalService.GetAllAnimalsAsync();

            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(int id)
        {
            var animals = await _animalService.GetAnimalById(id);

            if (animals == null)
            {
                return NotFound(new { message = "Animal not Found" });
            }

            return Ok(animals);
        }

        [HttpGet("{microchipNumber}")]
        [AllowAnonymous] //Rendo pubblico anche per utenti non autenticati
        public async Task<IActionResult> GetAnimalByMic(string microchip)
        {
            var animals = await _animalService.GetAnimalByMicrochip(microchip);

            if (animals == null)
            {
                return NotFound(new { message = "Animal not Found" });
            }

            return Ok(animals);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] CreateUpdateAnimalDto createAnimalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var animal = await _animalService.CreateAsync(createAnimalDto);

            return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(int id, [FromBody] CreateUpdateAnimalDto updateAnimalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var animal = await _animalService.UpdateAsync(id, updateAnimalDto);

            if (animal is null)
                return NotFound(new { message = "Animal not Found" });


            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var result = await _animalService.DeleteAsync(id);

            if (!result)
                return NotFound(new { message = "Animal not Found" });

            string message = "Success Deleting Animal";

            return Ok(message);
        }


    }
}
