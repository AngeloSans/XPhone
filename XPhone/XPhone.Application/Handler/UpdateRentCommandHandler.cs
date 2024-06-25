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
    public class UpdateRentCommandHandler : ICommandHandler<UpdateRentCommand>
    {
        private readonly IRentRepository _rentRepository;

        public UpdateRentCommandHandler(IRentRepository rentRepository) 
        { 
            _rentRepository = rentRepository;
        }
        public async Task<Guid> HandlerAsync(UpdateRentCommand command)
        {
            var rent = await _rentRepository.GetRentByIdAsync(command.Id);
            if(rent != null)
            {
                rent.StartDate = command.StartDate;
                rent.EndDate = command.EndDate;
                rent.Devolution = command.Devolution;
                rent.RentAmount = command.RentAmount;
                rent.ClientId = command.Id;
           
                await _rentRepository.UpdateRentAsync(rent);
            }
            else
            {
                throw new KeyNotFoundException("Rent not found");
            }
            return command.Id;
        }
    }
}
