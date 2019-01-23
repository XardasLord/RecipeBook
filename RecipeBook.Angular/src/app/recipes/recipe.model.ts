import { RecipePart } from './recipe-part.model';

export class Recipe {
    id: string;
    name: string;
    description: string;
    imageUrl: string;
    author: string;
    createdAt: Date;
    modifiedBy: string;
    modifiedAt: Date;
    recipeParts: RecipePart[];
}
