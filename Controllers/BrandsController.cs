using ApiProductManagment.Dtos;
using ApiProductManagment.Models;
using ApiProductManagment.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProductManagment.Controllers
{
    [Route("brand")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        private readonly IBrand _repository;
        public BrandsController(IBrand respository)
        {
            this._repository = respository;
        }


        // GET: api/<BrandsController>
        [HttpGet]
        public IEnumerable<ReadBrandDto> Get()
        {
            var brand = _repository.GetBrands().Select(p => p.brandtAsDto());
            return brand;
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public ActionResult<ReadBrandDto> Get(int id)
        {
            var b = _repository.GetBrand(id).brandtAsDto();
            if (b is null)
            {
                return NotFound();
            }
            return b;
        }

        // POST api/<BrandsController>
        [HttpPost]
        public ActionResult<EditingBrandDto> Post(EditingBrandDto b)
        {
            Brand newb = new Brand
            {
                BrandName = b.Brand,
                Country   = b.Country,
            };
            _repository.CreateBrand(newb);
            return newb.editingAsDto();
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public ActionResult<ReadBrandDto> Delete(int id)
        {
            Brand b = _repository.GetBrand(id);
            if (b is null)
            {
                return NotFound();
            }
            _repository.DeleteBrand(id);
            return NoContent();
        }
    }
}
