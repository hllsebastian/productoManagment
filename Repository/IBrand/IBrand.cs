using ApiProductManagment.Models;
using System.Collections.Generic;

namespace ApiProductManagment.Repository
{
    public interface IBrand
    {
        void CreateBrand(Brand b);
        void DeleteBrand(int id);
        Brand GetBrand(int id);
        IEnumerable<Brand> GetBrands();
        void UpdateBrand(Brand b);


    }
}