using ApiProductManagment.ModelsUpdate;
using System;
using System.Collections.Generic;

namespace ApiProductManagment.Repository.CategoryRepository
{
    public interface Icategory
    {
        void CreateCategory(Category c);
        void DeleteCategory(Guid id);
        Category GetCategory(Guid id);
        IEnumerable<Category> Getcategories();
        public void UpdateCategory(Category c);

    }
}