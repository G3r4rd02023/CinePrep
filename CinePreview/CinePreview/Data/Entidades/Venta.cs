using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CinePreview.Data.Entidades
{
    public class Venta
    {
        public int Id { get; set; }

        public Cliente Cliente { get; set; } = null!;
        public Funcion Funcion { get; set; } = null!;
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio Total")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal PrecioTotal { get; set; }

    }
}
