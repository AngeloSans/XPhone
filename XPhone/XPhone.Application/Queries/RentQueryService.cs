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
        public Task<IEnumerable<RentDTO>> GetAllRentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RentDTO> GetRentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
