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
        
        public IActionResult Edit([FromQuery] string id)
        {
            try
            {
                if(!string.IsNullOrEmpty(id))
                {
                    return View("Edit");
                }

                return View("Create");
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
        public async Task<ActionResult<List<ProductCategory>>> OnGet()
        {
            try
            {
               var response = await _service.GetAllProductsCategoriesAsync();
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

        [HttpGet]
        public async Task<ActionResult<ProductCategory>> OnGetById([FromQuery] string id)
        {
            try
            {
                var response = await _service.GetProductCategoryByIdAsync(id);
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

        [HttpGet] 
        public async Task<ActionResult<List<ProductCategory>>> OnGetCategoriesView()
        {
            try
            {
                var response = await _service.GetAllGetProductCategoryViewAsync();
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
                category.UpdatedBy = category.CreatedBy;

                await _service.CreateCategoryAsync(category);

                return RedirectToAction(actionName: "Index", controllerName: "Home");
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
        public async Task<IActionResult> OnPut(CategoryModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View("Edit", model);
                }

                ProductCategory product = new ProductCategory();

                product.Id = model.Id;
                product.Name = model.Name;
                product.Description = model.Description;
                product.UpdatedBy = "169C551E-D350-4B14-8842-FC0DF70DFB12";

                await _service.UpdateCategoryProductAsync(product);

                return RedirectToAction(actionName: "Index", controllerName: "Categories");

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

        [HttpDelete]
        public async Task<ActionResult> OnDelete([FromQuery] string id)
        {
            try{
                await _service.DeleteCategoryProductAsync(id);
                return Ok(new {
                    Message = "Record deleted wit success",
                    Code =  200
                });
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

    }
}