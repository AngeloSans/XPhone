using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Queries
{
    public interface IReturnQueryService
    {
        Task<DateTime> GetReturnAsync(Guid id);
        Task<ReturnDTO> GetDateReturnAsync(Guid id);

        Task<bool> GetReturnConditionAsync(Guid ReturnId);
    }
}
