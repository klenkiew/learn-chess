using LearnChess.Application.Domain;
using MediatR;

namespace LearnChess.Application.Handlers.GetChessPiecePossibleMoves
{
    public class GetChessPiecePossibleMovesRequest : IRequest<GetChessPiecePossibleMovesResponse>
    {
        public ChessboardPositionDto ChessboardPosition { get; }
        public ChessPieceKind ChessPieceKind { get; }

        public GetChessPiecePossibleMovesRequest(
            ChessboardPositionDto chessboardPosition, ChessPieceKind chessPieceKind)
        {
            ChessboardPosition = chessboardPosition;
            ChessPieceKind = chessPieceKind;
        }
    }
}