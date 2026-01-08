using Veterinary.Models.Dto_s;

namespace Veterinary.Services.Interface
{
    public interface ISaleInterface
    {
        Task<IEnumerable<SaleDto>> GetAllSaleAsync();
        Task<SaleDto> GetSaleById(int id);
        Task<SaleDto> CreateSaleAsync(CreateUpdateSaleDto createSaleDto);
        Task<SaleDto> UpdateSaleAsync(int id, CreateUpdateSaleDto updateSaleDto);
        
    }
}
