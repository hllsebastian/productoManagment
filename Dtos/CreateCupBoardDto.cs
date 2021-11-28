using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiProductManagment.Dtos
{
    public class CreateCupBoardDto
    {
        public string NameCupBoard { get; set; }
        public bool? IsDefault { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreationDate { get; set; }

        public List<CreateCupBoardDetailDto> CupBoardDetails { get; set; }     
    }
}
