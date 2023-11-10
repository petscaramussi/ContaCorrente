import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewLancComponent } from './new-lanc.component';

describe('NewLancComponent', () => {
  let component: NewLancComponent;
  let fixture: ComponentFixture<NewLancComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewLancComponent]
    });
    fixture = TestBed.createComponent(NewLancComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
