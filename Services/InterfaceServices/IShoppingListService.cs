using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services.InterfaceServices
{
    public interface IShoppingListService
    {
        IEnumerable<ShoppingListDto> GetShoppingLists();
        ShoppingListDto GetShoppingList(Guid id);
        Task<ShoppingListDto> CreateShoppingList(EditingShoppingListDto shoppingList);
        Task<EditingShoppingListDto> UploadShoppingList(Guid id, EditingShoppingListDto shoppingList);
        Task<ShoppingListDto> DeleteShoppingList(Guid id);
    }
}
