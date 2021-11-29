using System.ComponentModel.DataAnnotations;

namespace ApiProductManagment.Dtos 
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ClientURI { get; set; }
    }
}
