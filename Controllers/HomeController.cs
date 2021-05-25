using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using redis_distributed_cache.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace redis_distributed_cache.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // SET SESSION VALUE
        [HttpGet]
        public IActionResult SetSession()
        {
            var valueToWrite = $"Set session value: {DateTime.Now}";
            HttpContext.Session.SetString("SessionValue", valueToWrite);

            return Content($"Set session value - {valueToWrite}");
        }

        // GET SESSION VALUE
        [HttpGet]
        public IActionResult GetSession()
        {
            var value = HttpContext.Session.GetString("SessionValue");

            return Content($"Session value is : {value}");
        }
    }
}
