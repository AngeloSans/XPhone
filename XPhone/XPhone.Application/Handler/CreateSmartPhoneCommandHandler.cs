using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Handler
{
    public class CreateSmartPhoneCommandHandler : ICommandHandler<CreateSmartPhoneCommand>
    {
        private readonly ISmartPhoneRepository _smartPhoneRepository;
        private readonly IStockRepository _stockRepository;

        public CreateSmartPhoneCommandHandler(ISmartPhoneRepository smartPhoneRepository, IStockRepository stockRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
            _stockRepository = stockRepository;
        }
        public Task<Guid> HandlerAsync(CreateSmartPhoneCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
