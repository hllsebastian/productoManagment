using ApiProductManagment.Dtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.ProductRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProductManagment.Controllers
{
    [Route("Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper     = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            //IEnumerable<Product> products = new List<Product>();
            var products = _repository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }



        // GET api/<ProductsController>/5
        //[HttpGet("{id}")]
        //public string Get(Guid id)
        //{
        //    var p = _repository.GetProduct(id);
        //    if (p is null)
        //    {
               
        //    }
        //    return _mapper.Map(p);
        //}

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
