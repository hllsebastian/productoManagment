using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository 
    {
        private readonly IMapper _mapper;
        public CupboardContext CupboardContext { get; set; }

        public CategoryRepository(CupboardContext context, IMapper mapper) : base(context)
        {
            CupboardContext = context;
            _mapper = mapper;
        }

    }
}
