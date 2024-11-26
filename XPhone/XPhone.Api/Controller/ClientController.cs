using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;
using XPhone.Infrastructure.Repository;
using XPhone.Application.Command;
using XPhone.Application.Handler;
using XPhone.Application.Queries;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ICommandHandler<CreateClientCommand> _createClientCommand;
        private readonly IClientQueryService _clientQueryService;
        private readonly ICommandHandler<UpdateCLientCommand> _updateCLientCommand;
        private readonly ICommandHandler<DeleteClientCommand> _deleteCLientCommand;

        public ClientController(
            ICommandHandler<CreateClientCommand> createClientCommand,
            IClientQueryService clientQueryService,
            ICommandHandler<UpdateCLientCommand> updateCLientCommand,
            ICommandHandler<DeleteClientCommand> deleteCLientCommand
            )
        {
            _clientQueryService = clientQueryService;
            _createClientCommand = createClientCommand;
            _deleteCLientCommand = deleteCLientCommand;
            _updateCLientCommand = updateCLientCommand;

        }

        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientQueryService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("GetClientById/{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await _clientQueryService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClient([FromBody] CreateClientCommand command)
        {
            var client = await _createClientCommand.HandlerAsync(command);
            return Ok(client);
        }

        [HttpPut("UpdateClientById/{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] UpdateCLientCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Client ID mismatch");
            }

            var clientUpdated = await _updateCLientCommand.HandlerAsync(command);
            return Ok("client has been updated");
        }

        [HttpDelete("DeleteClientById/{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = await _clientQueryService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var command = new DeleteClientCommand { Id = id };
            await _deleteCLientCommand.HandlerAsync(command);
            return Ok("Client Was Deleted");
        }
    }
}
