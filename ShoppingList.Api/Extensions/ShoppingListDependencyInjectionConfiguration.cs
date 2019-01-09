using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Business.Helpers;
using ShoppingList.Business.Implementation.Authentications.Helpers;
using ShoppingList.Business.Implementation.Ingredients.Helpers;
using ShoppingList.Database;

namespace ShoppingList.Api.Extensions
{
    public static class ShoppingListDependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IIngredientHelper, IngredientHelper>();
            services.AddTransient<IAuthenticateHelper, AuthenticateHelper>();

            services.AddDbContext<IShoppingListDbContext, ShoppingListDbContext>(
                opts => opts.UseSqlServer(configuration.GetConnectionString("ShoppingListDB"),
                    b => b.MigrationsAssembly(typeof(IShoppingListDbContext).Namespace))
            );

            return services;
        }
    }
}
