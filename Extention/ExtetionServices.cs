using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Repository.RepositoryBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Extention
{
    public static class ExtetionServices
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<Product>), typeof(RepositoryBase<Product>));
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddScoped(typeof(IRepositoryBase<Category>), typeof(RepositoryBase<Category>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }


    }
}
