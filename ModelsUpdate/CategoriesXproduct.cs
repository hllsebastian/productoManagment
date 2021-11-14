using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    [Table("CategoriesXProduct")]
    public partial class CategoriesXproduct
    {
        [Key]
        [Column("idCategoryXProduct")]
        [StringLength(50)]
        public Guid IdCategoryXproduct { get; set; }
        [Column("idCategory")]
        [StringLength(50)]
        public Guid IdCategory { get; set; }
        [Column("idProduct")]
        [StringLength(50)]
        public Guid IdProduct { get; set; }

        [ForeignKey(nameof(IdCategory))]
        [InverseProperty(nameof(Category.CategoriesXproducts))]
        public virtual Category IdCategoryNavigation { get; set; }
        [ForeignKey(nameof(IdProduct))]
        [InverseProperty(nameof(Product.CategoriesXproducts))]
        public virtual Product IdProductNavigation { get; set; }
    }
}
