using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class ProductsController: Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductService _service; 

        public ProductsController(ILogger<ProductsController> logger, ProductService service)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(ProductModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View("Create", model);
                }

                Product product = new Product();

                product.Name = model.Name;
                product.CategoryId = model.Category;
                product.TypeId = model.Type;
                product.SizeId = model.Size;
                product.Tags = model.Tags.Trim();
                product.Price = model.Price;
                product.Description = model.Description;
                product.CreatedBy = "169C551E-D350-4B14-8842-FC0DF70DFB12";
                product.UpdatedBy = product.CreatedBy;

                await _service.CreateProductAsync(product);

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
