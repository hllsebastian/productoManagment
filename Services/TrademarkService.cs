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


        public IEnumerable<TrademarkDto> GetTrademarks()
        {
            var trademarks = _repository.Queries();
            var trademarksDto = _mapper.Map<IEnumerable<TrademarkDto>>(trademarks);
            return trademarksDto;
        }


        public TrademarkDto GetTrademark(Guid id)
        {
            var trademarkdb = _repository.QueryById(c => c.IdTrademark == id);
            if (trademarkdb != null)
            {
                return _mapper.Map<TrademarkDto>(trademarkdb);
            }
            throw new Exception("Error reading Trademark");
        }


        public async Task<TrademarkDto> CreateTrademark(EditingTrademarkDto trademark)
        {
            var newtrademark = _mapper.Map<Trademark>(trademark);
            await _repository.Create(newtrademark);
            var response = _mapper.Map<TrademarkDto>(newtrademark);
            return response;
        }


        public async Task<EditingTrademarkDto> UploadTrademark(Guid id, EditingTrademarkDto trademark)
        {
            var trademarkdb = _repository.QueryById(t => t.IdTrademark == id);
            if (trademarkdb != null)
            {
                trademarkdb.Mark = trademark.Mark;
                // var uptrademark = _mapper.Map<Trademark>(trademark);
                await _repository.Upload(trademarkdb);
                var response = _mapper.Map<EditingTrademarkDto>(trademarkdb);
                return response;
            }
            else
            {
                throw new Exception("Error editing Trademark");
            }
        }


        public async Task<TrademarkDto> DeleteTrademark(Guid id)
        {
            var trademarkDb = _repository.QueryById(t => t.IdTrademark == id);
            if (trademarkDb != null)
            {
               await _repository.Delete(trademarkDb);
                var response = _mapper.Map<TrademarkDto>(trademarkDb);
                return response;
            }
            else
            {
                throw new Exception("Error deleting Trademark");
            }
        }
    }
}