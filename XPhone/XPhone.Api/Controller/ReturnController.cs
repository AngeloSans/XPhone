﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ICommandHandler<CreateReturnCommand> _createReturnHandler;
        private readonly ICommandHandler<UpdateReturnCommand> _updateReturnHandler;
        private readonly IReturnQueryService _returnQueryService;

        public ReturnController(
            ICommandHandler<DeleteReturnCommand> deleteReturnHandler,
            IReturnQueryService returnQueryService,
            ICommandHandler<CreateReturnCommand> createReturnHandler,
            ICommandHandler<UpdateReturnCommand> updateReturnHandler
            )
        {
            _deleteReturnHandler = deleteReturnHandler;
            _returnQueryService = returnQueryService;
            _createReturnHandler = createReturnHandler;
            _updateReturnHandler = updateReturnHandler;
        }

        [HttpGet("GetReturn{id}")]
        public async Task<ActionResult<Return>> GetReturn(Guid id)
        {
            var ret = await _returnQueryService.GetReturnAsync(id);
            if (ret == null)
                return NotFound();
            return Ok(ret);
        }

        /*[HttpGet("GetReturnDate/{returnDate}")]
        public async Task<ActionResult<IEnumerable<Return>>> GetReturnsByDate(Guid id)
        {
            var returns = await _returnQueryService.GetDateReturnAsync(id);
            return Ok(returns);
        }*/
        [HttpPost("AddReturn")]
        public async Task<ActionResult> AddReturn([FromBody] CreateReturnCommand command)
        {
            var returnCreated = await _createReturnHandler.HandlerAsync(command);
            return Ok("return create");
        }

        /*[HttpGet("GetConditions/{returnId}")]
        public async Task<ActionResult<bool>> GetReturnCondition(Guid returnId)
        {
            var condition = await _returnQueryService.GetReturnConditionAsync(returnId);
            return Ok(condition);
        }*/

        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeleteReturn(Guid id)
        {
            var returnn = await _returnQueryService.GetReturnAsync(id);
            if (returnn == null)
            {
                return NotFound();
            }

            var command = new DeleteReturnCommand { Id = id };
            await _deleteReturnHandler.HandlerAsync(command);
            return Ok("Return Was Deleted");
        }
        [HttpPut("UpdateReturn{id}")]
        public async Task<IActionResult> UpdateReturn(Guid id, [FromBody] UpdateReturnCommand command)
        {
            var returnn = await _returnQueryService.GetReturnAsync(id);
            if (returnn == null)
            {
                return NotFound();
            }
            var updateReturn = await _updateReturnHandler.HandlerAsync(command);
            return Ok("return updated");
        }
    }
}
