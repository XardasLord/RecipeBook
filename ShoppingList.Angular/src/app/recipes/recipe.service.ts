import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';

import { Recipe } from './recipe.model';
import { Ingredient } from '../shared/ingredient.model';
import { ShoppingListService } from '../shopping-list/shopping-list.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  recipesChanged = new Subject<Recipe>();
  recipeUpdated = new Subject<Recipe>();

  constructor(private shoppingListService: ShoppingListService,
              private http: HttpClient) { }

  getRecipes(): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`https://localhost:44373/api/recipes`);
  }

  getRecipe(id: string): Observable<Recipe> {
    return this.http.get<Recipe>(`https://localhost:44373/api/recipes/${id}`);
  }

  addRecipe(recipe: Recipe): Observable<Recipe> {
    return this.http.post<Recipe>(`https://localhost:44373/api/recipes`, recipe);
  }

  updateRecipe(newRecipe: Recipe): Observable<Recipe> {
    return this.http.put<Recipe>(`https://localhost:44373/api/recipes`, newRecipe);
  }

  deleteRecipe(id: string) {
    return this.http.delete(`https://localhost:44373/api/recipes/${id}`);
  }

  addIngredientsToShoppingList(ingredients: Ingredient[]): void {
    this.shoppingListService.addIngredients(ingredients);
  }
}
