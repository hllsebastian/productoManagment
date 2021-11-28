using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    public class CupBoardDetail
    {
        public Guid IdCupboardDeatail { get; set; }
        public Guid IdCupBoard { get; set; }
        public Guid IdProduct { get; set; }
        public int? Amount { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public  CupBoard CupBoard { get; set; }
        public Product Product { get; set; } 
    }
}
