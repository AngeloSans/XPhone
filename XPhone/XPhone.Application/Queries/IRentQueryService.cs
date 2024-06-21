using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Domain.Entities;

namespace XPhone.Application.Queries
{
    public interface IRentQueryService
    {
        Task<IEnumerable<RentDTO>> GetAllRentAsync();
        Task<RentDTO> GetRentByIdAsync(Guid id);

    }
}
