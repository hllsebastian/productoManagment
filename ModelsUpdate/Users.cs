using Microsoft.AspNetCore.Identity;

namespace ApiProductManagment.ModelsUpdate
{
    public class Users: IdentityUser
    {
        public string NombreCompleto { get; set; }
    }
}
