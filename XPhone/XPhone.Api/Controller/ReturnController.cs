using Microsoft.AspNetCore.Mvc;
using XPhone.Domain.Entities;
using XPhone.Infra.Repository;
using XPhone.Application.Command;
using XPhone.Application.Handler;
using XPhone.Application.Queries;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone[Controller]")]
    public class ReturnController : ControllerBase
    {

        private readonly ICommandHandler<DeleteReturnCommand> _deleteReturnHandler;
        private readonly ReturnQueryService _returnQueryService;

        public ReturnController(IReturnRepository returnRepository)
        {
            _returnRepository = returnRepository;
        }

        [HttpGet("GetReturn{id}")]
        public async Task<ActionResult<Return>> GetReturn(Guid id)
        {
            var ret = await _returnRepository.GetReturnAsync(id);
            if (ret == null)
                return NotFound();
            return Ok(ret);
        }

        [HttpGet("GetReturnDate/{returnDate}")]
        public async Task<ActionResult<IEnumerable<Return>>> GetReturnsByDate(DateTime returnDate)
        {
            var returns = await _returnRepository.GetDateReturnAsync(returnDate);
            return Ok(returns);
        }

        [HttpGet("GetConditions/{returnId}")]
        public async Task<ActionResult<bool>> GetReturnCondition(Guid returnId)
        {
            var condition = await _returnRepository.GetReturnConditionAsync(returnId);
            return Ok(condition);
        }

        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeleteReturn(Guid id)
        {
            await _returnRepository.DeleteReturnByIdAsync(id);
            return NoContent();
        }
    }
}
