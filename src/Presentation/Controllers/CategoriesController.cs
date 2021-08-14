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
    
        [HttpPost]
        public async Task<IActionResult> OnPost(CategoryModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            ProductCategory category = new ProductCategory();
            category.Name = model.Name.Trim();
            category.Description = model.Description.Trim();

            await _service.CreateCategory(category);

            return View("Home");
        }
    }
}