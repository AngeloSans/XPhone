using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Domain.Entities;
using XPhone.Infra.Repository;

namespace XPhone.Application.Handler
{
    public class CreateRentCommandHandler : ICommandHandler<CreateRentCommand>
    {
        private readonly IRentRepository _rentRepository;
        public CreateRentCommandHandler(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }
        public async Task<Guid> HandlerAsync(CreateRentCommand command)
        {
            var rent = new Rent
            {
                RentAmount = command.RentAmount,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                Devolution = command.Devolution,
                ClientId = command.ClientId,
                SmartPhoneId = command.SmartPhoneId,
            };
            await _rentRepository.AddRentAdync(rent);
            return rent.Id;
        }
    }
}
