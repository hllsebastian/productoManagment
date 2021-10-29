using ApiProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public static class ProductAsDto
    {
        public static ReadProductDto productAsDto(this Product p)
        {

            return new ReadProductDto
            {
                Identification = p.IdProduct,
                Name           = p.ProductName,
                Price          = p.Price,
                Expiration     = p.ExpirationDate,
                Sku            = p.Sku
            };
        }

        public static EditingProductDto editingAsDto(this Product p)
        {
            return new EditingProductDto
            {
                Name       = p.ProductName,
                Price      = p.Price,
                Expiration = p.ExpirationDate,
                Sku        = p.Sku
            };
        }
    }
}
