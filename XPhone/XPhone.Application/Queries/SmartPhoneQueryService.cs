using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Queries
{
    public class SmartPhoneQueryService : ISmartPhoneQueryService
    {
        private readonly ISmartPhoneRepository _smartPhoneRepository;
        public Task<bool> checkAvaiable(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SmartPhoneDTO>> GetAllSmartPhoneAsync()
        {
            return await _smartPhoneRepository.GetAllSmartPhoneAsync();
        }

        public Task<SmartPhoneDTO> GetSmartPhoneAsync(Guid id)
        {
            
        }
    }
}
