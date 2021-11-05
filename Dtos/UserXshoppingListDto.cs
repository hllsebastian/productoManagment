using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public class UserXshoppingListDto
    {
        public Guid IdUserXshopping { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdShopping { get; set; }
    }
}
