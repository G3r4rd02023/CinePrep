using CinePreview.Data;
using CinePreview.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinePreview.Controllers
{
    public class GenerosController : Controller
    {
        private readonly DataContext _context;

        public GenerosController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Generos
                 .ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genero genero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(genero);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception exception)
                {
                    ViewBag.Error(exception.Message);
                }
            }
            return View(genero);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peliculas == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Genero genero)
        {
            if (id != genero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genero);
                    await _context.SaveChangesAsync();
                }
                catch (Exception exception)
                {
                    ViewBag.Error(exception.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Generos == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (genero == null)
            {
                return NotFound();
            }

            try
            {
                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync();
            }
            catch
            {
                ViewBag.Error("No se puede borrar el genero porque tiene registros relacionados.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
