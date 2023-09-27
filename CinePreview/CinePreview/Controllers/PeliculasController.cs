using CinePreview.Data;
using CinePreview.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CinePreview.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly DataContext _context;

        public PeliculasController(DataContext context)
        {
            _context = context;           
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Peliculas
                .Include(p => p.Genero)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pelicula pelicula)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Add(pelicula);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }                
                catch (Exception exception)
                {
                    ViewBag.Error(exception.Message);
                }
            }
            return View(pelicula);
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
        public async Task<IActionResult> Edit(int id, Pelicula pelicula)
        {
            if (id != pelicula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelicula);                   
                    await _context.SaveChangesAsync();
                }                
                catch (Exception exception)
                {
                    ViewBag.Error(exception.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peliculas == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }

            try
            {
                _context.Peliculas.Remove(pelicula);
                await _context.SaveChangesAsync();               
            }
            catch
            {
                ViewBag.Error("No se puede borrar la categoría porque tiene registros relacionados.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
