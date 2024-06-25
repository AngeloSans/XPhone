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
    public class DeleteSmartPhoneCommandHandler : ICommandHandler<DeleteSmartPhoneCommand>
    {
        private readonly ISmartPhoneRepository _smartPhoneRepository;
        public DeleteSmartPhoneCommandHandler(ISmartPhoneRepository smartPhoneRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
        }

        public async Task<Guid> HandlerAsync(DeleteSmartPhoneCommand command)
        {
            await _smartPhoneRepository.DeletePhoneAsync(command.Id);
            return command.Id;
        }
    }
}
