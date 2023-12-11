
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGI.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor que cero.")]
        public decimal Total { get; set; }

        [Required]
        public string VentasNumber { get; set; } = Guid.NewGuid().ToString(); // Genera un nuevo GUID como número de ventas único

        public virtual ICollection<VentaItem>? VentaItems { get; set; }

        public decimal TotalMonto { get; set; } // Puedes calcularlo según tus necesidades
    }
}


