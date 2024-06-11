using System;
using Microsoft.AspNetCore.Mvc;
using XPhone.Domain.Entities;
using XPhone.Infra.Repository;
using XPhone.Infrastructure.Repository;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone[Controller]")]
    public class RentController : ControllerBase
    {
        private readonly IRentRepository _rentRepository;

        public RentController(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        [HttpGet("Get all rents")]
        public async Task<ActionResult<IEnumerable<Rent>>> GetAllRents()
        {
            var rents = await _rentRepository.GetAllRentAsync();
            return Ok(rents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rent>> GetRentById(int id)
        {
            var rent = await _rentRepository.GetRentByIdAsync(id);
            if (rent == null)
                return NotFound();
            return Ok(rent);
        }

        //[HttpPut("{id}")]
       // public async Task<IActionResult> UpdateRent(int id, [FromBody] Rent rent)
        //{
          //  if (id != rent.Id)
               // return BadRequest();

       //     await _rentRepository.UpdateRentAsync(rent);
       //     return NoContent();
       // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(Guid id)
        {
            await _rentRepository.DeleteRentAsync(id);
            return NoContent();
        }
    }
}
