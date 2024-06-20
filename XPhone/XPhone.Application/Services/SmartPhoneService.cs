using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra;
using XPhone.Infra.Repository;
using XPhone.Infrastructure.Repository;

namespace XPhone.Application.Services
{
    public class SmartPhoneService : ISmartPhoneService
    {
        private readonly SmartPhoneRepository _smartPhoneRepository;

        public SmartPhoneService(SmartPhoneRepository smartPhoneRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
        }

        public bool checkAvaiable(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeletePhone(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmartPhoneDTO> GetAllSmartPhone()
        {
            throw new NotImplementedException();
        }

        public SmartPhoneDTO GetSmartPhone(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSmartPhone(SmartPhoneDTO smartPhoneDTO)
        {
            throw new NotImplementedException();
        }
    }
}
