using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services
{
    public class CupboardDetailService : ICupboardDetailService
    {
        private readonly ICupboardDetailRepository _repository;
        private readonly IMapper _mapper;

        public CupboardDetailService(ICupboardDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public IEnumerable<CupboardDetailDto> GetCupboardDetails()
        {
            var CupboardDetailDb = _repository.Queries();
            var CupboardDetailDto = _mapper.Map<IEnumerable<CupboardDetailDto>>(CupboardDetailDb);
            return CupboardDetailDto;
        }

        public CupboardDetailDto GetCupboardDetail(Guid id)
        {
            var CupboardDetailDb = _repository.QueryById(x => x.IdCupBoard == id);
            if (CupboardDetailDb != null)
            {
                return _mapper.Map<CupboardDetailDto>(CupboardDetailDb);
            }
            throw new Exception("Error reading Cupboard Detail"); ;
        }

        public async Task<CupboardDetailPutDto> UploadCupboardDetail(Guid id, CupboardDetailPutDto cupboardDetailDto)
        {
            var CupboardDetailDb = _repository.QueryById(x => x.IdProduct == id);
            if (CupboardDetailDb != null)
            {
                //CupboardDetailDb.IdProduct = CupboardDetailPutDto.IdProduct;
                // var upCategory = _mapper.Map<Category>(category);
                await _repository.Upload(CupboardDetailDb);
                var response = _mapper.Map<CupboardDetailPutDto>(CupboardDetailDb);
                return response;
            }
            else
            {
                throw new Exception("Error editing Cupboard Detail");
            }
        }


        public async Task<CupboardDetailPutDto> DeleteCupboardDetail(Guid id)
        {
            var CupboardDetailDb = _repository.QueryById(x => x.IdProduct == id);
            if (CupboardDetailDb != null)
            {
                await _repository.Delete(CupboardDetailDb);
                var response = _mapper.Map<CupboardDetailPutDto>(CupboardDetailDb);
                return response;
            }
            else
            {
                throw new Exception("Error deleting Cupboard Detail");
            }
        }

    }
}
