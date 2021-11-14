using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services.InterfaceServices
{
    public interface ITrademarkService
    {
        Task<IEnumerable<TrademarkDto>> GetTrademarks();
        TrademarkDto GetTrademark(Guid id);
        Task<TrademarkDto> CreateTrademark(EditingTrademarkDto Trademark);
        Task<TrademarkDto> UploadTrademark(EditingTrademarkDto Trademark);
        Task<TrademarkDto> DeleteTrademark(Guid id);
    }
}
