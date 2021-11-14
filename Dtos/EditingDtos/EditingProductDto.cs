using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos.EditingDtos
{
    public class EditingProductDto
    {
        public string Name { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
