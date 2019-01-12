using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Business.Helpers;
using RecipeBook.Business.Implementation.Ingredients.Helpers;
using RecipeBook.Database;

namespace RecipeBook.Api.Extensions
{
    public static class ShoppingListDependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IIngredientHelper, IngredientHelper>();

            services.AddDbContext<IShoppingListDbContext, ShoppingListDbContext>(
                opts => opts.UseSqlServer(configuration.GetConnectionString("ShoppingListDB"),
                    b => b.MigrationsAssembly(typeof(IShoppingListDbContext).Namespace))
            );

            return services;
        }
    }
}
