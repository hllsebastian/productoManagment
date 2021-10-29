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

        public void CreateCategory(Category c)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategor(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategory()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Category p)
        {
            throw new NotImplementedException();
        }
    }
}
