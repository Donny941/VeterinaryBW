using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Veterinary.Models;
using Veterinary.Models.Dto_s;
using Veterinary.Services;
using Veterinary.Services.Interface;

namespace Veterinary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInterface _productService;

        public ProductController(IProductInterface productInterface)
        {
            _productService = productInterface;
        }

        [HttpPost]
        [Authorize(Roles = "Ph")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productService.CreateProductAsync(createProductDto);

            return Ok(product);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Ph")]
        public async Task<IActionResult> UpdateProduct([FromBody] CreateUpdateProductDto updateProductDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {

            var product = await _productService.UpdateProductAsync(id, updateProductDto);
            return Ok(product);
            }
            catch { 
            
                return NotFound(new { message = "Product not Found" });
            }

            

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.IsInStockProductAsync(id);

            if (!result)
                return NotFound(new { message = "Product not Found" });

            string message = "Success Deleting Product";

            return Ok(message);
        }

        [HttpGet]
        [Authorize(Roles = "Vet, Ph")]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = await _productService.GetAllProductAsync();

            return Ok(product);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Vet, Ph")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product is null)
                return NotFound(new { message = "Product not Found" });

            return Ok(product);
        }

        [HttpGet("medicines")]
        [Authorize(Roles = "Vet, Ph")]
        public async Task<IActionResult> GetMedicine()
        {
            var product = await _productService.GetMedicinesAsync();

            return Ok(product);
        }

        [HttpGet("food")]
        [Authorize(Roles = "Vet, Ph")]
        public async Task<IActionResult> GetFood()
        {
            var product = await _productService.GetFoodsAsync();

            return Ok(product);
        }

        [HttpGet("location")]
        [Authorize(Roles = "Ph")]
        public async Task<IActionResult> GetMedicineLocation(int productId)
        {
            var location = await _productService.GetCabinetCodeAsync(productId);

            if (location is null)
                return NotFound(new { message = "Medicine not found or location not available" });

            return Ok(location);
        }

    }
}
