using AutoMapper;
using ShoppingList.Business.Models;
using ShoppingList.Entities;

namespace ShoppingList.Api.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Ingredients, IngredientModel>().ReverseMap();
            CreateMap<Recipes, RecipeModel>().ReverseMap();
        }
    }
}
