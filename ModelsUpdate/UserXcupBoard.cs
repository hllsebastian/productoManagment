using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    [Table("UserXCupBoard")]
    public partial class UserXcupBoard
    {
        [Key]
        [Column("idUserXCupboard")]
        [StringLength(50)]
        public Guid IdUserXcupboard { get; set; }
        [Column("idUser")]
        [StringLength(50)]
        public Guid IdUser { get; set; }
        [Column("idCupBoard")]
        [StringLength(50)]
        public Guid IdCupBoard { get; set; }

        [ForeignKey(nameof(IdCupBoard))]
        [InverseProperty(nameof(CupBoard.UserXcupBoards))]
        public virtual CupBoard IdCupBoardNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.UserXcupBoards))]
        public virtual User IdUserNavigation { get; set; }
    }
}
