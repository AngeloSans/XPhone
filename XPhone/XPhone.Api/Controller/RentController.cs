using System;
using Microsoft.AspNetCore.Mvc;
using XPhone.Domain.Entities;
using XPhone.Infra.Repository;
using XPhone.Infrastructure.Repository;

namespace XPhone.Api.Controller
{
    [ApiController]
    [Route("XPhone/Rent")]
    public class RentController : ControllerBase
    {
        private readonly IRentRepository _rentRepository;
        public IActionResult Index()
        {
            return View();
        }
    }
}
