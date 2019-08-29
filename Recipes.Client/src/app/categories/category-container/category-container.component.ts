import { CategoryService } from "../shared/category.service";
import { Category } from "../shared/category.model";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, ParamMap } from "@angular/router";
import { switchMap, map } from "rxjs/operators";
import { Observable } from "rxjs";

@Component({
  selector: 'app-category-container',
  templateUrl: './category-container.component.html',
  styleUrls: ['./category-container.component.scss']
})
export class CategoryContainerComponent implements OnInit {
  private route: ActivatedRoute;
  private categoryService: CategoryService;
  private category$: Observable<Category>;

  constructor(route: ActivatedRoute, categoryService: CategoryService) {
    this.route = route;
    this.categoryService = categoryService;
  }

  ngOnInit() {
    this.category$ = this.route.paramMap
      .pipe(map((params: ParamMap) => params.get("id")))
      .pipe(
        switchMap((id: string) =>
          id ? this.categoryService.get(id) : this.categoryService.prototype()
        )
      );
  }
}
