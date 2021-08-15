using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class CategoriesController: Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ProductCategoryService _service;

        public CategoriesController(ILogger<CategoriesController> logger, ProductCategoryService service)
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
        public async Task<ActionResult<List<ProductCategory>>> OnGet()
        {
            try
            {
                var response = await _service.GetAllProductsCategoriesAsync();
                return response;
            }
            catch(Exception error)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(CategoryModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View("Create", model);
                }

                ProductCategory category = new ProductCategory();
                category.Name = model.Name.Trim();

                if(!String.IsNullOrEmpty(model.Description))
                {
                    category.Description = model.Description.Trim();
                }

                category.CreatedBy = "169C551E-D350-4B14-8842-FC0DF70DFB12";
                category.UpdatedBy = "169C551E-D350-4B14-8842-FC0DF70DFB12";

                await _service.CreateCategory(category);

                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            catch(Exception error)
            {
                throw;
                //return View("Error" ,new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = error.Message });
            }
        }
    }
}