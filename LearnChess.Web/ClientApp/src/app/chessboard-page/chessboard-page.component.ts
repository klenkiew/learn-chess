import {Component, OnInit} from '@angular/core';
import {ChessPiece} from "./chess-piece.model";
import {Chessboard, FieldPosition, PlacedChessPiece} from "./chessboard/chessboard.model";
import {ChessService} from "./chess.service";
import {Observable} from "rxjs";
import {tap} from "rxjs/operators";

@Component({
  selector: 'app-chessboard-page',
  templateUrl: './chessboard-page.component.html',
  styleUrls: ['./chessboard-page.component.scss']
})
export class ChessboardPageComponent implements OnInit {

  chessPieces: ChessPiece[] = [];
  chessboard: Chessboard = new Chessboard();

  loading: boolean = false;
  displayError: boolean = false;

  constructor(private readonly chessService: ChessService) { }

  ngOnInit() {
    this.loading = true;
    this.chessService.getAvailableChessPieces().subscribe(chessPieces => {
      this.chessPieces = chessPieces;
      this.loading = false;
    });
  }

  onFieldClick(position: FieldPosition) {
    this.displayError = false;
    if (!this.chessboard.selectedChessPiece && !this.chessboard.placedChessPiece)
      return;

    if (this.chessboard.selectedChessPiece) {
      this.placeChessPieceOnChessboard(this.chessboard.selectedChessPiece, position);
      return;
    }

    if (!this.chessboard.placedChessPiece)
      return;

    if (this.chessboard.placedChessPiece.canMove) {

      const placedChessPiece = this.chessboard.placedChessPiece;
      this.tryMoveCheckPiece(placedChessPiece, position);
      return;
    }


    if (this.chessboard.placedChessPiece.position.sameAs(position)) {
      const chessPiece = this.chessboard.placedChessPiece;
      this.highlightPossiblePieceMoves(chessPiece);
    }
  }

  private placeChessPieceOnChessboard(chessPiece: ChessPiece, position: FieldPosition) {
    this.chessboard.placedChessPiece = {
      chessPiece: chessPiece,
      position: position
    };
    this.chessboard.selectedChessPiece = undefined;
  }

  private tryMoveCheckPiece(placedChessPiece, position: FieldPosition) {
    this
      .withLoader(this.chessService.validateMove(
        placedChessPiece.chessPiece.id,
        placedChessPiece.position,
        position))
      .subscribe(result => {
        if (placedChessPiece == undefined)
          return;

        if (result === "ValidMove")
          this.movePiece(placedChessPiece, position);
        else if (result === "InvalidMove") {
          placedChessPiece.canMove = false;
          placedChessPiece.possibleMoves = undefined;
          this.displayError = true;
        }
      });
  }

  private movePiece(chessPiece: PlacedChessPiece, position: FieldPosition) {
    chessPiece.position = position;
    chessPiece.canMove = false;
    chessPiece.possibleMoves = undefined;
  }

  private highlightPossiblePieceMoves(placedChessPiece: PlacedChessPiece) {
    placedChessPiece.canMove = true;
    this.withLoader(
      this.chessService
        .getAvailableMoves(placedChessPiece.chessPiece.id, placedChessPiece.position)
    )
      .subscribe(moves => {
        placedChessPiece.possibleMoves = moves;
      });
  }

  private withLoader<T>(observable: Observable<T>): Observable<T> {
    this.loading = true;
    return observable.pipe(tap(() => this.loading = false));
  }
}
