import { CategoryService } from "../shared/category.service";
import { Category } from "../shared/category.model";
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from "@angular/router";
import { switchMap, map, scan } from "rxjs/operators";
import { Observable, fromEvent } from "rxjs";

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  private route: ActivatedRoute;
  private categoryService: CategoryService;
  private categories: Observable<Category[]>;

  constructor(route: ActivatedRoute) {
    this.route = route;
  }

  ngOnInit() {
  }

}
