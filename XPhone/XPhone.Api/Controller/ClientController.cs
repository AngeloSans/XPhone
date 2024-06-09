using Microsoft.AspNetCore.Mvc;

namespace XPhone.Api.Controller

{
    [ApiController]
    [Route("XPhone/Clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
    }
}
