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
            if(!ModelState.IsValid)
            {
                return View("Create");
            }

            Product product = new Product();

            product.Name = model.Name;
            product.CategoryId = model.Category;
            product.TypeId = model.Type;
            product.SizeId = model.Size;
            product.Tags = model.Tags.Trim();
            product.Price = model.Price;
            product.Description = model.Description;

            await _service.CreateProductAsync(product);

            return RedirectToPage("Index");
        }
    }
}
