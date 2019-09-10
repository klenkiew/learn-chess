import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ChessPiece} from "./chess-piece.model";
import {Observable} from "rxjs";
import {FieldPosition} from "./chessboard/chessboard.model";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ChessService {

  constructor(private readonly httpClient: HttpClient) { }

  getAvailableChessPieces(): Observable<ChessPiece[]> {
    return this.httpClient.get<ChessPiece[]>('/api/learnChess/availableChessPieces');
  }

  getAvailableMoves(chessPieceId: string, currentPosition: FieldPosition): Observable<FieldPosition[]> {
    return this.httpClient
      .get<any>(`/api/learnChess/availableMoves?currentX=${currentPosition.column}
          &currentY=${currentPosition.row}&chessPieceKind=${chessPieceId}`)
      .pipe(map(response => response.possibleMoves.map(move => new FieldPosition(move.y, move.x))));
  }

  validateMove(chessPieceId: string, currentPosition: FieldPosition, targetPosition: FieldPosition)
      : Observable<'ValidMove' | 'InvalidMove'> {
    return this.httpClient.post<'ValidMove' | 'InvalidMove'>('/api/learnChess/validateMove', {
      chessPieceKind: chessPieceId,
      currentPosition: {
        x: currentPosition.column,
        y: currentPosition.row
      },
      targetPosition: {
        x: targetPosition.column,
        y: targetPosition.row
      },
    });
  }
}
