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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("Xphone/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ICommandHandler<UpdateStockCommmand> _updateStockHandler;
        private readonly ICommandHandler<DeleteStockCommand> _deleteStockHandler;
        private readonly ICommandHandler<CreateStockCommand> _createStockHandler;
        private readonly ICommandHandlerCreate<CreateSmartPhoneCommand> _createPhoneHandler;
        private readonly IStockQueryService _stockQueryService;

        public StockController(
            ICommandHandler<UpdateStockCommmand> updateStockHandler,
            ICommandHandler<DeleteStockCommand> deleteStockHandler,
            ICommandHandler<CreateStockCommand> createStockHandler,
            ICommandHandlerCreate<CreateSmartPhoneCommand> createPhoneHandler,
            IStockQueryService stockQueryService
            )
        {
            _createStockHandler = createStockHandler;
            _updateStockHandler = updateStockHandler;
            _deleteStockHandler = deleteStockHandler;
            _stockQueryService = stockQueryService;
            _createPhoneHandler = createPhoneHandler;
        }

        [HttpGet("GetAllStock")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAllStocks()
        {
            var stocks = await _stockQueryService.GetAllStocksAsync();
            return Ok(stocks);
        }

        [HttpGet("GetStockById/{id}")]
        public async Task<ActionResult<Stock>> GetStockById(Guid id)
        {
            var stock = await _stockQueryService.GetStockById(id);
            if (stock == null)
                return NotFound("Stock does not exist or found");
            return Ok(stock);
        }

        [HttpPut("UpdateStock/{id}")]
        public async Task<IActionResult> UpdateStock(Guid id, [FromBody] UpdateStockCommmand command)
        {
            if (id != command.id)
            {
                return BadRequest("Client ID mismatch");
            }

            var stockUpdated = await _updateStockHandler.HandlerAsync(command);
            return Ok("the stock " +command.stockName + "has been updated");
        }

        [HttpDelete("DeleteStock/{id}")]
        public async Task<IActionResult> DeleteStock(Guid id)
        {
            var stock = await _stockQueryService.GetStockById(id);
            if (stock == null)
            {
                return NotFound();
            }

            var command = new DeleteStockCommand { id = id };
            await _deleteStockHandler.HandlerAsync(command);
            return Ok("Stock Was Deleted");
        }

        [HttpGet("GetStockCount/{id}")]
        public async Task<ActionResult<int>> GetStockCount(Guid id)
        {
            
            var count = await _stockQueryService.GetStockCountAsync(id);
            return Ok(count);
        }

        [HttpPost("AddSmartPhoneToStock/{stockId}")]
        public async Task<IActionResult> AddSmartPhoneToStock(Guid stockId, [FromBody] CreateSmartPhoneCommand command)
        {
            var stock = await _stockQueryService.GetStockById(stockId);
            if(stock == null)
            {
                return NotFound("stock not found");
            }
            var phone = await _createPhoneHandler.HandlerAsync(stockId, command);
            return Ok(command.Model + " added");
        }
        

        [HttpPost("CreateStock")]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockCommand command)
        {
            var stock = await _createStockHandler.HandlerAsync(command); 
            return Ok("Stock " + command.stockName + " Has been created");
        }
    }
}
