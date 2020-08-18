import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { RecipeDto } from '../shared/recipe-dto.model';
import { CategoryDto } from 'src/app/categories/shared/category-dto.model';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.scss']
})
export class RecipeComponent implements OnInit {
  private fb: FormBuilder;
  public form: FormGroup;

  @Input() categories: CategoryDto[];

  @Input()
  set recipe(recipe: RecipeDto) {
    if (!recipe) {
      return;
    }

    this.form = this.fb.group({
      id: [recipe.id],
      name: [recipe.name],
      categories: [[...recipe.categories]],
      ingredients: [recipe.ingredients],
      preparation: [recipe.preparation]
    });
  }

  @Output() canceled = new EventEmitter<void>();
  @Output() saved = new EventEmitter<RecipeDto>();

  constructor(fb: FormBuilder) {
    this.fb = fb;
  }

  ngOnInit() {
  }

  cancel(): void {
    this.canceled.emit();
  }

  save(): void {
    let returnValue: RecipeDto = Object.assign({}, this.form.value);
    this.saved.emit(returnValue);
  }

}
