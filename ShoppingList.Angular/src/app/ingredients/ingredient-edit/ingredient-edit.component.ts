import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IngredientService } from '../../shared/services/ingredient.service';
import { Ingredient } from '../../shared/ingredient.model';

@Component({
  selector: 'app-ingredient-edit',
  templateUrl: './ingredient-edit.component.html',
  styleUrls: ['./ingredient-edit.component.css']
})
export class IngredientEditComponent implements OnInit {
  @ViewChild('f') ingredientForm: NgForm;

  constructor(private ingredientService: IngredientService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    const newIngredient = new Ingredient(form.value.name);

    this.ingredientService.add(newIngredient).subscribe(() => {
      // TODO: Information about succesfull ingredient add
      // ...
      this.ingredientService.ingredientsChanged.next(newIngredient);
      this.ingredientForm.reset();
    });

  }

}
