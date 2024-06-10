using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities;

namespace XPhone.Infra.Repository
{
    public interface IReturnRepository
    {
        Task<Return>GetReturnAsync(int id);
        Task<IEnumerable<Return>> GetReturnsByDateAsync(DateTime returnDate);

        Task<IEnumerable<Return>> GetReturnsByConditionAsync(bool condition);

        Task DeleteByIdAsync(Guid id);

    }
}
