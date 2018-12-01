import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { Ingredient } from '../shared/ingredient.model';
import { IngredientService } from '../shared/services/ingredient.service';

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.css']
})
export class IngredientsComponent implements OnInit {
  ingredients: Ingredient[] = [];

  constructor(private ingredientService: IngredientService,
              private toasrtService: ToastrService) { }

  ngOnInit() {
    this.ingredientService.getAll().subscribe(ingredients => {
      this.ingredients = ingredients;
    });

    this.ingredientService.ingredientsChanged.subscribe(newIngredient => {
      this.ingredients.push(newIngredient);

      this.sortIngredientsByName();
      this.showSuccess(newIngredient);
    });
  }

  private sortIngredientsByName() {
    this.ingredients.sort((a, b) => a.name.localeCompare(b.name));
  }

  private showSuccess(ingredient: Ingredient) {
    this.toasrtService.success(`${ingredient.name} has been added!`, 'New ingredient');
  }
}
