import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ChessPiece} from "../chess-piece.model";

@Component({
  selector: 'app-chess-piece-list',
  templateUrl: './chess-piece-list.component.html',
  styleUrls: ['./chess-piece-list.component.scss']
})
export class ChessPieceListComponent implements OnInit {

  @Input()
  chessPieces: ChessPiece[];

  @Output()
  selectedChessPieceChange = new EventEmitter<ChessPiece>();

  @Input()
  selectedChessPiece: ChessPiece | undefined;

  constructor() { }

  ngOnInit() {
  }

  onChessPieceClick(chessPiece: ChessPiece) {
    if (this.selectedChessPiece !== chessPiece)
      this.selectedChessPiece = chessPiece;
    else
      this.selectedChessPiece = undefined;

    this.selectedChessPieceChange.emit(this.selectedChessPiece);
  }
}
