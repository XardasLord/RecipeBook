import { NgModule } from '@angular/core';
import { IngredientsComponent } from './ingredients.component';
import { IngredientEditComponent } from './ingredient-edit/ingredient-edit.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    IngredientsComponent,
    IngredientEditComponent
  ],
  imports: [
    ReactiveFormsModule,
    SharedModule
  ]
})
export class IngredientsModule { }
