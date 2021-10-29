using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.Models
{
    [Table("Cupboard")]
    [Index(nameof(SectiontName), Name = "UQ__Cupboard__B7789ED58D700E80", IsUnique = true)]
    public partial class Cupboard
    {
        [Key]
        public int IdCupboard { get; set; }
        [Column("IdProduct_Cb")]
        public int IdProductCb { get; set; }
        [Required]
        [StringLength(30)]
        public string SectiontName { get; set; }
        public int ProductInput { get; set; }
        public int ProductOutput { get; set; }

        [ForeignKey(nameof(IdProductCb))]
        [InverseProperty(nameof(Product.Cupboards))]
        public virtual Product IdProductCbNavigation { get; set; }
    }
}
