using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra;
using XPhone.Infra.Repository;

namespace XPhone.Application.Services
{
    public class RentService : IRentService
    {
        private readonly RentRepository _rentRepository;

        public RentService(RentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public void AddRent(RentDTO rentDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteRent(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RentDTO> GetAllRent()
        {
            throw new NotImplementedException();
        }

        public RentDTO GetRentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRent(RentDTO rentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
