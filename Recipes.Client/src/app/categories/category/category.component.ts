import { CategoryService } from "../shared/category.service";
import { Category } from "../shared/category.model";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, ParamMap } from "@angular/router";
import { switchMap, map } from "rxjs/operators";
import { Observable } from "rxjs";
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: "app-category",
  templateUrl: "./category.component.html",
  styleUrls: ["./category.component.scss"]
})
export class CategoryComponent implements OnInit {
  private form: FormGroup;
  private route: ActivatedRoute;
  private fb: FormBuilder;
  private categoryService: CategoryService;
  private category$: Observable<Category>;

  constructor(route: ActivatedRoute, categoryService: CategoryService, fb: FormBuilder) {
    this.route = route;
    this.categoryService = categoryService;
    this.fb = fb;
  }

  ngOnInit() {
    this.category$ = this.route.paramMap
      .pipe(map((params: ParamMap) => params.get("id")))
      .pipe(
        switchMap((id: string) =>
          id ? this.categoryService.get(id) : this.categoryService.prototype()
        )
      );

    this.category$.subscribe(category => {
      this.form = this.fb.group({
        id: [category.id],
        name: [category.name]
      })
    });
  }

  save() {
    console.log(this.form.value);
  }
}
