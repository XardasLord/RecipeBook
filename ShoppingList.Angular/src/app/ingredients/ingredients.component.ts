import { Component, OnInit } from '@angular/core';

import { Ingredient } from '../shared/ingredient.model';
import { IngredientService } from '../shared/services/ingredient.service';

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.css']
})
export class IngredientsComponent implements OnInit {
  ingredients: Ingredient[] = [];

  constructor(private ingredientService: IngredientService) { }

  ngOnInit() {
    this.ingredientService.getAll().subscribe(ingredients => {
      this.ingredients = ingredients;
    });

    this.ingredientService.ingredientsChanged.subscribe(newIngredient => {
      this.ingredients.push(newIngredient);
    });
  }
}
