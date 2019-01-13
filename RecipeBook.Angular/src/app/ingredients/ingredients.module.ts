import { NgModule } from '@angular/core';
import { IngredientsComponent } from './ingredients.component';
import { IngredientEditComponent } from './ingredient-edit/ingredient-edit.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    IngredientsComponent,
    IngredientEditComponent
  ],
  imports: [
    SharedModule
  ]
})
export class IngredientsModule { }
