using Microsoft.EntityFrameworkCore;
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

        public ReturnQueryService(IReturnRepository returnRepository)
        {
            _returnRepository = returnRepository;
        }
        public async Task<DateTime> GetDateReturnAsync(Guid id)
        {
            return await _returnRepository.GetDateReturnAsync(id);
            
        }


        public async Task<ReturnDTO> GetReturnAsync(Guid id)
        {
            var returnEntity = await _returnRepository.GetReturnAsync(id);
            if (returnEntity == null)
            {
                throw new KeyNotFoundException("Return Does Not Exist");
            }
            return new ReturnDTO
            {
                Id = returnEntity.Id,
                ReturnDate = returnEntity.ReturnDate,
                Condition = returnEntity.Condition,
                RentId = returnEntity.RentId,
            };

        }

        public async Task<bool> GetReturnConditionAsync(Guid ReturnId)
        {
            return await _returnRepository.GetReturnConditionAsync(ReturnId);
        }


 
    }
}
