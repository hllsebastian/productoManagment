using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    public partial class User
    {
        public User()
        {
            UserXcupBoards = new HashSet<UserXcupBoard>();
            UserXshoppingLists = new HashSet<UserXshoppingList>();
        }

        [Key]
        [Column("idUser")]
        [StringLength(50)]
        public Guid IdUser { get; set; }

        [InverseProperty(nameof(UserXcupBoard.IdUserNavigation))]
        public virtual ICollection<UserXcupBoard> UserXcupBoards { get; set; }
        [InverseProperty(nameof(UserXshoppingList.IdUserNavigation))]
        public virtual ICollection<UserXshoppingList> UserXshoppingLists { get; set; }
    }
}
