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
        Task<IEnumerable<Return>> GetReturnListAsync();
        Task<Return> AddReturnAsync(Return returnn);
        Task UpdateReturnAsync(Return returnn);
        Task DeleteReturnByIdAsync(Guid id);

        
    }
}
