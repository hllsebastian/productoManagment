using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.Models
{
    [Table("Brand")]
    [Index(nameof(BrandName), Name = "UQ__Brand__2206CE9BD0A887C4", IsUnique = true)]
    public partial class Brand
    {
        [Key]
        public int IdBrand { get; set; }    
        [Required]
        [StringLength(30)]
        public string BrandName { get; set; }
        [Required]
        [StringLength(20)]
        public string Country { get; set; }
    }
}
