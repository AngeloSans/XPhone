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

        public ReturnController(
            ICommandHandler<DeleteReturnCommand> deleteReturnHandler,
            ReturnQueryService returnQueryService)
        {
            _deleteReturnHandler = deleteReturnHandler;
            _returnQueryService = returnQueryService;
        }

        [HttpGet("GetReturn{id}")]
        public async Task<ActionResult<Return>> GetReturn(Guid id)
        {
            var ret = await _returnQueryService.GetReturnAsync(id);
            if (ret == null)
                return NotFound();
            return Ok(ret);
        }

        [HttpGet("GetReturnDate/{returnDate}")]
        public async Task<ActionResult<IEnumerable<Return>>> GetReturnsByDate(DateTime returnDate)
        {
            var returns = await _returnQueryService.GetDateReturnAsync
            return Ok(returns);
        }

        [HttpGet("GetConditions/{returnId}")]
        public async Task<ActionResult<bool>> GetReturnCondition(Guid returnId)
        {
            var condition = await _returnQueryService.GetReturnConditionAsync(returnId);
            return Ok(condition);
        }

        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeleteReturn(Guid id)
        {
            var returnn = await _returnQueryService.GetReturnAsync(id);
            if (returnn == null)
            {
                return NotFound();
            }

            var command = new DeleteReturnCommand { id = id };
            await _deleteReturnHandler.HandlerAsync(command);
            return Ok("Return Was Deleted");
        }
    }
}
