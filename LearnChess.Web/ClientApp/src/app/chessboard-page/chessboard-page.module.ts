import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChessboardPageComponent } from './chessboard-page.component';
import { ChessboardComponent } from './chessboard/chessboard.component';
import { ChessboardFieldComponent } from './chessboard/chessboard-field/chessboard-field.component';
import {ChessPieceListComponent} from "./chess-piece-list/chess-piece-list.component";

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    ChessboardPageComponent
  ],
  declarations: [ChessboardPageComponent, ChessboardComponent, ChessPieceListComponent, ChessboardFieldComponent]
})
export class ChessboardPageModule { }
