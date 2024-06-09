using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Infrastructure.Repository
{
    public interface ISmartPhoneRepository
    {
        Task<IEnumerable<SmartPhone>> GetAllSmartPhoneAsync();
        Task<SmartPhone> AddAsync(SmartPhone smartPhone);

        Task<SmartPhone> UpdateAsync(SmartPhone smartPhone);

        Task DeleteAsync(Guid Id);

        Task<bool> checkAvaiable(Guid id);
    }
}
