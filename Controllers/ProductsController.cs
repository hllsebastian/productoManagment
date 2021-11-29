﻿using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace ApiProductManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
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
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }


        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(Guid id)
        {
            return _productService.GetProduct(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post(PostProductDto product)
        {
            var resultproduct = await _productService.CreateProduct(product);
            return Ok(resultproduct);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PutProductDto product)
        {
            var productresult = await _productService.UploadProduct(id, product);
            return Ok(productresult);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _productService.DeleteProduct(id);
            return Ok(response);
        }
    }
}
