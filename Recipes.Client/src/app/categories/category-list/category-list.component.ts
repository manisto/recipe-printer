import { Component, OnInit } from '@angular/core';
import { CategoryService } from "../shared/category.service";
import { Category } from "../shared/category.model";
import { Observable } from "rxjs";

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {
  private categoryService: CategoryService;
  private categories$: Observable<Category[]>;

  constructor(categoryService: CategoryService) {
    this.categoryService = categoryService;
  }

  ngOnInit() {
    this.categories$ = this.categoryService.listCategories();
  }

}
