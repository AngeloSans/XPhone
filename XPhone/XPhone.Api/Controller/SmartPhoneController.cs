using Microsoft.AspNetCore.Mvc;
using XPhone.Domain.Entities;
using XPhone.Infrastructure.Repository;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone[Controller]")]
    public class SmartPhoneController : ControllerBase
    {
        private readonly ISmartPhoneRepository _smartPhoneRepository;

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

        [HttpPost("AddSmartPhone")]
        public async Task<ActionResult<SmartPhone>> AddSmartPhone([FromBody] SmartPhone smartPhone)
        {
            if (smartPhone == null)
            {
                return BadRequest("SmartPhone cannot be null");
            }

            await _smartPhoneRepository.AddSmartPhoneAsync(smartPhone);
            return CreatedAtAction(nameof(GetAllSmartPhones), new { id = smartPhone.Id }, smartPhone);
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
            await _smartPhoneRepository.DeletePhoneAsync(id);
            return NoContent();
        }

        [HttpGet("CheckIsAvailable/{id}")]
        public async Task<ActionResult<bool>> CheckAvailability(Guid id)
        {
            var isAvailable = await _smartPhoneRepository.checkAvaiable(id);
            return Ok(isAvailable);
        }
    }
}
