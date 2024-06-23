using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;

namespace XPhone.Application.Handler
{
    public class DeleteStockCommandHandler : ICommandHandler<DeleteStockCommand>
    {
        private readonly StockRepository _stockRepository;

        public DeleteStockCommandHandler(StockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Guid> HandlerAsync(DeleteStockCommand command)
        {
            await _stockRepository.DeleteStockAsync(command.id);
            return command.id;
        }
    }
}
