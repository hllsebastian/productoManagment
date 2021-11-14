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
        IEnumerable<ProductDto> GetProducts();
        ProductDto GetProduct(Guid id);
        Task<ProductDto> CreateProduct(EditingProductDto product);
        Task<EditingProductDto> UploadProduct(Guid id, EditingProductDto product);
        Task<ProductDto> DeleteProduct(Guid id);
    }
}
