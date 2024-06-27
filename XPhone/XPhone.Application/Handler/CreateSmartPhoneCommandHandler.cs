using System;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Handler
{
    public class CreateSmartPhoneCommandHandler : ICommandHandlerCreate<CreateSmartPhoneCommand>
    {
        private readonly ISmartPhoneRepository _smartPhoneRepository;
        private readonly IStockRepository _stockRepository;

        public CreateSmartPhoneCommandHandler(ISmartPhoneRepository smartPhoneRepository, IStockRepository stockRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
            _stockRepository = stockRepository;
        }

        public async Task<Guid> HandleAsync(Guid stockId, CreateSmartPhoneCommand command)
        {
            // Verifica se o stockId passado é consistente com o command.StockId
            if (stockId != command.StockId)
            {
                throw new InvalidOperationException("The stock ID in the command does not match the provided stock ID.");
            }

            var stock = await _stockRepository.GetStockById(stockId);

            if (stock == null)
            {
                throw new InvalidOperationException("Stock not found.");
            }

            var smartPhone = new SmartPhone
            {
                Model = command.Model,
                Price = command.Price,
                Avaiable = command.Avaiable,
                OperationalSystem = command.OperationalSystem,
                Memory = command.Memory,
                Core = command.Core
            };

            var addedSmartPhone = await _stockRepository.AddsmartPhone(stockId, smartPhone);

            return addedSmartPhone.Id;
        }
    }
}
