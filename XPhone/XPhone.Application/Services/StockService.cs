using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Repository;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Services
{
    public class StockService : IStockService
    {
        private readonly StockRepository _stockRepository;

        public StockService(StockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public void AddsmartPhone(Guid id, SmartPhoneDTO smartPhoneDTO)
        {
            throw new NotImplementedException();
        }

        public void CreateStock(StockDTO stockDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteStock(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockDTO> GetAllStock()
        {
            throw new NotImplementedException();
        }

        public StockDTO GetStockById(Guid id)
        {
            throw new NotImplementedException();
        }

        public int GetStockCountAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStock(StockDTO stockDTO)
        {
            throw new NotImplementedException();
        }
    }
}
