import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Chessboard} from "./chessboard.model";
import {ChessPiece} from "../chess-piece.model";

@Component({
  selector: 'app-chessboard',
  templateUrl: './chessboard.component.html',
  styleUrls: ['./chessboard.component.scss']
})
export class ChessboardComponent implements OnInit {

  @Input()
  selectedPiece: ChessPiece;

  @Input()
  putChessPiece: ChessPiece & FieldPosition;

  @Output()
  fieldClick = new EventEmitter<FieldPosition>();

  chessboard: Chessboard = new Chessboard();

  constructor() { }

  ngOnInit() {
  }

  onChessboardFieldClick(row: number, column: number) {
    this.fieldClick.emit({ row, column });
  }
}

export interface FieldPosition {
  row: number;
  column: number;
}
