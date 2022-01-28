using System.Threading.Tasks;

using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IPaisService _paisService;

        public PaisesController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _paisService.GetPaisesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var pais = await _paisService.GetByIdAsync(id);
            if (pais == null)
                return NotFound();

            return View(pais);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaisDTO pais)
        {
            if (!ModelState.IsValid)
                return View(pais);

            await _paisService.AddAsync(pais);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var pais = await _paisService.GetByIdAsync(id);
            if (pais == null)
                return NotFound();

            return View(pais);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PaisDTO pais)
        {
           if (!ModelState.IsValid)
                return View(pais);

            await _paisService.UpdateAsync(pais);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var pais = await _paisService.GetByIdAsync(id);
            if (pais == null)
                return NotFound();

            return View(pais);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paisService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
