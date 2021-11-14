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
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var productsDb =  _repository.Queries();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>> (productsDb);
            return productsDto;
        }

        public ProductDto GetProduct(Guid id)
        {
            var productDb = _repository.QueryById(p => p.IdProduct == id);
            if (productDb != null)
            {
                return _mapper.Map<ProductDto>(productDb);
            }
            throw new Exception("Error reading Product");
        }

        public async Task<ProductDto> CreateProduct(EditingProductDto product)
        {
            var productDb = _mapper.Map<Product>(product);
            await _repository.Create(productDb);
            var response = _mapper.Map<ProductDto>(productDb);
            return response;
        }

        public async Task<EditingProductDto> UploadProduct(Guid id, EditingProductDto product)
        {
            var productDb = _repository.QueryById(p => p.IdProduct == id);
            if (productDb != null)
            {
                productDb.NameProduct = product.Name;
                // var upCategory = _mapper.Map<Category>(category);
                await _repository.Upload(productDb);
                var response = _mapper.Map<EditingProductDto>(productDb);
                return response;
            }
            else
            {
                throw new Exception("Error editing Product");
            }
        }

        public async Task<ProductDto> DeleteProduct(Guid id)
        {
            var productDb = _repository.QueryById(p => p.IdProduct == id);
            if (productDb != null)
            {
                await _repository.Delete(productDb);
                var response = _mapper.Map<ProductDto>(productDb);
                return response;
            }
            else
            {
                throw new Exception("Error deleting Category");
            }
        }
    }
}
