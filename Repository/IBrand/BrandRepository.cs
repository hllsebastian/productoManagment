using ApiProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository
{
    public class BrandRepository : IBrand
    {
        private readonly ProductsManagmentContext _context;
        public BrandRepository(ProductsManagmentContext context)
        {
            this._context = context;
        }

        // Post
        public void CreateBrand(Brand b)
        {
            try
            {
                _context.Brands.Add(b);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating Producto" + ex.ToString());
            }
        }

        // Delete
        public void DeleteBrand(int id)
        {
            try
            {
                var b = GetBrand(id);
                if (b != null)
                {
                    _context.Brands.Remove(b);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading Product" + ex.ToString()); ;
            }
        }

        // Get{id}
        public Brand GetBrand(int id)
        {
            try
            {
                var b = _context.Brands.FirstOrDefault(b => b.IdBrand == id);
                return b;
            }
            catch (Exception ex)
            {

                throw new Exception("Error reading Product" + ex.ToString());
            }
        }

        // Get
        public IEnumerable<Brand> GetBrands()
        {

            try
            {
                return _context.Brands.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error reading Products" + ex.ToString());
            }
        }

        // Put
        public void UpdateBrand(Brand b)
        {
            throw new NotImplementedException();
        }
    }

}

