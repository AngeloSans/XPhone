using Microsoft.AspNetCore.Mvc;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone/SmartPhone")]
    public class SmartPhoneController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
