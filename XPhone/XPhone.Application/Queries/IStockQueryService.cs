using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Queries
{
    public interface IStockQueryService
    {
        Task<IEnumerable<StockDTO>> GetAllStocksAsync();
        Task<IEnumerable<StockDTO>> GetStockById(Guid id);
        Task<int> GetStockCountAsync(Guid id);
    }
}
