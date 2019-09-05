import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../shared/recipe.service';
import { Observable } from 'rxjs';
import { RecipeDto } from '../shared/recipe-dto.model';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.scss']
})
export class RecipeListComponent implements OnInit {
  private recipeService: RecipeService;
  private recipes$: Observable<RecipeDto[]>;

  constructor(recipeService: RecipeService) {
    this.recipeService = recipeService;
  }

  ngOnInit() {
    this.recipes$ = this.recipeService.listRecipes();
  }

}
