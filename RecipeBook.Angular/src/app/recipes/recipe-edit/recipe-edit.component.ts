import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { IngredientService } from '../../ingredients/ingredient.service';
import { RecipeService } from '../recipe.service';
import { RecipePart } from '../recipe-part.model';
import { Ingredient } from '../../ingredients/ingredient.model';
import { Recipe } from '../recipe.model';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit {
  activeRecipe = new Recipe();
  ingredients: Ingredient[] = [];
  selectedIngredient: Ingredient;
  recipeId: string;
  editMode = false;
  ingredientNotSelected = false;
  ingredientAlreadyAdded = false;
  recipeForm: FormGroup;

  get recipeParts(): FormArray {
    return <FormArray>this.recipeForm.get('recipeParts');
  }

  constructor(private route: ActivatedRoute,
              private router: Router,
              private recipeService: RecipeService,
              private ingredientService: IngredientService,
              private toastrService: ToastrService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.recipeId = params['id'];
      this.editMode = params['id'] != null;
      this.initForm();
    });

    this.ingredientService.getAll().subscribe(ingredients => {
      this.ingredients = ingredients;
    });
  }

  onSubmit() {
    if (this.editMode) {
      this.recipeService.updateRecipe(this.recipeForm.value).subscribe(updatedRecipe => {
        this.recipeService.recipeUpdated.next(updatedRecipe);
      });
    } else {
      this.recipeService.addRecipe(this.recipeForm.value).subscribe(createdId => {
        this.recipeForm.controls['id'].setValue(createdId);

        this.recipeService.recipesChanged.next(this.recipeForm.value);
        this.toastrService.success(`${this.recipeForm.value.name} recipe has been added!`, `New recipe`);
      });
    }

    this.onCancel();
  }

  onAddIngredient() {
    if (!this.selectedIngredient) {
      this.ingredientNotSelected = true;
      this.ingredientAlreadyAdded = false;
      return;
    }

    if (this.checkIfIngredientAlreadyAdded(this.selectedIngredient)) {
      this.ingredientAlreadyAdded = true;
      this.ingredientNotSelected = false;
      return;
    }

    this.addIngredient(this.selectedIngredient);

    this.selectedIngredient = null;
    this.ingredientNotSelected = false;
    this.ingredientAlreadyAdded = false;
  }

  private checkIfIngredientAlreadyAdded(ingredient: Ingredient): boolean {
    let alreadyAdded = false;

    this.recipeParts.value.forEach((existingRecipePart: RecipePart) => {
      if (existingRecipePart.ingredient.id === ingredient.id) {
        alreadyAdded = true;
      }
    });

    return alreadyAdded;
  }

  private addIngredient(ingredientToAdd: Ingredient) {
    this.recipeParts.push(
      new FormGroup({
        id: new FormControl(null),
        ingredient: new FormGroup({
          id: new FormControl(this.selectedIngredient.id),
          name: new FormControl(this.selectedIngredient.name, Validators.required),
        }),
        unit: new FormControl(null, Validators.required),
        quantity: new FormControl(null, [
          Validators.required,
          Validators.pattern(/^[1-9]+[0-9]*$/)
        ])
      })
    );
  }

  onDeleteIngredient(index: number) {
    this.recipeParts.removeAt(index);
  }

  onSelectIngredient(ingredient: Ingredient) {
    this.selectedIngredient = ingredient;
  }

  onCancel() {
    this.router.navigate(['../'], { relativeTo: this.route });
  }

  private initForm() {
    const recipeParts = new FormArray([]);

    if (this.editMode) {
      this.recipeService.getRecipe(this.recipeId).subscribe(recipe => {

        recipe.recipeParts.forEach(recipePart => {
          recipeParts.push(
            new FormGroup({
              id: new FormControl(recipePart.id),
              ingredient: new FormGroup({
                id: new FormControl(recipePart.ingredient.id),
                name: new FormControl(recipePart.ingredient.name, Validators.required),
              }),
              unit: new FormControl(recipePart.unit, Validators.required),
              quantity: new FormControl(recipePart.quantity, [
                Validators.required,
                Validators.pattern(/^[1-9]+[0-9]*$/)
              ])
            })
          );
        });

        this.recipeForm.controls['id'].setValue(recipe.id);
        this.recipeForm.controls['name'].setValue(recipe.name);
        this.recipeForm.controls['imageUrl'].setValue(recipe.imageUrl);
        this.recipeForm.controls['description'].setValue(recipe.description);
      });
    }

    this.recipeForm = new FormGroup({
      id: new FormControl(this.activeRecipe.id),
      name: new FormControl(this.activeRecipe.name, Validators.required),
      imageUrl: new FormControl(this.activeRecipe.imageUrl, Validators.required),
      description: new FormControl(this.activeRecipe.description, Validators.required),
      recipeParts: recipeParts
    });
  }

}
