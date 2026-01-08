using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;



namespace Veterinary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleInterface _saleService;

        public SaleController(ISaleInterface saleInterface)
        {
            _saleService = saleInterface;
        }

        [HttpPost]
        [Authorize(Roles ="Ph")]
        public async Task<IActionResult> CreateSale([FromBody] CreateUpdateSaleDto createSaleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var bill = await _saleService.CreateSaleAsync(createSaleDto);
            return Ok(bill);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Ph")]
        public async Task<IActionResult> UpdateSale([FromBody] CreateUpdateSaleDto updateSaleDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var bill = await _saleService.UpdateSaleAsync(id, updateSaleDto);

            if (bill is null)
                return NotFound(new { message = "Sale not Found" });
            return Ok(bill);

        }

        [HttpGet]
        [Authorize(Roles = "Ph")]
        public async Task<IActionResult> GetAllSale()
        {
            var bill = await _saleService.GetAllSaleAsync();
            return Ok(bill);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Ph")]
        public async Task<IActionResult> GetSaleById(int id)
        {
            var bill = await _saleService.GetSaleById(id);

            if (bill is null)
                return NotFound(new { message = "Sale not Found" });

            return Ok(bill);
        }

    }
}
