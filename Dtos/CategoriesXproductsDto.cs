using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public class CategoriesXproductsDto
    {
        public Guid IdCategoryXproduct { get; set; }
        public Guid IdCategory { get; set; }
        public Guid IdProduct { get; set; }
    }
}
