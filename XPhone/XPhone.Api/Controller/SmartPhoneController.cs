/*using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmartPhone>>> GetAllSmartPhones()
        {
            var smartPhones = await _smartPhoneRepository.GetAllSmartPhoneAsync();
            return Ok(smartPhones);
        }

        //[HttpPost]
        //public async Task<ActionResult<SmartPhone>> AddSmartPhone([FromBody] SmartPhone smartPhone)
       /// <summary>
       /// {
       /// </summary>
        //    var addedSmartPhone = await _smartPhoneRepository.AddSmartPhoneAsync(smartPhone);
        ///    return CreatedAtAction(nameof(GetSmartPhoneById), new { id = addedSmartPhone.Id }, addedSmartPhone);
       // }

       // [HttpGet("{id}")]
       // public async Task<ActionResult<SmartPhone>> GetSmartPhoneById(Guid id)
       // {
         //   var smartPhone = await _smartPhoneRepository.GetSmartPhoneById(id);
        //    if (smartPhone == null)
       ///         return NotFound();
         ///   return Ok(smartPhone);
       // }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSmartPhone(Guid id, [FromBody] SmartPhone smartPhone)
        {
            if (id != smartPhone.Id)
                return BadRequest();

            await _smartPhoneRepository.UpdateSmartPhoneAsync(smartPhone);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmartPhone(Guid id)
        {
            await _smartPhoneRepository.DeletePhoneAsync(id);
            return NoContent();
        }

        [HttpGet("check/{id}")]
        public async Task<ActionResult<bool>> CheckAvailability(Guid id)
        {
            var isAvailable = await _smartPhoneRepository.checkAvaiable(id);
            return Ok(isAvailable);
        }
    }
}
*/