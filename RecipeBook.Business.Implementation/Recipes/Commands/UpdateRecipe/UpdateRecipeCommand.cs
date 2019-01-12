using System;
using System.Collections.Generic;
using MediatR;
using RecipeBook.Business.Models;

namespace RecipeBook.Business.Implementation.Recipes.Commands.UpdateRecipe
{
    public class UpdateRecipeCommand : IRequest<RecipeModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public IEnumerable<RecipePartModel> RecipeParts { get; set; }
    }
}
