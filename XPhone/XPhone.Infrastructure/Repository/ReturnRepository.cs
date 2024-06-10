using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Infrastructure;

namespace XPhone.Infra.Repository
{
    public class ReturnRepository : IReturnRepository
    {
        private readonly XPhoneDbContext _context;

        public ReturnRepository(XPhoneDbContext context)
        {
            _context = context;
        }

        public async Task<Return> GetReturnAsync(int id)
        {
            return await _context.Returns.FindAsync(id);
        }

        public async Task<IEnumerable<Return>> GetReturnsByDateAsync(DateTime returnDate)
        {
            return await _context.Returns
                .Where(r => r.ReturnDate.Date == returnDate.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Return>> GetReturnsByConditionAsync(bool condition)
        {
            return await _context.Returns
                .Where(r => r.Condition == condition)
                .ToListAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var returnEntity = await _context.Returns.FindAsync(id);
            if (returnEntity != null)
            {
                _context.Returns.Remove(returnEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
