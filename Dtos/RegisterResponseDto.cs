using System.Collections.Generic;


namespace ApiProductManagment.Dtos
{
    public class RegisterResponseDto
    {
        public bool RegistroExitoso { get; set; } 
        public IEnumerable<string> Errors { get; set; }
    }
}
