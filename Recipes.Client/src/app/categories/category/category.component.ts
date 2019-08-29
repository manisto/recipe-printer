import { Category } from "../shared/category.model";
import { Component, OnInit, Input, ChangeDetectionStrategy } from "@angular/core";
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: "app-category",
  templateUrl: "./category.component.html",
  styleUrls: ["./category.component.scss"]
})
export class CategoryComponent implements OnInit {
  private fb: FormBuilder;
  private form: FormGroup;

  @Input() set category(category: Category) {
    if (!category) {
      return;
    }

    this.form = this.fb.group({
      id: [category.id],
      name: [category.name]
    });
  }

  constructor(fb: FormBuilder) {
    this.fb = fb;
  }

  ngOnInit() { }

  save() {
    console.log(this.form.value);
  }
}
