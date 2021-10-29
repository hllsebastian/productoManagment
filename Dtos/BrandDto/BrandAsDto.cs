using ApiProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public static class BrandAsDto
    {
        public static ReadBrandDto brandtAsDto(this Brand p)
        {

            return new ReadBrandDto
            {
                Identification = p.IdBrand,
                Brand          = p.BrandName,
                Country        = p.Country
                
            };
        }

        public static EditingBrandDto editingAsDto(this Brand b)
        {
            return new EditingBrandDto
            {
                Brand      = b.BrandName,
                Country    = b.Country
            };
        }
    }
}
