
using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CupBoard, CupboardDto>().ReverseMap();
            CreateMap<CreateCupBoardDetailDto, CupBoard>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, EditingProductDto>().ReverseMap();


            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, EditingCategoryDto>().ReverseMap();
            
            CreateMap<Trademark, TrademarkDto>().ReverseMap();
            CreateMap<Trademark, EditingTrademarkDto>().ReverseMap();

            CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
            CreateMap<ShoppingList, EditingShoppingListDto>().ReverseMap();



        }
    }
}
