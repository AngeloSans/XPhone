using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XPhone.Infrastructure;
using XPhone.Domain;
using XPhone.Infrastructure.Repository;

namespace XPhone.Infra.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly XPhoneDbContext _context;

        public StockRepository(XPhoneDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllStocksAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock> GetStockById(Guid id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task UpdateStockAsync(Stock stock)
        {
            if(stock != null)
            {
                _context.Stocks.Update(stock);
                await _context.SaveChangesAsync();

            }
            
        }

        public async Task DeleteStockAsync(Guid id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetStockCountAsync(Guid id)
        {
            var stock = await _context.Stocks
                                .Where(s => s.Id == id)
                                .Select(s => s.Phones)
                                .CountAsync();
            return stock;

        }


        public async Task<SmartPhone> AddsmartPhone(Guid id, SmartPhone smartPhone)
        {
            
            await _context.SmartPhones.AddAsync(smartPhone);
            await _context.SaveChangesAsync();

            
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                throw new ArgumentException("Stock not found");
            }

          
            stock.Amount++;

           
            await _context.SaveChangesAsync();

            return smartPhone;
        }
    }
}
