using ApiProductManagment.Models;
using System.Collections.Generic;

namespace ApiProductManagment.Repository
{
    public interface ICategory
    {
        void CreateCategory(Category c);
        void DeleteCategory(int id);
        Category GetCategor(int id);
        IEnumerable<Category> GetCategory();
        void UpdateProduct(Category p);


    }
}