import { EventEmitter } from '@angular/core';
import { Recipe } from './recipe.model';
import { Ingredient } from '../shared/ingredient.model';

export class RecipeService {
  recipeSelected = new EventEmitter<Recipe>();

  private recipes: Recipe[] = [
    new Recipe(
      'Naleśniki',
      'Dla dwóch osób',
      'https://static.smaker.pl/photos/b/b/1/bb12c4f1be32ea8632028d3f402f421f_89088_59312e3b656aa_wm.jpg',
      [
        new Ingredient('Jajka', 2),
        new Ingredient('Mąka', 1)
      ]),
    new Recipe(
      'Jajecznica',
      'Dla jednej osoby',
      'https://www.zajadam.pl/wp-content/uploads/2015/11/jajecznica-3-2-891x500.jpg',
      [
        new Ingredient('Jajka', 4),
        new Ingredient('Masło', 1),
        new Ingredient('Sól', 1)
      ])
  ];

  getRecipes(): Recipe[] {
    return this.recipes.slice();
  }
}
