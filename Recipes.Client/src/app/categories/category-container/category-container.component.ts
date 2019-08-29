import { CategoryService } from "../shared/category.service";
import { CategoryDto } from "../shared/category-dto.model";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, ParamMap, Router } from "@angular/router";
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
  private router: Router;
  private category$: Observable<CategoryDto>;

  constructor(route: ActivatedRoute, categoryService: CategoryService, router: Router) {
    this.route = route;
    this.categoryService = categoryService;
    this.router = router;
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

  private backToList(): void {
    this.router.navigateByUrl("/categories");
  }
}
