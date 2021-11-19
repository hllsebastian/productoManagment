using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    public  class Product
    {
        public Product()
        {
            CategoriesXproducts = new HashSet<CategoriesXproduct>();
            CupBoardDetails = new HashSet<CupBoardDetail>();
            ShoppingLists = new HashSet<ShoppingList>();
        }

        [Key]
        [Column("idProduct")]
        [StringLength(50)]
        public Guid IdProduct { get; set; }
        [StringLength(50)]
        public Guid IdMark { get; set; }
        [StringLength(100)]
        public string NameProduct { get; set; }
        [Column("expirationDate")]
        public DateTime? ExpirationDate { get; set; }
        [Column("barCode")]
        [StringLength(300)]
        public string BarCode { get; set; }

        //[ForeignKey(nameof(IdMark))]
        //[InverseProperty(nameof(Trademark.Products))]
        public virtual Trademark IdMarkNavigation { get; set; }
        [InverseProperty(nameof(CategoriesXproduct.IdProductNavigation))]
        public virtual ICollection<CategoriesXproduct> CategoriesXproducts { get; set; }
        [InverseProperty(nameof(CupBoardDetail.IdProductNavigation))]
        public virtual ICollection<CupBoardDetail> CupBoardDetails { get; set; }
        [InverseProperty(nameof(ShoppingList.IdProductNavigation))]
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
