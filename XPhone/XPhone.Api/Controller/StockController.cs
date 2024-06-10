using Microsoft.AspNetCore.Mvc;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone/Stock")]
    public class StockController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
