using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Handler
{
    public class DeleteStockCommandHandler : ICommandHandler<DeleteStockCommand>
    {
        private readonly IStockRepository _stockRepository;

        public DeleteStockCommandHandler(IStockRepository stockRepository)
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
