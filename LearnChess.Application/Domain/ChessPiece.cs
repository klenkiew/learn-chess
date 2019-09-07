using System.Collections.Generic;

namespace LearnChess.Application.Domain
{
    internal class ChessPiece
    {
        private readonly IChessMoveTypeSpecification pieceAllowedMoves;

        public ChessPiece(IChessMoveTypeSpecification pieceAllowedMoves)
        {
            this.pieceAllowedMoves = pieceAllowedMoves;
        }

        public IEnumerable<ChessMove> GetPossibleMoves(ChessboardPosition currentPosition)
        {
            return pieceAllowedMoves.GetPossibleMoves(currentPosition);
        }
    }
}