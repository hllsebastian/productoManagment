using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _repository;
        private readonly IMapper _mapper;

        public ShoppingListService(IShoppingListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ShoppingListDto> GetShoppingLists()
        {
            var shoppingListsDb = _repository.Queries();
            var shoppingListsDto = _mapper.Map<IEnumerable<ShoppingListDto>>(shoppingListsDb);
            return shoppingListsDto;
        }

        public ShoppingListDto GetShoppingList(Guid id)
        {
            var shoppingListDb = _repository.QueryById(s => s.IdShopping== id);
            if (shoppingListDb != null)
            {
                return _mapper.Map<ShoppingListDto>(shoppingListDb);
            }
            throw new Exception("Error reading shopping List");
        }

        public async Task<ShoppingListDto> CreateShoppingList(EditingShoppingListDto shoppingList)
        {
            var ShoppingListDb = _mapper.Map<ShoppingList>(shoppingList);
            await _repository.Create(ShoppingListDb);
            var response = _mapper.Map<ShoppingListDto>(ShoppingListDb);
            return response;
            }

        public async Task<EditingShoppingListDto> UploadShoppingList(Guid id, EditingShoppingListDto shoppingList)
        {
            var shoppingListDb = _repository.QueryById(s => s.IdShopping == id);
            if (shoppingListDb != null)
            {
                // Si la propiedad va nula
                shoppingListDb.IdProduct = shoppingList.IdProduct;
                shoppingListDb.Amount = shoppingList.Amount ?? shoppingListDb.Amount;
                shoppingListDb.Value = shoppingList.Value ?? shoppingListDb.Value;
                shoppingListDb.ExpirationDate = shoppingList.ExpirationDate ?? shoppingListDb.ExpirationDate;
                
                await _repository.Upload(shoppingListDb);
                var response = _mapper.Map<EditingShoppingListDto>(shoppingListDb);
                return response;
            }
            throw new Exception("Error editing ShoppingList");
        }


        public async Task<ShoppingListDto> DeleteShoppingList(Guid id)
        {
            var shoppingListDB = _repository.QueryById(s => s.IdShopping == id);
            if (shoppingListDB != null)
            {
                await _repository.Delete(shoppingListDB);
                var response = _mapper.Map<ShoppingListDto>(shoppingListDB);
                return response;
            }
            else
            {
            throw new Exception("Error editing Category");
            }
        }      
    }
}
