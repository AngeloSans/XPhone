using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Queries
{
    public interface IClientQueryService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<ClientDTO> GetClientByIdAsync(Guid id);
    }
}
