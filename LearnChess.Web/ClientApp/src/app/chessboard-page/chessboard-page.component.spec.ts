import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChessboardPageComponent } from './chessboard-page.component';

describe('ChessboardPageComponent', () => {
  let component: ChessboardPageComponent;
  let fixture: ComponentFixture<ChessboardPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChessboardPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChessboardPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
