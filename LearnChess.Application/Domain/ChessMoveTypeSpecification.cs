using System.Collections.Generic;

namespace LearnChess.Application.Domain
{
    internal interface IChessMoveTypeSpecification
    {
        IEnumerable<ChessMove> GetPossibleMoves(ChessboardPosition currentPosition);
    }
}