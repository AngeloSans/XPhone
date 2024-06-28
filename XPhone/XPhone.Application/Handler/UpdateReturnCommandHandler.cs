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
    public class UpdateReturnCommandHandler : ICommandHandler<UpdateReturnCommand>
    {
        private readonly IReturnRepository _returnRepository;

        public UpdateReturnCommandHandler(IReturnRepository returnRepository)
        {
            _returnRepository = returnRepository;
        }

        public async Task<Guid> HandlerAsync(UpdateReturnCommand command)
        {
            var returnUpdated = await _returnRepository.GetReturnAsync(command.Id);
            if(returnUpdated != null)
            {
                returnUpdated.ReturnDate = command.ReturnDate;
                returnUpdated.Condition = command.Condition;
                returnUpdated.RentId = command.RentId;

                await _returnRepository.UpdateReturnAsync(returnUpdated);
            }
            else
            {
                throw new KeyNotFoundException("Return not found");
            }
            return returnUpdated.Id;
            
        }
    }
}
