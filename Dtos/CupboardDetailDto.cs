using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public class CupboardDetailDto
    {
        public Guid IdCupboardDeatail { get; set; }
        public Guid IdCupBoard { get; set; }
        public Guid IdProduct { get; set; }
        public int? Amount { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
