using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Queries
{
    public interface ISmartPhoneQueryService
    {
        Task<IEnumerable<SmartPhoneDTO>> GetAllSmartPhoneAsync();
        Task<SmartPhoneDTO> GetSmartPhoneAsync(Guid id);
        Task<bool> checkAvaiable(Guid id);

    }
}
