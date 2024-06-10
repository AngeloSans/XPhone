using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Infrastructure.Repository;

namespace XPhone.API.Controllers
{
    [ApiController]
    [Route("api[Controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
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
        public async Task<IActionResult> AddClient(Client client)
        {
            await _clientRepository.AddAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            await _clientRepository.UpdateAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _clientRepository.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
