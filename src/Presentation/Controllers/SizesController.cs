using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class SizesController: Controller
    {
        private readonly ILogger<SizesController> _logger;
        private readonly ProductSizeService _service;

        public SizesController(ILogger<SizesController> logger, ProductSizeService
        service)
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

        public IActionResult Create()
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

        [HttpGet]
        public async Task<ActionResult<List<ProductSize>>> OnGet([FromQuery] string id)
        {
            try
            {
                var response = await _service.GetAllProductSizesAsync();
                return Ok(response);
            }
            catch(Exception error)
            {
                return BadRequest(new {
                    Message = error.Message,
                    Code = 400,
                    Log = error.ToString()
                });
            }
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OnPost(SizeModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View("Create", model);
                }

                ProductSize size = new ProductSize();
                size.Name = model.Name.Trim();
                size.Description = model.Description.Trim();
                size.CreatedBy = "169C551E-D350-4B14-8842-FC0DF70DFB12";
                size.UpdatedBy = size.CreatedBy;

                var reponse = await _service.CreateProductSizeAsync(size);
                
                return RedirectToAction(actionName: "Index", controllerName: "Home");
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