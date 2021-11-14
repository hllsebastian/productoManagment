using ApiProductManagment.Dtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.ProductRepository;
using ApiProductManagment.Services.InterfaceServices;
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

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper     = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<ProductDto>Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }



    //    // GET api/<ProductsController>/5
    //    [HttpGet("{id}")]
    //    public ActionResult<ProductDto> Get(Guid id)
    //    {
    //        var p = _repository.GetProduct(id);
    //        if (p is null)
    //        {
    //            return NotFound();
    //        }
    //        return _mapper.Map<ProductDto>(p);
    //    }

    //    // POST api/<ProductsController>
    //    [HttpPost]
    //    public ActionResult<ProductDto> Post(ProductDto p)
    //    {
    //        var product = _mapper.Map<Product>(p);
    //        _repository.CreateProduct(product);
    //        return Ok();
    //    }

    //    // PUT api/<ProductsController>/5
    //    [HttpPut("{id}")]
    //    public ActionResult<ProductDto> Put(ProductDto product, Guid id)
    //    {
    //        var result = _repository.GetProduct(id);
    //        if (result is null) return NotFound();
    //        var newproduct = _mapper.Map<Product>(product);
    //        _repository.UpdateProduct(newproduct);
    //        return Ok();
    //    }

    //    // DELETE api/<ProductsController>/5
    //    [HttpDelete("{id}")]
    //    public ActionResult<ProductDto> Delete(Guid id)
    //    {
    //        Product p = _repository.GetProduct(id);
    //        if (p is null)
    //        {
    //            return NotFound();
    //        }
    //        _repository.DeleteProduct(id);
    //        return NoContent();
    //    }
    }
}
