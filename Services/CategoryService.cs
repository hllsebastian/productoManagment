using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = _repository.Queries();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesDto;
        }

        public CategoryDto GetCategory(Guid id)
        {
            var category = _repository.QueryById(c => c.IdCategory == id);
            if (category != null)
            {
                return _mapper.Map<CategoryDto>(category);
            }
            throw new Exception("Error reading Category");
        }

        public async Task<CategoryDto> CreateCategory(EditingCategoryDto category)
        {
            var newcategory = _mapper.Map<Category>(category);
            await _repository.Create(newcategory);
            var response = _mapper.Map<CategoryDto>(newcategory);
            return response; 
        }

        public async Task<CategoryDto> UploadCategory(EditingCategoryDto category)
        {
            //var idcategory = _repository.QueryById(c => c.IdCategory == id);
            //if (idcategory == null)
            //{
            //    throw new Exception("Error editing Category");
            //}
            var upCategory = _mapper.Map<Category>(category);
            await _repository.Upload(upCategory);
            var response = _mapper.Map<CategoryDto>(upCategory);
            return response;
        }

        public Task<ProductDto> DeleteCategory(Guid id)
        {
            var idcategory = _repository.QueryById(c => c.IdCategory == id);
            if (idcategory != null)
            {
                _repository.Delete(idcategory);
            }
            throw new Exception("Error editing Category");
        }
    }
}
