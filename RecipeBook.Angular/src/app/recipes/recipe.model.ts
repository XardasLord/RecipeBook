import { RecipePart } from './recipe-part.model';

export class Recipe {
    id: string;
    name: string;
    description: string;
    imageUrl: string;
    author: string;
    recipeParts: RecipePart[];

    constructor();
    // tslint:disable-next-line:unified-signatures
    constructor(name?: string, desc?: string, imageUrl?: string, author?: string, recipeParts?: RecipePart[]);
    constructor(name?: string, desc?: string, imageUrl?: string, author?: string, recipeParts?: RecipePart[]) {
        this.name = name;
        this.description = desc;
        this.imageUrl = imageUrl;
        this.author = author;
        this.recipeParts = recipeParts;
    }
}
