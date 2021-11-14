using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services.InterfaceServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        ProductDto GetProduct(int id);
        Task<EditingProductDto> CreateProduct(EditingProductDto cliente);
        Task<EditingProductDto> UploadProduct(int id, EditingProductDto cliente);
        Task<ProductDto> DeleteProduct(int id);
    }
}
