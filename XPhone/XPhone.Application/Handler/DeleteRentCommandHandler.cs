using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;

namespace XPhone.Application.Handler
{
    public class DeleteRentCommandHandler : ICommandHandler<DeleteRentCommand>
    {
        private readonly RentRepository _rentRepository;
        public DeleteRentCommandHandler(RentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }
        public async Task<Guid> HandlerAsync(DeleteRentCommand command)
        {
            await _rentRepository.DeleteRentAsync(command.Id);
            return command.Id;
        }
    }
}
