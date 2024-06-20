using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Services
{
    public interface ISmartPhoneService
    {
        IEnumerable<SmartPhoneDTO> GetAllSmartPhone();
        SmartPhoneDTO GetSmartPhone(Guid id);
        void UpdateSmartPhone(SmartPhoneDTO smartPhoneDTO);
        void DeletePhone(Guid Id);
        bool checkAvaiable(Guid id);
    }
}
