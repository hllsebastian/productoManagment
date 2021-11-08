using ApiProductManagment.Dtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.CategoryRepository;
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


        private readonly Icategory _repository;
        private readonly IMapper _mapper;

        public CategoriesController(Icategory repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        {
            var categories = _repository.Getcategories();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto>Get(Guid id)
        {
            var c = _repository.GetCategory(id);
            if (c is null)
            {
                return NotFound();
            }
            return _mapper.Map<CategoryDto>(c);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult<CategoryDto> Post(CategoryDto c)
        {
            var category = _mapper.Map<Category>(c);
            _repository.CreateCategory(category);
            return Ok();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult<CategoryDto>Put(CategoryDto c, Guid id)
        {
            var result = _repository.GetCategory(id);
            if (result is null) return NotFound();
            var newproduct = _mapper.Map<Category>(c);
            _repository.UpdateCategory(newproduct);
            return Ok();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult<CategoryDto> Delete(Guid id)
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
