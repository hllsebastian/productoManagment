using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    [Table("ShoppingList")]
    public partial class ShoppingList
    {
        public ShoppingList()
        {
            UserXshoppingLists = new HashSet<UserXshoppingList>();
        }

        [Key]
        [Column("idShopping")]
        [StringLength(50)]
        public Guid IdShopping { get; set; }
        [Column("idProduct")]
        [StringLength(50)]
        public Guid IdProduct { get; set; }
        [Column("amount")]
        public int? Amount { get; set; }
        [Column("value_", TypeName = "decimal(18, 0)")]
        public decimal? Value { get; set; }
        [Column("expirationDate", TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

        [ForeignKey(nameof(IdProduct))]
        [InverseProperty(nameof(Product.ShoppingLists))]
        public virtual Product IdProductNavigation { get; set; }
        [InverseProperty(nameof(UserXshoppingList.IdShoppingNavigation))]
        public virtual ICollection<UserXshoppingList> UserXshoppingLists { get; set; }
    }
}
