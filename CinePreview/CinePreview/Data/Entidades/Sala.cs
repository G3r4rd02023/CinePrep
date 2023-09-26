using System.ComponentModel.DataAnnotations;

namespace CinePreview.Data.Entidades
{
    public class Sala
    {
        public int Id { get; set; }

        [Display(Name = "Sala")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NombreSala { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Cantidad { get; set; }

    }
}
