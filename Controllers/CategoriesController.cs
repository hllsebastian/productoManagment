using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.CategoryRepository;
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
    [Route("Categories")]
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
        public ActionResult<CategoryDto> Get()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(Guid id)
        {
            return _categoryService.GetCategory(id);
            //var idcategory = _categoryService.GetCategory(id);
            //return idcategory;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult<CategoryDto> Post(EditingCategoryDto c)
        {
            var category = _categoryService.CreateCategory(c);
            return Ok(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult<CategoryDto> Put(Guid id, EditingCategoryDto c)
        {
            var idcategory = GetCategory(id);
            if (idcategory == null)
            {
                throw new Exception("Error editing Category");
            }
            var category = _categoryService.UploadCategory(c);
            return Ok(category);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
