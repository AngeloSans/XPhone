using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Infrastructure.Repository;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet("GetAllStock")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAllStocks()
        {
            var stocks = await _stockRepository.GetAllStocksAsync();
            return Ok(stocks);
        }

        [HttpGet("GetStockById/{id}")]
        public async Task<ActionResult<Stock>> GetStockById(Guid id)
        {
            var stock = await _stockRepository.GetStockById(id);
            if (stock == null)
                return NotFound();
            return Ok(stock);
        }

        [HttpPut("UpdateStock/{id}")]
        public async Task<IActionResult> UpdateStock(Guid id, [FromBody] Stock stock)
        {
            if (id != stock.Id)
                return BadRequest();

            await _stockRepository.UpdateStockAsync(stock);
            return NoContent();
        }

        [HttpDelete("DeleteStock/{id}")]
        public async Task<IActionResult> DeleteStock(Guid id)
        {
            await _stockRepository.DeleteStockAsync(id);
            return NoContent();
        }

        [HttpGet("GetStockCount/{id}")]
        public async Task<ActionResult<int>> GetStockCount(Guid id)
        {
            var count = await _stockRepository.GetStockCountAsync(id);
            return Ok(count);
        }

        [HttpPost("AddSmartPhoneToStock/{stockId}")]
        public async Task<IActionResult> AddSmartPhoneToStock(Guid stockId, [FromBody] SmartPhone smartPhone)
        {
            try
            {
                var addedSmartPhone = await _stockRepository.AddsmartPhone(stockId, smartPhone);
                return Ok($"Smartphone '{addedSmartPhone.Model}' adicionado ao estoque com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar smartphone ao estoque: {ex.Message}");
            }
        }
    }
}
