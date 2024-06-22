using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;
using XPhone.Domain.Entities;

namespace XPhone.Application.Handler
{
    public class CreateStockCommandHandler : ICommandHandler<CreateStockCommand>
    {
        private readonly StockRepository _stockRepository;

        public CreateStockCommandHandler(StockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Guid> HandlerAsync(CreateStockCommand command)
        {
            var stock = new Stock
            {
                stockName = command.stockName,
            };
            await _stockRepository.CreateStock(stock);
            return stock.Id;
        }
    }
}
