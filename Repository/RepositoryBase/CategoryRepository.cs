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
        public CategoryRepository(CupboardContext context) : base(context)
        {
        }
    }
}
