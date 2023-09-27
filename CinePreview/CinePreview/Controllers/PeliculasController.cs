using CinePreview.Data;
using CinePreview.Data.Entidades;
using CinePreview.Helpers;
using CinePreview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinePreview.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public PeliculasController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Peliculas
                .Include(p => p.Genero)
                .ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            CrearPeliculaViewModel model = new()
            {
                Generos = await _combosHelper.GetComboGenerosAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearPeliculaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var genero = await _context.Generos.FindAsync(model.GeneroId);
                if (genero == null)
                {
                    return NotFound();
                }
                Pelicula pelicula = new()
                {
                    Titulo = model.Titulo,
                    Duracion = model.Duracion,
                    Genero = genero,
                    FechaEstreno = model.FechaEstreno,
                };
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
            
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peliculas == null)
            {
                return NotFound();
            }

           

            var pelicula = await _context.Peliculas                                
                .FindAsync(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            

            CrearPeliculaViewModel model = new()
            {
                Id = pelicula.Id,
                Titulo = pelicula.Titulo,
                Duracion = pelicula.Duracion,                                
                FechaEstreno = pelicula.FechaEstreno,
                Generos = await _combosHelper.GetComboGenerosAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CrearPeliculaViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var genero = await _context.Generos.FindAsync(model.GeneroId);
                    if (genero == null)
                    {
                        return NotFound();
                    }

                    var pelicula = new Pelicula
                    {
                        Id = model.Id,
                        Titulo = model.Titulo,
                        Duracion = model.Duracion,
                        Genero = genero,
                        FechaEstreno = model.FechaEstreno
                    };
                    _context.Update(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (Exception exception)
                {
                    ViewBag.Error(exception.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            model.Generos = await _combosHelper.GetComboGenerosAsync();
            return View(model);
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
