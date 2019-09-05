import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RecipesRoutingModule } from './recipes-routing.module';
import { RecipeComponent } from './recipe/recipe.component';
import { RecipeContainerComponent } from './recipe-container/recipe-container.component';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { ReactiveFormsModule } from "@angular/forms";
import { NgSelectModule } from "@ng-select/ng-select";

@NgModule({
  declarations: [RecipeComponent, RecipeContainerComponent, RecipeListComponent],
  imports: [
    CommonModule,
    NgSelectModule,
    ReactiveFormsModule,
    RecipesRoutingModule
  ]
})
export class RecipesModule { }
