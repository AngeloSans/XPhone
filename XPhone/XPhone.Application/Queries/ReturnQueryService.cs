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
            returnRepository = _returnRepository;
        }
        public async Task<ReturnDTO> GetDateReturnAsync(Guid id)
        {
            var returnDate = await _returnRepository.GetDateReturnAsync(id); 
            if(returnDate == null)
            {
                throw new KeyNotFoundException("Date not found :(");
            }


            return await _returnRepository.GetDateReturnAsync(id);
        }


        public async Task<ReturnDTO> GetReturnAsync(Guid id)
        {
            var returnEntity = await _returnRepository.GetReturnAsync(id);
            if (returnEntity == null)
            {
                throw new KeyNotFoundException("Return Does Not Exist");
            }

        }

        public async Task<bool> GetReturnConditionAsync(Guid ReturnId)
        {
            return await _returnRepository.GetReturnConditionAsync(ReturnId);
        }
    }
}
