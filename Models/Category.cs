using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.Models
{
    [Table("Category")]
    [Index(nameof(CategoryName), Name = "UQ__Category__8517B2E04074083C", IsUnique = true)]
    public partial class Category
    {
        [Key]
        public int Id { get; set; }
        [Column("IdProduct_Ct")]
        public int IdProductCt { get; set; }
        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }
        public bool? Refrigerated { get; set; }
        public bool? Perishable { get; set; }

        [ForeignKey(nameof(IdProductCt))]
        [InverseProperty(nameof(Product.Categories))]
        public virtual Product IdProductCtNavigation { get; set; }
    }
}
