using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Queries
{
    public class StockQueryService : IStockQueryService
    {
        private readonly IStockRepository _stockRepository;
        private readonly ISmartPhoneRepository _smartPhoneRepository;

        public StockQueryService(IStockRepository stockRepository, ISmartPhoneRepository smartPhoneRepository)
        {
            _stockRepository = stockRepository;
            _smartPhoneRepository = smartPhoneRepository;
        }

        public async Task<IEnumerable<StockDTO>> GetAllStocksAsync()
        {
            var stocks = await _stockRepository.GetAllStocksAsync();
            return stocks.Select(s => new StockDTO
            {
                Id = s.Id,
                stockName = s.stockName,
                amount = s.Amount,
                Phones = s.Phones.Select(p => new SmartPhoneDTO
                {
                    Core = p.Core,
                    Model = p.Model,
                    Memory = p.Memory,
                    Price = p.Price,
                    Avaiable = p.Avaiable
                }).ToList()
            }).ToList();
        }

        public async Task<IEnumerable<StockDTO>> GetStockById(Guid id)
        {
            var stock = await _stockRepository.GetStockById(id);
            if (stock == null)
            {
                return null;
            }

            var phones = await _smartPhoneRepository.GetSmartPhoneAsync(id);

            return new StockDTO
            {
                Id = stock.Id,
                stockName = stock.stockName,
                amount = stock.Amount,
                Phones = phones.Select(p => new SmartPhoneDTO
                {
                    Core = p.Core,
                    Model = p.Model,
                    Memory = p.Memory,
                    Price = p.Price,
                    Available = p.A
                }).ToList()
            };
        }

        public async Task<int> GetStockCountAsync(Guid id)
        {
            return await _stockRepository.GetStockCountAsync(id);
        }
    }
}
