import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { RecipeDto } from '../shared/recipe-dto.model';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.scss']
})
export class RecipeComponent implements OnInit {
  private fb: FormBuilder;
  private form: FormGroup;

  @Input()
  set recipe(recipe: RecipeDto) {
    if (!recipe) {
      return;
    }

    this.form = this.fb.group({
      id: [recipe.id],
      name: [recipe.name],
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
    throw new Error("not implemented");
  }

}
