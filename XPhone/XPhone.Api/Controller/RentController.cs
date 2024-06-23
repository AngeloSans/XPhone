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

        public RentController(ICommandHandler<UpdateRentCommand> updateCommandHandler, ICommandHandler<DeleteRentCommand> deleteCommandHandler, ICommandHandler<CreateRentCommand> createCommandHandler, RentQueryService rentQueryService)
        {
            _updateCommandHandler = updateCommandHandler;
            _deleteCommandHandler = deleteCommandHandler;
            _createCommandHandler = createCommandHandler;
            _rentQueryService = rentQueryService;
        }

        [HttpGet("GetAllRents")]
        public async Task<ActionResult<IEnumerable<Rent>>> GetAllRents()
        {
            var rents = await _rentQueryService.GetAllRentAsync();
            return Ok(rents);
        }

        [HttpGet("GetRentBy{id}")]
        public async Task<ActionResult<Rent>> GetRentById(Guid id)
        {
            var rent = await _rentQueryService.GetRentByIdAsync(id);
            if (rent == null)
                return NotFound();
            return Ok(rent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRent(Guid id, [FromBody] UpdateRentCommand command)
        {           
            await _updateCommandHandler.HandlerAsync(command);
            var rentUpdate = await _rentQueryService.GetRentByIdAsync(id);
            return Ok(rentUpdate);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(Guid id)
        {
            var rent = await _rentQueryService.GetRentByIdAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            var command = new DeleteRentCommand { Id = id };
            await _deleteCommandHandler.HandlerAsync(command);
            return Ok("Rent Was Deleted");
        }

        [HttpPost("AddRent")]
        public async Task<IActionResult> AddRent([FromBody] CreateRentCommand command)
        {
            var rent = await _createCommandHandler.HandlerAsync(command);
            return Ok(rent);

            
        }
    }
}
