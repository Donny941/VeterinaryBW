using Veterinary.Models.Dto_s;

namespace Veterinary.Services.Interface
{
    public interface IProductInterface
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto?> GetProductById(int id);
        Task<IEnumerable<ProductDto>> GetMedicinesAsync();
        Task<IEnumerable<ProductDto>> GetFoodsAsync();

        Task<string?> GetCabinetCodeAsync(int productId);

        Task<ProductDto> CreateProductAsync(CreateUpdateProductDto createProductDto);
        Task<ProductDto> UpdateProductAsync(int id, CreateUpdateProductDto updateProductDto);

        Task<bool> IsInStockProductAsync(int id);

    }
}
