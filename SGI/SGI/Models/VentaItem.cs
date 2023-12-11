using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGI.Models
{
    public class VentaItem
    {
        [Key]
        public int Id { get; set; }
        public int VentaId { get; set; }
        [Required]
        public int ProductoId { get; set; }
        public decimal? Precio { get; set; } = 0;
        [Required]
        public int Cantidad { get; set; } = 1;
        [ForeignKey("VentaId")]
        public Venta? Venta { get; set; }

        [ForeignKey("ProductId")]
        public Producto? Producto { get; set; }

        public decimal? Subtotal { get; set; } = 0;
    } }
