using System;
using Microsoft.AspNetCore.Mvc;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Repository;
using XPhone.Infrastructure.Repository;
using XPhone.Application.Command;
using XPhone.Application.Handler;
using XPhone.Application.Queries;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone[Controller]")]
    public class RentController : ControllerBase
    {
        private readonly ICommandHandler<UpdateRentCommand> _updateCommandHandler;
        private readonly ICommandHandler<DeleteRentCommand> _deleteCommandHandler;
        private readonly ICommandHandler<CreateRentCommand> _createCommandHandler;
        private readonly RentQueryService _rentQueryService;

        public RentController(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        [HttpGet("GetAllRents")]
        public async Task<ActionResult<IEnumerable<Rent>>> GetAllRents()
        {
            var rents = await _rentRepository.GetAllRentAsync();
            return Ok(rents);
        }

        [HttpGet("GetRentBy{id}")]
        public async Task<ActionResult<Rent>> GetRentById(Guid id)
        {
            var rent = await _rentRepository.GetRentByIdAsync(id);
            if (rent == null)
                return NotFound();
            return Ok(rent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRent(Guid id, [FromBody] Rent rent)
        {
            

            await _rentRepository.UpdateRentAsync(rent);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(Guid id)
        {
            await _rentRepository.DeleteRentAsync(id);
            return NoContent();
        }

        [HttpPost("AddRent")]
        public async Task<IActionResult> AddRent([FromBody] RentDTO rentDTO)
        {
            if(rentDTO == null)
            {
                return BadRequest();
            }

            var rent = new Rent
            {
                StartDate = rentDTO.StartDate,
                EndDate = rentDTO.EndDate,
                RentAmount = rentDTO.RentAmount,
                Devolution = rentDTO.Devolution,
                ClientId = rentDTO.ClientId,
                SmartPhoneId = rentDTO.SmartPhoneId
            };

            rent = await _rentRepository.AddRentAdync(rent);

            return CreatedAtAction(nameof(GetRentById), new { id  = rent.Id }, rent);
        }
    }
}
