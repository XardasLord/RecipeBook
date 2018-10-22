import { Ingredient } from './ingredient.model';

export class RecipePart {
    id: string;
    ingredient: Ingredient;
    unit: string;
    quantity: number;

    constructor(ingredient: Ingredient, unit: string, quantity: number) {
        this.ingredient = ingredient;
        this.unit = unit;
        this.quantity = quantity;
    }
}
