using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Infra.Migrations;
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

        public async Task<Return> GetReturnAsync(Guid id)
        {
            return await _context.Returns.FindAsync(id);
        }



        public async Task<DateTime> GetDateReturnAsync(Guid id)
        {
            var returnDate = await _context.Returns
                .Where(r => r.Id == id)
                .Select(r => r.ReturnDate)
                .FirstOrDefaultAsync();

            return returnDate;
        }

        public async Task<bool> GetReturnConditionAsync(Guid ReturnId)
        {
            var retturn = await _context.Returns.FirstOrDefaultAsync(r => r.Id == ReturnId);
            return retturn.Condition;
        }

        public async Task DeleteReturnByIdAsync(Guid id)
        {
            var returnEntity = await _context.Returns.FindAsync(id);
            if (returnEntity != null)
            {
                _context.Returns.Remove(returnEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Return> AddReturnAsync(Return returnn)
        {
            await _context.AddAsync(returnn);
            await _context.AddRangeAsync(returnn);
            return returnn;
        }
    }
}
