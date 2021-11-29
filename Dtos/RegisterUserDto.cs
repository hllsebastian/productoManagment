using System.ComponentModel.DataAnnotations;


namespace ApiProductManagment.Dtos
{
    public class RegisterUserDto
    {
        public string NombreCompleto { get; set; }  
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo Password no puede ir vacío.")]
        public string Password { get; set; }

        public string ClientURI { get; set; }
    }
}
