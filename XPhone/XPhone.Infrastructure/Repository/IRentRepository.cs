using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities;

namespace XPhone.Infra.Repository
{
    public interface IRentRepository
    {
        Task<IEnumerable<Rent>> GetAllAsync();
        Task<Rent> GetAsync(int id);
        Task UpdateReturnAsync (Rent rent);

        Task DeleteReturnAsync (Guid id);
    }
}
