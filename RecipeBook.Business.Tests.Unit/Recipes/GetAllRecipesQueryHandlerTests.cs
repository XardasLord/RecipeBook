using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RecipeBook.Business.Implementation.Recipes.Queries.GetAllRecipes;
using RecipeBook.Business.Models;
using RecipeBook.Database;

namespace RecipeBook.Business.Tests.Unit.Recipes
{
    [TestFixture]
    public class GetAllRecipesQueryHandlerTests
    {
        private Mock<IShoppingListDbContext> _context;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _context = new Mock<IShoppingListDbContext>(MockBehavior.Strict);
            _mapper = new Mock<IMapper>(MockBehavior.Strict);
        }

        private async Task<IEnumerable<RecipeModel>> Act(GetAllRecipesQuery query)
        {
            return await new GetAllRecipesQueryHandler(_context.Object, _mapper.Object)
                .Handle(query);
        }

        [Test]
        public void GetAllRecipesQueryHandler_WithNullQuery_ThrowArgumentNullException()
        {
            GetAllRecipesQuery query = null;

            Func<Task> result = async () => await Act(query);

            result.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
