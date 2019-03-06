using AutoMapper;
using RecipeBook.Business.Implementation.Authentications.Commands.Register;
using RecipeBook.Business.Implementation.Ingredients.Commands.CreateIngredient;
using RecipeBook.Business.Implementation.Recipes.Commands.CreateRecipe;
using RecipeBook.Business.Implementation.Recipes.Commands.UpdateRecipe;
using RecipeBook.Business.Models;
using RecipeBook.Entities;

namespace RecipeBook.Api.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Ingredient, IngredientModel>().ReverseMap();
            CreateMap<Recipe, RecipeModel>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(x => x.CreatedBy))
                .ReverseMap();
            CreateMap<RecipePartModel, RecipePart>()
                .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(y => y.Ingredient.Id))
                .ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<CreateRecipeCommand, Recipe>();
            CreateMap<UpdateRecipeCommand, Recipe>();
            CreateMap<CreateIngredientCommand, Ingredient>();
            CreateMap<RegisterCommand, User>();
        }
    }
}
