import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ingredient } from '../ingredient.model';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {
  ingredientsChanged = new Subject<Ingredient>();

  constructor(private http: HttpClient) { }

  getAll(): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>(`https://localhost:44373/api/ingredients`);
  }

  add(ingredient: Ingredient): Observable<Ingredient> {
    return this.http.post<Ingredient>(`https://localhost:44373/api/ingredients`, ingredient);
  }
}
