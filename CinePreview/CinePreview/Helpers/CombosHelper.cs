using CinePreview.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinePreview.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;
        

        public CombosHelper(DataContext context)
        {
            _context = context;            
        }
        public async Task<IEnumerable<SelectListItem>> GetComboGenerosAsync()
        {
            List<SelectListItem> list = await _context.Generos               
               .Select(c => new SelectListItem
               {
                   Text = c.Descripcion,
                   Value = c.Id.ToString()
               })
               .OrderBy(c => c.Text)
               .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione un genero...", Value = "0" });
            return list;
        }
    }
}
