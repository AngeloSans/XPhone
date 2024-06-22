using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Repository;

namespace XPhone.Application.Queries
{
    public class RentQueryService : IRentQueryService
    {
        private readonly IRentRepository _rentRepository;
        public RentQueryService(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }
        public async Task<IEnumerable<RentDTO>> GetAllRentAsync()
        {
           
        }

        public async Task<RentDTO> GetRentByIdAsync(Guid id)
        {
            var rent = await _rentRepository.GetRentByIdAsync(id);
            if(rent == null)
            {
                throw new KeyNotFoundException("Rent not found");
            }
            return new RentDTO
            {
                Id = rent.Id,
                Devolution = rent.Devolution,
                EndDate = rent.EndDate,
                StartDate = rent.StartDate,
                ClientId = rent.ClientId,
                SmartPhoneId = rent.SmartPhoneId,
            };
        }
    }
}
