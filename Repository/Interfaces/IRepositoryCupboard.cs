using ApiProductManagment.Dtos;
using ApiProductManagment.ModelsUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.Interfaces
{
    public interface IRepositoryCupboard :  IRepositoryBase<CupBoard>
    {
        public CupBoard CreateCupBoard(CreateCupBoardDto cupboard); 
    }
}
