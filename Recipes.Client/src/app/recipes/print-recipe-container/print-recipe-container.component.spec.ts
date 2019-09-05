import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintRecipeContainerComponent } from './print-recipe-container.component';

describe('PrintRecipeContainerComponent', () => {
  let component: PrintRecipeContainerComponent;
  let fixture: ComponentFixture<PrintRecipeContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrintRecipeContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintRecipeContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
