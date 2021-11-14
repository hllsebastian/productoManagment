using ApiProductManagment.Dtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        public CupboardContext CupboardContext { get; set; }

        public ProductRepository(CupboardContext context, IMapper mapper) : base (context)
        {
            CupboardContext = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> ConsultData(ProductDto product)
        {
            var products = await CupboardContext.Products.ToListAsync();

            if (product.Name != null)
            {
                products = products.Where(x => x.NameProduct.ToLower().Contains(product.Name.ToLower())).ToList();
            }
            return products;

            //if (product.Id != null)
            //{
            //    products = products.Where(x => x.IdProduct.ToLower().Contains(product.Id.ToLower())).ToList();
            //}
        }
    }
}
