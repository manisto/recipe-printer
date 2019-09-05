import { CategoryDto } from 'src/app/categories/shared/category-dto.model';

export class RecipeDto {
    id: number;
    name: string;
    categories: CategoryDto[];
    ingredients: string;
    preparation: string;
}