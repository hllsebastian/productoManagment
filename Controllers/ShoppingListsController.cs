using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
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
    public class ShoppingListsController : ControllerBase
    {

        private readonly IShoppingListService _shoppingkService;
        private readonly IMapper _mapper;

        public ShoppingListsController(IShoppingListService shoppingService, IMapper mapper)
        {
            _shoppingkService = shoppingService;
            _mapper = mapper;
        }
       

        // GET: api/<ShoppingListsController>
        [HttpGet]
        public IActionResult Get()
        {
            var shoppingLists = _shoppingkService.GetShoppingLists();
            return Ok(shoppingLists);
        }


        // GET api/<ShoppingListsController>/5
        [HttpGet("{id}")]
        public ActionResult<ShoppingListDto> GetShoppinsList(Guid id)
        {
                return _shoppingkService.GetShoppingList(id);
                //var idcategory = _categoryService.GetCategory(id);
                //return idcategory
        }

        // POST api/<ShoppingListsController>
        [HttpPost]
        public async Task<IActionResult> Post(EditingShoppingListDto shoppingList)
        {
            var shoppingListresult = await _shoppingkService.CreateShoppingList(shoppingList);
            return Ok(shoppingListresult);
        }

        // PUT api/<ShoppingListsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, EditingShoppingListDto shoppingList)
        {
            var shoppingListresult = await _shoppingkService.UploadShoppingList(id, shoppingList);
            return Ok(shoppingListresult); ;
        }

        // DELETE api/<ShoppingListsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _shoppingkService.DeleteShoppingList(id);
            return Ok(response);
        }
    }
}
