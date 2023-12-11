using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGI.Models
{
    public class CompraItem
    {
        [Key]
        public int Id { get; set; }
        public int CompraId { get; set; }
        [Required]
        public int ProductoId { get; set; }
        public decimal? Precio { get; set; } = 0;
        [Required]
        public int Cantidad { get; set; } = 1;
        [ForeignKey("CompraId")]
        public Compra? Compra { get; set; }

        [ForeignKey("ProductId")]
        public Producto? Producto { get; set; }

        public decimal? Subtotal { get; set; } = 0;
    }
}
