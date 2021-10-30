using ApiProductManagment.Dtos.CategoryDto;
using ApiProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ProductsManagmentContext _context;
        public CategoryRepository(ProductsManagmentContext context)
        {
            this._context = context;
        }

        // Post
        public void CreateCategory(Category c)
        {
            try
            {
                _context.Categories.Add(c);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating category" + ex.ToString());
            }
        }

        // Put
        public void DeleteCategory(int id)
        {
            try
            {
                var c = GetCategory(id);
                if (c != null )
                {
                    _context.Categories.Remove(c);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

      

        // Get{id}
        public Category GetCategory(int id)
        {
            try
            {
                var p = _context.Categories.Find(id);
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading category" + ex.ToString());
            }
        }

   
        // Put
        public void UpdateProduct(Category p)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Category> GetCategories()
        {
            try
            {
                return _context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Reading categories" + ex.ToString());
            }
        }
    }
}
