using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Repository;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Queries
{
    public class SmartPhoneQueryService : ISmartPhoneQueryService
    {
        private readonly ISmartPhoneRepository _smartPhoneRepository;

        public SmartPhoneQueryService(ISmartPhoneRepository smartPhoneRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
        }

        public async Task<bool> checkAvaiable(Guid id)
        {
            return await _smartPhoneRepository.checkAvaiable(id);
           
        }

        public async Task<IEnumerable<SmartPhoneDTO>> GetAllSmartPhoneAsync()
        {
            var phones = await _smartPhoneRepository.GetAllSmartPhoneAsync();
            return phones.Select(p => new SmartPhoneDTO
            {
                Id = p.Id,
                Model = p.Model,
                Price = p.Price,
                Memory = p.Memory,
                Core = p.Core,
                OperationalSystem = p.OperationalSystem,
                StockId = p.StockId
            }).ToList(); 
        }
        public async Task<SmartPhoneDTO> GetSmartPhoneAsync(Guid id)
        {
            var phone = await _smartPhoneRepository.GetSmartPhoneAsync(id);
            if (phone == null)
            {
                throw new KeyNotFoundException("Phone not found");
            }

            return new SmartPhoneDTO
            {
                Id = phone.Id,
                Model = phone.Model,
                Price = phone.Price,
                Memory = phone.Memory,
                Core = phone.Core,
                Avaiable = phone.Avaiable,
                StockId=phone.StockId
            };
        }
    }
}
