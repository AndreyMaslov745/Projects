import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MethodDescriptionComponent } from './method-description.component';

describe('MethodDescriptionComponent', () => {
  let component: MethodDescriptionComponent;
  let fixture: ComponentFixture<MethodDescriptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MethodDescriptionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MethodDescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
