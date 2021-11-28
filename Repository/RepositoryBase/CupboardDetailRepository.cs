using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class CupboardDetailRepository : RepositoryBase<CupBoardDetail>, ICupboardDetailRepository
    {
        public CupboardDetailRepository(CupboardContext context) : base(context)
        {

        }
    }
}
