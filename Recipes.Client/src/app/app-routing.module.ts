import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: "categories",
    loadChildren: () => import("./categories/categories.module").then(m => m.CategoriesModule)
  },
  {
    path: "recipes",
    loadChildren: () => import("./recipes/recipes.module").then(m => m.RecipesModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
