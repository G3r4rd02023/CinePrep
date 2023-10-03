using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CinePreview.Data.Entidades
{
    public class Descuento
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Valor { get; set; }
        public Funcion Funcion { get; set; }

    }
}
