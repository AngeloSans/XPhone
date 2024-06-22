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
            return await _rentRepository.GetAllRentAsync();
        }

        public Task<RentDTO> GetRentByIdAsync(Guid id)
        {
            
        }
    }
}
