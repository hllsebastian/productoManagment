using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    [Table("CupBoardDetail")]
    public partial class CupBoardDetail
    {
        [Key]
        [Column("idCupboardDeatail")]
        [StringLength(50)]
        public Guid IdCupboardDeatail { get; set; }
        [Column("idCupBoard")]
        [StringLength(50)]
        public Guid IdCupBoard { get; set; }
        [Column("idProduct")]
        [StringLength(50)]
        public Guid IdProduct { get; set; }
        [Column("amount")]
        public int? Amount { get; set; }
        [Column("entryDate", TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [Column("exitDate", TypeName = "datetime")]
        public DateTime? ExitDate { get; set; }
        [Column("expirationDate", TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

        [ForeignKey(nameof(IdCupBoard))]
        [InverseProperty(nameof(CupBoard.CupBoardDetails))]
        public virtual CupBoard IdCupBoardNavigation { get; set; }
        [ForeignKey(nameof(IdProduct))]
        [InverseProperty(nameof(Product.CupBoardDetails))]
        public virtual Product IdProductNavigation { get; set; }
    }
}
