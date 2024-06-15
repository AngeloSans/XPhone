using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;
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

        [HttpGet("GetClientById/{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClient([FromBody] ClientDTO clientDTO)
        {
            if (clientDTO == null)
            {
                return BadRequest("Invalid client data.");
            }

            var client = new Client
            {
                Id = Guid.NewGuid(),
                Name = clientDTO.Name,
                Email = clientDTO.Email,
                Fine = clientDTO.Fine,
                FineAmount = clientDTO.FineAmount,
                Phone = clientDTO.Phone
            };

            await _clientRepository.AddClientAsync(client);


            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }

        [HttpPut("UpdateClientById/{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] ClientDTO clientDTO)
        {
            if (id != clientDTO.Id)
            {
                return BadRequest("Client ID mismatch");
            }

            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            client.Name = clientDTO.Name;
            client.Email = clientDTO.Email;
            client.Fine = clientDTO.Fine;
            client.FineAmount = clientDTO.FineAmount;
            client.Phone = clientDTO.Phone;

            await _clientRepository.UpdateClientAsync(client);
            return NoContent();
        }

        [HttpDelete("DeleteClientById/{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            await _clientRepository.DeleteClientByIdAsync(id);
            return NoContent();
        }
    }
}