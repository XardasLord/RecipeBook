using AutoMapper;
using ShoppingList.Business.Models;
using ShoppingList.Entities;

namespace ShoppingList.Api.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Ingredient, IngredientModel>().ReverseMap();
            CreateMap<Recipe, RecipeModel>().ReverseMap();
            CreateMap<RecipePart, RecipePartModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
