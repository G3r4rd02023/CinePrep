using CinePreview.Data.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CinePreview.Models
{
    public class CrearPeliculaViewModel:Pelicula
    {
        [Display(Name = "Genero")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un genero.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int GeneroId { get; set; }
        public IEnumerable<SelectListItem> Generos { get; set; }
    }
}
