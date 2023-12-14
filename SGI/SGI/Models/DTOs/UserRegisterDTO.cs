using System.ComponentModel.DataAnnotations;

namespace SGI.Models.DTOs
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "El Usuario es obligatorio")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El Apellido es obligatorio")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string Password{ get; set; }
        public string Role{ get; set; }
    }
}
