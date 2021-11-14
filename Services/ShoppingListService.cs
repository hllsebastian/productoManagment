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

        public async Task<IEnumerable<ShoppingListDto>> GetShoppingLists()
        {
            var shoppingLists = _repository.Queries();
            var shoppingListsDto = _mapper.Map<IEnumerable<ShoppingListDto>>(shoppingLists);
            return shoppingListsDto;
        }

        public ShoppingListDto GetShoppingList(Guid id)
        {
            var shoppingList = _repository.QueryById(s => s.IdShopping== id);
            if (shoppingList != null)
            {
                return _mapper.Map<ShoppingListDto>(shoppingList);
            }
            throw new Exception("Error reading Category");
        }

        public async Task<ShoppingListDto> CreateShoppingList(EditingShoppingListDto shoppingList)
        {
            var newShoppingList = _mapper.Map<ShoppingList>(shoppingList);
            await _repository.Create(newShoppingList);
            var response = _mapper.Map<ShoppingListDto>(newShoppingList);
            return response;
            }

        public async Task<ShoppingListDto> UploadShoppingList(EditingShoppingListDto shoppingList)
        {
            if (shoppingList != null)
            {
                var upshoppingList = _mapper.Map<ShoppingList>(shoppingList);
                await _repository.Upload(upshoppingList);
                var response = _mapper.Map<ShoppingListDto>(upshoppingList);
                return response;
            }
            throw new Exception("Error editing Category");
        }


        public Task<ShoppingListDto> DeleteShoppingList(Guid id)
        {
            var idshoppingList = _repository.QueryById(s => s.IdShopping == id);
            if (idshoppingList != null)
            {
                _repository.Delete(idshoppingList);
            }
            throw new Exception("Error editing Category");
        }      
    }
}
