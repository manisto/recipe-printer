import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { CategoryDto } from "./category-dto.model";
import { Observable } from "rxjs";
import { SaveCategoryCommand } from './save-category-command.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private readonly BASE_URL = "/api/categories";
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  listCategories(): Observable<CategoryDto[]> {
    return this.http.get<CategoryDto[]>(this.BASE_URL);
  }

  get(id): Observable<CategoryDto> {
    return this.http.get<CategoryDto>(`${this.BASE_URL}/${id}`);
  }

  saveCategory(command: SaveCategoryCommand): Observable<void> {
    return this.http.post<void>(`${this.BASE_URL}`, command);
  }

  prototype(): Observable<CategoryDto> {
    return this.http.get<CategoryDto>(`${this.BASE_URL}/prototype`);
  }
}
