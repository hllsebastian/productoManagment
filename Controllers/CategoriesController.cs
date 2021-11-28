using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {


        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryservice, IMapper mapper)
        {
            _categoryService = categoryservice;
            _mapper = mapper;
        }


        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            var categories =  _categoryService.GetCategories();
            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(Guid id)
        {
            return _categoryService.GetCategory(id);
            //var idcategory = _categoryService.GetC<ategory(id);
            //return idcategory;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post(EditingCategoryDto category)
        {
            var resultcategory = await _categoryService.CreateCategory(category);
            return Ok(resultcategory);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, EditingCategoryDto category)
        {
            var categoryresult = await _categoryService.UploadCategory(id, category);
            return Ok(categoryresult);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _categoryService.DeleteCategory(id);
            return Ok(response);
        }
    }
}
