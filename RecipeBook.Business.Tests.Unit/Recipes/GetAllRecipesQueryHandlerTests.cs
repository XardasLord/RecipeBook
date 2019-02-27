using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using RecipeBook.Business.Implementation.Recipes.Queries.GetAllRecipes;
using RecipeBook.Business.Models;
using RecipeBook.Database;
using RecipeBook.Entities;

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

        [Test]
        public async Task GetAllRecipesQueryHandler_WithValidQuery_ReturnListOfRecipesTypeAsync()
        {
            var query = new GetAllRecipesQuery();
            var recipes = new List<Recipe>();
            var recipesMock = recipes.AsQueryable().BuildMockDbSet();

            _context.Setup(x => x.Recipes).Returns(recipesMock.Object);
            _mapper.Setup(x => x.Map<IEnumerable<RecipeModel>>(It.IsAny<IEnumerable<Recipe>>()))
                .Returns(new List<RecipeModel>());

            var result = await Act(query);

            result.Should().BeOfType<List<RecipeModel>>();
        }
    }
}
