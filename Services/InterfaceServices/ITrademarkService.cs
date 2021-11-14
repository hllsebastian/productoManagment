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
        IEnumerable<TrademarkDto> GetTrademarks();
        TrademarkDto GetTrademark(Guid id);
        Task<TrademarkDto> CreateTrademark(EditingTrademarkDto trademark);
        Task<EditingTrademarkDto> UploadTrademark(Guid id, EditingTrademarkDto trademark);
        Task<TrademarkDto> DeleteTrademark(Guid id);
    }
}
