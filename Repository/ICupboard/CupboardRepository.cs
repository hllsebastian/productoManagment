using ApiProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.ICupboard
{
    public class CupboardRepository
    {

        private readonly ProductsManagmentContext _context;

        public CupboardRepository(ProductsManagmentContext context)
        {
            _context = context;
        }

        // Get
        public IEnumerable<Cupboard> GetCupboards()
        {
            try
            {
                return _context.Cupboards.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading cupboards" + ex.ToString());
            }
        }

        // Get{id}
        public Cupboard GetCupboard(int id)
        {
            try
            {
                var p = _context.Cupboards.FirstOrDefault(p => p.IdCupboard == id);
                return p;
            }
            catch (Exception)
            {
                throw new Exception("Error reading cupboards");
            }
        }

        // Post
        public void PostCupboard(Cupboard c)
        {
            try
            {
                _context.Cupboards.Add(c);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating cupboard" + ex.ToString());;
            }
        }

        // Delete
        public void Delete()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

