using System;
using System.ComponentModel.DataAnnotations;


namespace ApiProductManagment.Dtos.EditingDtos
{
    public class CupboardDetailPutDto
    {
        public Guid IdProduct { get; set; }
        public int? Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EntryDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ExitDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }
    }
}
