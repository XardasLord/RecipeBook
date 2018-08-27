import { Ingredient } from '../shared/ingredient.model';

export class ShoppingListService {
  private ingredients: Ingredient[] = [
    new Ingredient('mleko', 1),
    new Ingredient('jajko', 3),
    new Ingredient('mąka', 1.25)
  ];

  getIngredients(): Ingredient[] {
    return this.ingredients;
  }

  addIngredient(ingredient: Ingredient): void {
    this.ingredients.push(ingredient);
  }
}
