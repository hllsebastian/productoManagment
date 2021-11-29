using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
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
        public IActionResult Get()
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
        public async Task<IActionResult> Post(EditingTrademarkDto trademark)
        {
            var resultrademark = await _trademarkService.CreateTrademark(trademark);
            return Ok(resultrademark);
        }

        // PUT api/<TrademarksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, EditingTrademarkDto trademark)
        {
            var trademarkresult = await _trademarkService.UploadTrademark(id, trademark);
            return Ok(trademarkresult);
        }

        // DELETE api/<TrademarksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _trademarkService.DeleteTrademark(id);
            return Ok(response);
        }
    }
}
