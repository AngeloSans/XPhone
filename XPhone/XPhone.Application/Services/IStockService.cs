using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Services
{
    public interface IStockService
    {
        IEnumerable<StockDTO> GetAllStock();
        StockDTO GetStockById(Guid id);
        void UpdateStock(StockDTO stockDTO);
        void DeleteStock(Guid id);
        void AddsmartPhone(Guid id, SmartPhoneDTO smartPhoneDTO);
        void CreateStock(StockDTO stockDTO);
        int GetStockCountAsync(Guid id);
    }
}
