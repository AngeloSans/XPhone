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


        public async Task DeletePhoneAsync(Guid id)
        {
            var phone = await _context.SmartPhones.FindAsync(id);

            if (phone == null)
            {
                throw new InvalidOperationException($"Phone with Id {id} not found.");
            }

            var stock = await _context.Stocks.FindAsync(phone.StockId);

            if (stock == null)
            {
                throw new InvalidOperationException($"Stock associated with Phone Id {id} not found.");
            }

            _context.SmartPhones.Remove(phone);
            stock.Amount--; 

            await _context.SaveChangesAsync();
        }



        public async Task<IEnumerable<SmartPhone>> GetAllSmartPhoneAsync()
        {          
            return await _context.SmartPhones.ToListAsync();
        }

        public async Task<SmartPhone> GetSmartPhoneAsync(Guid id)
        {
            return await _context.SmartPhones.FindAsync(id);
        }

        public async Task UpdateSmartPhoneAsync(SmartPhone smartPhone)
        {
            
            if (smartPhone != null)
            {
                _context.SmartPhones.Update(smartPhone);
                await _context.SaveChangesAsync();
            }
        }
    }
}
