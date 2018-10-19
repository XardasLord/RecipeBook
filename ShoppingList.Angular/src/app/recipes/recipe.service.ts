import { Injectable } from '@angular/core';
import { Recipe } from './recipe.model';
import { Ingredient } from '../shared/ingredient.model';
import { ShoppingListService } from '../shopping-list/shopping-list.service';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  recipesChanged = new Subject<Recipe[]>();

  private recipes: Recipe[] = [
    new Recipe(
      'Naleśniki',
      'Dla dwóch osób',
      'https://static.smaker.pl/photos/b/b/1/bb12c4f1be32ea8632028d3f402f421f_89088_59312e3b656aa_wm.jpg',
      [
        new Ingredient('Jajka'),
        new Ingredient('Mąka')
      ]),
    new Recipe(
      'Jajecznica',
      'Dla jednej osoby',
      'https://www.zajadam.pl/wp-content/uploads/2015/11/jajecznica-3-2-891x500.jpg',
      [
        new Ingredient('Jajka'),
        new Ingredient('Masło'),
        new Ingredient('Sól')
      ])
  ];

  constructor(private shoppingListService: ShoppingListService) { }

  getRecipes(): Recipe[] {
    return this.recipes.slice();
  }

  getRecipe(index: number): Recipe {
    return this.recipes[index];
  }

  addIngredientsToShoppingList(ingredients: Ingredient[]): void {
    this.shoppingListService.addIngredients(ingredients);
  }

  addRecipe(recipe: Recipe) {
    this.recipes.push(recipe);
    this.notifyRecipesChanged();
  }

  updateRecipe(index: number, newRecipe: Recipe) {
    this.recipes[index] = newRecipe;
    this.notifyRecipesChanged();
  }

  deleteRecipe(index: number) {
    this.recipes.splice(index, 1);
    this.notifyRecipesChanged();
  }

  private notifyRecipesChanged() {
    this.recipesChanged.next(this.recipes.slice());
  }
}
