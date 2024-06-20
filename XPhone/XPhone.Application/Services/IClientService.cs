using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Services
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAllClients();
        ClientDTO GetClientById(Guid id);
        void AddClient(ClientDTO clientDTO);
        void UpdateClient(ClientDTO clientDTO);
        void DeleteClientById(Guid id);

    }
}
