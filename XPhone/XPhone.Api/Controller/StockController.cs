using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ICommandHandler<UpdateStockCommand> _updateStockHandler;
        private readonly ICommandHandler<DeleteSmartPhoneCommand> _deleteStockHandler;
        private readonly ICommandHandler<CreateStockCommand> _createStockHandler;
        private readonly RentQueryService _rentQueryService;

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
                return NotFound("Stock does not exist or found");
            return Ok(stock);
        }

        [HttpPut("UpdateStock/{id}")]
        public async Task<IActionResult> UpdateStock(Guid id, [FromBody] StockDTO stockDTO)
        {
            if (id != stockDTO.Id)
            {
                return BadRequest("Client ID mismatch");
            }

            var stock = await _stockRepository.GetStockById(id);
            if (stock == null)
            {
                return NotFound();
            }

            stock.stockName = stockDTO.stockName;

            await _stockRepository.UpdateStockAsync(stock);
            return Ok("Stock Was Updated");
        }

        [HttpDelete("DeleteStock/{id}")]
        public async Task<IActionResult> DeleteStock(Guid id)
        {
            var stock = await _stockRepository.GetStockById(id);
            if (stock == null)
            {
                return NotFound("Stock not found.");
            }

            await _stockRepository.DeleteStockAsync(id);
            return Ok($"Stock '{stock.stockName}' was deleted.");
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
