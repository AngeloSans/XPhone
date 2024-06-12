using Microsoft.AspNetCore.Mvc;
using XPhone.Infrastructure.Repository;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone[Controller]")]
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

        [HttpGet("GetStockBy{id}")]
        public async Task<ActionResult<Stock>> GetStockById(Guid id)
        {
            var stock = await _stockRepository.GetStockById(id);
            if (stock == null)
                return NotFound();
            return Ok(stock);
        }

        [HttpPut("UpdateStock{id}")]
        public async Task<IActionResult> UpdateStock(Guid id, [FromBody] Stock stock)
        {
            if (id != stock.Id)
                return BadRequest();

            await _stockRepository.UpdateStockAsync(stock);
            return NoContent();
        }

        [HttpDelete("DeleteOnStock{id}")]
        public async Task<IActionResult> DeleteStock(Guid id)
        {
            await _stockRepository.DeleteStockAsync(id);
            return NoContent();
        }

        [HttpGet("GetCountSmarthPone/{id}")]
        public async Task<ActionResult<int>> GetStockCount(Guid id)
        {
            var count = await _stockRepository.GetStockCountAsync(id);
            return Ok(count);
        }
    }
}
