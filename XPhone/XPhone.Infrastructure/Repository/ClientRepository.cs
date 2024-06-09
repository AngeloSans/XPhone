using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities;

namespace XPhone.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly XPhoneDbContext _context;

        public ClientRepository(XPhoneDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
