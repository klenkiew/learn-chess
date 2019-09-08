import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChessPieceListComponent } from './chess-piece-list.component';

describe('FigureListComponent', () => {
  let component: ChessPieceListComponent;
  let fixture: ComponentFixture<ChessPieceListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChessPieceListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChessPieceListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
