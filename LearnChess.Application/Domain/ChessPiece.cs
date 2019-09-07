using System.Collections.Generic;
using System.Linq;

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
        
        public bool IsMoveAllowed(ChessboardPosition currentPosition, ChessboardPosition targetPosition)
        {
            return GetPossibleMoves(currentPosition).Any(move => move.To.Equals(targetPosition));
        }
    }
}