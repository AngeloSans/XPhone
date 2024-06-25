using System;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;

namespace XPhone.Application.Handler
{
    public class DeleteRentCommandHandler : ICommandHandler<DeleteRentCommand>
    {
        private readonly IRentRepository _rentRepository;

        public DeleteRentCommandHandler(IRentRepository rentRepository)
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
