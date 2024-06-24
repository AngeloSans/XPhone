using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;
using XPhone.Domain.Entities;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Handler
{
    public class CreateStockCommandHandler : ICommandHandler<CreateStockCommand>
    {
        private readonly IStockRepository _stockRepository;

        public CreateStockCommandHandler(IStockRepository stockRepository)
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
