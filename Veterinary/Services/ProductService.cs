using Microsoft.EntityFrameworkCore;
using Veterinary.Models;
using Veterinary.Models.Data;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;

namespace Veterinary.Services
{
    public class ProductService : IProductInterface
    {

        private readonly VetClinicDbContext _context;

        public ProductService(VetClinicDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> CreateProductAsync(CreateUpdateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                SupplierName = createProductDto.SupplierName,
                SupplierAddress = createProductDto.SupplierAddress,
                Uses = createProductDto.Uses,
                IsMedicine = createProductDto.IsMedicine,
                CabinetCode = createProductDto.CabinetCode,
                Price = createProductDto.Price,
                InStock = createProductDto.InStock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                SupplierName = product.SupplierName,
                SupplierAddress = product.SupplierAddress,
                IsMedicine = product.IsMedicine,
                CabinetCode = product.CabinetCode,
                Uses = product.Uses,
                Price = product.Price,
                InStock = product.InStock
            };
        }

        public async Task<ProductDto> UpdateProductAsync(int id, CreateUpdateProductDto updateProductDto)
        {
            var product = await _context.Products.FindAsync(id);

            product.Name = updateProductDto.Name;
            product.SupplierName = updateProductDto.SupplierName;
            product.SupplierAddress = updateProductDto.SupplierAddress;
            product.Uses = updateProductDto.Uses;
            product.IsMedicine = updateProductDto.IsMedicine;
            product.CabinetCode = updateProductDto.CabinetCode;
            product.Price = updateProductDto.Price;
            product.InStock = updateProductDto.InStock;

            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                SupplierName = product.SupplierName,
                SupplierAddress = product.SupplierAddress,
                IsMedicine = product.IsMedicine,
                CabinetCode = product.CabinetCode,
                Uses = product.Uses,
                Price = product.Price,
                InStock = product.InStock
            };

        }

        public async Task<bool> IsInStockProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return false;

            product.InStock = false;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            return await _context.Products
              .Where(p => !p.InStock)
              .Select(p => new ProductDto
              {
                  Id = p.Id,
                  Name = p.Name,
                  SupplierName = p.SupplierName,
                  SupplierAddress = p.SupplierAddress,
                  IsMedicine = p.IsMedicine,
                  CabinetCode = p.CabinetCode,
                  Uses = p.Uses,
                  Price = p.Price,
                  InStock = p.InStock
              })
              .ToListAsync();
        }

        public async Task<string?> GetCabinetCodeAsync(int productId)
        {
            var location = _context.Products
                .Where(p => p.Id == productId && p.IsMedicine)
                .Select(p => p.CabinetCode)
                .FirstOrDefault();

            return location;
        }

        public async Task<IEnumerable<ProductDto>> GetFoodsAsync()
        {
            return await _context.Products
                .Where(p => !p.IsMedicine)
                 .Select(p => new ProductDto
                 {
                     Id = p.Id,
                     Name = p.Name,
                     SupplierName = p.SupplierName,
                     SupplierAddress = p.SupplierAddress,
                     CabinetCode = p.CabinetCode,
                     Uses = p.Uses,
                     Price = p.Price,
                     InStock = p.InStock
                 })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetMedicinesAsync()
        {
            return await _context.Products
                .Where(p => p.IsMedicine)
                 .Select(p => new ProductDto
                 {
                     Id = p.Id,
                     Name = p.Name,
                     SupplierName = p.SupplierName,
                     SupplierAddress = p.SupplierAddress,
                     CabinetCode = p.CabinetCode,
                     Uses = p.Uses,
                     Price = p.Price,
                     InStock = p.InStock
                 })
                .ToListAsync();
        }

        public async Task<ProductDto?> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                SupplierName = product.SupplierName,
                SupplierAddress = product.SupplierAddress,
                IsMedicine = product.IsMedicine,
                CabinetCode = product.CabinetCode,
                Uses = product.Uses,
                Price = product.Price,
                InStock = product.InStock
            };

        }

    }
}
