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

        public async Task<Guid> HandlerAsync(Guid stockId, CreateSmartPhoneCommand command)
        {   

            var stock = await _stockRepository.GetStockById(stockId);

            if (stock == null)
            {
                throw new InvalidOperationException("Stock not found.");
            }

            var smartPhone = new SmartPhone
            {
                Id = Guid.NewGuid(),
                Model = command.Model,
                Price = command.Price,
                Avaiable = command.Avaiable,
                OperationalSystem = command.OperationalSystem,
                Memory = command.Memory,
                Core = command.Core,
                StockId = stockId,
            };

            await _stockRepository.AddsmartPhone(stockId, smartPhone);

            return smartPhone.Id;
        }
    }
}
