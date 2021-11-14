using ApiProductManagment.ModelsUpdate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.CategoryRepository
{
    public interface Icategory
    {
        void CreateCategory(Category c);
        void DeleteCategory(Guid id);
        Category GetCategory(Guid id);
        IEnumerable<Category> Getcategories();
        Task <ActionResult<Category>> UpdateCategory(Category c);

    }
}