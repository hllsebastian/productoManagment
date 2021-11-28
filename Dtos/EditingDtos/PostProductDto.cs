using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos.EditingDtos
{
    public class PostProductDto
    {
        public Guid IdMark { get; set; }

        public string NameProduct { get; set; }

        //public DateTime? ExpirationDate { get; set; }

        public string BarCode { get; set; }
    }
}
