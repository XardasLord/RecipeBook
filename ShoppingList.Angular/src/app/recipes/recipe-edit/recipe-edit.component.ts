import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { RecipeService } from '../recipe.service';
import { Recipe } from '../recipe.model';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit {
  recipeOnForm = new Recipe('', '', '', []); // TODO: To fix...
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
    const recipeParts = new FormArray([]);

    if (this.editMode) {
      this.recipeService.getRecipe(this.id).subscribe(recipe => {

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

        this.recipeForm.controls['id'].setValue(recipe.id);
        this.recipeForm.controls['name'].setValue(recipe.name);
        this.recipeForm.controls['imageUrl'].setValue(recipe.imageUrl);
        this.recipeForm.controls['description'].setValue(recipe.description);
        console.log(this.recipeForm);
      });
    }

    this.recipeForm = new FormGroup({
      'id': new FormControl(this.recipeOnForm.id),
      'name': new FormControl(this.recipeOnForm.name, Validators.required),
      'imageUrl': new FormControl(this.recipeOnForm.imageUrl, Validators.required),
      'description': new FormControl(this.recipeOnForm.description, Validators.required),
      'recipeParts': recipeParts
    });
  }

}
