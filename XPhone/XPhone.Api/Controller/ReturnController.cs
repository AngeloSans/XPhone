/*using Microsoft.AspNetCore.Mvc;
using XPhone.Domain.Entities;
using XPhone.Infra.Repository;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone[Controller]")]
    public class ReturnController : ControllerBase
    {
        private readonly IReturnRepository _returnRepository;

        public ReturnController(IReturnRepository returnRepository)
        {
            _returnRepository = returnRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Return>> GetReturn(int id)
        {
            var ret = await _returnRepository.GetReturnAsync(id);
            if (ret == null)
                return NotFound();
            return Ok(ret);
        }

        [HttpGet("date/{returnDate}")]
        public async Task<ActionResult<IEnumerable<Return>>> GetReturnsByDate(DateTime returnDate)
        {
            var returns = await _returnRepository.GetDateReturnAsync(returnDate);
            return Ok(returns);
        }

        [HttpGet("condition/{returnId}")]
        public async Task<ActionResult<bool>> GetReturnCondition(Guid returnId)
        {
            var condition = await _returnRepository.GetReturnConditionAsync(returnId);
            return Ok(condition);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturn(Guid id)
        {
            await _returnRepository.DeleteReturnByIdAsync(id);
            return NoContent();
        }
    }
}
*/