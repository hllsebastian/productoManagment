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
    }
}
