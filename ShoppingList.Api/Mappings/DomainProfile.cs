using AutoMapper;
using ShoppingList.Business.Implementation.Authentications.Commands.Register;
using ShoppingList.Business.Implementation.Ingredients.Commands.CreateIngredient;
using ShoppingList.Business.Implementation.Recipes.Commands.CreateRecipe;
using ShoppingList.Business.Implementation.Recipes.Commands.UpdateRecipe;
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

            CreateMap<CreateRecipeCommand, Recipe>();
            CreateMap<UpdateRecipeCommand, Recipe>();
            CreateMap<CreateIngredientCommand, Ingredient>();
            CreateMap<RegisterCommand, User>();
        }
    }
}
