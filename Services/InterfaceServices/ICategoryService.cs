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
        Task<IEnumerable<CategoryDto>> GetCategories();
        CategoryDto GetCategory(Guid id);
        Task<CategoryDto> CreateCategory(EditingCategoryDto category);
        Task<CategoryDto> UploadCategory(EditingCategoryDto category);
        Task<ProductDto> DeleteCategory(Guid id);
    }
}
