using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Infrastructure.Repository
{
    public interface IStockRepository
    {
        Task<Stock> GetAllStocks();
    }
}
