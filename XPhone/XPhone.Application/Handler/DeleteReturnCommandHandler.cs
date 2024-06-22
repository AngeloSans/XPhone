using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;

namespace XPhone.Application.Handler
{
    public class DeleteReturnCommandHandler : ICommandHandler<DeleteReturnCommand>
    {
        private readonly ReturnRepository _returnRepository;

        public DeleteReturnCommandHandler(ReturnRepository returnRepository)
        {
            _returnRepository = returnRepository;
        }

        public async Task<Guid> HandlerAsync(DeleteReturnCommand command)
        {
            await _returnRepository.DeleteReturnByIdAsync(command.id);
            return command.id;
        }
    }
}
