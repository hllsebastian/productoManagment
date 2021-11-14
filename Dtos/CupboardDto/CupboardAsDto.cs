using ApiProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos.CupboardDto
{
    public static class CupboardAsDto
    {
        public static ReadingCupboardDto readingCupboardAsDto ( this Cupboard c)
        {
            return new ReadingCupboardDto
            {
                Identification = c.IdCupboard,
                Product        = c.IdProductCb,
                Inputs         = c.ProductInput,
                Outputs        = c.ProductOutput
            };
        }

        public static EditingCupboardDto editingCupboardAsDto(this Cupboard c)
        {
            return new EditingCupboardDto
            {
                Section = c.IdCupboard,
                product = c.IdProductCb,
                Inputs  = c.ProductInput,
                Outputs = c.ProductOutput
            };
        }


    }
}
