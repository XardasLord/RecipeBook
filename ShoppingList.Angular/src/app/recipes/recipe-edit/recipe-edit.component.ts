import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit {
  id: string;
  editMode = false;
  recipeForm: FormGroup;

  get recipeParts(): FormArray {
    return <FormArray>this.recipeForm.get('recipeParts');
  }

  constructor(private route: ActivatedRoute,
              private router: Router,
              private recipeService: RecipeService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.editMode = params['id'] != null;
      this.initForm();
    });
  }

  onSubmit() {
    if (this.editMode) {
      this.recipeService.updateRecipe(this.recipeForm.value).subscribe(updatedRecipe => {
        // TODO: Changed updated recipe on the list
        // ...
      });
    } else {
      this.recipeService.addRecipe(this.recipeForm.value).subscribe(createdRecipe => {
        // TODO: Add created recipe to the list
        // ...
      });
    }

    this.onCancel();
  }

  onAddIngredient() {
    this.recipeParts.push(
      new FormGroup({
        'name': new FormControl(null, Validators.required),
        'quantity': new FormControl(null, [
          Validators.required,
          Validators.pattern(/^[1-9]+[0-9]*$/)
        ])
      })
    );
  }

  onDeleteIngredient(index: number) {
    this.recipeParts.removeAt(index);
  }

  onCancel() {
    this.router.navigate(['../'], { relativeTo: this.route });
  }

  private initForm() {
    let recipeName = '';
    let recipeImageUrl = '';
    let recipeDescription = '';
    const recipeParts = new FormArray([]);

    if (this.editMode) {
      this.recipeService.getRecipe(this.id).subscribe(recipe => {
        recipeName = recipe.name;
        recipeImageUrl = recipe.imageUrl;
        recipeDescription = recipe.description;

        if (recipe.recipeParts) {
          recipe.recipeParts.forEach(recipePart => {
            recipeParts.push(
              new FormGroup({
                'name': new FormControl(recipePart.ingredient.name, Validators.required),
                'quantity': new FormControl(recipePart.quantity, [
                  Validators.required,
                  Validators.pattern(/^[1-9]+[0-9]*$/)
                ])
              })
            );
          });
        }
      });
    }

    this.recipeForm = new FormGroup({
      'name': new FormControl(recipeName, Validators.required),
      'imageUrl': new FormControl(recipeImageUrl, Validators.required),
      'description': new FormControl(recipeDescription, Validators.required),
      'recipeParts': recipeParts
    });
  }

}
