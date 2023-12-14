using System.ComponentModel.DataAnnotations;

namespace SGI.Models.DTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "El Usuario es obligatorio")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string Password { get; set; }
    }
}
