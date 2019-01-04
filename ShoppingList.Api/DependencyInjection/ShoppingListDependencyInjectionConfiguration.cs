using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingList.Business;
using ShoppingList.Business.Helpers;
using ShoppingList.Business.Implementation.Helpers;
using ShoppingList.Business.Implementation.Queries;
using ShoppingList.Business.Implementation.Services;
using ShoppingList.Business.Queries;
using ShoppingList.Business.Services;
using ShoppingList.Database;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShoppingListDependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IIngredientQuery, IngredientQuery>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IIngredientHelper, IngredientHelper>();
            services.AddTransient<IRecipeQuery, RecipeQuery>();
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IAuthenticateService, AuthenticateService>();

            services.AddDbContext<IShoppingListDbContext, ShoppingListDbContext>(
                opts => opts.UseSqlServer(configuration.GetConnectionString("ShoppingListDB"),
                    b => b.MigrationsAssembly(typeof(IShoppingListDbContext).Namespace))
            );

            return services;
        }
    }
}
