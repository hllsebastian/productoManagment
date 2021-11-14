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
    public class TrademarksController : ControllerBase
    {

        private readonly ITrademarkService _trademarkService;
        private readonly IMapper _mapper;

        public TrademarksController(ITrademarkService trademarkservice, IMapper mapper)
        {
            _trademarkService = trademarkservice;
            _mapper = mapper;
        }


        // GET: api/<TrademarksController>
        [HttpGet]
        public ActionResult<TrademarkDto> Get()
        {
            var trademarks = _trademarkService.GetTrademarks();
            return Ok(trademarks);
        }

        // GET api/<TrademarksController>/5
        [HttpGet("{id}")]
        public ActionResult<TrademarkDto> GetCategory(Guid id)
        {
            return _trademarkService.GetTrademark(id);
            //var idcategory = _categoryService.GetCategory(id);
            //return idcategory;
        }

        // POST api/<TrademarksController>
        [HttpPost]
        public ActionResult<CategoryDto> Post(EditingTrademarkDto t)
        {
            var newtrademark = _trademarkService.CreateTrademark(t);
            return Ok(newtrademark);
        }

        // PUT api/<TrademarksController>/5
        [HttpPut("{id}")]
        public ActionResult<TrademarkDto>Put(Guid id, EditingTrademarkDto t)
        {
            var idtrademark = GetCategory(id);
            if (idtrademark == null)
            {
                var trademark = _trademarkService.UploadTrademark(t);
                return Ok(trademark);
            }
            throw new Exception("Error editing Category");
        }

        // DELETE api/<TrademarksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _trademarkService.DeleteTrademark(id);
            return NoContent();
        }
    }
}
