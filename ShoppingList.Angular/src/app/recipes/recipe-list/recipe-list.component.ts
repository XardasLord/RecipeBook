import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Recipe } from '../recipe.model';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {
  recipes: Recipe[];

  constructor(private recipeService: RecipeService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.recipeService.recipesChanged.subscribe(createdRecipe => {
      this.recipes.push(createdRecipe);
    });

    this.recipeService.recipeUpdated.subscribe(updatedRecipe => {
      const index = this.recipes.findIndex(x => x.id === updatedRecipe.id);
      this.recipes[index] = updatedRecipe;
    });

    this.recipeService.getRecipes().subscribe(recipes => {
      this.recipes = recipes;
    });
  }

  onNewRecipe() {
    this.router.navigate(['new'], { relativeTo: this.route });
  }

}
