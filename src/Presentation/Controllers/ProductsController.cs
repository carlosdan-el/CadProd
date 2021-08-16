using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Presentation.Models;
using System.IO;

namespace Presentation.Controllers
{
    public class ProductsController: Controller
    {
        private readonly ILogger<ProductsController> _logger;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly ProductService _service; 

        public ProductsController(ILogger<ProductsController> logger,
        ProductService service, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHostEnvironment = webHost;
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
        public async Task<ActionResult<List<Product>>> OnGet()
        {
            try
            {
                var response = await _service.GetAllProductsAsync();
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
                var response = await _service.GetProductByIdAsync(id);
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
                product.ImagePath = "";

                if(model.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + model.Image.FileName;;
                    string folder = Path.Combine(_webHostEnvironment.WebRootPath, "images/thumbs");
                    string filePath = Path.Combine(folder, fileName);

                    using(var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Image.CopyTo(fileStream);
                    }

                    product.ImagePath = $"/images/thumbs/{fileName}";
                }

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
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPut(ProductModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View("Edit", model);
                }

                Product product = new Product();

                product.Id = model.Id;
                product.Name = model.Name;
                product.CategoryId = model.Category;
                product.TypeId = model.Type;
                product.SizeId = model.Size;
                product.Tags = model.Tags.Trim();
                product.Price = model.Price;
                product.Description = model.Description;
                product.UpdatedBy = "169C551E-D350-4B14-8842-FC0DF70DFB12";

                await _service.UpdateProductAsync(product);

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

        [HttpDelete]
        public async Task<ActionResult> OnDelete([FromQuery] string id)
        {
            try{
                await _service.DeleteProductAsync(id);
                return Ok(new {
                    Message = "Record deleted wit success.",
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
