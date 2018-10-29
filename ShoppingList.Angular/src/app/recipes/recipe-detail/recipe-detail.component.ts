import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { Recipe } from '../recipe.model';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css']
})
export class RecipeDetailComponent implements OnInit {
  recipe = new Recipe();

  constructor(private recipeService: RecipeService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.recipeService.getRecipe(params['id']).subscribe(recipe => {
        this.recipe = recipe;
      });
    });

    this.recipeService.recipeUpdated.subscribe(updatedRecipe => {
      this.recipe = updatedRecipe;
    });
  }

  onAddToShoppingList(): void {
    // TODO: Logic
  }

  onRecipeEdit() {
    this.router.navigate(['edit'], { relativeTo: this.route });
  }

  onRecipeDelete() {
    this.recipeService.deleteRecipe(this.recipe.id).subscribe(() => {
      this.router.navigate(['/recipes']);
    });
  }
}
