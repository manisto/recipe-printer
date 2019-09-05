import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { RecipeContainerComponent } from './recipe-container/recipe-container.component';
import { PrintRecipeContainerComponent } from './print-recipe-container/print-recipe-container.component';


const routes: Routes = [
  {
    path: "recipes",
    children: [
      {
        path: "",
        component: RecipeListComponent
      },
      {
        path: "new",
        component: RecipeContainerComponent
      },
      {
        path: "edit/:recipeId",
        component: RecipeContainerComponent
      },
      {
        path: "print/:recipeId",
        component: PrintRecipeContainerComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecipesRoutingModule { }
