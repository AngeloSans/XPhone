using Microsoft.EntityFrameworkCore;
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


        public async Task<bool> checkAvaiable(Guid id)
        {
            var phone = await _context.SmartPhones.FirstOrDefaultAsync(i => i.Id == id && i.Avaiable);
            return phone != null;
        }
        

        public async Task DeletePhoneAsync(Guid Id)
        {
            var phone = await _context.SmartPhones.FindAsync(Id);
            if(phone != null)
            {
                _context.SmartPhones.Remove(phone);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SmartPhone>> GetAllSmartPhoneAsync()
        {
            
            return await _context.SmartPhones
                .Include(SmartPhone => SmartPhone.Stock)
                .ToListAsync();
        }

        public async Task<SmartPhone> GetSmartPhoneAsync(Guid id)
        {
            return await _context.SmartPhones.FindAsync(id);
        }

        async Task ISmartPhoneRepository.UpdateSmartPhoneAsync(SmartPhone smartPhone)
        {
            
            if (smartPhone != null)
            {
                _context.SmartPhones.Update(smartPhone);
                await _context.SaveChangesAsync();
            }
        }
    }
}
