import { RecipePart } from '../shared/recipe-part.model';

export class Recipe {
    id: string;
    name: string;
    description: string;
    imageUrl: string;
    recipeParts: RecipePart[];

    constructor(name: string, desc: string, imageUrl: string, recipeParts: RecipePart[]) {
        this.name = name;
        this.description = desc;
        this.imageUrl = imageUrl;
        this.recipeParts = recipeParts;
    }
}
