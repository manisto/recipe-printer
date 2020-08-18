import { CategoryDto } from "../shared/category-dto.model";
import { Component, OnInit, Input, ChangeDetectionStrategy, Output, EventEmitter } from "@angular/core";
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: "app-category",
  templateUrl: "./category.component.html",
  styleUrls: ["./category.component.scss"]
})
export class CategoryComponent implements OnInit {
  private fb: FormBuilder;
  public form: FormGroup;

  @Input()
  set category(category: CategoryDto) {
    if (!category) {
      return;
    }

    this.form = this.fb.group({
      id: [category.id],
      name: [category.name]
    });
  }

  @Output() canceled = new EventEmitter<void>();
  @Output() saved = new EventEmitter<CategoryDto>();

  constructor(fb: FormBuilder) {
    this.fb = fb;
  }

  ngOnInit() { }

  cancel(): void {
    this.canceled.emit();
  }

  save() {
    let returnValue: CategoryDto = Object.assign({}, this.form.value);
    this.saved.emit(returnValue);
  }
}
