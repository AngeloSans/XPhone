using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;
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
        public async Task<IActionResult> AddSmartPhoneToStock(Guid stockId, [FromBody] SmartPhoneDTO smartPhoneDTO)
        {
            
            var stock = await _stockRepository.GetStockById(stockId);
            if (stock == null)
            {
                return NotFound("Stock not found.");
            }

            var smartphone = new SmartPhone
            {
                Id = Guid.NewGuid(),
                Model = smartPhoneDTO.Model,
                Price = smartPhoneDTO.Price,
                Avaiable = smartPhoneDTO.Avaiable,
                OperationalSystem = smartPhoneDTO.OperationalSystem,
                Memory = smartPhoneDTO.Memory,
                Core = smartPhoneDTO.Core,
                StockId = stockId 
            };

            await _stockRepository.AddsmartPhone(stockId, smartphone);

            return CreatedAtAction(nameof(GetStockById), new { id = smartphone.Id }, smartphone);
        }


        [HttpPost("CreateStock")]
        public async Task<IActionResult> CreateStock([FromBody] StockDTO stockDTO)
        {
            if (stockDTO == null)
            {
                return BadRequest("Invalid client data.");
            }

            var stock = new Stock
            {
                Id = Guid.NewGuid(),
                stockName = stockDTO.stockName,
                
            };

            await _stockRepository.CreateStock(stock);

            return CreatedAtAction(nameof(GetStockById), new { id = stock.Id }, stock);
        }

    }
}
