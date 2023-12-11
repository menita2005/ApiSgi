using System.ComponentModel.DataAnnotations;

namespace SGI.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
       
        public required string Nombre { get; set; }
        [MaxLength(64)]
        public required string Contacto { get; set; }
        public ICollection<Producto>? Productos { get; set; }

        // Otros campos relevantes
    }

}
    