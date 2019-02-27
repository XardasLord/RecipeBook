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

        private async Task<RecipeModel> Act(GetRecipeQuery request)
        {
            return await new GetRecipeQueryHandler(_context.Object, _mapper.Object)
                .Handle(request);
        }

        [Test]
        public void GetRecipeQueryHandler_WithNullRequest_ThrowArgumentNullException()
        {
            GetRecipeQuery request = null;

            Func<Task> result = async () => await Act(request);

            result.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void GetRecipeQueryHandler_WithEmptyIdInRequest_ThrowArgumentException()
        {
            var request = new GetRecipeQuery
            {
                Id = Guid.Empty
            };

            Func<Task> result = async () => await Act(request);

            result.Should().ThrowExactly<ArgumentException>();
        }
    }
}
