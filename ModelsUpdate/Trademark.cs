using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    public class Trademark
    {
        //public Trademark()
        //{
        //    Products = new HashSet<Product>();
        //}

        [Key]
        [Column("idTrademark")]
        [StringLength(50)]
        public Guid IdTrademark { get; set; }
        [Column("mark")]
        [StringLength(100)]
        public string Mark { get; set; }

        //[InverseProperty(nameof(Product.IdMarkNavigation))]
        public ICollection<Product> Products { get; set; }
    }
}
