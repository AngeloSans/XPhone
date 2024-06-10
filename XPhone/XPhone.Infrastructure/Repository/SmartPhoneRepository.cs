using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Infrastructure;
using XPhone.Infrastructure.Repository;

namespace XPhone.Infra.Repository
{
    public class SmartPhoneRepository : ISmartPhoneRepository
    {
        private readonly XPhoneDbContext _context;

        public SmartPhoneRepository(XPhoneDbContext context)
        {
            _context = context;
        }
        public Task<SmartPhone> AddAsync(SmartPhone smartPhone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> checkAvaiable(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SmartPhone>> GetAllSmartPhoneAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SmartPhone> UpdateAsync(SmartPhone smartPhone)
        {
            throw new NotImplementedException();
        }
    }
}
