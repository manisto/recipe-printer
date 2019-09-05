import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { RecipeService } from '../shared/recipe.service';
import { Observable } from 'rxjs';
import { RecipeDto } from '../shared/recipe-dto.model';
import { switchMap, map } from 'rxjs/operators';
import { SaveRecipeCommand } from '../shared/save-recipe-command.model';

@Component({
  selector: 'app-recipe-container',
  templateUrl: './recipe-container.component.html',
  styleUrls: ['./recipe-container.component.scss']
})
export class RecipeContainerComponent implements OnInit {
  private route: ActivatedRoute;
  private recipeService: RecipeService;
  private router: Router;
  private recipe$: Observable<RecipeDto>;

  constructor(
    route: ActivatedRoute,
    recipeService: RecipeService,
    router: Router
  ) {
    this.route = route;
    this.recipeService = recipeService;
    this.router = router;
  }

  ngOnInit() {
    this.recipe$ = this.route.paramMap
      .pipe(map((params: ParamMap) => params.get("recipeId")))
      .pipe(
        switchMap((recipeId: string) =>
          recipeId ? this.recipeService.get(recipeId) : this.recipeService.prototype()
        )
      );
  }

  private backToList(): void {
    this.router.navigateByUrl("/recipes");
  }

  private save(dto: RecipeDto): void {
    let command: SaveRecipeCommand = {
      id: dto.id,
      name: dto.name,
      ingredients: dto.ingredients,
      preparation: dto.preparation,
      categories: null
    };

    this.recipeService
      .saveRecipe(command)
      .subscribe(() => this.router.navigateByUrl("/recipes"));
  }

}
