﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public class ProductDto
    {
        public Guid IdProduct { get; set; }

        public Guid IdMark { get; set; }

        public string Product { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string BarCode { get; set; }
    }
}
