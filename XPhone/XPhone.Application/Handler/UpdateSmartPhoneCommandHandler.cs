using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;

namespace XPhone.Application.Handler
{
    public class UpdateSmartPhoneCommandHandler : ICommandHandler<UpdateSmartPhoneCommand>
    {
        private readonly SmartPhoneRepository _smartPhoneRepository;
        public UpdateSmartPhoneCommandHandler(SmartPhoneRepository smartPhoneRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
        }
        public async Task<Guid> HandlerAsync(UpdateSmartPhoneCommand command)
        {
            var phone = await _smartPhoneRepository.GetSmartPhoneAsync(command.Id);
            if(phone != null)
            {
                phone.Price = command.Price;
                phone.Model = command.Model;
                phone.Core = command.Core;
                phone.Memory = command.Memory;
                phone.Avaiable = command.Avaiable;
                
                await _smartPhoneRepository.UpdateSmartPhoneAsync(phone);
            }
            else
            {
                throw new KeyNotFoundException("Phone not found");
            }
            return phone.Id;
        }
    }
}
