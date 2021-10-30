using ApiProductManagment.Dtos.CategoryDto;
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
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategory _repository;

        public CategoriesController(ICategory repository)
        {
            _repository = repository;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<ReadCategoryDto> Get()
        {
            var c = _repository.GetCategories().Select(p => p.categoryAsDto());
            return c;         
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult<ReadCategoryDto> Get(int id)
        {
            var c = _repository.GetCategory(id).categoryAsDto();
            if (c is null) { NotFound(); }
            return c;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult<EditingCategoryDto> Post(EditingCategoryDto c)
        {
            Category newC = new Category
            {
                CategoryName = c.Category,
                Refrigerated = c.Refrigerated,
                Perishable = c.Perishable
            };
            _repository.CreateCategory(newC);
            return newC.editingCategoryDto();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult<ReadCategoryDto> Delete(int id)
        {
            Category c = _repository.GetCategory(id);
            if (c is null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(id);
            return NoContent();
        }
    }
}
