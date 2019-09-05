import { Component, OnInit, Input } from "@angular/core";
import { RecipeDto } from "../shared/recipe-dto.model";

@Component({
  selector: "app-print-recipe",
  templateUrl: "./print-recipe.component.html",
  styleUrls: ["./print-recipe.component.scss"]
})
export class PrintRecipeComponent implements OnInit {
  @Input() recipe: RecipeDto;

  constructor() {}

  ngOnInit() {}
}
