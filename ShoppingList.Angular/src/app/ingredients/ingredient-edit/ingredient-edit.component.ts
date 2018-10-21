import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { IngredientService } from '../../shared/services/ingredient.service';
import { Ingredient } from '../../shared/ingredient.model';

@Component({
  selector: 'app-ingredient-edit',
  templateUrl: './ingredient-edit.component.html',
  styleUrls: ['./ingredient-edit.component.css']
})
export class IngredientEditComponent implements OnInit {
  ingredientForm: FormGroup;

  constructor(private ingredientService: IngredientService) { }

  ngOnInit() {
    this.initForm();
  }

  private initForm() {
    this.ingredientForm = new FormGroup({
      'name': new FormControl(null, Validators.required)
    });
  }

  onSubmit() {
    const ingredientToAdd = new Ingredient(this.ingredientForm.value['name']);

    this.ingredientService.add(ingredientToAdd).subscribe(newIngredient => {
      // TODO: Information about successful ingredient add
      // ...
      this.ingredientService.ingredientsChanged.next(newIngredient);
      this.ingredientForm.reset();
    });
  }
}
