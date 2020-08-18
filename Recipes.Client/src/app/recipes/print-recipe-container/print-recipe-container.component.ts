import { Component, OnInit } from "@angular/core";
import { RecipeService } from "../shared/recipe.service";
import { Observable } from "rxjs";
import { RecipeDto } from "../shared/recipe-dto.model";
import { ActivatedRoute, ParamMap } from "@angular/router";
import { map, switchMap } from "rxjs/operators";

@Component({
  selector: "app-print-recipe-container",
  templateUrl: "./print-recipe-container.component.html",
  styleUrls: ["./print-recipe-container.component.scss"]
})
export class PrintRecipeContainerComponent implements OnInit {
  private recipeService: RecipeService;
  public recipe$: Observable<RecipeDto>;
  private route: ActivatedRoute;

  constructor(recipeService: RecipeService, route: ActivatedRoute) {
    this.recipeService = recipeService;
    this.route = route;
  }

  ngOnInit() {
    this.recipe$ = this.route.paramMap
      .pipe(map((paramMap: ParamMap) => paramMap.get("recipeId")))
      .pipe(switchMap((recipeId: string) => this.recipeService.get(recipeId)));
  }
}
