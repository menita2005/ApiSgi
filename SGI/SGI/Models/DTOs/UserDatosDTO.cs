namespace SGI.Models.DTOs
{
    public class UserDatosDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirtName { get; set; } 
        public string LastName{ get; set;}

        public static implicit operator UserDatosDTO(UserDTO v)
        {
            throw new NotImplementedException();
        }
    }
}