export class Chessboard {

  readonly rows: ChessboardRow[];

  constructor() {
    this.rows = [];
    for (let i = 0; i < 8; ++i) {
      const isRowOdd = i%2 !== 0;
      this.rows[i] = new ChessboardRow(isRowOdd);
    }
  }
}

export class ChessboardRow {

  readonly fields: ChessboardField[];

  constructor(isOdd: boolean) {
    this.fields = [];
    for (let i = 0; i < 8; ++i) {
      const fieldType = (i%2) === (<any>isOdd|0) ? 'dark' : 'light';
      this.fields[i] = new ChessboardField(fieldType);
    }
  }
}

export class ChessboardField {

  readonly type: 'dark' | 'light';

  constructor(type: "dark" | "light") {
    this.type = type;
  }
}
