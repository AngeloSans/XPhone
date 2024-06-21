using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Repository;

namespace XPhone.Application.Queries
{
    public class ReturnQueryService : IReturnQueryService
    {
        private readonly IReturnRepository _returnRepository;
        public Task<IEnumerable<ReturnDTO>> GetDateReturnAsync(DateTime returnDate)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnDTO> GetReturnAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetReturnConditionAsync(Guid ReturnId)
        {
            throw new NotImplementedException();
        }
    }
}
