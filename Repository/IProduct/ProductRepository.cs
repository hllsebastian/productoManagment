using ApiProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ProductsManagmentContext _context;
        public ProductRepository(ProductsManagmentContext context)
        {
            this._context = context;
        }

        // Post
        public void CreateProduct(Product p)
        {
            try
            {
                _context.Products.Add(p);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating Producto" + ex.ToString());
            }
        }

        // Delete
        public void DeleteProduct(int id)
        {
            try
            {
                var p = GetProduct(id);
                if (p != null)
                {
                    _context.Products.Remove(p);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading Product" + ex.ToString()); ;
            }
        }

        // Get{id}
        public Product GetProduct(int id)
        {
            try
            {
                var p = _context.Products.FirstOrDefault(p => p.IdProduct == id);
                return p;
            }
            catch (Exception ex)
            {

                throw new Exception("Error reading Product" + ex.ToString());
            }
        }

        // Get
        public IEnumerable<Product> GetProducts()
        {

            try
            {
                return _context.Products.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error reading Products" + ex.ToString());
            }
        }

        // Put
        public void UpdateProduct(Product p)
        {
            throw new NotImplementedException();
        }
    }

}

