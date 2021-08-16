using System;
using System.Diagnostics;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _service;

        public HomeController(ILogger<HomeController> logger,
        ProductService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch(Exception error)
            {
                ErrorViewModel log = new ErrorViewModel();
                log.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                log.Message = error.Message;
                log.Trace = error.ToString();

                return View("Error", log);
            }
        }

        public IActionResult Privacy()
        {
            try
            {
                return View();
            }
            catch(Exception error)
            {
                ErrorViewModel log = new ErrorViewModel();
                log.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                log.Message = error.Message;
                log.Trace = error.ToString();

                return View("Error", log);
            }
        }
    }
}
