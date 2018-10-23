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
  id: string;
  recipe = new Recipe('', '', '', []); // TODO: To fix

  constructor(private recipeService: RecipeService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];

      this.recipeService.getRecipe(this.id).subscribe(recipe => {
        this.recipe = recipe;
      });
    });
  }

  onAddToShoppingList(): void {
    // this.recipeService.addIngredientsToShoppingList(this.recipe.ingredients);
  }

  onRecipeEdit() {
    this.router.navigate(['edit'], { relativeTo: this.route });
  }

  onRecipeDelete() {
    this.recipeService.deleteRecipe(this.id).subscribe(() => {
      this.router.navigate(['/recipes']);
    });
  }
}
