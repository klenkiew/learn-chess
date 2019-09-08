import {Component, Input, OnInit} from '@angular/core';
import {ChessboardField} from "../chessboard.model";

@Component({
  selector: 'app-chessboard-field',
  templateUrl: './chessboard-field.component.html',
  styleUrls: ['./chessboard-field.component.scss']
})
export class ChessboardFieldComponent implements OnInit {

  @Input()
  field: ChessboardField;

  @Input()
  hoverContent: string | undefined;

  @Input()
  content: string | undefined;

  constructor() { }

  ngOnInit() {
  }

}
