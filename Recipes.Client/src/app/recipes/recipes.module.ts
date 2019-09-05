import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RecipesRoutingModule } from './recipes-routing.module';
import { RecipeComponent } from './recipe/recipe.component';
import { RecipeContainerComponent } from './recipe-container/recipe-container.component';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [RecipeComponent, RecipeContainerComponent, RecipeListComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RecipesRoutingModule
  ]
})
export class RecipesModule { }
