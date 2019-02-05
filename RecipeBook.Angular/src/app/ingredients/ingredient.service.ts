import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ingredient } from './ingredient.model';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../environments/environment';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class IngredientService {
  ingredientsChanged = new Subject<Ingredient>();

  constructor(private http: HttpClient) { }

  getAll(): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>(`${API_URL}/ingredients`);
  }

  add(ingredient: Ingredient): Observable<Ingredient> {
    return this.http.post<Ingredient>(`${API_URL}/ingredients`, ingredient);
  }
}
