using System.IO;
using System.Threading.Tasks;

using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        private readonly IWebHostEnvironment _environment;

        public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _categoryService = categoryService;

            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _productService.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            var categories = await _categoryService.GetCategoriesAsync();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _productService.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + product.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(product);
        }
    }
}
