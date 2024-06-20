using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public void AddClient(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteClientById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientDTO> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public ClientDTO GetClientById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }
    }
}
