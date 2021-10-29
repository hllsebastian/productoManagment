using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos.CategoryDto
{
    public class ReadCategoryDto
    {
        public int Identification { get; set; }
        public int ProductID { get; set; }
        public string Category { get; set; }
        public bool? Refrigerated { get; set; }
        public bool? Perishable { get; set; }
    }
}
