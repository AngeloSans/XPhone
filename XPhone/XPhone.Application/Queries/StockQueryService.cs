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

            if (stocks == null)
            {
                throw new Exception("Failed to retrieve stocks from the repository.");
            }

            return stocks.Select(s => new StockDTO
            {
                Id = s.Id,
                stockName = s.stockName,
                amount = s.Amount
            });
        }

        public async Task<StockDTO> GetStockById(Guid id)
        {
            var stock = await _stockRepository.GetStockById(id);
            if (stock == null)
            {
                return null;
            }

            return new StockDTO
            {
                Id = stock.Id,
                stockName = stock.stockName, 
                amount = stock.Amount
            };
        }


        public async Task<int> GetStockCountAsync(Guid id)
        {
            return await _stockRepository.GetStockCountAsync(id);
        }
    }
}
