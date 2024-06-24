using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Handler
{
    public class DeleteClientCommandHandler : ICommandHandler<DeleteClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Guid> HandlerAsync(DeleteClientCommand command)
        {
            await _clientRepository.DeleteClientByIdAsync(command.Id);
            return command.Id;
        }
    }
}
