using Microsoft.AspNetCore.Mvc;
using XPhone.Domain.Entities;
using XPhone.Infra.Repository;
using XPhone.Infrastructure.Repository;
using XPhone.Application.Command;
using XPhone.Application.Handler;
using XPhone.Application.Queries;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone[Controller]")]
    public class SmartPhoneController : ControllerBase
    {
        private readonly ICommandHandler<UpdateSmartPhoneCommand> _updateCommandHandler;
        private readonly ICommandHandler<DeleteSmartPhoneCommand> _deleteCommandHandler;
        private readonly ICommandHandler<CreateSmartPhoneCommand> _createCommandHandler;
        private readonly ISmartPhoneQueryService _phoneQueryService;

        public SmartPhoneController(
            ICommandHandler<UpdateSmartPhoneCommand> updateCommandHandler,
            ICommandHandler<DeleteSmartPhoneCommand> deleteCommandHandler,
            ISmartPhoneQueryService phoneQueryService
            )
        {
            _deleteCommandHandler = deleteCommandHandler;
            _phoneQueryService = phoneQueryService;
            _updateCommandHandler = updateCommandHandler;
        }

        [HttpGet("GetAllSmartPhones")]
        public async Task<ActionResult<IEnumerable<SmartPhone>>> GetAllSmartPhones()
        {
            var smartPhones = await _phoneQueryService.GetAllSmartPhoneAsync();
            return Ok(smartPhones);
        }


        [HttpPut("UpdateSmartPhone{id}")]
        public async Task<IActionResult> UpdateSmartPhone(Guid id, [FromBody] UpdateSmartPhoneCommand command)
        {
            
            await _updateCommandHandler.HandlerAsync(command);
            return Ok("Phone was updated");
        }

        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeleteSmartPhone(Guid id)
        {
            var phone = await _phoneQueryService.GetSmartPhoneAsync(id);
            if (phone == null)
            {
                return NotFound("Phone not found.");
            }

            var command = new DeleteSmartPhoneCommand { Id = id };
            await _deleteCommandHandler.HandlerAsync(command);
            return Ok("Phone Was Deleted");
        }

        [HttpGet("CheckIsAvailable/{id}")]
        public async Task<ActionResult<bool>> CheckAvailability(Guid id)
        {
            var isAvailable = await _phoneQueryService.checkAvaiable(id);
            return Ok(isAvailable);
        }
    }
}
