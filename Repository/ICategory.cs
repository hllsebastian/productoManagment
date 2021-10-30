using ApiProductManagment.Models;
using System.Collections.Generic;

namespace ApiProductManagment.Repository
{
    public interface ICategory
    {
        void CreateCategory(Category c);
        void DeleteCategory(int id);
        Category GetCategory(int id);
        IEnumerable<Category> GetCategories();
        void UpdateProduct(Category p);


    }
}