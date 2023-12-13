

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGI.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }

        
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor que cero.")]
        public Double Total { get; set; }

        [Required]
        public string NumeroCompra { get; set; } = Guid.NewGuid().ToString(); // Genera un nuevo GUID como número de compra único

        public virtual ICollection<CompraItem>? CompraItems { get; set; }

        [NotMapped] // No se mapea a la base de datos
        public Double TotalMonto { get; set; } // Puedes calcularlo según tus necesidades
    }
}

