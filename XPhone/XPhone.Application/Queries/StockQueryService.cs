using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return await _stockRepository.GetAllStocksAsync();
        }

        public async Task<StockDTO> GetStockById(Guid id)
        {
            var stock = await _stockRepository.GetStockById(id);
            var phones = await _smartPhoneRepository.GetSmartPhoneAsync(id);
            if(stock == null)
            {
                return null;
            }
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
                    Avaiable = p.Avaiable,
                })
            };
        }

        public async Task<int> GetStockCountAsync(Guid id)
        {
            return await _stockRepository.GetStockCountAsync(id);
        }
    }
}
