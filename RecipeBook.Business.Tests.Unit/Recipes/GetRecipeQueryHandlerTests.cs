using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RecipeBook.Business.Implementation.Recipes.Queries.GetRecipe;
using RecipeBook.Business.Models;
using RecipeBook.Database;

namespace RecipeBook.Business.Tests.Unit.Recipes
{
    public class GetRecipeQueryHandlerTests
    {
        private Mock<IShoppingListDbContext> _context;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _context = new Mock<IShoppingListDbContext>(MockBehavior.Strict);
            _mapper = new Mock<IMapper>(MockBehavior.Strict);
        }

        private async Task<RecipeModel> Act(GetRecipeQuery query)
        {
            return await new GetRecipeQueryHandler(_context.Object, _mapper.Object)
                .Handle(query);
        }

        [Test]
        public void GetRecipeQueryHandler_WithNullQuery_ThrowArgumentNullException()
        {
            GetRecipeQuery query = null;

            Func<Task> result = async () => await Act(query);

            result.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
