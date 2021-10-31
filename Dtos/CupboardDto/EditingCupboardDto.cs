using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos.CupboardDto
{
    public class EditingCupboardDto
    {
        public int Section { get; set; }
        public int product { get; set; }
        public int Inputs { get; set; }
        public int Outputs { get; set; }
    }
}
