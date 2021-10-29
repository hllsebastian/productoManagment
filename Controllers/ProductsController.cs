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
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProduct _repository;

        public ProductsController(IProduct repository)
        {
            this._repository = repository;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<ReadProductDto> Get()
        {
            var product = _repository.GetProducts().Select(p=> p.productAsDto());
            return product;
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<ReadProductDto> Get(int id)
        {
            var p = _repository.GetProduct(id).productAsDto();
            if (p is null)
            {
                return NotFound();
            }
            return p;
        }


        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<EditingProductDto> Post(EditingProductDto p)
        {
            Product newp = new Product
            {
                ProductName    = p.Name,
                Price          = p.Price,
                ExpirationDate = p.Expiration,
                Sku            = p.Sku,
                
            };
            _repository.CreateProduct(newp);
            return newp.editingAsDto();
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult<ReadProductDto> Delete(int id)
        {
            Product p = _repository.GetProduct(id);
            if (p is null)
            {
                return NotFound();
            }
            _repository.DeleteProduct(id);
            return NoContent();
        }

    }   
}
