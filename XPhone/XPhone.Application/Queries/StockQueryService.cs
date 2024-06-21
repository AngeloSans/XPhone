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
        public Task<IEnumerable<StockDTO>> GetAllStocksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StockDTO> GetStockById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetStockCountAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
