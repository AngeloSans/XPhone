using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Domain.Entities;
using XPhone.Infra.Migrations;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Handler
{
    public class CreateClientCommandHandler : ICommandHandler<CreateClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Guid> HandlerAsync(CreateClientCommand command)
        {
            var client = new Client
            {
                Email = command.Email,
                Name = command.Name,
                Fine = command.Fine,
                FineAmount = command.FineAmount,
                Phone   = command.Phone,
            };
            await _clientRepository.AddClientAsync(client);
            return client.Id;
        }
    }
}
