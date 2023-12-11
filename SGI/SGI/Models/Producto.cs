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
    
        public double Precio { get; set; }
        [Required]   
        public int Stock { get; set; }

        // Relaciones
        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        
        public Categoria? Categoria { get; set; }

        [ForeignKey("ProveedorId")]
        public int ProveedorId { get; set; }
       
        public Proveedor? Proveedores { get; set; }
        
        public ICollection<VentaItem>? VentaItems { get; set; }
        public ICollection<CompraItem>? CompraItems { get; set; }
    }

}
