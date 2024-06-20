using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Services
{
    public interface IRentService
    {
        IEnumerable<RentDTO> GetAllRent();
        RentDTO GetRentById(Guid id);
        void UpdateRent(RentDTO rentDTO);
        void DeleteRent(Guid id);
        void AddRent(RentDTO rentDTO);
    }
}
