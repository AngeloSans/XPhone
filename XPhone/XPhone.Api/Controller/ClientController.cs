using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Infrastructure.Repository;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientRepository.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest("Client cannot be null");
            }

            await _clientRepository.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] Client client)
        {
            if (id != client.Id)
            {
                return BadRequest("Client ID mismatch");
            }

            await _clientRepository.UpdateClientAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _clientRepository.DeleteClientByIdAsync(id);
            return NoContent();
        }
    }
}
