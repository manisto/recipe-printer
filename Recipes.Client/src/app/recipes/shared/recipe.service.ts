import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RecipeDto } from './recipe-dto.model';
import { SaveRecipeCommand } from './save-recipe-command.model';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  private readonly BASE_URL = "/api/recipes";
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  listRecipes(): Observable<RecipeDto[]> {
    return this.http.get<RecipeDto[]>(this.BASE_URL);
  }

  get(recipeId: number | string): Observable<RecipeDto> {
    return this.http.get<RecipeDto>(`${this.BASE_URL}/${recipeId}`);
  }

  saveRecipe(command: SaveRecipeCommand): Observable<void> {
    return this.http.post<void>(`${this.BASE_URL}`, command);
  }

  prototype(): Observable<RecipeDto> {
    return this.http.get<RecipeDto>(`${this.BASE_URL}/prototype`);
  }
}
