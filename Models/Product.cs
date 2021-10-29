using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.Models
{
    [Table("Product")]
    [Index(nameof(ProductName), Name = "UQ__Product__DD5A978AF54FC23A", IsUnique = true)]
    public partial class Product
    {
        public Product()
        {
            Categories = new HashSet<Category>();
            Cupboards = new HashSet<Cupboard>();
        }

        [Key]
        public int IdProduct { get; set; }
        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }
        public double Price { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [StringLength(100)]
        public string Sku { get; set; }

        [InverseProperty(nameof(Category.IdProductCtNavigation))]
        public virtual ICollection<Category> Categories { get; set; }
        [InverseProperty(nameof(Cupboard.IdProductCbNavigation))]
        public virtual ICollection<Cupboard> Cupboards { get; set; }
    }
}
