using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services
{
    public class TrademarkService : ITrademarkService
    {
        private readonly ITrademarkRepository _repository;
        private readonly IMapper _mapper;

        public TrademarkService(ITrademarkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TrademarkDto>> GetTrademarks()
        {
            var trademarks = _repository.Queries();
            var trademarksDto = _mapper.Map<IEnumerable<TrademarkDto>>(trademarks);
            return trademarksDto;
        }


        public TrademarkDto GetTrademark(Guid id)
        {
            var trademark = _repository.QueryById(c => c.IdTrademark == id);
            if (trademark != null)
            {
                return _mapper.Map<TrademarkDto>(trademark);
            }
            throw new Exception("Error reading Category");
        }


        public async Task<TrademarkDto> CreateTrademark(EditingTrademarkDto trademark)
        {
            var newtrademark = _mapper.Map<Trademark>(trademark);
            await _repository.Create(newtrademark);
            var response = _mapper.Map<TrademarkDto>(newtrademark);
            return response;
        }


        public async Task<TrademarkDto> UploadTrademark(EditingTrademarkDto Trademark)
        {

            if (Trademark == null)
            {
                var uptrademark = _mapper.Map<Trademark>(Trademark);
                await _repository.Upload(uptrademark);
                var response = _mapper.Map<TrademarkDto>(uptrademark);
                return response;
            }
            throw new Exception("Error editing Category");
        }


        public Task<TrademarkDto> DeleteTrademark(Guid id)
        {
            var idTrademark = _repository.QueryById(c => c.IdTrademark == id);
            if (idTrademark != null)
            {
                _repository.Delete(idTrademark);
            }
            throw new Exception("Error editing Category");


        }
    }
}