using ApiProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos.CategoryDto
{
    public static class CategoryAsDto
    {
        public static ReadCategoryDto categoryAsDto(this Category c) 
        {
            return new ReadCategoryDto
            {
                Identification = c.Id,
                ProductID      = c.IdProductCt,
                Category       = c.CategoryName,
                Refrigerated   = c.Refrigerated,
                Perishable     = c.Perishable
            };
        }

        public static EditingCategoryDto editingCategoryDto(this Category c)
        {
            return new EditingCategoryDto
            {
                Category     = c.CategoryName,
                Refrigerated = (bool)c.Refrigerated,
                Perishable   = (bool)c.Perishable
            };
        }
    }
}
