using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public class EditingProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Expiration { get; set; }
        public string Sku { get; set; }
    }
}
