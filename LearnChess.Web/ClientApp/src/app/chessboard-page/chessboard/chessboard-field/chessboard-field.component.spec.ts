import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChessboardFieldComponent } from './chessboard-field.component';

describe('ChessboardFieldComponent', () => {
  let component: ChessboardFieldComponent;
  let fixture: ComponentFixture<ChessboardFieldComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChessboardFieldComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChessboardFieldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
