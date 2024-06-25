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
    public class CreateReturnCommandHandler : ICommandHandler<CreateReturnCommand>
    {
        private readonly IReturnRepository _returnRepository;

        public CreateReturnCommandHandler(IReturnRepository returnRepository)
        {
            _returnRepository = returnRepository;
        }
        public async Task<Guid> HandlerAsync(CreateReturnCommand command)
        {
            var returnCreate = new Return
            {
                Condition = command.Condition,
                ReturnDate = command.ReturnDate,
                RentId = command.RentId,
            };
            await _returnRepository.AddReturnAsync(returnCreate);
            return returnCreate.Id ;
        }
    }
}
