using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Domain.Entities;
using XPhone.Infra.Repository;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Handler
{
    public class CreateRentCommandHandler : ICommandHandler<CreateRentCommand>
    {
        private readonly IRentRepository _rentRepository;
        private readonly ISmartPhoneRepository _smartPhoneRepository;
        public CreateRentCommandHandler(IRentRepository rentRepository, ISmartPhoneRepository smartPhoneRepository)
        {
            _rentRepository = rentRepository;
            _smartPhoneRepository = smartPhoneRepository;
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
            var smartphoneAvaible = await _smartPhoneRepository.GetSmartPhoneAsync(command.SmartPhoneId);
            if (smartphoneAvaible.Avaiable)
            {
                await _rentRepository.AddRentAdync(rent);


                if (smartphoneAvaible != null)
                {
                    smartphoneAvaible.Avaiable = false;
                    await _smartPhoneRepository.UpdateSmartPhoneAsync(smartphoneAvaible);
                }
                
            }
            else
            {
                throw new Exception("Phone is not avaiable");
            }
            return rent.Id;
        }
    }
}
