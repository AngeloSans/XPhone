using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Handler
{
    public class UpdateCLientCommandHandler : ICommandHandler<UpdateCLientCommand>
    {
        private readonly IClientRepository _clientRepository;
        public UpdateCLientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Guid> HandlerAsync(UpdateCLientCommand command)
        {
            var client = await _clientRepository.GetClientByIdAsync(command.Id);
            if(client != null) 
            { 
                client.Name = command.Name;
                client.Email = command.Email;
                client.Phone = command.Phone;
                client.Fine = command.Fine;
                client.FineAmount = command.FineAmount;
               
                await _clientRepository.UpdateClientAsync(client);
            }
            else
            {
                throw new KeyNotFoundException("Client not found :(");
            }
            return command.Id;
        }
    }
}
