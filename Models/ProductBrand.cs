using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.Models
{
    [Keyless]
    [Table("Product_Brand")]
    public partial class ProductBrand
    {
        [Column("IdProduct_PB")]
        public int IdProductPb { get; set; }
        [Column("IdBrand_PB")]
        public int IdBrandPb { get; set; }

        [ForeignKey(nameof(IdBrandPb))]
        public virtual Brand IdBrandPbNavigation { get; set; }
        [ForeignKey(nameof(IdProductPb))]
        public virtual Product IdProductPbNavigation { get; set; }
    }
}
