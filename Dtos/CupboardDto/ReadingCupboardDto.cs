using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos.CupboardDto
{
    public class ReadingCupboardDto
    {
        public int Identification { get; set; }
        public int Product { get; set; }
        public string Section { get; set; }
        public int Inputs { get; set; }
        public int Outputs { get; set; }
    }
}
