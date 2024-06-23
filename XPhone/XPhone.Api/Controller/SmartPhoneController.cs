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
        //private readonly ICommandHandler<CreateSmartPhoneCommand> _createCommandHandler;
        private readonly RentQueryService _rentQueryService;

        public SmartPhoneController(ISmartPhoneRepository smartPhoneRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
        }

        [HttpGet("GetAllSmartPhones")]
        public async Task<ActionResult<IEnumerable<SmartPhone>>> GetAllSmartPhones()
        {
            var smartPhones = await _smartPhoneRepository.GetAllSmartPhoneAsync();
            return Ok(smartPhones);
        }


        [HttpPut("UpdateSmartPhone{id}")]
        public async Task<IActionResult> UpdateSmartPhone(Guid id, [FromBody] SmartPhone smartPhone)
        {
            if (id != smartPhone.Id)
                return BadRequest();

            await _smartPhoneRepository.UpdateSmartPhoneAsync(smartPhone);
            return NoContent();
        }

        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeleteSmartPhone(Guid id)
        {
            var phone = await _smartPhoneRepository.GetSmartPhoneAsync(id);
            if (phone == null)
            {
                return NotFound("Phone not found.");
            }

            await _smartPhoneRepository.DeletePhoneAsync(id);
            return Ok($"Phone '{phone.Model}' was deleted.");
        }

        [HttpGet("CheckIsAvailable/{id}")]
        public async Task<ActionResult<bool>> CheckAvailability(Guid id)
        {
            var isAvailable = await _smartPhoneRepository.checkAvaiable(id);
            return Ok(isAvailable);
        }
    }
}
