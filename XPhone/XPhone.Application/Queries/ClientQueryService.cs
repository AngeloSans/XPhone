/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Migrations;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Queries
{
    public class ClientQueryService : IClientQueryService
    {
        private readonly IClientRepository _clientRepository;

        public ClientQueryService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public Task<IEnumerable<ClientDTO>> GetAllClientsAsync()
        {           
            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Phone = client.Phone,
                Fine = client.Fine,
                FineAmount = client.FineAmount,
                Rents = client.Rents,
            };
        }

        public async Task<ClientDTO> GetClientByIdAsync(Guid id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);

            if(client == null)
            {
                throw new KeyNotFoundException("Client not found");
            }
            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Phone = client.Phone,
                Fine = client.Fine,
                FineAmount = client.FineAmount,
                Rents = client.Rents
            };
        }
    }
}
*/