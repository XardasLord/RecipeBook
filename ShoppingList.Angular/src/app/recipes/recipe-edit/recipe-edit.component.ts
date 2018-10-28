import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { RecipeService } from '../recipe.service';
import { Recipe } from '../recipe.model';
import { Ingredient } from 'src/app/shared/ingredient.model';
import { IngredientService } from 'src/app/shared/services/ingredient.service';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit {
  activeRecipe = new Recipe();
  ingredients: Ingredient[] = [];
  selectedIngredient: Ingredient;
  id: string;
  editMode = false;
  recipeForm: FormGroup;

  get recipeParts(): FormArray {
    return <FormArray>this.recipeForm.get('recipeParts');
  }

  constructor(private route: ActivatedRoute,
              private router: Router,
              private recipeService: RecipeService,
              private ingredientService: IngredientService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
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
        console.log(updatedRecipe);
        this.recipeService.recipeUpdated.next(updatedRecipe);
      });
    } else {
      this.recipeService.addRecipe(this.recipeForm.value).subscribe(createdRecipe => {
        this.recipeService.recipesChanged.next(createdRecipe);
      });
    }

    this.onCancel();
  }

  onAddIngredient() {
    this.recipeParts.push(
      new FormGroup({
        id: new FormControl(null),
        ingredient: new FormGroup({
          id: new FormControl(this.selectedIngredient.id),
          name: new FormControl(this.selectedIngredient.name, Validators.required),
        }),
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
      this.recipeService.getRecipe(this.id).subscribe(recipe => {

        recipe.recipeParts.forEach(recipePart => {
          recipeParts.push(
            new FormGroup({
              id: new FormControl(recipePart.id),
              ingredient: new FormGroup({
                id: new FormControl(recipePart.ingredient.id),
                name: new FormControl(recipePart.ingredient.name, Validators.required),
              }),
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
