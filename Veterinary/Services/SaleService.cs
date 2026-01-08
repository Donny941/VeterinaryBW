using Microsoft.EntityFrameworkCore;
using Veterinary.Models;
using Veterinary.Models.Data;
using Veterinary.Models.Dto_s;
using Veterinary.Services.Interface;

namespace Veterinary.Services
{
    public class SaleService : ISaleInterface
    {
        private readonly VetClinicDbContext _context;

        public SaleService(VetClinicDbContext context)
        {
            _context = context;
        }

        public async Task<SaleDto> CreateSaleAsync(CreateUpdateSaleDto createSaleDto)
        {
            var bill = new Sale
            {
                SaleDate = createSaleDto.SaleDate,
                ClientTaxCode=createSaleDto.ClientTaxCode,
                PrescriptionNumber=createSaleDto.PrescriptionNumber,
                ProductId=createSaleDto.ProductId,
                Quantity=createSaleDto.Quantity
            };
            _context.Sales.Add(bill);
            await _context.SaveChangesAsync();
            return new SaleDto
            {
                Id = bill.Id,
                SaleDate = bill.SaleDate,
                ClientTaxCode = bill.ClientTaxCode,
                PrescriptionNumber = bill.PrescriptionNumber,
                ProductId = bill.ProductId,
                Quantity = bill.Quantity
            };
        }

        public async Task<IEnumerable<SaleDto>> GetAllSaleAsync()
        {
            return await _context.Sales.Select(s => new SaleDto
            {
                Id = s.Id,
                SaleDate = s.SaleDate,
                ClientTaxCode = s.ClientTaxCode,
                PrescriptionNumber = s.PrescriptionNumber,
                ProductId = s.ProductId,
                Quantity = s.Quantity
            }).ToListAsync();
        }

        public async Task<SaleDto> GetSaleById(int id)
        {
            var bill = await _context.Sales.FindAsync(id);
            if (bill is null)
                return null;
            return new SaleDto
            {
                Id = bill.Id,
                SaleDate = bill.SaleDate,
                ClientTaxCode = bill.ClientTaxCode,
                PrescriptionNumber = bill.PrescriptionNumber,
                ProductId = bill.ProductId,
                Quantity = bill.Quantity
            };
        }

        public async Task<SaleDto> UpdateSaleAsync(int id, CreateUpdateSaleDto updateSaleDto)
        {
            var bill = await _context.Sales.FindAsync(id);

            bill.SaleDate = updateSaleDto.SaleDate;
            bill.ClientTaxCode = updateSaleDto.ClientTaxCode;
            bill.PrescriptionNumber = updateSaleDto.PrescriptionNumber;
            bill.ProductId = updateSaleDto.ProductId;
            bill.Quantity = updateSaleDto.Quantity;

            await _context.SaveChangesAsync();
            return new SaleDto
            {
                Id = bill.Id,
                SaleDate = bill.SaleDate,
                ClientTaxCode = bill.ClientTaxCode,
                PrescriptionNumber = bill.PrescriptionNumber,
                ProductId = bill.ProductId,
                Quantity = bill.Quantity
            };


        }
    }
}
