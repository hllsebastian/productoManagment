using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
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

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products =  _repository.Queries();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>> (products);
            return productsDto;

        }







        public Task<EditingProductDto> CreateProduct(EditingProductDto cliente)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<EditingProductDto> UploadProduct(int id, EditingProductDto cliente)
        {
            throw new NotImplementedException();
        }
    }
}
