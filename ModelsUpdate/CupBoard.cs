using System;
using System.Collections.Generic;

namespace ApiProductManagment.ModelsUpdate
{
    public class CupBoard
    {
        public Guid IdCupBoard { get; set; }
        public string NameCupBoard { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreationDate { get; set; }

        public  ICollection<CupBoardDetail> CupBoardDetails { get; set; }    
        public ICollection<UserXcupBoard> UserXcupBoards { get; set; }
    }
}
