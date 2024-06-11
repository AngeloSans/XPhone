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

        public async Task<SmartPhone> AddSmartPhoneAsync(SmartPhone smartPhone)
        {
            await _context.SmartPhones.AddAsync(smartPhone);
            await _context.SaveChangesAsync();
            return smartPhone;
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
            return await _context.SmartPhones.ToListAsync();
        }

        async Task ISmartPhoneRepository.UpdateSmartPhoneAsync(SmartPhone smartPhone)
        {
            _context.SmartPhones.Update(smartPhone);
            await _context.SaveChangesAsync();
        }
    }
}
