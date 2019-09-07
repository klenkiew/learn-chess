using System.Collections.Generic;

namespace LearnChess.Application.Handlers.GetChessPiecePossibleMoves
{
    public class GetChessPiecePossibleMovesResponse
    {
        public ChessboardPositionDto CurrentPosition { get; }
        public IEnumerable<ChessboardPositionDto> PossibleMoves { get; }

        public GetChessPiecePossibleMovesResponse(
            ChessboardPositionDto currentPosition, IEnumerable<ChessboardPositionDto> possibleMoves)
        {
            CurrentPosition = currentPosition;
            PossibleMoves = possibleMoves;
        }
    }
}