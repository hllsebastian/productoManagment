using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    public partial class Category
    {
        public Category()
        {
            CategoriesXproducts = new HashSet<CategoriesXproduct>();
        }

        [Key]
        [Column("idCategory")]
        [StringLength(50)]
        public Guid IdCategory { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty(nameof(CategoriesXproduct.IdCategoryNavigation))]
        public virtual ICollection<CategoriesXproduct> CategoriesXproducts { get; set; }
    }
}
