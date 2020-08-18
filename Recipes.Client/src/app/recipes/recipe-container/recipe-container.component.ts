import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { RecipeService } from '../shared/recipe.service';
import { Observable } from 'rxjs';
import { RecipeDto } from '../shared/recipe-dto.model';
import { switchMap, map } from 'rxjs/operators';
import { SaveRecipeCommand } from '../shared/save-recipe-command.model';
import { CategoryService } from 'src/app/categories/shared/category.service';
import { CategoryDto } from 'src/app/categories/shared/category-dto.model';

@Component({
  selector: 'app-recipe-container',
  templateUrl: './recipe-container.component.html',
  styleUrls: ['./recipe-container.component.scss']
})
export class RecipeContainerComponent implements OnInit {
  private route: ActivatedRoute;
  private recipeService: RecipeService;
  private categoryService: CategoryService;
  private router: Router;
  public recipe$: Observable<RecipeDto>;
  public categories$: Observable<CategoryDto[]>;

  constructor(
    route: ActivatedRoute,
    recipeService: RecipeService,
    router: Router,
    categoryService: CategoryService
  ) {
    this.route = route;
    this.recipeService = recipeService;
    this.router = router;
    this.categoryService = categoryService;
  }

  ngOnInit() {
    this.recipe$ = this.route.paramMap
      .pipe(map((params: ParamMap) => params.get("recipeId")))
      .pipe(
        switchMap((recipeId: string) =>
          recipeId ? this.recipeService.get(recipeId) : this.recipeService.prototype()
        )
      );
    
    this.categories$ = this.categoryService.listCategories();
  }

  public backToList(): void {
    this.router.navigateByUrl("/recipes");
  }

  public save(dto: RecipeDto): void {
    let command: SaveRecipeCommand = {
      id: dto.id,
      name: dto.name,
      categories: dto.categories.map(c => c.id),
      ingredients: dto.ingredients,
      preparation: dto.preparation
    };

    this.recipeService
      .saveRecipe(command)
      .subscribe(() => this.router.navigateByUrl("/recipes"));
  }

}
