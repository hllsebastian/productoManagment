using ApiProductManagment.ModelsUpdate;
using System;
using System.Collections.Generic;

namespace ApiProductManagment.Repository.ProductRepository
{
    public interface IProductRepository
    {
        void CreateProduct(Product p);

        void DeleteProduct(Guid id);

        Product GetProduct(Guid id);

        IEnumerable<Product> GetProducts();

        void UpdateProduct(Product p);

    }
}