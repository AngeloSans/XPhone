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
        Task<IEnumerable<Rent>> GetAllRentAsync();
        Task<Rent> GetRentByIdAsync(Guid id);
        Task UpdateRentAsync(Rent rent);

        Task DeleteRentAsync (Guid id);

        Task<Rent> AddRentAdync(Rent rent);
    }
}
