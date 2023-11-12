import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditLancComponent } from './edit-lanc.component';

describe('EditLancComponent', () => {
  let component: EditLancComponent;
  let fixture: ComponentFixture<EditLancComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditLancComponent]
    });
    fixture = TestBed.createComponent(EditLancComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
