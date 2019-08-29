import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryContainerComponent } from './category-container/category-container.component';


const routes: Routes = [
  {
    path: "categories",
    children: [
      {
        path: "",
        component: CategoryListComponent
      },
      {
        path: "new",
        component: CategoryContainerComponent
      },
      {
        path: "edit/:id",
        component: CategoryContainerComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }
