using ApiProductManagment.ModelsUpdate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.CategoryRepository
{
    public class CategoryRepository : Icategory
    {
        private readonly CupboardContext _context;

        public CategoryRepository(CupboardContext context)
        {
            _context = context;
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
                throw new Exception("Error creating Category" + ex.ToString());
            }
        }

        // Delete
        public void DeleteCategory(Guid id)
        {
            try
            {
                var c = _context.Categories.FirstOrDefault(c => c.IdCategory == id);
                if (c != null)
                {
                    _context.Remove(c);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error deleting Category" + ex.ToString());
            }
        }

        // Get{id}
        public Category GetCategory(Guid id)
        {
            try
            {
                var c = _context.Categories.FirstOrDefault(c => c.IdCategory== id);
                return c;
                // return _context.Products.Where(p => p.IdProduct == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading Product" + ex.ToString()); ;
            }
        }


        //Get
        public IEnumerable<Category> Getcategories()
        {
            try
            {
                return _context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading Categories" + ex.ToString());
            }
        }



        // Put
        public async Task<ActionResult<Category>> UpdateCategory(Category c)
        {
            try
            {
                _context.Categories.Update(c);
                _context.SaveChanges();
                return c;
            }
            catch (Exception ex)
            {

                throw new Exception("Error updating Category" + ex.ToString());
            }
        }


    }

}

