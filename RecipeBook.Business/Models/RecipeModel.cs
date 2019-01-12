using System;
using System.Collections.Generic;

namespace RecipeBook.Business.Models
{
    public class RecipeModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public IEnumerable<RecipePartModel> RecipeParts { get; set; }
    }
}