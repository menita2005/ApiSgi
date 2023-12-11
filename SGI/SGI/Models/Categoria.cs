using System.ComponentModel.DataAnnotations;

namespace SGI.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
       [Required]
        [MaxLength(64)]

        public required string Nombre { get; set; }
        
    }

}
