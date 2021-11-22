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
        //public Product()
        //{
        //    CategoriesXproducts = new HashSet<CategoriesXproduct>();
        //    CupBoardDetails = new HashSet<CupBoardDetail>();
        //    ShoppingLists = new HashSet<ShoppingList>();
        //}

        [Key]
        [Column("idProduct")]
        [StringLength(50)]
        public Guid IdProduct { get; set; }

        [Column("idMark")]
        [StringLength(50)]
        public Guid IdMark { get; set; }

        [Column("nameProduct")]
        [StringLength(100)]
        public string NameProduct { get; set; }

        [Column("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [Column("barCode")]
        [StringLength(300)]
        public string BarCode { get; set; }

        //[ForeignKey(nameof(IdMark))]
        //[InverseProperty(nameof(Trademark.Products))]
        public  Trademark IdMarkNavigation { get; set; }
        //[InverseProperty(nameof(CategoriesXproduct.IdProductNavigation))]
        public ICollection<CategoriesXproduct> CategoriesXproducts { get; set; }
        //[InverseProperty(nameof(CupBoardDetail.IdProductNavigation))]
        public  ICollection<CupBoardDetail> CupBoardDetails { get; set; }
        //[InverseProperty(nameof(ShoppingList.IdProductNavigation))]
        public  ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
