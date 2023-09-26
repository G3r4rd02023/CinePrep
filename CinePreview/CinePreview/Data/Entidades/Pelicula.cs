using System.ComponentModel.DataAnnotations;

namespace CinePreview.Data.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Titulo { get; set; } = null!;
        public Genero Genero { get; set; } = null!;
        
        [Display(Name = "Duración")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Duracion { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        [Display(Name = "Fecha de Estreno")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaEstreno { get; set; }

    }
}
