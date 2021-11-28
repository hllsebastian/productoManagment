using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services.InterfaceServices
{
    public interface ICupboardDetailService
    {
        IEnumerable<CupboardDetailDto> GetCupboardDetails();
        CupboardDetailDto GetCupboardDetail(Guid id);
        Task<CupboardDetailPutDto> UploadCupboardDetail(Guid id, CupboardDetailPutDto cupboardDetailDto);
        Task<CupboardDetailPutDto> DeleteCupboardDetail(Guid id);
    }
}
