using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public class ReadBrandDto
    {
        public int Identification { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
    }
}
