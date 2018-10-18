﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingList.Database;

namespace ShoppingList.Database.Migrations
{
    [DbContext(typeof(ShoppingListDbContext))]
    partial class ShoppingListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingList.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("ShoppingList.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("ShoppingList.Entities.RecipePart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<Guid?>("IngredientId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<decimal>("Quantity");

                    b.Property<Guid?>("RecipeId");

                    b.Property<string>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeParts");
                });

            modelBuilder.Entity("ShoppingList.Entities.RecipePart", b =>
                {
                    b.HasOne("ShoppingList.Entities.Ingredient", "Ingredient")
                        .WithMany("RecipeParts")
                        .HasForeignKey("IngredientId");

                    b.HasOne("ShoppingList.Entities.Recipe", "Recipe")
                        .WithMany("RecipeParts")
                        .HasForeignKey("RecipeId");
                });
#pragma warning restore 612, 618
        }
    }
}
