import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoriesRoutingModule } from './categories-routing.module';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryComponent } from './category/category.component';
import { ReactiveFormsModule } from "@angular/forms";
import { CategoryContainerComponent } from './category-container/category-container.component';

@NgModule({
  declarations: [CategoryListComponent, CategoryComponent, CategoryContainerComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CategoriesRoutingModule
  ]
})
export class CategoriesModule { }
