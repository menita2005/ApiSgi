using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGI.Models
{
    public class Producto
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public required string Nombre { get; set; }
        [Required]
        [MaxLength(64)]
        public decimal Precio { get; set; } = 0;
        [Required]
        [MaxLength(64)]
        public int Stock { get; set; } = 1;

        // Relaciones
        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        [Required]
        public Categoria Categoria { get; set; }

        public string Package { get; set; }

        public int ProveedorId { get; set; }
        [ForeignKey("ProveedorId")]
        public  Proveedor? Proveedores { get; set; }
        
        public ICollection<VentaItem>? VentaItems { get; set; }
        public ICollection<CompraItem>? CompraItems { get; set; }
    }

}
