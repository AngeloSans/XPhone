using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Services
{
    public interface IReturnService
    {
        ReturnDTO GetReturn(Guid id);
        IEnumerable<ReturnDTO> GetDateReturn(DateTime ReturnDate);
        bool GetReturnCondition(Guid ReturnId);
        void DeleteReturnById(Guid id);

    }
}
