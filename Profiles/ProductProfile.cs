using ApiProductManagment.Dtos;
using ApiProductManagment.ModelsUpdate;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Profiles
{
    public class ProductProfile : Profile 
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
