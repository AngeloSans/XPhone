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
        Task<Return>GetReturnAsync(Guid id);
        Task<IEnumerable<Return>> GetDateReturnAsync(DateTime returnDate);

        Task<bool> GetReturnConditionAsync(Guid ReturnId);

        Task DeleteReturnByIdAsync(Guid id);

        
    }
}
