import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Chessboard, FieldPosition} from "./chessboard.model";

@Component({
  selector: 'app-chessboard',
  templateUrl: './chessboard.component.html',
  styleUrls: ['./chessboard.component.scss']
})
export class ChessboardComponent implements OnInit {

  @Input()
  chessboard: Chessboard = new Chessboard();

  @Output()
  fieldClick = new EventEmitter<FieldPosition>();


  constructor() { }

  ngOnInit() {
  }

  onChessboardFieldClick(row: number, column: number) {
    this.fieldClick.emit(new FieldPosition(row, column));
  }

  isFieldActive(row: number, column: number): boolean | undefined{
    const placedChessPiece = this.chessboard.placedChessPiece;
    return placedChessPiece != undefined && placedChessPiece.canMove && placedChessPiece.possibleMoves != undefined
      && placedChessPiece.possibleMoves.filter(m => m.row === row && m.column === column).length > 0;
  }
}
