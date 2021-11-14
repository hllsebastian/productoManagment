using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services.InterfaceServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
        CategoryDto GetCategory(Guid id);
        Task<CategoryDto> CreateCategory(EditingCategoryDto category);
        Task<EditingCategoryDto> UploadCategory(Guid id, EditingCategoryDto category);
        Task<CategoryDto> DeleteCategory(Guid id);
    }
}
