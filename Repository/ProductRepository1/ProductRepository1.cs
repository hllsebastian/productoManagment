using ApiProductManagment.ModelsUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.ProductRepository
{
    public class ProductRepository1 : IProductRepository
    {
        private readonly CupboardContext _context;

        public ProductRepository1(CupboardContext context)
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
        public void DeleteProduct(Guid id) 
        {
            try
            {
                var p = _context.Products.FirstOrDefault(p => p.IdProduct == id);
                if ( p != null)
                {
                    _context.Remove(p);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error reading Product" + ex.ToString());
            }
        }
        
        // Get{id}
        public Product GetProduct(Guid id) 
        {
            try
            {
                //var p = _context.Products.FirstOrDefault(p => p.IdProduct == id);
                //return p;
                return _context.Products.Where(p => p.IdProduct == id).SingleOrDefault();

            }
            catch (Exception ex)
            {

                throw new Exception("Error reading Product" + ex.ToString()); ;
            }
        }


        //Get
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
            try
            {
                _context.Products.Update(p);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Product" + ex.ToString());
            }
            
        }


    }

    


}
