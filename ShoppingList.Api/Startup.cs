﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShoppingList.Business;
using ShoppingList.Business.Implementation.Queries;
using ShoppingList.Business.Implementation.Services;
using ShoppingList.Business.Queries;
using ShoppingList.Business.Services;
using ShoppingList.Database;

namespace ShoppingList.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IShoppingListDbContext, ShoppingListDbContext>(
                opts => opts.UseSqlServer(Configuration["ConnectionString:ShoppingListDB"], 
                b => b.MigrationsAssembly("ShoppingList.Database"))
            );

            services.AddTransient<IIngredientQuery, IngredientQuery>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IRecipeQuery, RecipeQuery>();
            services.AddTransient<IRecipeService, RecipeService>();

            services.AddAutoMapper();
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
