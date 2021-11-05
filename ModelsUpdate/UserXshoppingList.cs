using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    [Table("UserXShoppingList")]
    public partial class UserXshoppingList
    {
        [Key]
        [Column("idUserXShopping")]
        [StringLength(50)]
        public Guid IdUserXshopping { get; set; }
        [Column("idUser")]
        [StringLength(50)]
        public Guid IdUser { get; set; }
        [Column("idShopping")]
        [StringLength(50)]
        public Guid IdShopping { get; set; }

        [ForeignKey(nameof(IdShopping))]
        [InverseProperty(nameof(ShoppingList.UserXshoppingLists))]
        public virtual ShoppingList IdShoppingNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.UserXshoppingLists))]
        public virtual User IdUserNavigation { get; set; }
    }
}
