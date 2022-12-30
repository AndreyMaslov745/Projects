import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArrayBenchmarkComponent } from './array-benchmark.component';

describe('ArrayBenchmarkComponent', () => {
  let component: ArrayBenchmarkComponent;
  let fixture: ComponentFixture<ArrayBenchmarkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArrayBenchmarkComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArrayBenchmarkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
