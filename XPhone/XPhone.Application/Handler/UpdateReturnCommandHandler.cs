using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;

namespace XPhone.Application.Handler
{
    public class UpdateReturnCommandHandler : ICommandHandler<UpdateReturnCommand>
    {
        private readonly IReturnRepository _returnRepository;

        public UpdateReturnCommandHandler(IReturnRepository returnRepository)
        {
            _returnRepository = returnRepository;
        }

        public Task<Guid> HandlerAsync(UpdateReturnCommand command)
        {
            var returnUpdated = 
        }
    }
}
