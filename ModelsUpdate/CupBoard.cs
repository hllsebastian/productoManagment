using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    public partial class CupBoard
    {
        public CupBoard()
        {
            CupBoardDetails = new HashSet<CupBoardDetail>();
            UserXcupBoards = new HashSet<UserXcupBoard>();
        }

        [Key]
        [Column("idCupBoard")]
        [StringLength(50)]
        public Guid IdCupBoard { get; set; }
        [Column("nameCupBoard")]
        [StringLength(50)]
        public string NameCupBoard { get; set; }
        [Column("isDefault")]
        public bool? IsDefault { get; set; }
        [Column("creationDate", TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [InverseProperty(nameof(CupBoardDetail.IdCupBoardNavigation))]
        public virtual ICollection<CupBoardDetail> CupBoardDetails { get; set; }
        [InverseProperty(nameof(UserXcupBoard.IdCupBoardNavigation))]
        public virtual ICollection<UserXcupBoard> UserXcupBoards { get; set; }
    }
}
