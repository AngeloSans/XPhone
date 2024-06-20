using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Repository;

namespace XPhone.Application.Services
{
    public class ReturnService : IReturnService
    {
        private readonly ReturnRepository _repository;

        public ReturnService(ReturnRepository repository)
        {
            _repository = repository;
        }

        public void DeleteReturnById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool GetReturnCondition(Guid ReturnId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ReturnDTO> IReturnService.GetDateReturn(DateTime returnDate)
        {
            throw new NotImplementedException();
        }

        ReturnDTO IReturnService.GetReturn(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
