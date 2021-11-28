using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupboardDetailsController : ControllerBase
    {
        private readonly ICupboardDetailService _cupboardDetailService;
        private readonly IMapper _mapper;

        public CupboardDetailsController(ICupboardDetailService service, IMapper mapper)
        {
            _cupboardDetailService = service;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var cupboardDetailsDto = _cupboardDetailService.GetCupboardDetails();
            return Ok(cupboardDetailsDto);
        }


        [HttpGet("{id}")]
        public ActionResult<CupboardDetailDto> GetCupboardDetail(Guid id)
        {
            return _cupboardDetailService.GetCupboardDetail(id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, CupboardDetailPutDto cupboardDetailDto)
        {
            var resultDto = await _cupboardDetailService.UploadCupboardDetail(id, cupboardDetailDto);
            return Ok(resultDto);
        }


        /*[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _cupboardDetailService.DeleteCupboardDetail(id);
            return Ok(response);
        }*/

    }
}
