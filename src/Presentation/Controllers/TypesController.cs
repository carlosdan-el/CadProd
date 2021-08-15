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
    public class TypesController: Controller
    {
        private readonly ILogger<TypesController> _logger;
        private readonly ProductTypeService _service;

        public TypesController(ILogger<TypesController> logger,
        ProductTypeService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> OnGet([FromQuery] string id)
        {
            try
            {
                if(string.IsNullOrEmpty(id))
                {
                    var response = await _service.GetAllProductTypes();
                    return Ok(response);
                }
                else {
                    var response = await _service.GetProductTypesByCategoryId(id);
                    return Ok(response);
                }
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
        public async Task<ActionResult> OnPost(TypeModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View("Create", model);
                }

                ProductType type = new ProductType();
                type.Name = model.Name.Trim();
                type.ProductCategoryId = model.Category.Trim();

                if(!string.IsNullOrEmpty(model.Description))
                {
                    type.Description = model.Description.Trim();
                }

                type.CreatedBy = "169C551E-D350-4B14-8842-FC0DF70DFB12";
                type.UpdatedBy = "169C551E-D350-4B14-8842-FC0DF70DFB12";

                await _service.CreateProductType(type);

                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            catch(Exception error)
            {
                ErrorViewModel log = new ErrorViewModel();
                log.RequestId = Activity.Current?.Id ??
                HttpContext.TraceIdentifier;
                log.Message = error.Message;
                log.Trace = error.ToString();

                return View("Error", log);
            }
        }
    }
}