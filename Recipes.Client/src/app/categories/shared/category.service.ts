import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Category } from "./category.model";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private readonly BASE_URL = "/api/categories";
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  listCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.BASE_URL);
  }

  get(id): Observable<Category> {
    return this.http.get<Category>(`${this.BASE_URL}/${id}`);
  }

  prototype(): Observable<Category> {
    return this.http.get<Category>(`${this.BASE_URL}/prototype`);
  }
}
