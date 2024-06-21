using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Queries
{
    public class ClientQueryService : IClientQueryService
    {
        public Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClientDTO> GetClientByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
