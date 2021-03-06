import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';

import { Recipe } from './recipe.model';
import { Ingredient } from '../ingredients/ingredient.model';
import { ShoppingListService } from '../shopping-list/shopping-list.service';
import { environment } from '../../environments/environment';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  recipesChanged = new Subject<Recipe>();
  recipeUpdated = new Subject<Recipe>();
  recipeDeleted = new Subject<string>();

  constructor(private shoppingListService: ShoppingListService,
              private http: HttpClient) { }

  getRecipes(): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`${API_URL}/recipes`);
  }

  getRecipe(id: string): Observable<Recipe> {
    return this.http.get<Recipe>(`${API_URL}/recipes/${id}`);
  }

  addRecipe(recipe: Recipe): Observable<string> {
    return this.http.post<string>(`${API_URL}/recipes`, recipe);
  }

  updateRecipe(newRecipe: Recipe): Observable<Recipe> {
    return this.http.put<Recipe>(`${API_URL}/recipes/${newRecipe.id}`, newRecipe);
  }

  deleteRecipe(id: string) {
    return this.http.delete(`${API_URL}/recipes/${id}`);
  }

  addIngredientsToShoppingList(ingredients: Ingredient[]): void {
    this.shoppingListService.addIngredients(ingredients);
  }
}
