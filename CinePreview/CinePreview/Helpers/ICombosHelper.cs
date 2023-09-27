using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinePreview.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboGenerosAsync();
    }
}
