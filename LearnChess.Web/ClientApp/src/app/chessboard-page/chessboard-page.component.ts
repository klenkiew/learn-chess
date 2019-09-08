import { Component, OnInit } from '@angular/core';
import {ChessPiece} from "./chess-piece.model";
import {FieldPosition} from "./chessboard/chessboard.component";

@Component({
  selector: 'app-chessboard-page',
  templateUrl: './chessboard-page.component.html',
  styleUrls: ['./chessboard-page.component.scss']
})
export class ChessboardPageComponent implements OnInit {

  chessPieces: ChessPiece[] = [
    {
      id: 'Queen',
      label: 'Hetman',
      unicode: '&#x265B;'
    },
    {
      id: 'Rook',
      label: 'Wieża',
      unicode: '&#x265C;'
    },
    {
      id: 'Knight',
      label: 'Skoczek',
      unicode: '&#9822;'
    }
  ];

  selectedChessPiece: ChessPiece | undefined;
  putChessPiece: ChessPiece & FieldPosition | undefined;

  constructor() { }

  ngOnInit() {
  }

  onFieldClick(position: FieldPosition) {
    if (!this.selectedChessPiece)
      return;

    this.putChessPiece = {
      ...this.selectedChessPiece,
      ...position
    };
    this.selectedChessPiece = undefined;
  }
}
